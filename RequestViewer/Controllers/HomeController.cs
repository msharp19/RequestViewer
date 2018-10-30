using RequestResolver;
using RequestViewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace RequestViewer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(GetDataModel());
        }

        private KeyValuePairs GetDataModel()
        {
            var values = RequestUtil.GetServerVariables(Request);
            var ip = Request.UserHostAddress;
            return new KeyValuePairs() { Data = values, IP = ip, GeoLocation = RequestUtil.GetGeoLocation(ip) };
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult GetJson()
        {
            var jsonData = GetDataModel();
            return new JsonResult() { Data= jsonData, JsonRequestBehavior= JsonRequestBehavior.AllowGet };
        }
    }
}