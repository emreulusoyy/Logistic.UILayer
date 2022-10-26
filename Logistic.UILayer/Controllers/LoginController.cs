using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Logistic.UILayer.Models;
namespace Logistic.UILayer.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        
        DBLogisticEntities db = new DBLogisticEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TblCustomer p)
        {
            var values = db.TblCustomer.FirstOrDefault(x => x.CustomerMail == p.CustomerMail && x.CustomerPassword == p.CustomerPassword);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.CustomerMail, false); //Sisteme Yetkili Kıl . Bu kullanıcı verileri saklanmasın.
                Session["CustomerMail"] = values.CustomerMail;//Bu kullanıcının Customer Mail Bilgisini oturum açma parametresi olarak sakla.
                return RedirectToAction("Index", "Dashboard"); //Başarılı olursa beni Dashboarda yönlendir.
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}