using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercises.Models.Data;
using Exercises.Models.ViewModels;

namespace Exercises.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = StudentRepository.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new StudentVM();
            viewModel.Student.Courses = new List<Course>();
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            viewModel.SetStateItems(StateRepository.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(StudentVM studentVM)
        {
          
            if (!ModelState.IsValid)
            {
                var viewModel = new StudentVM();
                viewModel.Student.Courses = new List<Course>();
                viewModel.SetCourseItems(CourseRepository.GetAll());
                viewModel.SetMajorItems(MajorRepository.GetAll());
                viewModel.SetStateItems(StateRepository.GetAll());
                return View("Add", viewModel);
            }
            studentVM.Student.Courses = new List<Course>();
            

            foreach (var id in studentVM.CourseItems.Where(m=>m.Selected))
                studentVM.Student.Courses.Add(CourseRepository.Get(int.Parse(id.Value)));

            studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);

            StudentRepository.Add(studentVM.Student);

            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var student = StudentRepository.Get(id);

            var viewModel = new StudentVM();
            viewModel.Student = student;



            
            
            viewModel.SetCourseItems(CourseRepository.GetAll());
            
            viewModel.SetMajorItems(MajorRepository.GetAll());
            viewModel.SetStateItems(StateRepository.GetAll());

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(StudentVM studentVM)
        {
            if (ModelState.IsValid)
            {
                studentVM.Student.Courses = new List<Course>();
                foreach (var id in studentVM.CourseItems.Where(m => m.Selected))
                    studentVM.Student.Courses.Add(CourseRepository.Get(int.Parse(id.Value)));

                studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);
                StudentRepository.Edit(studentVM.Student);
                return RedirectToAction("List");
            }
            else
            {
                var student = StudentRepository.Get(studentVM.Student.StudentId);

                var viewModel = new StudentVM();
                viewModel.Student = student;

                viewModel.SetCourseItems(CourseRepository.GetAll());
                viewModel.SetMajorItems(MajorRepository.GetAll());
                viewModel.SetStateItems(StateRepository.GetAll());
                return View("Edit",viewModel);
            }


        }

        [HttpPost]
        public ActionResult EditAddress(StudentVM studentVM)
        {

            

            
                StudentRepository.SaveAddress(studentVM.Student.StudentId, studentVM.Student.Address);
                return RedirectToAction("List");
            
          
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            StudentRepository.Delete(id);
            return RedirectToAction("List");
        }
    }
}