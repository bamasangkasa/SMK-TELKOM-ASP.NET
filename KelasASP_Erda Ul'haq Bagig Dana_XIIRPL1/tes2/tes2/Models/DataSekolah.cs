using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tes2.Models
{
    public class Siswa
    {
        [Key]
        public int IDSiswa { get; set; }

        [Required(ErrorMessage = "field tidak boleh kosong !")]
        [Display(Name = "Nama Lengkap")]
        public string NamaLengkap { get; set; }

        [Required(ErrorMessage = "field tidak boleh kosong !")]
        public string Email { get; set; }

        [Required(ErrorMessage = "field tidak boleh kosong !")]
        public decimal NISN { get; set; }

        public int IDSekolah { get; set; }

        [ForeignKey("IDSekolah")]
        public virtual Sekolah Sekolah { get; set; }
    }

    public class Sekolah
    {
        public Sekolah()
        {
            Siswaa = new List<Siswa>();
        }

        [Key]
        public int IDSekolah { get; set; }

        [Required(ErrorMessage = "field tidak boleh kosong !")]
        [Display(Name = "Nama Sekolah")]
        public string NamaSekolah { get; set; }

        [Required(ErrorMessage = "field tidak boleh kosong !")]
        public string Kota { get; set; }

        public virtual ICollection<Siswa> Siswaa { get; set; }
    }

    public class DataSekolahDbContext : DbContext
    {
        public DbSet<Siswa> Siswaa { get; set; }
        public DbSet<Sekolah> Sekolahh { get; set; }
    }
}