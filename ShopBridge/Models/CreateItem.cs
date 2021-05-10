using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Models
{
    public class CreateItem
    {
        [Required()]
        public string Name { get; set; }
        [Required()]
        public string Description { get; set; }
        [Required()]
        [Range(0, float.MaxValue, ErrorMessage = "Please enter valid price")]
        [RegularExpression("([+-]?([0-9]*[.])?[0-9]+)", ErrorMessage = "Please enter valid price again")]
        public float MaxPrice { get; set; }
        [Range(10, 100,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public float DiscountPercent { get; set; }

      
    }
}
