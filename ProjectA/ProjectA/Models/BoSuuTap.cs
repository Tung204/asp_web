using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectA.Models
{
    public class BoSuuTap 
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên bộ sưu tập không được để trống!")]
        [StringLength(100)]
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
		public string? ImageUrl_2 { get; set; }
		public string? ImageUrl_3 { get; set; }
		public string? ImageUrl_4 { get; set; }

		[Required]
        public int TheLoaiId { get; set; }
        [ForeignKey("TheLoaiId")]
        [ValidateNever]
        public TheLoai TheLoai { get; set; }

        public ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
    }
}
