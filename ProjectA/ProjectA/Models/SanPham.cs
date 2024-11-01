using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectA.Models
{
	public class SanPham
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string? Description { get; set; }
		public string price { get; set; }
		public string? ImageUrl { get; set; }
        public string? ImageUrl_2 { get; set; }
        public string? ImageUrl_3 { get; set; }
        public string? ImageUrl_4 { get; set; }
        [Required]
		public int TheLoaiId { get; set; }
		[ForeignKey("TheLoaiId")]
		[ValidateNever]
		public TheLoai TheLoai { get; set; }

		[Required]
        public int NhaSanXuatId { get; set; }
        [ForeignKey("NhaSanXuatId")]
        [ValidateNever]
        public NhaSanXuat NhaSanXuat { get; set; }

        public int? BoSuuTapId { get; set; } // Khóa ngoại, có thể là nullable
        [ValidateNever]
        public BoSuuTap BoSuuTap { get; set; } // Navigation property
    }
}
