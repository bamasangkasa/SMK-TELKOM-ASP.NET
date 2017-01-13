using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace BookingHotel.Models
{
    public class Pemesanan
    {
        [Key]
        public int IdPesan { get; set; }


        [Display(Name="Nama Depan")]
        [Required(ErrorMessage = "Nama Depan harus diisi!!!")]
        public string NamaDepan { get; set; }

        [Display(Name = "Nama Belakang")]
        [Required(ErrorMessage = "Nama Belakang harus diisi!!!")]
        public string NamaBelakang { get; set; }

        [Required(ErrorMessage = "Email harus diisi!!!")]
        public string Email { get; set; }

        [Display(Name="Jenis Kamar")]
        public int IDJenisKamar { get; set; }

        [Display(Name = "Tanggal Pemesanan")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [Required(ErrorMessage = "Tanggal Pemesanan harus diisi!!!")]
        public DateTime TanggalPesan { get; set; }

        public int Jumlah { get; set; }

        [ForeignKey("IDJenisKamar")]
        public virtual Kamar Kamar { get; set; }
    }
public class Kamar
{
    public Kamar()
    {
     Pesanan = new List<Pemesanan>();
    }

    [Key]
    public int IDJenisKamar { get; set; }

    [Display(Name="Nama Kamar")]
    [Required(ErrorMessage = "Nama Kamar harus diisi!!!")]
    public string NamaKamar{ get; set; }

    public virtual ICollection<Pemesanan> Pesanan { get; set; }
}

    public class BookingHotelDbContext : DbContext
    { 
        public DbSet<Pemesanan> Pesanan { get; set; }
        public DbSet<Kamar> Kamars { get; set; }
       
    }
}