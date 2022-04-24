using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class ShopReports
    {
        [Key]
        public int reportID { get; set; }

        public int? ProductID { get; set; }
        [ForeignKey("ProductID")]
        public Products Products { get; set; }

        public int? Quantity { get; set; }

        public string isAble { get; set; }

        public string Note { get; set; }

        public DateTime Date { get; set; }

        public string Action { get; set; }

        public int? UserID { get; set; }
        [ForeignKey("UserID")]
        public Users Users { get; set; }
    }
}