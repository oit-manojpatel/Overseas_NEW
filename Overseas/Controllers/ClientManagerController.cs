using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using Overseas.Manager.DB;
using System.Data.Entity.Validation;
using System.Web;

namespace Overseas.Controllers
{
    [Authorize]
    public class ClientManagerController : Controller
    {
        private readonly dbOITReporting db = new dbOITReporting();
        public ActionResult Index()
        {


            ViewBag.countryId = new SelectList(db.tblCountries, "countryId", "countryName");
            var domainList = db.domainMasters.ToList();
            ViewBag.domainList = new SelectList(domainList, "domainId", "domainName");
            var userList = db.userMasters.ToList();
            ViewBag.UserList = new SelectList(userList, "userId", "firstName");
            return View(db.clientMasters.ToList());
        }
        [HttpGet]
        public ActionResult Add()
        {
            var allcontractData = db.tblCountries.ToList();
            ViewBag.user = new SelectList(allcontractData, "ContractId", "ContractName");
            return PartialView($"Partial/__Addclient");
        }
        [HttpPost]
        public ActionResult AddClient(clientMaster client)
        {
            if (!ModelState.IsValid) return PartialView("Partial/_AddClient", client);
            if (client.clientId == 0)
            {
                db.clientMasters.Add(client);
            }
            else if (client.clientId != 0)
            {
                db.Entry(client).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                return HttpNotFound();
            }
            db.SaveChanges();

            ViewBag.status = "User is Added";
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.countryId = new SelectList(db.tblCountries, "countryId", "countryName");
            var domainList = db.domainMasters.ToList();
            ViewBag.domainList = new SelectList(domainList, "domainId", "domainName");
            var userList = db.userMasters.ToList();
            ViewBag.UserList = new SelectList(userList, "userId", "firstName");
            var v = db.clientMasters.FirstOrDefault(s => s.clientId == id);
            return PartialView("Partial/_AddClient", v);
        }
        //[HttpPost]
        //public ActionResult Update(clientMaster cm)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(cm).State = System.Data.Entity.EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return PartialView("Partial/_Editclient", cm);
        //}


        public ActionResult Delete(int id)
        {
            var clientDelete = db.clientMasters.FirstOrDefault(a => a.clientId == id);
            db.clientMasters.Remove(clientDelete);
            db.SaveChanges();
            return Json("ok", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Details(int Id)
        {
            var v = db.clientMasters.FirstOrDefault(s => s.clientId == Id);
            var query = (from n in db.tblCountries
                         join m in db.clientMasters on n.countryId equals m.countryId
                         select new
                         {
                             m.countryId,
                             n.countryName
                         });
            ViewBag.q = query;
            return PartialView("Partial/_DetailsClient", v);
        }

        public JsonResult StateList(int country)
        {
            List<tblState> listState = db.tblStates.Where(x => x.countryId == country).ToList();
            return Json(new SelectList(listState, "stateId", "stateName"), JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        public ActionResult ImportClient(HttpPostedFileBase excelfile)
        {
            if (excelfile != null)
            {
                var filename = excelfile.FileName;
                var path = Server.MapPath("~/ExcelFiles/");

                if (filename.EndsWith(".xls") || filename.EndsWith(".xlsx"))
                {
                    ViewBag.error = "Record Added Success";
                    return View("Index", db.clientMasters.ToList());
                }
                else
                {
                    ViewBag.error = "Please select only excel file";
                    return View("Index", db.clientMasters.ToList());
                }
            }
            else
            {
                ViewBag.error = "Please select file...";
                return View("Index", db.clientMasters.ToList());
            }
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