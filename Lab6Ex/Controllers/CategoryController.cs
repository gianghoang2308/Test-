using Lab6Ex.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab6Ex.Controllers
{
    public class CategoryController : Controller
    {
        private readonly BookStoreBkapContext cats = new BookStoreBkapContext();

        [HttpGet]
        public IActionResult Index()
        {
            var publisher = cats.Categories.ToList();
            return View(publisher);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(Category data)
        {
            cats.Categories.Add(data); 
            cats.SaveChanges();
            return RedirectToAction("Index");  
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var cat = cats.Categories.Find(id);
            if(cat == null)
            {
                return NotFound("Khong tim thay id can truy van: "+id);
            }
           else
            {
                return View(cat);
            }
        }

        [HttpPost]
        public IActionResult Edit(Category data)
        {
            cats.Categories.Update(data);
            cats.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category = cats.Categories.Find(id);
            if(category == null)
            {
                return NotFound("Khong tim thay id can truy van: " + id);
            }
            else
            {
                cats.Remove(category);
                cats.SaveChanges();
                return RedirectToAction("Index");
            }
        }

    }
}
