using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IssueTracker.Models
{
    public class IssueModel
    {
        [HiddenInput(DisplayValue = false)]
        public int IssueId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Detail { get; set; }

        public List<string> Attachments { get; set; }

        //[UIHint("EnumList")]
        public IssuePriority Priority { get; set; }
    }

    public enum IssuePriority
    {
        eNone,
        eLow,
        eHigh,
        eCritical
    }

    public enum IssueStateEnum
    {
        eNone,
        eNew,   // to implement
        eImplemented,   // to test
        eClosed,
        eFailed,    // to implement
    }

    public enum IssueActionEnum
    {
        eNone,
        eImplement,
        eTest,
    }

    public class IssueState
    {
        public int IssueStateId { get; set; }
        public int IssueId { get; set; }
        public int AccountId { get; set; }
        public IssueActionEnum Action { get; set; }

        public IssueStateEnum State { get; set; }

        public string Reason { get; set; }
        public string Solution { get; set; }
        public string ChangeSet { get; set; }
    }
}