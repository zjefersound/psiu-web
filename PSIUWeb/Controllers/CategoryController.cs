using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PSIUWeb.Data.Interface;
using PSIUWeb.Models;

namespace PSIUWeb.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryRepository categoryRepository;

        public CategoryController(
            ICategoryRepository _categoryRepo
        )
        {
            categoryRepository = _categoryRepo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(
                categoryRepository.GetCategories()
            );
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id <= 0 || id == null)
                return NotFound();

            Category? p =
                categoryRepository.GetCategoryById(id.Value);

            if (p == null)
                return NotFound();

            return View(p);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    categoryRepository.Update(category);
                    return View("Index", categoryRepository.GetCategories());
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }
            return View("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            Category? p = categoryRepository.GetCategoryById(id.Value);

            if (p == null)
                return NotFound();

            return View(p);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (id == null || id == 0)
                return NotFound();

            categoryRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(Category p)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    categoryRepository.Create(p);
                    return View("Index", categoryRepository.GetCategories());
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return View();
        }

    }
}
