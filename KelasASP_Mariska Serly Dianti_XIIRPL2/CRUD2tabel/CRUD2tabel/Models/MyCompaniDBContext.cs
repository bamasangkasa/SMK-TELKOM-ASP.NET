using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CRUD2tabel.Models
{
    public class MyCompaniDBContext : DbContext
    {
        public DbSet<MahasiswaModels> MahasiswaModels { get; set; }
        public DbSet<FakultasModels> FakultasModels { get; set; }
    }
}