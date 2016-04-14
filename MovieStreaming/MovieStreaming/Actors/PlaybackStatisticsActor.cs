using Akka.Actor;
using System;

namespace MovieStreaming.Actors
{
    public sealed class PlaybackStatisticsActor : ReceiveActor
    {
        public PlaybackStatisticsActor()
        {
            Context.ActorOf(Props.Create<MoviePlayCounterActor>(), "MoviePlayCounter");
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
