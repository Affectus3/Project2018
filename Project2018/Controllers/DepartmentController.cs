using Project2018.Models.EntityFramework;
using Project2018.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project2018.Controllers
{
    [Authorize(Roles = "A,U")]
    public class DepartmentController : Controller
    {
        PersonelDbEntities3 db = new PersonelDbEntities3();    
            
        // GET: Department
        public ActionResult Index()
        {
            var model = db.Department1.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult New()
        {
            return View("DepartmentForm", new Department1());
        }
        [ValidateAntiForgeryToken]
        public ActionResult Save(Department1 department)
        {
            if (!ModelState.IsValid)
            {
                return View("DepartmentForm");
            }

            MessageViewModel model = new MessageViewModel();

            if (department.Id == 0)
            {
                db.Department1.Add(department);
                model.Message = department.Name + " added. Press to return ";
            }
            else
            {
                var deparmentToUpdate = db.Department1.Find(department.Id);
                if (deparmentToUpdate == null)
                    return HttpNotFound();
                deparmentToUpdate.Name = department.Name;
                model.Message = department.Name + " updated. Press to return ";
            }
            db.SaveChanges();
            model.Status = true;
            model.LinkText = "Department List";
            model.Url = "/Department";
            return View("_Message",model);
        }
        public ActionResult Update(int id)
        {
            var model = db.Department1.Find(id);
            if (model == null)
                return HttpNotFound();
            return View("DepartmentForm", model);
        }
        public ActionResult Delete(int id)
        {
            var departmentToDelete = db.Department1.Find(id);
            if (departmentToDelete == null)
                return HttpNotFound();
            db.Department1.Remove(departmentToDelete);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}