using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;

namespace BlowOut.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            ViewBag.phone = "Please call Support at <strong><u>801-555-1212.</u></strong> Thank you!";
            return View();
        }

        public ActionResult Email(string sName, string sEmail)
        {
            ViewBag.email = "Thank you " + sName + ". We will send an email to " + sEmail;

            /**This was the code we worked on to send the email but it kept bugging out on the client.send part
             * MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("ishomework2.3@gmail.com");
            mailMessage.To.Add(new MailAddress("puker514@aol.com"));
            mailMessage.Subject = "Your subject";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = "Email body";
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("ishomework2.3@gmail.com", "abcd1234!@#$");
            client.Host = "smtp.gmail.com";
            client.Send(mailMessage);**/


            return View();
        }
        public ActionResult SendEmail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendEmail(string receiver, string subject, string message)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var senderEmail = new MailAddress("syd.j.christensen@gmail.com", "Sydnee Christensen");
                    var receiverEmail = new MailAddress(receiver, "Receiver");
                    var password = "twinsydnee";
                    var sub = subject;
                    var body = message;
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };
                    using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = subject,
                        Body = message
                    })
                    {
                        smtp.Send(mess);
                    }
                    return View();
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Some Error";
            }
            return View();
        }

    }
}