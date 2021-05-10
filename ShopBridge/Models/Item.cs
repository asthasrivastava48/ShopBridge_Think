using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Models
{
    public class Item
    {
        public int Id { get; set; }
        [Required()]
        public string Name { get; set; }
        [Required()]
        public string Description { get; set; }
        [Required()]
        public float MaxPrice { get; set; }
        [Range(10, 1000,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public float DiscountPercent { get; set; }
        public float SellingPrice { get; set; }
        public bool IsOnSale { get; set; }
    }
}
