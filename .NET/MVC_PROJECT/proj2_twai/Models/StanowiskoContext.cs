using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace proj2_twai.Models
{
    public class StanowiskoContext : DbContext
    {
        public StanowiskoContext() : base("name=Database")
        { }
        public System.Data.Entity.DbSet<proj2_twai.Models.Stanowisko> Stanowiskas { get; set; }
    }
}