﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment4.Models;
using Assignment4.Controllers;

namespace Assignment4.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }
    // GET : /Teacher/List
    public ActionResult List(string SearchKey = null)
        {
            TeacherDataController controller = new TeacherDataController();
            IEnumerable<Teacher> Teachers =  controller.ListTeachers(SearchKey);
            return View(Teachers);
        }
    

        //GET : /Teacher/Show
        public ActionResult Show(int id)

        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);
             return View(NewTeacher);

        }
        //GET : /Teacher/DeleteConfirm/{id}
        public ActionResult DeleteConfirm(int id)

        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);

            return View(NewTeacher);

        }

        //Creating method to delete teacher from database
        //POST : /Teacher/Delete/{id}
        public ActionResult Delete(int id)
            {
                return RedirectToAction("List");
            }

        //GET : /Teacher/AddTeacher/{id}
        public ActionResult AddTeacher(int id)

        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);

            return View(NewTeacher);

        }

        //Creating method to add a teacher Database
        //POST : /Teacher/Add/{id}
        public ActionResult Add(int id)
        {
            return RedirectToAction("List");
        }

    }

}