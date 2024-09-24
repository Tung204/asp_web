using BaiKiemTra02.Data;
using Microsoft.AspNetCore.Mvc;
using BaiKiemTra02.Models;
using BaiKiemTra02.Data;
namespace BaiKiemTra02.Controllers
{
	public class LopHocController : Controller
	{
		private readonly ApplicationDbContext _db;
		public LopHocController(ApplicationDbContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
			var lophoc = _db.LopHoc.ToList();
			ViewBag.LopHoc = lophoc;	
			return View();
		}
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}
        [HttpPost]
        public IActionResult Create(LopHoc theloai)
        {
            // Thêm thông tin vào bảng TheLoai
            if (ModelState.IsValid)
            {
                _db.LopHoc.Add(theloai);
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
            var theloai = _db.LopHoc.Find(id);
            return View(theloai);
        }
        [HttpPost]
        public IActionResult Edit(LopHoc theloai)
        {
            // Thêm thông tin vào bảng TheLoai
            if (ModelState.IsValid)
            {
                _db.LopHoc.Update(theloai);
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
            var theloai = _db.LopHoc.Find(id);
            return View(theloai);
        }
        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var theloai = _db.LopHoc.Find(id);
            // Thêm thông tin vào bảng TheLoai
            if (theloai == null)
            {
                return NotFound();
            }
            _db.LopHoc.Remove(theloai);
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
            var theloai = _db.LopHoc.Find(id);
            if (theloai == null)
            {
                return NotFound();
            }
            return View(theloai);
        }
    }
}
