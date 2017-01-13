using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Sekolah2.Models
{
    public class Siswa
    {
        public int SiswaID { get; set; }

        [Display(Name = "Nama Siswa")]
        public string NamaSiswa { get; set; }

        public int KelasID { get; set; }

        [ForeignKey("KelasID")]
        public virtual Kelas Kelas { get; set; }

    }

    public class Kelas
    {
        public Kelas()
        {
            ParaSiswa = new List<Siswa>();
        }

        public int KelasID { get; set; }

        [Display(Name = "Nama Kelas")]
        public string NamaKelas { get; set; }

        public string Jurusan { get; set; }

        public virtual ICollection<Siswa> ParaSiswa { get; set; }

    }
    public class SekolahDbContext : DbContext
    {
        public DbSet<Siswa> ParaSiswa { get; set; }
        public DbSet<Kelas> KelasKelas { get; set; }
    }
}