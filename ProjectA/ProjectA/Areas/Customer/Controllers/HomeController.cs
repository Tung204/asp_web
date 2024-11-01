using Microsoft.AspNetCore.Mvc;
using ProjectA.Models;
using System.Diagnostics;
using ProjectA.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
namespace ProjectA.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<SanPham> sanpham = _db.SanPham.Include("TheLoai").ToList();
            return View(sanpham);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult Details(int sanphamId)
        {
            GioHang gioHang = new GioHang()
            {
                SanPhamId = sanphamId,
                SanPham = _db.SanPham.Include(sp => sp.TheLoai).FirstOrDefault(sp => sp.Id == sanphamId),
                Quantity = 1 // Set default quantity to 1
            };
            return View(gioHang);
        }   

        [HttpGet]
        public IActionResult FilterByTheLoai(int id)
        {
            IEnumerable<SanPham> sanpham = _db.SanPham.Include("TheLoai")
                .Where(sp => sp.TheLoai.Id == id)
                .ToList();

            // Pass the flag to indicate that filtering is applied
            ViewBag.IsFilterApplied = true;
            ViewBag.IsFilterByBoSuuTap = false;
            return View("Index", sanpham);
        }
        [HttpGet]
        public IActionResult FilterByBoSuuTap(int id)
        {
            IEnumerable<SanPham> sanpham = _db.SanPham
                .Include(sp => sp.TheLoai)
                .Where(sp => sp.BoSuuTapId == id)
                .ToList();
            // Lấy bộ sưu tập để hiển thị hình ảnh
            var boSuuTap = _db.BoSuuTap.FirstOrDefault(bst => bst.Id == id);

            // Nếu không tìm thấy bộ sưu tập
            if (boSuuTap == null)
            {
                return NotFound();
            }

            // Truyền dữ liệu đến View
            ViewBag.BoSuuTap = boSuuTap; // Chứa thông tin bộ sưu tập

            ViewBag.IsFilterApplied = true;
            ViewBag.IsFilterByBoSuuTap = true;
            return View("Index", sanpham);
        }
        [HttpPost]
        [Authorize]
        public IActionResult Details(GioHang giohang)
        {
            // Lấy thông tin tài khoản người dùng đang đăng nhập
            var identity = (ClaimsIdentity)User.Identity;
            var claim = identity.FindFirst(ClaimTypes.NameIdentifier);

            // Gán thông tin người dùng vào giỏ hàng
            giohang.ApplicationUserId = claim.Value;

            //Kiểm tra sản phẩm đã có trong cơ sở dữ liệuhay chưa?
            var giohangdb = _db.GioHang.FirstOrDefault(gh => gh.SanPhamId == giohang.SanPhamId
            && gh.ApplicationUserId == giohang.ApplicationUserId);

            if (giohangdb == null)
            {
                _db.GioHang.Add(giohang); // them san pham vao gio hang
            }
            else
            {
                giohangdb.Quantity += giohang.Quantity;
            }
            // Thêm sản phẩm vào giỏ hàng và lưu thay đổi vào cơ sở dữ liệu
            
            _db.SaveChanges();

            // Chuyển hướng về trang "Index" sau khi thêm sản phẩm vào giỏ hàng thành công
            return RedirectToAction("Index");
        }
		[HttpGet]
		public IActionResult Search(string searchString)
		{
			if (!string.IsNullOrEmpty(searchString))
			{
				IEnumerable<SanPham> sanpham = _db.SanPham.Include("TheLoai")
					.Where(tl => tl.Name.Contains(searchString))
					.ToList();

				ViewBag.SearchString = searchString;
				ViewBag.SanPham = sanpham;
				ViewBag.IsFilterSearch = true;
				// Kiểm tra nếu không có sản phẩm nào được tìm thấy
				if (!sanpham.Any())
				{
					ViewBag.Message = "Không tìm thấy sản phẩm nào.";
				}
				return View("Index");
			}
			else
			{
				IEnumerable<SanPham> sanpham = _db.SanPham.Include("TheLoai").ToList();
				return View("Index", sanpham);
			}
		}
	}
}
