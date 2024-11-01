using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectA.Data;
using ProjectA.Models;

namespace ProjectA.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BoSuuTapController : Controller
    {
        private readonly ApplicationDbContext _db;
        public BoSuuTapController(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
			// Lấy danh sách bộ sưu tập từ cơ sở dữ liệu
			var boSuuTapList = await _db.BoSuuTap
				.Include(b => b.SanPhams) // Bao gồm thông tin sản phẩm nếu cần
				.Include(b => b.TheLoai)  // Bao gồm thông tin thể loại nếu cần
				.ToListAsync();

			// Truyền danh sách bộ sưu tập đến view
			return View(boSuuTapList);
		}
        // GET: BoSuuTap/Create
        public async Task<IActionResult> Create(int? id)
        {
            BoSuuTap boSuuTap = null;

            if (id.HasValue) // Nếu có ID, đây là chỉnh sửa
            {
                boSuuTap = await _db.BoSuuTap
                    .Include(b => b.SanPhams)
                    .FirstOrDefaultAsync(b => b.Id == id.Value);

                if (boSuuTap == null)
                {
                    return NotFound();
                }
            }
            else
            {
                boSuuTap = new BoSuuTap(); // Khởi tạo một BoSuuTap mới
            }

            ViewBag.TheLoaiList = new SelectList(_db.TheLoai, "Id", "Name", boSuuTap.TheLoaiId);
            ViewBag.SelectedSanPhamIds = boSuuTap.SanPhams.Select(sp => sp.Id).ToArray(); // Lưu danh sách sản phẩm đã chọn
            return View(boSuuTap);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BoSuuTap boSuuTap, int[] selectedSanPhamIds)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra xem có sản phẩm nào được chọn không
                if (selectedSanPhamIds != null && selectedSanPhamIds.Length > 0)
                {
                    List<SanPham> temp = new List<SanPham>();
                    //temp = await _db.SanPham.Where(sp => selectedSanPhamIds.Contains(sp.Id)).ToListAsync();
                    temp = await _db.SanPham.ToListAsync();
                    boSuuTap.SanPhams = temp.Where(t => selectedSanPhamIds.Contains(t.Id)).ToList();

                }
                else
                {
                    // Nếu không có sản phẩm nào được chọn, có thể thêm một thông báo lỗi
                    ModelState.AddModelError("", "Vui lòng chọn ít nhất một sản phẩm.");
                }

                if (ModelState.IsValid) // Kiểm tra lại ModelState
                {
                    if (boSuuTap.Id == 0) // Nếu là tạo mới
                    {
                        _db.Add(boSuuTap);
                    }
                    else // Nếu là cập nhật
                    {
                        _db.Update(boSuuTap);
                    }
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }

            ViewBag.TheLoaiList = new SelectList(_db.TheLoai, "Id", "Name");
            return View(boSuuTap);
        }

        [HttpGet]
        public JsonResult GetNhaSanXuatByTheLoai(int theLoaiId)
        {
            var nhaSanXuats = _db.NhaSanXuat
                .Where(nsx => _db.SanPham.Any(sp => sp.TheLoaiId == theLoaiId && sp.NhaSanXuatId == nsx.Id))
                .Select(nsx => new { nsx.Id, nsx.Name })
                .ToList();
            return Json(nhaSanXuats);
        }

        [HttpGet]
        public JsonResult GetSanPhamByNhaSanXuat(int nhaSanXuatId)
        {
            var sanPhams = _db.SanPham
                .Where(sp => sp.NhaSanXuatId == nhaSanXuatId)
                .Select(sp => new { sp.Id, sp.Name })
                .ToList();
            return Json(sanPhams);
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
            var bosuutap = _db.BoSuuTap.Include(b => b.SanPhams).FirstOrDefault(sp => sp.Id == id);
            if (bosuutap == null)
            {
                return Json(new { success = false, message = "Bộ sưu tập không tìm thấy" });
            }

			// Remove associated products
			_db.SanPham.RemoveRange(bosuutap.SanPhams);
			_db.BoSuuTap.Remove(bosuutap);
            _db.SaveChanges();
            return Json(new { success = true });
        }
    }
}
