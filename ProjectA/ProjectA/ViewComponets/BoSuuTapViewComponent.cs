using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectA.Data;
using ProjectA.Models;
namespace ProjectA.ViewComponets
{
    public class BoSuuTapViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _db;
        public BoSuuTapViewComponent(ApplicationDbContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            var bst = _db.BoSuuTap.ToList();
            return View(bst);
        }
    }
}
