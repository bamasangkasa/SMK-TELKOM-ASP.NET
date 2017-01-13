using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
namespace CRUD.Models
{
    public class Kasir
    {
        public Kasir()
        {
            Barang = new List<Barang>();
        }
        [Key]
        public int IDKasir { get; set; }
        public string NamaKasir { get; set; }
        public string Alamat { get; set; }

        public virtual ICollection<Barang> Barang { get; set; }

    }
}