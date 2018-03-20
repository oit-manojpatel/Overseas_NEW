using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data;
using System.Data.Entity.Validation;
using Overseas.Manager.DB;

namespace Overseas.Controllers
{
    public class EmailController : Controller
    {
        private readonly dbOITReporting db = new dbOITReporting();
        // GET: Email
        public ActionResult Index()
        {
            var clientlist = db.clientMasters.ToList();
            ViewBag.clientList = new SelectList(clientlist, "clientId", "emailId");
            var v = db.emailSendingHistories.ToList();
            return View(v);
        }
        [HttpGet]
        public ActionResult AddEmail()
        {
            return PartialView("Partial/_AddEmail");
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Create(emailSendingHistory em)
        {
            if (ModelState.IsValid)
            {
                if (em.ID <= 0)
                {
                    db.emailSendingHistories.Add(em);
                }
                else
                {
                    db.Entry(em).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return PartialView("Partial/_AddEmail", em);
            }

        }




        public ActionResult Edit(int id)
        {
            var v = db.emailSendingHistories.FirstOrDefault(s => s.ID == id);
            return PartialView("Partial/_AddEmail", v);
        }

        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public ActionResult Update(emailSendingHistory em)
        //{
        //    if (!ModelState.IsValid) return View(em);
        //    db.Entry(em).State = System.Data.Entity.EntityState.Modified;
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}


        public ActionResult Delete(int Id)
        {
            var Emaildelete = db.emailSendingHistories.FirstOrDefault(predicate: a => a.ID == Id) ?? throw new ArgumentNullException("db.emailSendingHistories.FirstOrDefault(predicate: a => a.ID == Id)");
            db.emailSendingHistories.Remove(entity: Emaildelete ?? throw new InvalidOperationException());
            db.SaveChanges();
            return Json("ok");
        }
    }
}