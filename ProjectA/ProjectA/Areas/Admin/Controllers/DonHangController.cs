using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectA.Data;
using ProjectA.Models;

namespace ProjectA.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class DonHangController : Controller
	{
		private readonly ApplicationDbContext _db;
		public DonHangController(ApplicationDbContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
			IEnumerable<HoaDon> hoadon = _db.HoaDon.Include("ApplicationUser").ToList();	
			return View(hoadon);
		}
        public IActionResult Details(int id)
        {
            // Lấy thông tin hóa đơn theo id
            var hoadon = _db.HoaDon.Include(h => h.ApplicationUser)
                                   .FirstOrDefault(h => h.Id == id);

            if (hoadon == null)
            {
                return NotFound();
            }

            // Lấy danh sách chi tiết hóa đơn liên quan
            var chiTietHoaDon = _db.ChiTietHoaDon
                                   .Include(c => c.SanPham) // Bao gồm cả sản phẩm để lấy thông tin hình ảnh
                                   .Where(c => c.HoaDonId == id)
                                   .ToList();

            // Tạo ViewModel để truyền cả hóa đơn và chi tiết hóa đơn vào view
            var viewModel = new HoaDonViewModel
            {
                HoaDon = hoadon,
                ChiTietHoaDon = chiTietHoaDon
            };

            return View(viewModel);
        }
    }
}
