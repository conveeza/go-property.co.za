using go_property.co.za.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.IO;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Web.Helpers;
using System.Web.Services.Description;
using System.Xml.Linq;
using Newtonsoft.Json;
using go_property.co.za.Mailkit;

namespace go_property.co.za.Controllers
{
    public class PropertyController : Controller
    {
        // GET: Property
        private readonly goproperty_dbEntities go_db = new goproperty_dbEntities();
        public ActionResult Buy()
        {
            var listings = new ListingsVM();
            listings.PropListings = go_db.Listings.Where(l => l.Listing_Type_Id == 1).ToList();
            listings.Listing_Type = go_db.Listing_Type.Where(lt => lt.Name == "For Sale").ToList();
            return View(listings);
        }

        public ActionResult Rent()
        {
            var listings = new ListingsVM();
            listings.PropListings = go_db.Listings.Where(l => l.Listing_Type_Id  == 2).ToList();
            listings.Listing_Type = go_db.Listing_Type.Where(lt => lt.Name == "Rental").ToList();
            return View(listings);
        }
        public ActionResult Sell()
        {
            return View();
        }

        public ActionResult ListingDetails(int propId)
        {
            var listings = new ListingsVM();
            listings.PropListings = go_db.Listings.Where(l => l.Listing_Id == propId).ToList();
            listings.Listing_Type = go_db.Listing_Type.ToList();
            listings.Property_Type = go_db.Property_Type.ToList();
            return View(listings);
        }
        public ActionResult New_Development()
        {
            var listings = new ListingsVM();
            listings.PropListings = go_db.Listings.Where(l => l.Listing_Type_Id == 3).ToList();
            listings.Listing_Type = go_db.Listing_Type.Where(lt => lt.Name == "Development").ToList();
            return View(listings);
        }

        public string sendSellPropEmail(string cusName, string cusEmail, string cusPhone, string propDesc, string propBeds, string propBaths, string propAddress)
        {
            try
            {
                //send email
                var emailservice = new EmailService();
                var emailModel = new EmailModel("admin@go-property.co.za", "New Listing request - Go Property", SellConfirmationBody.EmailStringSellBody(cusName, cusEmail, cusPhone, propDesc, propBeds, propBaths, propAddress));
                emailservice.SendEmail(emailModel);

                return JsonConvert.SerializeObject(new { message = "Message sent. We will get back to you soon." }); ;
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new { message = "Failed to send email." });
            }
        }
    }
}