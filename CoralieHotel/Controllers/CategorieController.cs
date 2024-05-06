using CoralieHotel.Data;
using CoralieHotel.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoralieHotel.Controllers
{
    public class CategorieController : Controller
    {
        private readonly AppDbContext _db;
        public CategorieController( AppDbContext db)
        {
            _db=db;
            
        }
        public IActionResult Index()
        {
            List<Categorie> ObjCategorie= _db.Categories.ToList();

            return View(ObjCategorie);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Categorie obj)
        {

            if (_db.Categories.Any(o => o.Name == obj.Name))
            {
                ModelState.AddModelError($"Name ", $"{obj.Name} exits already in the Category ");
                return View(obj);
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
