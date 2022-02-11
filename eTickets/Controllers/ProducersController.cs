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
    public class ProducersController : Controller
    {
        private readonly IProducerService _producerService;

        public ProducersController(IProducerService producerService)
        {
            _producerService = producerService;
        }

        public async Task<IActionResult> Index()
        {
            var allProducers = await _producerService.GetAllAsync();
            return View(allProducers);
        }

        public async Task<IActionResult> Details(int id)
        {
            var ProducersDetails = await _producerService.GetByIdAsync(id);
            if (ProducersDetails == null) return View("NotFound");

            return View(ProducersDetails);
        }

        //GET producers /CREATE
        public IActionResult Create()
        {
            return View();
        }


        // POST producer/ create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL,FullName,Bio")] Producer producer)
        {
            if (!ModelState.IsValid) return View(producer);

            await _producerService.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }

        //GET producers/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var producerDetail = await _producerService.GetByIdAsync(id);
            if (producerDetail == null) return View("NotFound");

            return View(producerDetail);
        }


        // POST producer/ create
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("id,ProfilePictureURL,FullName,Bio")] Producer producer)
        {
            if (!ModelState.IsValid) return View(producer);
            if (id == producer.id)
            {
                await _producerService.UpdateAsync(id, producer);
                return RedirectToAction(nameof(Index));
            }

            return View(producer);
        }


        //GET producers/Edit/1
        public async Task<IActionResult> Delete(int id)
        {
            var producerDetail = await _producerService.GetByIdAsync(id);
            if (producerDetail == null) return View("NotFound");

            return View(producerDetail);
        }


        // POST producer/ create
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producerDetail = await _producerService.GetByIdAsync(id);
            if (producerDetail == null) return View("NotFound");

            await _producerService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
