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
		[Required]
		public int TheLoaiId { get; set; }
		[ForeignKey("TheLoaiId")]
		public TheLoai TheLoai { get; set; }
	}
}
