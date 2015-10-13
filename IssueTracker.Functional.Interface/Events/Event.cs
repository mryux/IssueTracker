using IssueTracker.Functional.Interface.Buses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Functional.Interface.Events
{
    public class Event : Message
    {
        public int Version { get; set; }
    }
}
