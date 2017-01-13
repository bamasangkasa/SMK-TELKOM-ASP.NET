using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Biodata.Models
{
    public class BiodataOrangTua
    {
        [Key]
        public int BiodataOrangTuaID { get; set; }

        [Display(Name="Nama Ayah")]
        public string NamaA { get; set; }

        [Display(Name = "Nama Ibu")]
        public string NamaI { get; set; }

        [Display(Name = "Nama Anak")]
        public string NamaAn { get; set; }

        public string Alamat { get; set; }

        public int BiodataAnakID { get; set; }

        [ForeignKey("BiodataAnakID")]
        public virtual BiodataAnak BiodataAnak { get; set; }

    }

    public class BiodataAnak

    { 
        public BiodataAnak()
        {
            BiodataOrangTuaa = new List<BiodataOrangTua>();
        }
        [Key]
        public int BiodataAnakID { get; set; }

        [Display(Name = "Nama Lengkap")]
        public string Nama { get; set; }

        public decimal Umur { get; set; }

        public List<BiodataOrangTua> BiodataOrangTuaa { get; set; }
    }

    public class BiodataDbContext : DbContext
    {
        public DbSet<BiodataOrangTua> BiodataOrangtuaa { get; set; }
        public DbSet<BiodataAnak> BiodataAnakk { get; set; }
    }
}