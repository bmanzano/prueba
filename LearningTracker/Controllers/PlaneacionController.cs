using LearningTracker.Helpers;
using LearningTracker.Models;
using LTraker.Data.Entities;
using LTraker.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace LearningTracker.Controllers
{
    public class PlaneacionController : BaseController
    {
        // GET: Planeacion/Create
        public ActionResult Edit(int id)
        {
            int idPlaneacion = 0;
            //Se busca si existe algun Id
            var repository = new PlaneacionRepository(context);
            var course = repository.Query(x => x.AssignedCourseId == id).SingleOrDefault();
            var model = MapperHelper.Map<PlaneacionViewModels>(course);
            if (model != null)
                idPlaneacion = model.Id == null ? 0 : model.Id.Value;
            model.IdPlaneacion = idPlaneacion;
            return View(model);
        }

        // POST: Planeacion/Create
        [HttpPost]
        public ActionResult Edit(int id, PlaneacionViewModels model)
        {
            var repository = new PlaneacionRepository(context);
            try
            {
                if (ModelState.IsValid)
                {
                    model.Id = model.IdPlaneacion;
                    var planeacionUpd = MapperHelper.Map<Planeacion>(model);
                    repository.Update(planeacionUpd);
                    context.SaveChanges();
                    return RedirectToAction("Index", "Assignment");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(model);
            }
        }

    }
}
