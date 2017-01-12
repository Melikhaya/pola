using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication6.Models
{
    public class EmailModel
    {
        public int ID { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Urgancy { get; set; }
        public string IpAddress { get; set; }
        public string Location { get; set; }
        public DateTime date { get; set; }
    }
}