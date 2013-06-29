using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NerdDinner.Models;

namespace NerdDinner.Controllers
{
    public class IntraAgentController : Controller
    {
        private NerdDinnerContext db = new NerdDinnerContext();

        private IntraAgent IntraAgent
        {
            get
            {
                var intraAgent = db.IntraAgents.FirstOrDefault(agent => agent.UserName == User.Identity.Name);
                return intraAgent;
            }
        }


        //
        // GET: /IntraAgent/

        public ActionResult Index()
        {
            return View(IntraAgent);
        }

        //
        // GET: /IntraAgent/Create
        [Authorize]
        public ActionResult Edit()
        {
            if (IntraAgent == null)
            {
                db.IntraAgents.Add(new IntraAgent() {UserName = User.Identity.Name});
                db.SaveChanges();
            }
            return View(IntraAgent);
        }



        //
        // POST: /IntraAgent/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IntraAgent intraagent)
        {
            if (ModelState.IsValid)
            {
                var agent = IntraAgent; //from db
                agent.IntraUserName = intraagent.IntraUserName;
                agent.IntraPassword = intraagent.IntraPassword;
                agent.AgentRunning = true;
 
                db.SaveChanges();
                
                return RedirectToAction("Index");
            }

            return View(intraagent);
        }



        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Stop()
        {
            IntraAgent.AgentRunning = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Start()
        {
            if (IntraAgent == null)
            {
                return RedirectToAction("Index");
            }

            IntraAgent.AgentRunning = true;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}