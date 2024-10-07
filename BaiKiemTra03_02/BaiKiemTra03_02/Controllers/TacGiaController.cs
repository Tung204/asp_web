using BaiKiemTra03_02.Data;
using BaiKiemTra03_02.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiKiemTra03_02.Controllers
{
    public class TacGiaController : Controller
    {
        private readonly ApplicationDbContext _db;
        public TacGiaController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var tacGia = _db.TacGia.ToList();
            ViewBag.TacGia = tacGia;
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TacGia tacgia)
        {
            // Thêm thông tin vào bảng TheLoai
            if (ModelState.IsValid)
            {
                _db.TacGia.Add(tacgia);
                // Lưu lại
                _db.SaveChanges();
                //Chuyen trang ve index
                return RedirectToAction("Index");
            }
            return View();

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var tacgia = _db.TacGia.Find(id);
            return View(tacgia);
        }
        [HttpPost]
        public IActionResult Edit(TacGia theloai)
        {
            // Thêm thông tin vào bảng TheLoai
            if (ModelState.IsValid)
            {
                _db.TacGia.Update(theloai);
                // Lưu lại
                _db.SaveChanges();
                //Chuyen trang ve index
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var tacgia = _db.TacGia.Find(id);
            return View(tacgia);
        }
        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var theloai = _db.TacGia.Find(id);
            // Thêm thông tin vào bảng TheLoai
            if (theloai == null)
            {
                return NotFound();
            }
            _db.TacGia.Remove(theloai);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Detail(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var tacgia = _db.TacGia.Find(id);
            if (tacgia == null)
            {
                return NotFound();
            }
            return View(tacgia);
        }
    }
}
