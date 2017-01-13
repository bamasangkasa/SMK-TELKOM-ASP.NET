using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace CRUD2tabel.Models
{
    public class MahasiswaModels
    {
        [Key]
        public int ID_mhs { get; set; }
        [Display(Name="Nama")]
        public String nama { get; set; }
        [Display(Name = "Alamat")]
        public String alamat { get; set; }
        [Display(Name = "Jenis Kelamin")]
        public String jenis_kelamin { get; set; }
        [Display(Name = "IPK")]
        public int IPK { get; set; }
        [Display(Name = "Fakultas")]
        public int ID_fakultas { get; set; }

         [Display(Name = "Fakultas")]
        [ForeignKey("ID_fakultas")]
        public virtual FakultasModels FakultasModels { get; set; }
    }

   
}