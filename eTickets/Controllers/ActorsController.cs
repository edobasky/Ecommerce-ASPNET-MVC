using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorService _actorService;

        public ActorsController(AppDbContext context, IActorService actorService)
        {
            _actorService = actorService;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _actorService.GetAllAsync();
            return View(data);
        }

        // Get: Actors/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")]Actor actor)
        {
            if(!ModelState.IsValid)
            {
                return View(actor);
            }

           await _actorService.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult>Details(int id)
        {
            var actorDetails = await _actorService.GetByIdAsync(id);

            if (actorDetails == null)
            {
                return View("Empty");
            }

            return View(actorDetails);
        }

        // Get: Actors/Create
        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _actorService.GetByIdAsync(id);

            if (actorDetails == null)
            {
                return View("NotFound");
            }

            return View(actorDetails);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("id,FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            await _actorService.UpdateAsync(id,actor);
            return RedirectToAction(nameof(Index));
        }

    }
}
