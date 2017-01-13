using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace KedaiMakanan.Models
{
    public class KedaiMakanan
    {
        [Key]
        public int PelangganID { get; set; }

        [Display(Name = "Nama Pelanggan")]
        public string NamaPelaggan { get; set; }

        [Display(Name = "Menu Makanan")]
        public string MenuMakanan { get; set; }

        [Display(Name = "Tanggal Pembelian")]
        [DisplayFormat(DataFormatString = "0:d")]
        public DateTime TanggalPembelian { get; set; }

        public int MenuID { get; set; }

        [ForeignKey("MenuID")]
        public virtual Menu Menu { get; set; }
    }

   public class Menu
    {
        public Menu()
        {
            MenuMakanan = new List<KedaiMakanan>();
        }

        [Key]
        public int MenuID { get; set; }

        [Display(Name ="Menu")]
        public string NamaMenu { get; set; }

        public string HargaMenu { get; set; }

        public virtual ICollection<KedaiMakanan> MenuMakanan { get; set; }
    }

    public class KedaiMakananDbContext : DbContext
    {
        public DbSet<KedaiMakanan> MenuMakanan { get; set; }
        public DbSet<Menu> KedaiMakanan { get; set; }
    }
}
