using IssueTracker.Functional.Interface.Buses;
using IssueTracker.Functional.Interface.Commands;
using IssueTracker.Functional.Interface.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Functional.Buses
{
    public class InMemoryMessageBus : ICommandSender, IEventPublisher
    {
        private readonly Dictionary<Type, List<Action<Message>>> _routes = new Dictionary<Type, List<Action<Message>>>();

        public void RegisterHandler<T>(Action<T> pHandler)
            where T : Message
        {
            List<Action<Message>> lHandlers;

            if (!_routes.TryGetValue(typeof(T), out lHandlers))
            {
                lHandlers = new List<Action<Message>>();
                _routes.Add(typeof(T), lHandlers);
            }

            lHandlers.Add(m => pHandler(m as T));
        }

        public void Send<T>(T pCommand)
            where T : Command
        {
            List<Action<Message>> lHandlers;

            if (!_routes.TryGetValue(typeof(T), out lHandlers))
                throw new InvalidOperationException("no handler registered!");

            if (lHandlers.Count != 1)
                throw new InvalidOperationException("cannot send to more than one handler");

            lHandlers[0](pCommand);
        }

        public void Publish<T>(T pEvent)
            where T : Event
        {
            List<Action<Message>> lHanders;

            if (!_routes.TryGetValue(pEvent.GetType(), out lHanders))
                return;

            lHanders.All(e =>
            {
                e(pEvent);
                return true;
            });
        }
    }
}
