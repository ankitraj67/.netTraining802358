﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using V3_Movie_MVC_RepoPattern_Ef_CodeFirst_Identity.Data;
using V3_Movie_MVC_RepoPattern_Ef_CodeFirst_Identity.Models;
using V3_Movie_MVC_RepoPattern_Ef_CodeFirst_Identity.ViewModels;

namespace V3_Movie_MVC_RepoPattern_Ef_CodeFirst_Identity.Controllers
{
    public class MoviesController : Controller
        
    {
        IRepository repository = null;
        public MoviesController(IRepository repository)
        {
            this.repository = repository;
        }
        // GET: Movies
        public ActionResult Index()
        {
            return View(repository.GetMovies());
        }

        // GET: Movies/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            var viewModel = new MovieViewModel
            {
                Actors = repository.GetActors().Select(a =>
                 new SelectListItem(a.Name, a.Id.ToString())).ToList()
            };
            return View(viewModel);
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovieViewModel viewModel )
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool result = repository.AddMovie(viewModel);
                    if (result)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }

                viewModel = new MovieViewModel
                {
                    Actors = repository.GetActors().Select(a =>
                     new SelectListItem(a.Name, a.Id.ToString())).ToList()
                };
                return View();
            }
            catch
            {
                viewModel = new MovieViewModel
                {
                    Actors = repository.GetActors().Select(a =>
                     new SelectListItem(a.Name, a.Id.ToString())).ToList()
                };
                return View();
            }
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Movies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Movies/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}