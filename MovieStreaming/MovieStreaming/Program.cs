﻿using Akka.Actor;
using MovieStreaming.Actors;
using System;

namespace MovieStreaming
{
    class Program
    {
        private static ActorSystem MovieStreamingActorSystem;

        static void Main(string[] args)
        {
            MovieStreamingActorSystem = ActorSystem.Create("MovieStreamingActorSystem");
            Console.WriteLine("Actor system created");

            Props playbackActorProps = Props.Create<PlaybackActor>();

            IActorRef playbackActorRef = MovieStreamingActorSystem.ActorOf(playbackActorProps, "PlaybackActor");
            playbackActorRef.Tell("Akka.NET: The Movie");
            playbackActorRef.Tell(42);
            playbackActorRef.Tell('f');

            Console.ReadLine();

            MovieStreamingActorSystem.Terminate();
        }
    }
}
