using Akka.Actor;
using MovieStreaming.Actors;
using MovieStreaming.Messages;
using System;

namespace MovieStreaming
{
    class Program
    {
        private static ActorSystem MovieStreamingActorSystem;

        static void Main(string[] args)
        {
            MovieStreamingActorSystem = ActorSystem.Create("MovieStreamingActorSystem");
            Console.WriteLine("Actor system created.");

            Props playbackActorProps = Props.Create<PlaybackActor>();
            IActorRef playbackActorRef = MovieStreamingActorSystem.ActorOf(playbackActorProps, "PlaybackActor");

            playbackActorRef.Tell(new PlayMovieMessage("Akka.NET: The Movie", 42));
            playbackActorRef.Tell(new PlayMovieMessage("Partial Recall", 99));
            playbackActorRef.Tell(new PlayMovieMessage("Boolean Lies", 77));
            playbackActorRef.Tell(new PlayMovieMessage("Codenan the Destroyer", 1));

            playbackActorRef.Tell(PoisonPill.Instance);

            Console.ReadKey();

            // Tell actory system (ann all child actors) to terminate
            MovieStreamingActorSystem.Terminate();
            // Wait for actor system to finish termination
            MovieStreamingActorSystem.AwaitTermination();
            Console.WriteLine("Actor system terminated.");
        }
    }
}
