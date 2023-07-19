using System.ComponentModel.DataAnnotations;

namespace  ShoppingCart.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Display(Name = "Product Name")]
        [StringLength(50)]
        public string? PName { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DOT { get; set; }

        [StringLength(150)]
        public string? SDescription { get; set; }

        [StringLength(350)]
        public string? LDescription { get; set; }

        public int Qty { get; set; }

        [Display(Name = "Product Image")]
        [StringLength(30)]
        public string? PImage { get; set; }

        public string? Price { get; set; }

        public string? Slug { get; set; }

        [Display(Name = "Product Available")]
        public Boolean IsAvailable { get; set; }

        public Category? Category { get; set; }

        public int CategoryId { get; set; }


    }
}