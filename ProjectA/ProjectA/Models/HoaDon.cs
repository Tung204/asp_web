using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectA.Models
{
	public class HoaDon
	{
		[Key]
		public int Id { get; set; }
		public string ApplicationUserId { get; set; }
		[ForeignKey("ApplicationUserId")]
		[ValidateNever]
		public ApplicationUser ApplicationUser { get; set; }
        public double Total { get; set; }

		public DateTime OrderDate { get; set; }

		public string? OrderStatus { get; set; }

		public string PhoneNumber { get; set; }

		public string Name { get; set; }
		public int? discountcode { get; set; }
        public string Province { get; set; } // Tỉnh/thành
        public string District { get; set; } // Quận/huyện
        public string Ward { get; set; } // Phường/xã
        public string DetailedAddress { get; set; } // Địa chỉ chi tiết (số nhà, đường, ...)

    }

}