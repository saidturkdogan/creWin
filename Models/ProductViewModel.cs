using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace creWin.Models
{
    public class ProductViewModel
    {
        [Required]
        [DisplayName("id")]
        public int id { get; set; }
        
        [Required]
        [DisplayName("title")]
        public string title { get; set; }
        
        [Required]
        [DisplayName("description")]
        public string description { get; set; }
        
        [Required]
        [DisplayName("category")]
        public string category { get; set; }
        
        [Required]
        [DisplayName("price")]
        public double price { get; set; }
        
        [Required]
        [DisplayName("discountPercentage")]
        public double discountPercentage { get; set; }
        
        [Required]
        [DisplayName("rating")]
        public double rating { get; set; }
        
        [Required]
        [DisplayName("stock")]
        public int stock { get; set; }
    }
}
