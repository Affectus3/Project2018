using System.Web.Mvc;
using MVCEmail.Models;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Net;
using System;
using System.Text;
using System.Threading;
using System.IO;
using Project2018.ViewModels;

namespace Project2018.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        // GET: Home               
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailFormModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("")); //replace with valid value
                message.Subject = "Personal Management System - Contact";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;
                if (model.Upload != null && model.Upload.ContentLength > 0)
                {
                    message.Attachments.Add(new Attachment(model.Upload.InputStream, Path.GetFileName(model.Upload.FileName)));
                }
                using (var smtp = new SmtpClient())
                {
                    await smtp.SendMailAsync(message);
                    ViewBag.Message = "Your message has been sent";
                    return View();
                }
            }
            return View(model);
        }
        public ActionResult Sent()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}
