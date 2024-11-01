using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectA.Data;
using ProjectA.Models;

namespace ProjectA.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class NhaSanXuatController : Controller
    {
        private readonly ApplicationDbContext _db;
        public NhaSanXuatController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var nsx = _db.NhaSanXuat.ToList();
            ViewBag.nsx = nsx;
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(NhaSanXuat nhaSanXuat)
        {
            // Thêm thông tin vào bảng TheLoai
            if (ModelState.IsValid)
            {
                _db.NhaSanXuat.Add(nhaSanXuat);
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
            var nsx = _db.NhaSanXuat.Find(id);
            return View(nsx);
        }
        [HttpPost]
        public IActionResult Edit(NhaSanXuat nhaSanXuat)
        {
            // Thêm thông tin vào bảng TheLoai
            if (ModelState.IsValid)
            {
                _db.NhaSanXuat.Update(nhaSanXuat);
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
            var nsx = _db.NhaSanXuat.Find(id);
            return View(nsx);
        }
        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var nsx = _db.NhaSanXuat.Find(id);
            // Thêm thông tin vào bảng TheLoai
            if (nsx == null)
            {
                return NotFound();
            }
            _db.NhaSanXuat.Remove(nsx);
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
            var nsx = _db.NhaSanXuat.Find(id);
            if (nsx == null)
            {
                return NotFound();
            }
            return View(nsx);
        }
        [HttpGet]
        public IActionResult Search(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                var nsx = _db.NhaSanXuat
                    .Where(tl => tl.Name.Contains(searchString))
                    .ToList();

                ViewBag.SearchString = searchString;
                ViewBag.nsx = nsx;
            }
            else
            {
                var nsx = _db.NhaSanXuat.ToList();
                ViewBag.nsx = nsx;
            }
            return View("Index");
        }
    }
}