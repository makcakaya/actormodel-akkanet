using Akka.Actor;
using MovieStreaming.Messages;
using System;

namespace MovieStreaming.Actors
{
    public sealed class PlaybackActor : UntypedActor
    {
        public PlaybackActor()
        {
            Console.WriteLine("Creating a PlaybackActor");
        }

        protected override void OnReceive(object message)
        {
            if (message is PlayMovieMessage)
            {
                var m = message as PlayMovieMessage;
                Console.WriteLine("Received movie title " + m.MovieTitle);
                Console.WriteLine("Received user Id " + m.UserId);
            }
            else
            {
                Unhandled(message);
            }
        }
    }
}
