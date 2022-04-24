using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class Orders
    {
        [Key]
        [Display(Name = "Order ID")]
        public int OrderID { get; set; }

        public int? ProductID { get; set; }
        [ForeignKey("ProductID")]
        public Products Products { get; set; }

        
        public int? UserID { get; set; }
        [ForeignKey("UserID")]
        public Users Users { get; set; }

        [Display(Name = "Orders")]
        public int OrderCount { get; set; }

        public string Status { get; set; }

        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }

       
        public DateTime DateConfirmed { get; set; }

        public DateTime DateCompleted { get; set; }

        [Display(Name = "Pick Up Date")]
        public DateTime PickUpDate { get; set; }


    }
}