using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class ResponseController : Controller
    {
        private ResponseContext db = new ResponseContext();

        public ActionResult Index()
        {
            ViewBag.Message = Request.UserHostAddress;
            return View();
        }

        [HttpPost]
        public ActionResult Index([Bind(Include = "ID,From,Subject,Body,Urgancy,IpAddress,Location,date")] EmailModel _objModelMail)
        {
            UniqueNumber();
            if (ModelState.IsValid)
            {
                _objModelMail.date = DateTime.Now;
                _objModelMail.IpAddress = GetIPAddress();
                //db.EmailModels.Add(_objModelMail);
                //db.SaveChanges();
                try
                {
                    string senderAd = "vincmelzp@gmail.com";
                    MailMessage mail = new MailMessage();
                    mail.To.Add(senderAd);
                    mail.From = new MailAddress(senderAd);
                    mail.Subject = _objModelMail.Urgancy;
                    string subject = _objModelMail.Subject;
                    string Type = _objModelMail.Urgancy;
                    string Body = _objModelMail.Body;
                    mail.Body = "Type: " + subject + Environment.NewLine + "Body: " + Body + Environment.NewLine + "IP Address" + GetIPAddress() + Environment.NewLine + "Online Number: " + UniqueNumber();
                    mail.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential
                    ("vincmelzp@gmail.com", "P@umon66");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
                catch(Exception ex)
                {
                    Console.Write(ex.Message);
                }
                
                return RedirectToAction("Index");
            }
            else
            {
                return View("Index", _objModelMail);
            }
        }

        public static String GetIPAddress()
        {
            String ip =
                System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (string.IsNullOrEmpty(ip))
                ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            else
                ip = ip.Split(',')[0];

            return ip;
        }
        public static String UniqueNumber()
        {
            string num = "0123456789";
            int len = num.Length;
            string otp = string.Empty;
            int otpdigit = 8;
            string finaldigit;
            int getindex;
            for(int i = 0; i < otpdigit; i++ )
            {
                do
                {
                    getindex = new Random().Next(0, len);
                    finaldigit = num.ToCharArray()[getindex].ToString();
                }
                while (otp.IndexOf(finaldigit) != -1);
                otp += finaldigit;
            }
            return otp;
        }

    }
}
