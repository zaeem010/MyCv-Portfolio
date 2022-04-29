using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyCv.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MyCv.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SendEmail(EmailModel model)
        {
            model.Email = "Khanzaeem010@gmail.com";
            model.Password = "Mynameiszaeemkhan010";
            using (MailMessage mm = new MailMessage(model.Email, model.To))
            {
                mm.Subject = "Work";
                mm.Body = model.Body;
                mm.IsBodyHtml = false;
                try
                {
                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential(model.Email, model.Password);
                        smtp.EnableSsl = true;
                        smtp.Send(mm);
                    }
                }
                catch (Exception e) 
                {
                   string error = e.Message;
                }
            }
                return RedirectToAction("Index");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
