using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Univ.Models
{
    public class Mahasiswa
    {
        [Key]
        public int MahasiswaID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Jurusan")]
        public string Jurusan { get; set; }

        public string Email { get; set; }

        public int DosenID { get; set; }

        [ForeignKey("DosenID")]
        public virtual Dosen Dosen { get; set; }
    }

    public class Dosen
    {
        public Dosen()
        {
            Mahasiswas = new List<Mahasiswa>();
        }
        [Key]
        public int DosenID { get; set; }

        [Display(Name = "Nama Dosen")]
        public string NamaDosen { get; set; }

        [Display(Name = "Alamat Dosen")]
        public string AlamatDosen { get; set; }

        [Display(Name = "Mata Kuliah")]
        public string MataKuliah { get; set; }


        public virtual ICollection<Mahasiswa> Mahasiswas { get; set; }
    }

    public class MyCompanyDbContext : DbContext
    {
        public DbSet<Mahasiswa> Mahasiswas { get; set; }
        public DbSet<Dosen> Dosens { get; set; }
    }
}