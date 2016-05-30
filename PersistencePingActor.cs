using System.Collections.Generic;
using Akka.Actor;
using Akka.Persistence;

namespace AkkaSqlPersistenceIssue
{
    class PersistencePingActor : PersistentActor
    {
        List<string> _events = new List<string>();
        private readonly IActorRef _notifyActor;
        
        public PersistencePingActor(IActorRef notifyActor)
        {
            _notifyActor = notifyActor;
        }

        protected override bool ReceiveRecover(object message)
        {
            if (message is SnapshotOffer)
            {
                _events = (List<string>)((SnapshotOffer)message).Snapshot;
            }
            return true;
        }

        protected override bool ReceiveCommand(object message)
        {
            if (message is SqlJournalPing)
            {
                var m = message as SqlJournalPing;
                _events.Add(m.Payload);
                Persist(m.Payload, e => _notifyActor.Tell(new Persisted() { Payload = m.Payload}));
            }
            return true;
        }

        public override string PersistenceId => "test";
    }
}