using IssueTracker.Functional.Interface.Commands;
using IssueTracker.Functional.Interface.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Functional.Interface.Buses
{
    public interface ICommandSender
    {
        void Send<T>(T command) where T : Command;
    }

    public interface IEventPublisher
    {
        void Publish<T>(T @event) where T : Event;
    }
}
