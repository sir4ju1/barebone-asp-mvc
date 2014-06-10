using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web.Mvc;
using BareboneFramework.Models;

namespace BareboneFramework.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            ViewBag.Location = "23.7819834,90.3966283";
            return View();
        }

        [HttpPost]
        public ActionResult SendMail(ContactViewModel c)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var msg = new MailMessage();
                    var smtp = new SmtpClient();
                    var from = new MailAddress(c.Email);
                    var sb = new StringBuilder();
                    msg.IsBodyHtml = false;
                    smtp.Host = "smtp.domain.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential("username", "password");
                    msg.To.Add("some@email.com");
                    msg.From = from;
                    msg.Subject = "Contact Us";
                    sb.Append("First name: " + c.FirstName);
                    sb.Append(Environment.NewLine);
                    sb.Append("Last name: " + c.LastName);
                    sb.Append(Environment.NewLine);
                    sb.Append("Email: " + c.Email);
                    sb.Append(Environment.NewLine);
                    sb.Append("Comments: " + c.Comment);
                    msg.Body = sb.ToString();
                    smtp.Send(msg);
                    msg.Dispose();
                    return View("Index");
                }
                catch (Exception)
                {
                    return View("Error");
                }
            }
            return View("Index");
        }
    }
}