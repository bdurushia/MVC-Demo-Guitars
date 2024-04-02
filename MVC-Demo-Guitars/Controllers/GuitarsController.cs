using Microsoft.AspNetCore.Mvc;
using MVC_Demo_Guitars.Models;
using MVC_Demo_Guitars.Models.Data;

namespace MVC_Demo_Guitars.Controllers
{
    public class GuitarsController : Controller
    {
        private readonly IGuitarsRepository repo;

        public GuitarsController(IGuitarsRepository repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            var guitars = repo.GetAllGuitars();
            return View(guitars);
        }
        public IActionResult ViewGuitars(int id)
        {
            var guitar = repo.GetGuitar(id);
            return View(guitar);
        }
        public IActionResult UpdateGuitars(int id)
        {
            Guitars guitar = repo.GetGuitar(id);
            if (guitar == null) 
            {
                return View("GuitarNotFound");
            }
            return View(guitar);
        }
        public IActionResult UpdateGuitarsToDatabase(Guitars guitar)
        {
            repo.UpdateGuitars(guitar);
            return RedirectToAction("ViewGuitars", new { id =  guitar.Id });
        }
        public IActionResult InsertGuitars()
        {
            var gtr = new Guitars();
            return View(gtr);
        }
        public IActionResult InsertGuitarsToDatabase(Guitars guitarToInsert)
        {
            repo.InsertGuitars(guitarToInsert);
            return RedirectToAction("Index");
        }
    }
}
