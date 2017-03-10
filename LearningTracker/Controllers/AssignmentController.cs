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
    public class AssignmentController : BaseController
    {
        // GET: Assignment
        public ActionResult Index()
        {
            var repository = new AssignedCourseRepository(context);
            //Expression<>[]
            //Expression<Func<Type,object>>[]{ x=>x.Propiedad }
            var includes = new Expression<Func<AssignedCourse, object>>[] { x => x.Course, x => x.Individual };
            var courses = repository.QueryIncluding(null, includes, "AssignmentDate");
            var models = MapperHelper.Map<ICollection<AssignedCourseViewModels>>(courses);
            return View(models);
        }

        // GET: Assignment/Create
        public ActionResult Create()
        {
            var model = new NewAssignedCourseViewModels();
            model.CoursesList = PopulateCourses(model.CourseId);
            model.IndividualList = PopulateInviduals(model.IndividualId);
            model.AssignmentDate = DateTime.Now;
            return View(model);
        }

        // POST: Assignment/Create
        [HttpPost]
        public ActionResult Create(NewAssignedCourseViewModels model)
        {
            var repository = new AssignedCourseRepository(context);
            try
            {
                if (ModelState.IsValid)
                {
                    var assignedCourse = MapperHelper.Map<AssignedCourse>(model);
                    assignedCourse.IsCompleted = false;
                    repository.InsertAssignedPlaneacionRepository(assignedCourse);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                model.CoursesList = PopulateCourses(model.CourseId);
                model.IndividualList = PopulateInviduals(model.IndividualId);
                return View(model);
            }
            catch (Exception ex)
            {
                model.CoursesList = PopulateCourses(model.CourseId);
                model.IndividualList = PopulateInviduals(model.IndividualId);
                return View(model);
            }
        }

        // GET: Assignment/Edit/5
        public ActionResult Edit(int id)
        {
            var model = m_CargaModeloEdit(id);
            return View(model);
        }

        // POST: Assignment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EditAssignedCourseViewModels model)
        {
            var repository = new AssignedCourseRepository(context);
            try
            {
                if (ModelState.IsValid)
                {
                    var assigenmetUpd = MapperHelper.Map<AssignedCourse>(model);
                    repository.Update(assigenmetUpd);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else {
                    var model2 = m_CargaModeloEdit(id);
                    return View(model2);
                }
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                var model2 = m_CargaModeloEdit(id);
                return View(model2);
            }
        }

        private object m_CargaModeloEdit(int id)
        {
            var repository = new AssignedCourseRepository(context);
            //Expression<>[]
            //Expression<Func<Type,object>>[]{ x=>x.Propiedad }
            var includes = new Expression<Func<AssignedCourse, object>>[] { x => x.Course, x => x.Individual };
            var criteria = new AssignedCourse { Id = id };
            var courses = repository.QueryByExampleIncludig(criteria, includes).SingleOrDefault();
            var model = MapperHelper.Map<EditAssignedCourseViewModels>(courses);
            return model;
        }


        public SelectList PopulateInviduals(object selectedItem = null)
        {
            var repository = new IndividualRepository(context);
            var individuals = repository.Query(null, "Name").ToList();
            individuals.Insert(0, new Individual { Id = null, Name = "Seleccione" });
            return new SelectList(individuals, "Id", "Name", selectedItem);
        }

        public SelectList PopulateCourses(object selectedItem = null)
        {
            var repository = new CourseRepository(context);
            var courses = repository.Query(null, "Name").ToList();
            courses.Insert(0, new Course { Id = null, Name = "Seleccione" });
            return new SelectList(courses, "Id", "Name", selectedItem);
        }
    }
}
