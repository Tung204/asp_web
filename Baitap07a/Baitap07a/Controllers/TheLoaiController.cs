using Baitap07a.Data;
using BaiTap07a.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiTap07a.Controllers
{
    public class TheLoaiController : Controller
    {
        private readonly ApplicationDbContext _db;
        public TheLoaiController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var theloai = _db.TheLoai.ToList();
            ViewBag.TheLoai = theloai;
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TheLoai theloai)
        {
            // Thêm thông tin vào bảng TheLoai
            if (ModelState.IsValid)
            {
                _db.TheLoai.Add(theloai);
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
            var theloai = _db.TheLoai.Find(id);
            return View(theloai);
        }
        [HttpPost]
        public IActionResult Edit(TheLoai theloai)
        {
            // Thêm thông tin vào bảng TheLoai
            if (ModelState.IsValid)
            {
                _db.TheLoai.Update(theloai);
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
            var theloai = _db.TheLoai.Find(id);
            return View(theloai);
        }
        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var theloai = _db.TheLoai.Find(id);
            // Thêm thông tin vào bảng TheLoai
            if (theloai == null)
            {
                return NotFound();
            }
            _db.TheLoai.Remove(theloai);
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
            var theloai = _db.TheLoai.Find(id);
            if (theloai == null)
            {
                return NotFound();
            }
            return View(theloai);
        }
		[HttpGet]
		public IActionResult Search(string searchString)
		{
            if (!string.IsNullOrEmpty(searchString))
            {
                var theloai = _db.TheLoai
                    .Where(tl => tl.Name.Contains(searchString))
                    .ToList();

				ViewBag.SearchString = searchString;
				ViewBag.TheLoai = theloai;
            }
            else { 
                var theloai = _db.TheLoai.ToList();
                ViewBag.TheLoai = theloai;
            }
            return View("Index");
		}
	}
}