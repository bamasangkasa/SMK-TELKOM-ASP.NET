using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CRUD.Models
{
    public class MyCompanyDBContext : DbContext
    {
        public DbSet<Barang> Barang { get; set; }
        public DbSet<Kasir> Kasir { get; set;}
    }
}