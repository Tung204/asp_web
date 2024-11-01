using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ProjectA.Models
{
    public class GioHang
    {
        [Key]
        public int Id { get; set; }

        // Foreign key for the product
        public int SanPhamId { get; set; }

        [ForeignKey("SanPhamId")]
        [ValidateNever]
        public SanPham SanPham { get; set; }

        // Quantity of the product in the cart
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }

        // Foreign key for the user
        public string ApplicationUserId { get; set; }

        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }
    }
}