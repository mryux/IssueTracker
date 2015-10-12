using IssueTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IssueTracker.Views
{
    public class IssueController : Controller
    {
        private static readonly List<IssueModel> Issues = new List<IssueModel>();

        public IssueController()
        {
        }

        // GET: Issue
        public ActionResult Index()
        {
            return View( Issues );
        }

        public ActionResult Add()
        {
            return View(new IssueModel());
        }

        [HttpPost]
        public ActionResult Add(IssueModel pIssue)
        {
            Issues.Add(pIssue);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(IssueModel pIssue)
        {
            return View(pIssue);
        }

        [HttpPost]
        public ActionResult SaveIssue(IssueModel pIssue)
        {
            return RedirectToAction("Index");
        }
    }
}