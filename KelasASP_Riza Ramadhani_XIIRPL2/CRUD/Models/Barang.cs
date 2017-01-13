using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace CRUD.Models
{
    public class Barang
    {
        [Key]
        public int IDBarang { get; set; }
        public string NamaBarang { get; set; }
        public string Merk { get; set; }
        public int Harga { get; set; }
        public int Stok { get; set; }

        public int IDKasir { get; set; }

        [ForeignKey("IDKasir")]
        public virtual Kasir Kasir { get; set; }

    }

    
}