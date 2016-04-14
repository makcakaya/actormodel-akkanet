using Akka.Actor;
using MovieStreaming.Common.Exceptions;
using System;

namespace MovieStreaming.Common.Actors
{
    public sealed class PlaybackStatisticsActor : ReceiveActor
    {
        public PlaybackStatisticsActor()
        {
            Context.ActorOf(Props.Create<MoviePlayCounterActor>(), "MoviePlayCounter");
        }

        protected override SupervisorStrategy SupervisorStrategy()
        {
            return new OneForOneStrategy(exception =>
            {
                if (exception is SimulatedCorruptStateException)
                {
                    return Directive.Restart;
                }

                if (exception is SimulatedTerribleMovieException)
                {
                    return Directive.Resume;
                }

                return Directive.Restart;
            });
        }

        protected override void PreStart()
        {
            ColorConsole.WriteLineWhite("PlaybackStatisticsActor PreStart");
        }

        protected override void PostStop()
        {
            ColorConsole.WriteLineWhite("PlaybackStatisticsActor PostStop");
        }

        protected override void PreRestart(Exception reason, object message)
        {
            ColorConsole.WriteLineWhite("PlaybackStatisticsActor PreRestart because: " + reason);
        }

        protected override void PostRestart(Exception reason)
        {
            ColorConsole.WriteLineWhite("PlaybackStatisticsActor PostRestart because: " + reason);

            base.PostRestart(reason);
        }
    }
}
