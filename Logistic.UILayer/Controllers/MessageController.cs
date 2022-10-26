using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Logistic.UILayer.Models;

namespace Logistic.UILayer.Controllers
{
    public class MessageController : Controller
    {
        DBLogisticEntities db = new DBLogisticEntities();
        public ActionResult Inbox()
        {
            var mail = Session["CustomerMail"].ToString();
            var values = db.TblMessage.Where(x => x.MessageReciver == mail).ToList();
            return View(values);
        }

        public ActionResult Outbox()
        {
            var mail = Session["CustomerMail"].ToString();
            var values = db.TblMessage.Where(x => x.MessageReciver == mail).ToList();
            return View(values);
         
        }
        [HttpGet]
        public ActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendMessage(TblMessage p)
        {
            var mail = Session["CustomerMail"].ToString();

            string mesajiGonderen = db.TblCustomer.Where(x => x.CustomerMail == mail).Select(y => y.CustomerName + " " + y.CustomerSurname).FirstOrDefault();

            string alici = db.TblCustomer.Where(x => x.CustomerMail == p.MessageReciver).Select(y => y.CustomerName + " " + y.CustomerSurname).FirstOrDefault();

            p.ReciverName = alici;
            p.SenderName = mesajiGonderen;
            p.MessageSender = mail;
            p.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            db.TblMessage.Add(p);
            db.SaveChanges();
            return RedirectToAction("Outbox");
        }
        //public ActionResult MessageDetails(int )

    }
}