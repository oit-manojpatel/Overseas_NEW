using Overseas.Manager.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity.Validation;

namespace Overseas.Controllers
{
    [Authorize]
    public class UserManagerController : BaseController
    {
        // GET: UserManager
        private readonly dbOITReporting db;

        public UserManagerController()
        {
            db = new dbOITReporting();
        }

        public ActionResult Index()
        {
            var rolelist = db.RoleMasters.ToList();
            ViewBag.rolelist = new SelectList(rolelist, "Id", "Name");
            ViewBag.countryId = new SelectList(db.tblCountries, "countryId", "countryName");
            var user = db.userMasters.ToList();
            return View(user);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var rolelist = db.RoleMasters.ToList();
            ViewBag.rolelist = new SelectList(rolelist, "Id", "Name");
            ViewBag.countryId = new SelectList(db.tblCountries, "countryId", "countryName");
            return PartialView("Partial/_Adduser");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult addUser(userMaster um)
        {
            if (ModelState.IsValid)
            {
                if (um.userId == 0)
                {
                    db.userMasters.Add(um);
                }
                else
                {
                    db.Entry(um).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return PartialView("Partial/_Adduser", um);
        }


        public ActionResult Edit(int userId)
        {
            var rolelist = db.RoleMasters.ToList();
            ViewBag.rolelist = new SelectList(rolelist, "Id", "Name");
            var countryList = db.tblCountries.ToList();
            ViewBag.countryId = new SelectList(countryList, "countryId", "countryName");
            var user = db.userMasters.FirstOrDefault(s => s.userId == userId);
            return PartialView("Partial/_Adduser", user);
        }


        public ActionResult Delete(int id)
        {

            var v = db.userMasters.FirstOrDefault(s => s.userId == id);
            db.userMasters.Remove(v);
            db.SaveChanges();
            return Json("ok", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(int Id)
        {
            var v = db.userMasters.FirstOrDefault(s => s.userId == Id);
            return PartialView("Partial/_DetailsUser", v);
        }

        public JsonResult StateList(int Id)
        {
            var state = from s in db.tblStates
                        where s.countryId == Id
                        select s;
            return Json(new SelectList(state.ToArray(), "stateId", "stateName"), JsonRequestBehavior.AllowGet);
        }

        public IList<tblState> Getstate(int countryId)
        {
            return db.tblStates.Where(m => m.countryId == countryId).ToList();
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult LoadClassesByCountryId(string CountryName)
        {
            var stateList = this.Getstate(Convert.ToInt32(CountryName));
            var stateData = stateList.Select(m => new SelectListItem()
            {
                Text = m.stateName,
                Value = m.countryId.ToString(),
            });
            return Json(stateData, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}