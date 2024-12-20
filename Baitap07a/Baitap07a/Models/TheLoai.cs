﻿using System.ComponentModel.DataAnnotations;
using Baitap07a.Data;
using BaiTap07a.Models;

namespace BaiTap07a.Models
{
    public class TheLoai
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage="Khong duoc de trong ten theloai!")]
        [StringLength(20, ErrorMessage = "{0} phải có độ dài phải từ {2} đến {1} ký tự.", MinimumLength = 8)]
        [Display(Name="The Loai")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Khong dung dinh dang ngay!")]
        [Display(Name = "Ngay tao")]
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}