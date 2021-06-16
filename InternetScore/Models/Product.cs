using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InternetScore.Models
{
    public class Product
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Name Product")]
        [Required(ErrorMessage ="Enter Name Product")]
        public string Name { get; set; }

        [Display(Name = "Count Product")]
        [Required(ErrorMessage ="Count Product >0")]
        public double Count { get; set; }

        [Display(Name = "Price Product")]
        [Required(ErrorMessage ="Price Product>0")]
        public decimal Price { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}