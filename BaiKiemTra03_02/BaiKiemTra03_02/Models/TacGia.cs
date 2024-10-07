using System.ComponentModel.DataAnnotations;

namespace BaiKiemTra03_02.Models
{
    public class TacGia
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        public string Name { get; set; }
        public string QuocTich { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name = "Năm Sinh")]
        public DateTime NamSinh { get; set; }
    }
}
