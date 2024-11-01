using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectA.Models
{
    public class NhaSanXuat
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên nhà sản xuất không được để trống!")]
        [StringLength(50, ErrorMessage = "{0} phải có độ dài từ {2} đến {1} ký tự.", MinimumLength = 3)]
        [Display(Name = "Tên Nhà Sản Xuất")]
        public string Name { get; set; }

        [Display(Name = "Ngày Thành Lập")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Ngày thành lập không được để trống!")]
        public DateTime DateEstablished { get; set; }
    }
}
