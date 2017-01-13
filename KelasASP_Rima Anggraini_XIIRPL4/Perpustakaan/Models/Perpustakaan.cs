using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
namespace Perpustakaan.Models
{
    public class Peminjaman
    {
        [Key]
        public int Id_peminjaman { get; set; }

        [Display(Name= "Nama Peminjam")]
        public string Nama_Peminjam { get; set; }

        [Display(Name = "Tanggal Peminjam")]
        [DisplayFormat(DataFormatString="{0:d}")]
        public DateTime Tgl_Peminjaman { get; set; }

        [Display(Name = "Id Buku")]
        public int Id_Buku { get; set; }

        [ForeignKey("Id_Buku")]
        public virtual Buku Buku { get; set; }

    }

    public class Buku
    {
        public Buku(){
        Perpustakaans = new List<Peminjaman>();
        }
        [Key]
        public int Id_Buku {get; set;}
        [Display(Name = "Nama Buku")]
        public string Nama_Buku {get; set;}

        [Display(Name = "Nama Pengarang")]
        public string Nama_Pengarang {get; set;}

        [Display(Name = "Tahun Terbit")]
        public int Tahun_Terbit {get; set;}

        public virtual ICollection<Peminjaman>Perpustakaans {get; set; }

    }

    public class PerpustakaanDbContext : DbContext
    {
        public DbSet<Peminjaman> Pinjam { get; set; }
        public DbSet<Buku> Bukus { get; set; }
    }
}