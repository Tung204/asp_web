using Microsoft.AspNetCore.Mvc;
using ProjectA.Models;
using System.Diagnostics;
using ProjectA.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public IActionResult Details(int id)
        {
            SanPham sanpham = new SanPham();
            sanpham = _db.SanPham.Include(sp => sp.TheLoai).FirstOrDefault(sp => sp.Id == id);
            return View(sanpham);
        }
    }
}
