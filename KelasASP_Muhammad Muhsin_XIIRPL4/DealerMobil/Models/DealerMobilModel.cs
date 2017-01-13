using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DealerMobil.Models
{
    public class Dealer
    {
        [Key]
        public int iddealer { get; set; }

        [Display(Name = "Nama Dealer")]
        [Required(ErrorMessage = "Nama Dealer Harus Diisi")]
        public string namadealer { get; set; }

        [Display(Name = "Nomer Dealer")]
        [Required(ErrorMessage="Nomer Harus Diisi")]
        public string nomer { get; set; }

        [Display(Name = "Alamat Dealer")]
        [Required(ErrorMessage = "Alamat Harus Diisi")]
        public string alamatdealer { get; set; }

        public int idmobil { get; set; }

        [ForeignKey("idmobil")]
        public virtual Mobil Mobil { get; set; }
    }


    public class Mobil
    {
        public Mobil()
        {

            Dealers = new List<Dealer>();

        }
        [Key]
        public int idmobil { get; set; }

        [Display(Name = "Nama Mobil")]
        [Required(ErrorMessage = "Nama Mobil Harus Diisi")]
        public string namamobil { get; set; }

        [Display(Name = "Merk Mobil")]
        [Required(ErrorMessage = "Merk Mobil Harus Diisi")]
        public string merkmobil { get; set; }

        public virtual ICollection<Dealer> Dealers { get; set; }
    }

    public class DealerDbCotext : DbContext
    {
        public DbSet<Mobil> Mobils { get; set; }
        public DbSet<Dealer> Dealers { get; set; }
    }

}