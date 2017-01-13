using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Dosen
{
    public class Kuliah
    {
        [Key]
        public int kodemapel { get; set; }

        [Display(Name = "Nama Pelajaran")]
        public string NamaPelajaran { get; set; }

        [Display(Name = "Jumlah Jam Pelajaran")]
        public string JumlahJam { get; set; }

        [Display(Name = "Semester")]
        public string Semester { get; set; }

        public int DosenID { get; set; }

        [ForeignKey("DosenID")]
        public virtual Dosen Dosen { get; set; }

    }

    public class Dosen
    {
        
        public Dosen()
        {
            MaPell = new List<Kuliah>();
    }
        [Key]
        public int DosenID { get; set; }

        [Display(Name = "Nama Dosen")]
        public string NamaDosen { get; set; }

        [Display(Name = "Kode Dosen")]
        public string KodeDosen { get; set; }

        public virtual ICollection<Kuliah> MaPell {get; set;}


    }

    public class MyCompanyDbContext : DbContext
    {
        public DbSet<Kuliah> MaPell { get; set; }
        public DbSet<Dosen> Dosenn { get; set; }
    }
    }