using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PSIUWeb.Data.Interface;
using PSIUWeb.Models;

namespace PSIUWeb.Controllers
{
    public class PatientController : Controller
    {
        private IPatientRepository pacientRepository;

        public PatientController(
            IPatientRepository _pacientRepo
        ) 
        {
            pacientRepository = _pacientRepo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View( 
                pacientRepository.GetPatients() 
            );
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id <= 0 || id == null)
                return NotFound();

            Patient? p = 
                pacientRepository.GetPatientById(id.Value);

            if (p == null)
                return NotFound();

            return View(p);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Patient pacient)
        {
            if ( ModelState.IsValid )
            {
                try
                {
                    pacientRepository.Update(pacient);
                    return View("Index", pacientRepository.GetPatients());
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
            if(id == null)
                return NotFound();

            Patient? p = pacientRepository.GetPatientById(id.Value);
            
            if (p == null)
                return NotFound();

            return View(p);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        { 
            if(id == null || id == 0)
                return NotFound();

            pacientRepository.Delete(id);

            return RedirectToAction( nameof(Index) );
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(Patient p)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    pacientRepository.Create(p);
                    return View("Index", pacientRepository.GetPatients());
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
