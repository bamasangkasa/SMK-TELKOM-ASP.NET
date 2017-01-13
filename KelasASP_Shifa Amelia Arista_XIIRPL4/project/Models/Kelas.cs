using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project.Models
{
    public class Kelas
    {
    
        public Kelas()
        {
            DataSiswa2 = new List<DataSiswa>();
        }

        [Key]
        public int KodeKelas {get;set;}

        [Display(Name = "Nama Kelas")]
        public string NamaKelas { get; set; }

        public virtual ICollection<DataSiswa> DataSiswa2 {get; set;}

    }
}