using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace LibraryManagement.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ILibraryAsset _assets;

        public CatalogController(ILibraryAsset assets)
        {
            _assets = assets;
        }

        public ActionResult Index()
        {
            var assets = _assets.GetAll();
            var assetsViewModel = assets.Select(a => new AssetViewModel
            {
                Id = a.Id,
                ImageUrl = a.ImageUrl,
                Title = a.Title,
                AuthorOrDirector = _assets.GetAuthorOrDirector(a.Id),
                DeweyCallNumber = _assets.GetDeweyIndex(a.Id),
                Type = _assets.GetType(a.Id)
            });

            var model = new AssetIndexViewModel
            {
                Assets = assetsViewModel
            };

            return View(model);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

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

        public ActionResult Delete(int id)
        {
            return View();
        }

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