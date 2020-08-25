using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TestAspNetSite.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string Url_to_Download { get; set; }
        public string Image_Url { get; set; }

        public string Category { get; set; }
    }
}
