using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectA.Data;
using ProjectA.Models;
using System.Security.Claims;

namespace ProjectA.Areas.Customer.Controllers
{
    [Area("Customer")]
	public class GioHangController : Controller
    {
        private readonly ApplicationDbContext _db;
        public GioHangController(ApplicationDbContext db)
        {
            _db = db;
        }
        [Authorize]
        public IActionResult Index()
        {

            // Lấy thông tin tài khoản người dùng đang đăng nhập
            var identity = (ClaimsIdentity)User.Identity;
            var claim = identity.FindFirst(ClaimTypes.NameIdentifier);

            // Lay danh sach cac san pham trong gio hang User
            //IEnumerable<GioHang> dsGioHang = _db.GioHang.Include("SanPham").
            //                                Where(gh => gh.ApplicationUserId == claim.Value).ToList();
            //return View(dsGioHang);
            GioHangViewModel giohang = new GioHangViewModel
            {
                DsGioHang = _db.GioHang.Include("SanPham").
                                            Where(gh => gh.ApplicationUserId == claim.Value).ToList(),
                HoaDon = new HoaDon()
            };
            foreach (var item in giohang.DsGioHang)
            {
                double prodcutprice = (double)(item.Quantity * decimal.Parse(item.SanPham.price));
                giohang.HoaDon.Total += prodcutprice;
            }    
            return View(giohang);
		}
        [Authorize]
        [HttpGet]
		public IActionResult Xoa(int giohangId)
		{
            var giohang = _db.GioHang.FirstOrDefault(gh => gh.Id == giohangId);

            _db.GioHang.Remove(giohang);
            _db.SaveChanges();
			return RedirectToAction("Index");
		}
        [Authorize]
        [HttpGet]
        public IActionResult Tang(int giohangId)
        {
            var giohang = _db.GioHang.FirstOrDefault(gh => gh.Id == giohangId);

            giohang.Quantity = giohang.Quantity + 1;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        [HttpGet]
        public IActionResult Giam(int giohangId)
        {
            var giohang = _db.GioHang.FirstOrDefault(gh => gh.Id == giohangId);

            giohang.Quantity = giohang.Quantity - 1;
            if (giohang.Quantity == 0)
            {
                _db.GioHang.Remove(giohang);
            }    

            _db.SaveChanges();
            return RedirectToAction("Index");
        }
		[Authorize]
		public IActionResult ThanhToan()
		{
            // Lấy thông tin tài khoản người dùng đang đăng nhập
            var identity = (ClaimsIdentity)User.Identity;
            var claim = identity.FindFirst(ClaimTypes.NameIdentifier);

            // Lay danh sach cac san pham trong gio hang User
            //IEnumerable<GioHang> dsGioHang = _db.GioHang.Include("SanPham").
            //                                Where(gh => gh.ApplicationUserId == claim.Value).ToList();
            //return View(dsGioHang);
            GioHangViewModel giohang = new GioHangViewModel
            {
                DsGioHang = _db.GioHang.Include("SanPham").
                                            Where(gh => gh.ApplicationUserId == claim.Value).ToList(),
                HoaDon = new HoaDon()
            };
            foreach (var item in giohang.DsGioHang)
            {
                double prodcutprice = (double)(item.Quantity * decimal.Parse(item.SanPham.price));
                giohang.HoaDon.Total += prodcutprice;
            }
            return View(giohang);
        }
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult ThanhToan(GioHangViewModel giohang)
        {
            // Lay thong tin tai khoan
            var identity = (ClaimsIdentity)User.Identity;
            var claim = identity.FindFirst(ClaimTypes.NameIdentifier);


            giohang.DsGioHang = _db.GioHang.Include("SanPham").Where(gh => gh.ApplicationUserId == claim.Value).ToList();

            giohang.HoaDon.ApplicationUserId = claim.Value;
            giohang.HoaDon.OrderDate = DateTime.Now;
            giohang.HoaDon.OrderStatus = "Đang xác nhận";


            //foreach (var item in giohang.DsGioHang)
            //{
            //    // Tính tien san pham theo so luong
            //    double prodcutprice = (double)(item.Quantity * decimal.Parse(item.SanPham.price));
            //    giohang.HoaDon.Total += prodcutprice;
            //}
            _db.HoaDon.Add(giohang.HoaDon);
            _db.SaveChanges();

            // Them thong tin chi tiet hoa don
            foreach (var item in giohang.DsGioHang)
            {
                ChiTietHoaDon chitiethoadon = new ChiTietHoaDon()
                {
                    SanPhamId = item.SanPhamId,
                    HoaDonId = giohang.HoaDon.Id,
                    ProductPrice = (double)(item.Quantity * decimal.Parse(item.SanPham.price)),
                    Quantity = item.Quantity
                };
                _db.ChiTietHoaDon.Add(chitiethoadon);
                _db.SaveChanges();

            }

            // Xoa thong tin trong gio hang
            _db.GioHang.RemoveRange(giohang.DsGioHang);
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
