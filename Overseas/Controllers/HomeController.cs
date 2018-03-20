using Newtonsoft.Json;
using Overseas.Manager.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OITReporting.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };

        private readonly dbOITReporting db = new dbOITReporting();
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Dashboard()
        {
            try
            {
                ViewBag.countUser = db.userMasters.Count();
                ViewBag.countProject = db.domainMasters.Count();
                ViewBag.countClients = db.clientMasters.Count();
                //ViewBag.DataPoints = JsonConvert.SerializeObject(db.client_select_totalcount().ToList(), _jsonSetting);
                return View();
            }
            catch (System.Data.Entity.Core.EntityException)
            {
                return View("Error");
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return View("Error");
            }

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}