using Lab6Ex.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab6Ex.Controllers
{

    public class PublisherController : Controller
    {
        private readonly BookStoreBkapContext pubs = new BookStoreBkapContext();
        [HttpGet]
        public IActionResult Index()
        {
            var publisher = pubs.Publishers.ToList();
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Publisher data)
        {
            pubs.Add(data);
            pubs.SaveChanges();
            return View(data);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var publisher = pubs.Publishers.Find(id);
            return View(publisher);
        }

        [HttpPost]
        public IActionResult Edit(Publisher data)
        {
            pubs.Update(data);
            pubs.SaveChanges();
            return View(data);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var publisher = pubs.Publishers.Find(id);
            if (publisher == null)
            {
                return NotFound("Khong tim thay id can tim: " + id);
            }
            else
            {
                pubs.Remove(id);
                pubs.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}
