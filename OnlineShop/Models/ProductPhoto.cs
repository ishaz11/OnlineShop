using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class ProductPhoto
    {
        public int ProductPhotoID { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }

        public string FilePath { get; set; }

        public Products Products { get; set; }
    }
}