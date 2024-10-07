using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaiKiemTra03_02.Models
{
    public class Sach
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Không được để trống")]
        public string Name { get; set; }
        public string TieuDe {  get; set; }
        public DateTime NamXB { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn tác giả")]
        public int TacGiaID {get;set;}
        [ForeignKey(nameof(TacGiaID))]
        [ValidateNever]
        public TacGia TacGia { get; set; }

    }
}
