using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace MySchools.Models
{
    public class Schools
    {
        [Key]
        public int SchoolID { get; set; }

        [Display(Name = "School Name")]
        public string SchoolName { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

       
        public int YayasanID { get; set; }

         [ForeignKey("YayasanID")]
        public virtual Yayasan Yayasan { get; set; }

    }

    public class Yayasan
{
        public string Address;
        public Yayasan()
        {
            Schoolss = new List<Schools>();
        }

        [Key]
        public int YayasanID {get; set;}

        [Display(Name="Yayasan")]
        public string NamaYayasan {get; set;}

        public string Alamat {get; set;}

        public virtual ICollection<Schools> Schoolss {get; set;}

}

    public class MySchoolsDbContext : DbContext
    {
        public DbSet<Schools> Schoolss {get; set; }
        public DbSet<Yayasan> Yayasann {get; set; }
    }
}

