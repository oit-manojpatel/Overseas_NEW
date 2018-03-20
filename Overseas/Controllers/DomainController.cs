using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Overseas.Manager.DB;

namespace Overseas.Controllers
{
    [Authorize]
    public class DomainController : Controller
    {
        // GET: Domain
        private readonly dbOITReporting db = new dbOITReporting();
        public ActionResult Index()
        {
            var v = db.domainMasters.ToList();
            return View(v);
        }

        public ActionResult adddomain()
        {
            return PartialView("Partial/_adddomain");
        }
        [HttpPost]
        public ActionResult domainadd(domainMaster dm)
        {
            if (ModelState.IsValid)
            {
                if (dm.domainId == 0)
                {
                    db.domainMasters.Add(dm);
                }
                else if (dm.domainId != 0)
                {
                    db.Entry(dm).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    return HttpNotFound();
                }
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.status = "Invalid Request";
                return PartialView("Partial/_adddomain", dm);
            }
        }
        public ActionResult Editdomain(int id)
        {
            var v = db.domainMasters.FirstOrDefault(s => s.domainId == id);
            return PartialView("Partial/_adddomain", v);
        }
        //public ActionResult update(domainMaster dm)
        //{
        //    var v = db.domainMasters.FirstOrDefault(s => s.domainId == dm.domainId);
        //    if (v != null)
        //    {
        //        v.domainName = dm.domainName;
        //        db.SaveChanges();
        //    }
        //    return RedirectToAction("Index");
        //}

        public ActionResult Delete(int Id)
        {
            var v = db.domainMasters.FirstOrDefault(s => s.domainId == Id);
            db.domainMasters.Remove(v);
            db.SaveChanges();
            return Json("ok");
        }
    }
}