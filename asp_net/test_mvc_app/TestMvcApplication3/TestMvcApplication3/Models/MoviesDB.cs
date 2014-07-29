using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TestMvcApplication3.Models
{
    //[Table("")]
    public class MoviesDB
    {
       // [Key]
        public int ID { get; set; }
        public DateTime date { get; set; }
        public String title { get; set; }
        public String director { get; set; }
    }

    public class MoviesDBContext : DbContext
    {
        public DbSet<MoviesDB> movies { get; set; }
    }
}