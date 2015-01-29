using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using SendGrid;
using System.Configuration;

namespace MVCResumeWebsite.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(MVCResumeWebsite.Models.ContactMessage Message)
        {
            var MyAddress = ConfigurationManager.AppSettings["ContactEmail"];
            var MyUsername = ConfigurationManager.AppSettings["Username"];
            var MyPassword = ConfigurationManager.AppSettings["Password"];

            if (ModelState.IsValid)
            {
                SendGridMessage mail = new SendGridMessage();
                mail.From = new MailAddress(Message.FromEmail);
                mail.AddTo(MyAddress);
                mail.Subject = Message.Subject;
                mail.Text = Message.Message;

                var credentials = new NetworkCredential(MyUsername, MyPassword);
                var transportWeb = new Web(credentials);
                transportWeb.Deliver(mail);

            }

            return View();
        }
    }
}