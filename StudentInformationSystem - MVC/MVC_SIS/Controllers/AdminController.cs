using Exercises.Models.Data;
using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Web;
using System.Web.Mvc;

namespace Exercises.Controllers
{
    public class AdminController : Controller
    {

        [HttpGet]
        public ActionResult Majors()
        {
            var model = MajorRepository.GetAll();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddMajor()
        {
            return View(new Major());
        }

        [HttpPost]
        public ActionResult AddMajor(Major major)
        {
            if (string.IsNullOrWhiteSpace(major.MajorName))
            {
                ModelState.AddModelError("MajorName", "Enter a valid major name.");
            }
            if (ModelState.IsValid)
            {
                MajorRepository.Add(major.MajorName);
                return RedirectToAction("Majors");
            }
            return View("AddMajor");
        }

        [HttpGet]
        public ActionResult EditMajor(int id)
        {
            var major = MajorRepository.Get(id);
            return View(major);
        }

        [HttpPost]
        public ActionResult EditMajor(Major major)
        {
            if (string.IsNullOrWhiteSpace(major.MajorName))
            {
                ModelState.AddModelError("MajorName", "Enter a valid major name.");
            }
            if (ModelState.IsValid)
            {
                MajorRepository.Edit(major);
                return RedirectToAction("Majors");
            }
            var NewMajor = MajorRepository.Get(major.MajorId);
            return View(NewMajor);
        }

        [HttpGet]
        public ActionResult DeleteMajor(int id)
        {
            var major = MajorRepository.Get(id);
            return View(major);
        }

        [HttpPost]
        public ActionResult DeleteMajor(Major major)
        {
            MajorRepository.Delete(major.MajorId);
            return RedirectToAction("Majors");
        }

        [HttpGet]
        public ActionResult States()
        {
            var model = StateRepository.GetAll();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddState()
        {
            return View(new State());
        }

        [HttpPost]
        public ActionResult AddState(State state)
        {
            if (string.IsNullOrEmpty(state.StateName))
            {
                ModelState.AddModelError("StateName", "Enter a valid state name.");
            }
            if (string.IsNullOrEmpty(state.StateAbbreviation))
            {
                ModelState.AddModelError("StateAbbreviation", "Enter a valid state abbreviation.");
            }
            if (ModelState.IsValid)
            {
                StateRepository.Add(state);
                return RedirectToAction("States");
            }
            else
            {
                return View("AddState", state);
            }
        }

        [HttpGet]
        public ActionResult EditState(string stateAbbreviation)
        {
            var state = StateRepository.Get(stateAbbreviation);
            
            
            return View(state);
        }

        [HttpPost]
        public ActionResult EditState(State state)
        {
            if (string.IsNullOrEmpty(state.StateName))
            {
                ModelState.AddModelError("StateName", "Enter a valid state name.");
            }
            if (!ModelState.IsValid)
            {
                return View("EditState", state);
            }
            StateRepository.Edit(state);
            return RedirectToAction("States");
        }

        [HttpGet]
        public ActionResult DeleteState(string stateAbbreviation)
        {
            var state = StateRepository.Get(stateAbbreviation);
            return View(state);
        }

        [HttpPost]
        public ActionResult DeleteState(State state)
        {
            StateRepository.Delete(state.StateAbbreviation);
            return RedirectToAction("States");
        }

        [HttpGet]
        public ActionResult Courses()
        {
            var model = CourseRepository.GetAll();
            return View(model.ToList());
        }
        [HttpGet]
        public ActionResult AddCourse()
        {
            return View(new Course());
        }

        [HttpPost]
        public ActionResult AddCourse(string courseName)
        {
            if (string.IsNullOrWhiteSpace(courseName))
            {
                ModelState.AddModelError("courseName", "Enter valid course name.");
            }
            if (ModelState.IsValid)
            {
                CourseRepository.Add(courseName);
                return RedirectToAction("Courses");
            }
            else
            {
                return View("AddCourse", courseName);
            }
        }

        [HttpGet]
        public ActionResult EditCourse(int id)
        {
            var course = CourseRepository.Get(id);
            return View(course);
        }

        [HttpPost]
        public ActionResult EditCourse(Course course)
        {
            if (string.IsNullOrWhiteSpace(course.CourseName))
            {
                ModelState.AddModelError("courseName","Enter valid course name.");
            }
            if (ModelState.IsValid)
            {
                CourseRepository.Edit(course);
                return RedirectToAction("Courses");
            }
            else
            {
                return View("EditCourse", course);
            }
        }

        [HttpGet]
        public ActionResult DeleteCourse(int id)
        {
            var course = CourseRepository.Get(id);
            return View(course);
        }

        [HttpPost]
        public ActionResult DeleteCourse(Course course)
        {
            CourseRepository.Delete(course.CourseId);
            return RedirectToAction("Courses");
        }
    }
}