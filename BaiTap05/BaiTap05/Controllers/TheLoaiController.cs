using BaiTap05.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiTap05.Controllers
{
    public class TheLoaiController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.ngay = "Ngày 1";
            ViewBag.thang = "Tháng 2";
            ViewData["Nam"] = "Năm 2030";
            return View();
        }
        public IActionResult Index2()
        {
            var theloai = new TheLoaiViewModel
            {
                Id = 1,
                Name = "Trinh Tham"
            };
            return View(theloai);
        }
    }
}