using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IssueTracker.Functional.Buses;
using IssueTracker.Functional.Interface.Commands;
using System.Collections.Generic;

namespace IssueTracker.Functional.Tests.Buses
{
    [TestClass]
    public class CommandBusTests
    {
        class CreateCommand : Command
        {
            public Guid Id { get; private set; }

            public CreateCommand(Guid pId)
            {
                Id = pId;
            }
        }

        class CreateCommandHandlers
        {
            public List<Guid> HandledIds { get; set; }

            public CreateCommandHandlers()
            {
                HandledIds = new List<Guid>();
            }

            public void Handle(CreateCommand pCommand)
            {
                HandledIds.Add(pCommand.Id);
            }
        }

        [TestMethod]
        public void TestMethod1()
        {
            var bus = new InMemoryMessageBus();
            var lHandler = new CreateCommandHandlers();
            CreateCommand lCommand = new CreateCommand(Guid.NewGuid());

            bus.RegisterHandler<CreateCommand>(lHandler.Handle);
            bus.Send(lCommand);

            Assert.IsTrue(lHandler.HandledIds.Contains(lCommand.Id));
        }
    }
}
