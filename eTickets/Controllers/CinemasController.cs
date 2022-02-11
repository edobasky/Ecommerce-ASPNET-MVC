using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemaService _cinemaService;

        public CinemasController(ICinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        public async Task<IActionResult> Index()
        {
            var allCinema = await _cinemaService.GetAllAsync();
            return View(allCinema);
        }

        //Get Cinema/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] 
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")]Cinema cinema)
        {
            if (!ModelState.IsValid) return View(cinema);
            await _cinemaService.AddAsync(cinema);

            return RedirectToAction(nameof(Index)); 
        }

        public async Task<IActionResult> Details(int id)
        {
            var cinemaDetails = await _cinemaService.GetByIdAsync(id);
            if (cinemaDetails == null) return View("NotFound");
            return View(cinemaDetails);
        }

        //Get Cinema/create
        public async Task<IActionResult> Edit(int id)
        {
            var cinemaDetails = await _cinemaService.GetByIdAsync(id);
            if(cinemaDetails == null) return View("NotFound");
            return View(cinemaDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("id,Logo,Name,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid) return View(cinema);
            await _cinemaService.UpdateAsync(id,cinema);

            return RedirectToAction(nameof(Index));
        }

        //Get Cinema/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var cinemaDetails = await _cinemaService.GetByIdAsync(id);
            if (cinemaDetails == null) return View("NotFound");
            return View(cinemaDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        { 
            await _cinemaService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
