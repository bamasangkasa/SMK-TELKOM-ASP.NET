using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;


namespace MyCompany.Models
{
    public class MyCompanyDbContext : DbContext
    {
        public DbSet<Murid> Muridd { get; set; }
        public DbSet<Kelas> Kelass { get; set; }
    }
}