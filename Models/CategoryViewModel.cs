using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace creWin.Models
{
    public class CategoryViewModel
    {
        [Required]
        [DisplayName("Product Slug")]
        public string Slug { get; set; }

        [Required]
        [DisplayName("Product Name")]
        public string Name { get; set; }

        [Required]
        public string Url { get; set; }
        }
    }

