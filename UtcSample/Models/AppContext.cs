using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UtcSample.Models
{
    public class AppContext : DbContext
    {
        public AppContext() : base("AppContext")
        {

        }

        public DbSet<Soliloquy> Soliluies { get; set; }
    }
}