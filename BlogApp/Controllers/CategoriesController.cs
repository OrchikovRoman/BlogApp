﻿using AutoMapper;
using BlogApp.Models;
using BlogBL.Interfaces;
using BlogBL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BlogApp.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _service;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var categoriesBL = _service.GetAll().ToList();
            var categoriesPL = _mapper.Map<IEnumerable<CategoryViewModel>>(categoriesBL);

            return View(categoriesPL);
        }

        public ActionResult Details(int id)
        {
            var categoriesBL = _service.GetById(id);
            var categoriesPL = _mapper.Map<CategoryViewModel>(categoriesBL);

            return View(categoriesPL);
        }

        // GET: Post/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Post/Create
        [HttpPost]
        public ActionResult Create(CategoryViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var modelBL = _mapper.Map<CategoryModel>(model);
                _service.Create(modelBL);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Post/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CategoryViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var modelBL = _mapper.Map<CategoryModel>(model);
                _service.Update(modelBL);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Post/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _service.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}


