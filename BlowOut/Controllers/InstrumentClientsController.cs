using BlowOut.DAL;
using BlowOut.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BlowOut.Controllers
{
    public class InstrumentClientsController : Controller
    {
         private Instrument_RentalsContext db = new Instrument_RentalsContext();
     

        // GET: InstrumentClients
        
       [Authorize]
        public ActionResult UpdateData(string sEmail)
        {
            List<InstrumentClients> orders = new List<InstrumentClients>();
            foreach(Instrument IC in db.Instruments)
            {
                Instrument myInstrument = db.Instruments.Find(IC.ClientID);
                Client myClient;
                if (IC.ClientID != null)
                {
                    myClient = db.Clients.Find(IC.ClientID);
                }
                else
                {
                    myClient = new Client() { ClientFirstName = "N/A", ClientLastName = "N/A", Email = "N/A" };
                }
                InstrumentClients model = new InstrumentClients() { client = myClient, instrument = myInstrument };
                orders.Add(model);
            }

            return View(orders);
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

            if (string.Equals(email, "Missouri") && (string.Equals(password, "ShowMe")))
            {
                FormsAuthentication.SetAuthCookie(email, rememberMe);

                return RedirectToAction("UpdateData", "InstrumentClients");

            }
            else
            {
                return View();
            }
    

     /*   [HttpPost]
        public ActionResult Login(FormCollection form, bool rememberMe = false)
        {
            String email = form["Email address"].ToString();
            String password = form["Password"].ToString();
            
            //var currentUser = db.Database.SqlQuery<InstrumentClients>(
            //"Select * " +
            //"FROM Users " +
           // "WHERE UserID = '" + "Missouri" + "' AND " +
           // "UserPassword = '" + "ShowMe" + "'");


            
            if (email == "Missouri" && password == "ShowMe")
            //if (currentUser.Count() > 0)


            {
                FormsAuthentication.SetAuthCookie(email, rememberMe);
                return RedirectToAction("UpdateData", "InstrumentClients", new { userlogin = email });
            }
            else
            {
                return View();
            }
            */
        }
    }
}