using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
    public class Products
    {
        public string Id{ get; set; }

        //Restricting the length of name to be of maximum 20 characters
        //Adding a place holder "Product name" 
        [StringLength(20)]
        [DisplayName("Product Name")]
        public string name{get;set;}
        public string Descp { get; set; }

        //Restricts the range to be between 0 and 1000
        [Range(0, 1000)]
        public decimal price { get; set; }
        public string catg { get; set; }
        public string img{ get; set; }

        public Products()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
