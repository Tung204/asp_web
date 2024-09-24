using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectA.Data;
using ProjectA.Models;

namespace ProjectA.Controllers
{
	[Area("Admin")]
	public class SanPhamController : Controller
	{
		private readonly ApplicationDbContext _db;
		public SanPhamController(ApplicationDbContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
			IEnumerable<SanPham> sanpham =_db.SanPham.Include("TheLoai").ToList();
			return View();
		}
		[HttpGet]
		public IActionResult Upsert(int id)
		{
			//SanPham sanpham = new SanPham();
			//IEnumerable<SelectListItem> dstheloai = _db.TheLoai.Select(
				
				
			//	);
			return View();
		}
	}
}
