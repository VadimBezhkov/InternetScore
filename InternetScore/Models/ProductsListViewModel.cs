using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InternetScore.Models
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set;}
        public SelectList Categoryes { get; set; }
        public SelectList Price { get; set; }

    }
}