using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
namespace CRUD2tabel.Models
{
    public class FakultasModels
    {
        public FakultasModels()
        {
            MahasiswaModels = new List<MahasiswaModels>();
        }
        [Key]
        public int ID_fakultas { get; set; }
        [Display(Name="Nama Fakultas")]
        public String Fakultas { get; set; }

        public virtual ICollection<MahasiswaModels> MahasiswaModels { get; set; }

    }
     
}