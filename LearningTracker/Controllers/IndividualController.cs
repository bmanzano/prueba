using LearningTracker.Helpers;
using LearningTracker.Models;
using LTraker.Data;
using LTraker.Data.Entities;
using LTraker.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearningTracker.Controllers
{
    public class IndividualController : BaseController
    {
        // GET: Individual
        public ActionResult Index()
        {
            var repository = new IndividualRepository(context);
            var individual = repository.GetAll();
            /*var model = individual.Select(x => new IndividualViewModel
            { Id = x.Id, Name = x.Name, Email = x.Email }
            ).ToList();*/
            var model = MapperHelper.Map<IEnumerable<IndividualViewModel>>(individual);
            return View(model);
        }

        // GET: Individual/Details/5
        public ActionResult Details(int id)
        {
            var repository = new IndividualRepository(context);
            var individual = repository.Find(id);
            var model = MapperHelper.Map<IndividualViewModel>(individual);
            return View(model);
        }

        // GET: Individual/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Individual/Create
        [HttpPost]
        public ActionResult Create(IndividualViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var repository = new IndividualRepository(context);
                    var validacionEmail = new Individual { Email = model.Email };
                    var emailExiste = repository.QueryByExample(validacionEmail).Count > 0;
                    if (!emailExiste)
                    {
                        var individual = MapperHelper.Map<Individual>(model);
                        repository.Insert(individual);
                        context.SaveChanges();
                    }
                    else
                    {
                        ModelState.AddModelError("Email", "El email esta ocupado");
                        return View(model);
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Individual/Edit/5
        public ActionResult Edit(int id)
        {
            var repository = new IndividualRepository(context);
            var individual = repository.Find(id);
            var model = MapperHelper.Map<IndividualViewModel>(individual);
            model.EmailAnterior = model.Email;
            return View(model);
        }

        // POST: Individual/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, IndividualViewModel model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var repository = new IndividualRepository(context);
                    if (model.Email == model.EmailAnterior)
                    {
                        var individual = MapperHelper.Map<Individual>(model);
                        repository.Update(individual);
                        context.SaveChanges();
                    }
                    else
                    {
                        var emailExiste = repository.Query(x => x.Email == model.Email).Count > 0;
                        if (!emailExiste)
                        {
                            var individual = MapperHelper.Map<Individual>(model);
                            repository.Update(individual);
                            context.SaveChanges();
                        }
                        else
                        {
                            ModelState.AddModelError("Email", "El email esta ocupado");
                            return View(model);
                        }
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Individual/Delete/5
        public ActionResult Delete(int id)
        {
            var repository = new IndividualRepository(context);
            var individual = repository.Find(id);
            var model = MapperHelper.Map<IndividualViewModel>(individual);
            return View(model);
        }

        // POST: Individual/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, IndividualViewModel model)
        {
            try
            {
                var repository = new IndividualRepository(context);
                var individual = MapperHelper.Map<Individual>(model);
                repository.Delete(individual);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [AllowAnonymous]
        public JsonResult CheckEmail(string Email)
        {
            var repository = new IndividualRepository(context);
            var emailExiste = repository.Query(x => x.Email == Email).Count == 0;
            return Json(emailExiste, JsonRequestBehavior.AllowGet);
        }
    }
}
