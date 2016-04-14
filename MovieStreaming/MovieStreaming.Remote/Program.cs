using Akka.Actor;
using MovieStreaming.Common;

namespace MovieStreaming.Remote
{
    class Program
    {
        private static ActorSystem MovieStreamingActorSystem;

        static void Main(string[] args)
        {
            ColorConsole.WriteLineGray("Creating MovieStreamingActorSystem in remote");

            MovieStreamingActorSystem = ActorSystem.Create("MovieStreamingActorSystem");

            MovieStreamingActorSystem.AwaitTermination();
        }
    }
}
