using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Overseas.Common;

namespace Overseas.Controllers
{
    public class BaseController : Controller
    {
        public SessionWrapper sessionWrapper = new SessionWrapper();
        public BaseController()
        {
            
        }
        



    }
}