using BaiKiemTra03_02.Data;
using BaiKiemTra03_02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BaiKiemTra03_02.Controllers
{
    public class SachController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SachController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
           IEnumerable<Sach> sach = _db.Sach.Include("TacGia").ToList();
            return View(sach);
        }
        [HttpGet]
        public IActionResult Upsert(int id)
        {
            Sach sach = new Sach();
            IEnumerable<SelectListItem> dstacgia = _db.TacGia.Select(
                item => new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.Name
                }
                );
            ViewBag.DSTacGia = dstacgia;
            if (id == 0)
            {
                return View(sach);
            }
            else
            {
                sach = _db.Sach.Include("TacGia").FirstOrDefault(sp => sp.Id == id);
                return View(sach);
            }
        }
        [HttpPost]
        public IActionResult Upsert(Sach sach)
        {
            if (ModelState.IsValid)
            {
                if (sach.Id == 0)
                {
                    _db.Sach.Add(sach);
                }
                else
                {
                    _db.Sach.Update(sach);
                }
                // Lưu lại
                _db.SaveChanges();
                //Chuyen trang ve index
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
            var sach = _db.Sach.FirstOrDefault(sp => sp.Id == id);
            if (sach == null)
            {
                return Json(new { success = false, message = "Sach khong tim thay" });
            }
            _db.Sach.Remove(sach);
            _db.SaveChanges();
            return Json(new { success = true });
        }
        [HttpGet]
        public IActionResult Detail(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var sach = _db.Sach.Find(id);
            if (sach == null)
            {
                return NotFound();
            }
            return View(sach);
        }
    }
}
