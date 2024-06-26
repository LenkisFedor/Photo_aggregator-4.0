﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Photo_aggregator.DAL;
using Photo_aggregator.Service;
using Photo_aggregator.Service.Interfaces;

namespace Photo_aggregator.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IProfileService _profileService;

        private readonly photo_aggrContext context;

        public ProfileController(IProfileService profileService, photo_aggrContext context)
        {
            _profileService = profileService;
            this.context = context;
        }

        public ActionResult PhotographerProfile()
        {
            var requests = context.Requests
                .Where(req => req.PhotographerId == (context.Users.First(user => user.UserLogin == User.Identity.Name).UserId))
                .ToList();

            return View(context);
        }

        // GET: ProfileController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProfileController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfileController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProfileController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProfileController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProfileController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProfileController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
