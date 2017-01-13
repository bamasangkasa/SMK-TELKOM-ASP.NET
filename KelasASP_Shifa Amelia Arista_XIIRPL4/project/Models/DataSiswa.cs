using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace project.Models
{
    public class DataSiswa
    {
        [Key]
        public int NIS { get; set; }

        [Display(Name = "Nama Lengkap")]
        public string NamaLengkap { get; set; }

        [Display(Name = "Tempat Tanggal Lahir")]
        public string TTL { get; set; }

        [Display(Name = "Alamat")]
        public string Alamat { get; set; }

        [Display(Name = "Jenis Kelamin")]
        public string JK { get; set; }

        [Display(Name = "No Telepon")]
        public string NoTelp { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Hired Date")]
        [DisplayFormat(DataFormatString="{0:d}")]
        public DateTime HireDate { get; set; }

        public int KodeKelas { get; set; }

        [ForeignKey("KodeKelas")]
        public virtual Kelas Kelas { get; set; }
    }
}