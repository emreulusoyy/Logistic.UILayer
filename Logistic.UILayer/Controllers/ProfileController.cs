using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logistic.UILayer.Models;

namespace Logistic.UILayer.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        DBLogisticEntities db = new DBLogisticEntities();
        public ActionResult Index()
        {
            var mail = Session["CustomerMail"].ToString();
            var values = db.TblCustomer.Where(x => x.CustomerMail == mail).FirstOrDefault();
            ViewBag.v1 = values.CustomerName;
            ViewBag.v2 = values.CustomerSurname;
            ViewBag.v3 = values.CustomerMail;
            ViewBag.v4 = values.CustomerPhone;
            return View();
        }
    }
}