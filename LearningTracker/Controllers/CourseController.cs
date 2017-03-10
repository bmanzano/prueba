using LearningTracker.Helpers;
using LearningTracker.Models;
using LTraker.Data;
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
    public class CourseController : BaseController
    {
       
        // GET: Course
        public ActionResult Index()
        {
            var repository = new CourseRepository(context);
            var course = repository.Query(null, "Name");
            var model = MapperHelper.Map<IEnumerable<CourseViewModel>>(course);
            return View(model);
        }

        // GET: Course/Details/5
        public ActionResult Details(int id)
        {
            var repository = new CourseRepository(context);
            var includes = new Expression<Func<Course, object>>[] { x => x.Topics };
            var course = repository.QueryIncluding(x=> x.Id == id, includes).SingleOrDefault();
            var model = MapperHelper.Map<DetailsTopicCourseViewModel>(course);
            return View(model);
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            var model = new CourseViewModel();
            var repository = new TopicRepository(context);
            var topic = repository.Query(null, "Name");
            model.AvailableTopics = MapperHelper.Map<ICollection<TopicCourseViewModel>>(topic);
            return View(model);
        }

        // POST: Course/Create
        [HttpPost]
        public ActionResult Create(CourseViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var repository = new CourseRepository(context);
                    var validacionName = new Course { Name = model.Name };
                    var nameExiste = repository.QueryByExample(validacionName).Count > 0;
                    if (!nameExiste)
                    {
                        var course = MapperHelper.Map<Course>(model);
                        repository.InsertCourseWithTopics(course, model.SelectTopics);
                        context.SaveChanges();
                    }
                    else
                    {
                        ModelState.AddModelError("Name", "El Nombre del curso ya existe");
                        var topicrepository = new TopicRepository(context);
                        var topic = topicrepository.Query(null, "Name");
                        model.AvailableTopics = MapperHelper.Map<ICollection<TopicCourseViewModel>>(topic);
                        return View(model);
                    }
                }
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int id)
        {
            var repository = new CourseRepository(context);
            var topicrepository = new TopicRepository(context);
            var includes = new Expression<Func<Course, object>>[] { x => x.Topics };
            var course = repository.QueryIncluding(x => x.Id == id, includes).SingleOrDefault();
            var model = MapperHelper.Map<CourseViewModel>(course);

            var topic = topicrepository.Query(null, "Name");
            model.AvailableTopics = MapperHelper.Map<ICollection<TopicCourseViewModel>>(topic);
            model.SelectTopics = course.Topics.Select(x => x.Id.Value).ToArray();

            return View(model);
        }

        // POST: Course/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CourseViewModel model)
        {
            var topicRepository = new TopicRepository(context);
            try
            {
                var repository = new CourseRepository(context);
                if (ModelState.IsValid)
                {
                    var course = MapperHelper.Map<Course>(model);
                    repository.UpdateCourseWithTopics(course, model.SelectTopics);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                var topic = topicRepository.Query(null, "Name");
                model.AvailableTopics = MapperHelper.Map<ICollection<TopicCourseViewModel>>(topic);
                return View(model);
            }
            catch
            {
                var topic = topicRepository.Query(null, "Name");
                model.AvailableTopics = MapperHelper.Map<ICollection<TopicCourseViewModel>>(topic);
                return View(model);
            }
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int id)
        {
            var repository = new CourseRepository(context);
            var course = repository.Find(id);
            var model = MapperHelper.Map<CourseViewModel>(course);
            return View(model);
        }

        // POST: Course/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CourseViewModel model)
        {
            try
            {
                var repository = new CourseRepository(context);
                var course = MapperHelper.Map<Course>(model);
                repository.Delete(course);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
