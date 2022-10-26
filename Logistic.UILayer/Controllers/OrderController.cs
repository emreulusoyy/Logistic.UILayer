using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logistic.UILayer.Models;

namespace Logistic.UILayer.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {

        DBLogisticEntities db = new DBLogisticEntities();
        public ActionResult Index()
        {
            var values = db.TblOrder.ToList();
            return View(values);
        }
        public ActionResult DeleteOrder(int id)
        {
            var values = db.TblOrder.Find(id);
            db.TblOrder.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
