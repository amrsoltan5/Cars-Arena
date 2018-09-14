using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using System.Globalization;
namespace Fabrika_Cars.Controllers
{
    public class BaseController : Controller
    {


        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (Session["lang"] != null)
           
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session["lang"].ToString());

           


        }


    }
}