using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class Products
    {
        [Key]
        [Display(Name = "Product ID")]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Product Name Required")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Description Required")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price Required")]
        [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        //[DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "Quantity Required")]
        [Display(Name = "Quantity")]
        public int Qty { get; set; }

        [Display(Name = "Available")]
        public bool Available { get; set; }

        [Display(Name = "Photo #1")]
        public string Photo1 { get; set; }


        [Display(Name = "Photo #2")]
        public string Photo2 { get; set; }

        [Display(Name = "Photo #3")]
        public string Photo3 { get; set; }

        [NotMapped]
        //[Required(ErrorMessage = "Required")]
        public HttpPostedFileBase File1 { get; set; }
        [NotMapped]
        //[Required(ErrorMessage = "Required")]
        public HttpPostedFileBase File2 { get; set; }
        [NotMapped]
        //[Required(ErrorMessage = "Required")]
        public HttpPostedFileBase File3 { get; set; }
    }
}