using Akka.Actor;
using MovieStreaming.Common.Messages;
using System;
using System.Collections.Generic;

namespace MovieStreaming.Common.Actors
{
    public sealed class UserCoordinatorActor : ReceiveActor
    {
        private readonly Dictionary<int, IActorRef> _users;

        public UserCoordinatorActor()
        {
            _users = new Dictionary<int, IActorRef>();

            Receive<PlayMovieMessage>(message =>
            {
                CreateChildUserIfNotExists(message.UserId);

                IActorRef childActorRef = _users[message.UserId];
                childActorRef.Tell(message);
            });

            Receive<StopMovieMessage>(message =>
            {
                CreateChildUserIfNotExists(message.UserId);

                IActorRef childActorRef = _users[message.UserId];
                childActorRef.Tell(message);
            });
        }

        protected override void PreStart()
        {
            ColorConsole.WriteLineCyan("UserCoordinatorActor PreStart");
        }

        protected override void PostStop()
        {
            ColorConsole.WriteLineCyan("UserCoordinatorActor PostStop");
        }

        protected override void PreRestart(Exception reason, object message)
        {
            ColorConsole.WriteLineCyan("UserCoordinatorActor PreRestart because: " + reason);
        }

        protected override void PostRestart(Exception reason)
        {
            ColorConsole.WriteLineCyan("UserCoordinatorActor PostRestart because: " + reason);

            base.PostRestart(reason);
        }

        private void CreateChildUserIfNotExists(int userId)
        {
            if(!_users.ContainsKey(userId))
            {
                IActorRef newChildActorRef = Context.ActorOf(Props.Create(() => new UserActor(userId)), "User" + userId);

                _users.Add(userId, newChildActorRef);
                ColorConsole.WriteLineCyan("UserCoordinatorActor created new child UserActor for {0} (Total Users: {1})", userId, _users.Count);
            }
        }
    }
}
