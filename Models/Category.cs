using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Display(Name = "Category Name")]
        [StringLength(50)]
        public string CName { get; set; }

        [StringLength(50)]
        public string Slug { get; set; }
    }
}
