using Akka.Actor;
using MovieStreaming.Messages;
using System;

namespace MovieStreaming.Actors
{
    public sealed class PlaybackActor : ReceiveActor
    {
        public PlaybackActor()
        {
            Console.WriteLine("Creating a PlaybackActor");

            // Actor will receive only PlayMovieMessage with UserId of 42.
            Receive<PlayMovieMessage>(message => HandlePlayMovieMessage(message),
                message => message.UserId == 42);
        }

        private void HandlePlayMovieMessage(PlayMovieMessage message)
        {
            Console.WriteLine("Received movie title " + message.MovieTitle);
            Console.WriteLine("Received user Id " + message.UserId);
        }
    }
}