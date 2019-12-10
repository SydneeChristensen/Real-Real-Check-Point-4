using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BlowOut.DAL;
using BlowOut.Models;

namespace BlowOut.Controllers
{
    public class HomeController : Controller
    {
        private Instrument_RentalsContext db = new Instrument_RentalsContext();

        [Authorize]
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

        [HttpGet]
        public ActionResult Create(int ID)
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="ClientId, ClientFirstName, ClientLastName, Address, City, State, Zip, Email, Phone")] Client client, int ID)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();

                Instrument instrument = db.Instruments.Find(ID);
                instrument.ClientID = client.ClientID;
                //db.Entry(instrument).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Summary", new { ClientID = client.ClientID, InstrumentID = instrument.InstrumentID });
            }

            return View(client);
        }


        public ActionResult Summary(int ClientID, int InstrumentID)
        {
            Client client = db.Clients.Find(ClientID);
            Instrument instrument = db.Instruments.Find(InstrumentID);

            ViewBag.Client = client;
            ViewBag.Instrument = instrument;
            ViewBag.months18 = instrument.Price * 18;

            return View();
        }

        //stuff for the RENTAL process
        //Create a Rentals view that allows users to select a type of instrument by clicking on an image.

        //After clicking on the instrument image you should be taken to a new page that shows the instrument.
        //The user should be able to select new or used.Depending on whether its new or used, you should show the price for the instrument.

        public ActionResult Rental()
        {
            ViewBag.space = " ";
            return View(db.Instruments.ToList());
        }
        // GET: Home
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form, bool rememberMe = false)
        {
            String email = form["Email address"].ToString();
            String password = form["Password"].ToString();

            if (string.Equals(email, "greg@test.com") && (string.Equals(password, "greg")))
            {
                FormsAuthentication.SetAuthCookie(email, rememberMe);

                return RedirectToAction("Index", "Home");

            }
            else
            {
                return View();
            }
        }
    }
}