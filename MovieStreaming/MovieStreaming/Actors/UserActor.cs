using Akka.Actor;
using MovieStreaming.Messages;
using System;

namespace MovieStreaming.Actors
{
    public sealed class UserActor : ReceiveActor
    {
        private string _currentlyWatching;
        private int _userId;

        public UserActor(int userId)
        {
            _userId = userId;
            Stopped();
        }

        private void Playing()
        {
            Receive<PlayMovieMessage>(message => ColorConsole.WriteLineRed("Error: cannot start playing another movie before stopping existing one."));
            Receive<StopMovieMessage>(message => StopPlayingCurrentMovie());

            ColorConsole.WriteLineYellow("UserActor {0} has now become Playing", _userId);
        }

        private void Stopped()
        {
            Receive<PlayMovieMessage>(message => StartPlayingMovie(message.MovieTitle));
            Receive<StopMovieMessage>(message => ColorConsole.WriteLineRed("Error: cannot stop if nothing is playing"));

            ColorConsole.WriteLineYellow("UserActor has now become Stopped", _userId);
        }

        private void StopPlayingCurrentMovie()
        {
            ColorConsole.WriteLineYellow(string.Format("User has stopped watching '{0}'", _currentlyWatching));

            _currentlyWatching = null;

            Become(Stopped);
        }

        private void StartPlayingMovie(string title)
        {
            _currentlyWatching = title;

            ColorConsole.WriteLineYellow(string.Format("User is currently watching '{0}'", _currentlyWatching));

            Become(Playing);
        }

        protected override void PreStart()
        {
            ColorConsole.WriteLineYellow("UserActor {0} PreStart", _userId);
        }

        protected override void PostStop()
        {
            ColorConsole.WriteLineGreen("UserActor PostStop");
        }

        protected override void PreRestart(Exception reason, object message)
        {
            ColorConsole.WriteLineGreen("UserActor PreRestart because: " + reason);

            base.PreRestart(reason, message);
        }

        protected override void PostRestart(Exception reason)
        {
            ColorConsole.WriteLineGreen("UserActor PostRestart because: " + reason);

            base.PostRestart(reason);
        }
    }
}
