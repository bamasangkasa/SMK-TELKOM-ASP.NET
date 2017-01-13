using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace project.Models
{
    public class MyCompanyDbContext : DbContext
    {
        public DbSet<DataSiswa> DataSiswa2 { get; set; }
        public DbSet<Kelas> Kelas2 { get; set; }
    }
}