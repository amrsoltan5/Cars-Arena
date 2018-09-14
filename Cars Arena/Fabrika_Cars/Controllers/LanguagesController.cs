using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fabrika_Cars.Controllers
{
    public class LanguagesController : Controller
    {
        // GET: Languages
        public ActionResult Arabic()
        {

            Session["lang"] = "ar-EG";
            return Redirect(Request.UrlReferrer.ToString());
        }



        public ActionResult English()
        {
            Session["lang"] = "en-US";

          return  Redirect(Request.UrlReferrer.ToString());
        }

    }
}