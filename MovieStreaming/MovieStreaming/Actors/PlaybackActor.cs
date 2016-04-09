using Akka.Actor;
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
            if (message is string)
            {
                Console.WriteLine("Received movie title " + message);
            }
            else if (message is int)
            {
                Console.WriteLine("Received User ID " + message);
            }
            else
            {
                Unhandled(message);
            }
        }
    }
}
