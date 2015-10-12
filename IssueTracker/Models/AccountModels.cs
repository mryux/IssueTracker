using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IssueTracker.Models
{
    public class AccountModel
    {
        public int AccountId { get; set; }
        public string Name { get; set; }
        public RoleEnum Role { get; set; }
    }

    public enum RoleEnum
    {
        eNone,
        eDevelopper,
        eTester,
        eManager,
    }
}