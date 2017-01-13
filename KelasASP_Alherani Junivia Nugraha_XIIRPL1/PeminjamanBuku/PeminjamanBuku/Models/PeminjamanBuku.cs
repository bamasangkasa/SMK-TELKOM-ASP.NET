using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace PeminjamanBuku.Models
{
    public class Buku
    {
        [Key]
        public int KodeBuku { get; set; }

        [Display(Name = "Judul")]
        public string Judul { get; set; }

        [Display(Name = "Pengarang")]
        public string Pengarang { get; set; }

        [Display(Name = "Penerbit")]
        public string Penerbit { get; set; }

        [Display(Name = "Tahun Terbit")]
        public int TahunTerbit { get; set; }

        public int NoAnggota{ get; set; }

        [ForeignKey("NoAnggota")]
        public virtual Anggota Anggota { get; set; }
    }
    public class Anggota
    {
        public Anggota()
        {
            Bukuu = new List<Buku>();
        }
        [Key]
        public int NoAnggota { get; set; }

        [Display(Name = "Nama Anggota")]
        public string NamaAnggota { get; set; }

        [Display(Name = "Tanggal Lahir")]
        [DisplayFormat(DataFormatString="{0:d}")]
        public DateTime TanggalLahir { get; set; }

        public string Alamat { get; set; }

        [Display(Name = "Tanggal Masuk")]
        [DisplayFormat(DataFormatString="{0:d}")]
        public DateTime TanggalMasuk { get; set; }

        public virtual ICollection<Buku> Bukuu { get; set; }

    }
    public class PeminjamanBukuDbContext : DbContext
    {
        public DbSet<Buku> Bukuu { get; set; }
        public DbSet<Anggota> Anggotaa { get; set; }
    }
}