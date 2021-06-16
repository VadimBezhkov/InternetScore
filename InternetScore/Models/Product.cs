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
        [StringLength(50,MinimumLength =3,ErrorMessage ="Count name>3")]
        public string Name { get; set; }

        [Display(Name = "Count Product")]
        [Required(ErrorMessage ="Count Product >0")]
        [Range (0,100000,ErrorMessage ="Incorect Count")]
        public double Count { get; set; }

        [Display(Name = "Price Product")]
        [Required(ErrorMessage ="Price Product>0")]
        [Range(0, 90000, ErrorMessage = "Incorect Price")]
        public decimal Price { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}