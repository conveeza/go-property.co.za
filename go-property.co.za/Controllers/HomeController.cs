using go_property.co.za.Mailkit;
using go_property.co.za.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.IO;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Xml.Linq;
using System.Configuration;

namespace go_property.co.za.Controllers
{
    public class HomeController : Controller
    {
        private goproperty_dbEntities db = new goproperty_dbEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public string ContactUs(string name, string email, string phone, string message)
        {
            //create current date
            DateTime currentDateTime = DateTime.Now;

            //adding the contact message to db
            db.Contact_Form.Add(new Contact_Form
            {
                Full_Names = name,
                Email = email,
                Phone = phone,
                Message = message,
                Date = currentDateTime
            });

            //savedb
            try
            {
                db.SaveChanges();

                //send email
                var emailservice = new EmailService();
                var emailModel = new EmailModel("admin@go-property.co.za", "Contact Form", ContactFrmBody.EmailStringContactBody(name, message, email, phone));
                emailservice.SendEmail(emailModel);

                //return response
                return JsonConvert.SerializeObject(new { message = "Message sent" });
            }
            catch (Exception)
            {
                return JsonConvert.SerializeObject(new { message = "Message failed to save!" });
            }  
        }
    }
}