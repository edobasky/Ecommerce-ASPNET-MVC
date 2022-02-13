using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class MovieController : Controller
    {
        private readonly IMoviesService _moviesService;

        public MovieController(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        [AllowAnonymous]

        public async Task<IActionResult> Index()
        {
            var allMovies = await _moviesService.GetAllAsync(n => n.Cinema);
            if (allMovies == null) return NotFound();
            return View(allMovies);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allMovies = await _moviesService.GetAllAsync(n => n.Cinema);
            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allMovies.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();
                return View("Index", filteredResult);

            }
            return View("Index",allMovies);
        }


        //GET: Movies/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var movieDetails = await _moviesService.GetMovieByIdAsync(id);
            return View(movieDetails);
        }

        public async Task<IActionResult> Create()
        {
            var movieDropDownData = await _moviesService.GetNewMovieDropDownsValues();

            ViewBag.Cinemas = new SelectList(movieDropDownData.Cinemas, "id", "Name");
            ViewBag.Actors = new SelectList(movieDropDownData.Actors, "id", "FullName");
            ViewBag.Producers = new SelectList(movieDropDownData.Producers, "id", "FullName");

            return View();

        }


        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM movie)
        {
            var movieDropDownData = await _moviesService.GetNewMovieDropDownsValues();

            ViewBag.Cinemas = new SelectList(movieDropDownData.Cinemas, "id", "Name");
            ViewBag.Actors = new SelectList(movieDropDownData.Actors, "id", "FullName");
            ViewBag.Producers = new SelectList(movieDropDownData.Producers, "id", "FullName");


            if (!ModelState.IsValid)
            {
                return View(movie);
            }

             await _moviesService.AddNewMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails = await _moviesService.GetMovieByIdAsync(id);
            if (movieDetails == null) return View("NotFound ");

            var response = new NewMovieVM()
            {
                id = movieDetails.id,
                Name = movieDetails.Name,
                Description = movieDetails.Description,
                Price = movieDetails.Price,
                StartDate = movieDetails.StartDate,
                EndDate = movieDetails.EndDate,
                ImageURL = movieDetails.ImageURL,
                MovieCategory = movieDetails.MovieCategory,
                Actorids = movieDetails.Actor_Movies.Select(x => x.ActorId).ToList(),
                CinemaId = movieDetails.CinemaId,
                ProducerId = movieDetails.ProducerId

            };

            var movieDropDownData = await _moviesService.GetNewMovieDropDownsValues();

            ViewBag.Cinemas = new SelectList(movieDropDownData.Cinemas, "id", "Name");
            ViewBag.Actors = new SelectList(movieDropDownData.Actors, "id", "FullName");
            ViewBag.Producers = new SelectList(movieDropDownData.Producers, "id", "FullName");

            return View(response);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,NewMovieVM movie)
        {
            if (id != movie.id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var movieDropDownData = await _moviesService.GetNewMovieDropDownsValues();

                ViewBag.Cinemas = new SelectList(movieDropDownData.Cinemas, "id", "Name");
                ViewBag.Actors = new SelectList(movieDropDownData.Actors, "id", "FullName");
                ViewBag.Producers = new SelectList(movieDropDownData.Producers, "id", "FullName");


                return View(movie);
            }

            await _moviesService.UpdateMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }
    }
}
