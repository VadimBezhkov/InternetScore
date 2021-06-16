using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InternetScore.Models
{
    public class ScoreContext: DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categoryes { get; set; }

    }
}