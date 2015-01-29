using SendGrid;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace MVCResumeWebsite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact ()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(MVCResumeWebsite.Models.ContactMessage ContactForm)
        {
            var MyAddress = ConfigurationManager.AppSettings["ContactEmail"];
            var MyUsername = ConfigurationManager.AppSettings["Username"];
            var MyPassword = ConfigurationManager.AppSettings["Password"];

            if (ModelState.IsValid)
            {
                SendGridMessage mail = new SendGridMessage();
                mail.From = new MailAddress(ContactForm.FromEmail);
                mail.AddTo(MyAddress);
                mail.Subject = ContactForm.Subject;
                mail.Text = ContactForm.Message + " from " + ContactForm.Name;

                var credentials = new NetworkCredential(MyUsername, MyPassword);
                var transportWeb = new Web(credentials);
                transportWeb.Deliver(mail);

            }

            return View();
        }

        public ActionResult Skills()
        {
            return View();
        }

        public ActionResult Works()
        {
            return View();
        }

        public ActionResult SendEmail()
        {
            return View();
        }
    }
}