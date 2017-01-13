using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Tanggal")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public string TanggalPembelian { get; set; }

        public decimal Jumlah { get; set; }

        [Display(Name = "Nama")]
        public string NamaBarang { get; set; }

        [Display(Name = "Merk")]
        public string MerkBarang { get; set; }

        public decimal Harga { get; set; }

        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }
        public int CustomerID { get; set; }
    }

    public class Customer
    {
        public Customer()
        {
            Products = new List<Product>();
        }

        [Key]
        public int CustomerID { get; set; }

        [Display(Name="Nama Customer")]
        public string Nama { get; set; }
        public string Umur { get; set; }
        public string Alamat { get; set; }
        public string Negara { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }

    public class OnlineShopDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }


}