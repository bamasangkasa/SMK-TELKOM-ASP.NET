using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace MyCompany.Models
{
    public class Kelas
    {
        public Kelas()
        {
            Muridd = new List<Murid>();
        }
        public int KelasID { get; set; }


        public string Nama { get; set; }

        public virtual ICollection<Murid> Muridd { get; set; }

    }
}