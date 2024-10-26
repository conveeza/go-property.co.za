using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace go_property.co.za.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        public ActionResult Loan_Calculator()
        {
            return View();
        }

        public ActionResult CSI()
        {
            return View();
        }

        public ActionResult Team()
        {
            return View();
        }

        public ActionResult Interior_Design()
        {
            return View();
        }
    }
}