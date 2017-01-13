using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace MyCompany.Models
{
    public class Murid
    {
        public int MuridID { get; set; }

        public string Nama { get; set; }

        public string Email { get; set; }

        public decimal Score { get; set; }

        public int KelasID { get; set; }

        [ForeignKey("KelasID")]
        public virtual Kelas Kelas { get; set; }

    }
}
