using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    public class ResponseContext : DbContext
    {    
        public ResponseContext() : base("name=ResponseContext")
        {
        }

        public System.Data.Entity.DbSet<WebApplication6.Models.EmailModel> EmailModels { get; set; }
    }
}
