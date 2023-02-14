using EntityFrameworkDemoCrud.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityFrameworkDemoCrud.Controllers
{
    public class StudentController : Controller
    {
        //https://www.youtube.com/watch?v=PQF2x2iFUag&t=127s
        DB_TestEntities Dbobj = new DB_TestEntities();

        // GET: Student
        public ActionResult Student()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStudent(Tbl_Student model)
        {
            if (ModelState.IsValid)
            {
                Tbl_Student obj = new Tbl_Student()
                obj.Name = model.Name;
                obj.FName = model.FName;
                obj.Email = model.Email;
                obj.Mobile = model.Mobile;
                obj.Description = model.Description;
                Dbobj.Tbl_Student.Add(obj);
                Dbobj.SaveChanges();
            }
            ModelState.Clear();
            return View("Student");
        }
        public ActionResult StudentList()
        {
            var res = Dbobj.Tbl_Student.ToList();
            return View(res);
        }
    }
}