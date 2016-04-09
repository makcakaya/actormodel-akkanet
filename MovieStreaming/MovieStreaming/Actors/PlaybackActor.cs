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
            throw new NotImplementedException();
        }
    }
}
