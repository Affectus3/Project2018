using Project2018.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Project2018.ViewModels;

namespace Project2018.Controllers
{
    [Authorize(Roles = "A,U")]
    public class PersonalController : Controller
    {
        PersonelDbEntities3 db = new PersonelDbEntities3();
        // GET: Personal        
        public ActionResult Index()
        {
            var model = db.Personal.Include(x => x.Department1).ToList();
            return View(model);
        }        
        public ActionResult New()
        {
            var model = new PersonalFormViewModel()
            {
                Departments = db.Department1.ToList(),
                Personal = new Personal()
            };
            return View("PersonalForm", model);
        }
        [ValidateAntiForgeryToken]
        public ActionResult Save(Personal personal)
        {
            if (!ModelState.IsValid)
            {
                var model = new PersonalFormViewModel()
                {
                    Departments = db.Department1.ToList(),
                    Personal = personal
                };
                return View("PersonalForm", model);
            }
            MessageViewModel modelMessage = new MessageViewModel();
            if (personal.Id == 0)
            {
                db.Personal.Add(personal);
                modelMessage.Message = personal.Name + " " + personal.Surname + " added. Press to return ";
            }
            else
            {
                db.Entry(personal).State = System.Data.Entity.EntityState.Modified;
                modelMessage.Message = "Data of " + personal.Name + " " + personal.Surname + " updated. Press to return ";
            }
            db.SaveChanges();
            modelMessage.Status = true;
            modelMessage.LinkText = "Personal List";
            modelMessage.Url = "/Personal";
            return View("_Message", modelMessage);
        }
        public ActionResult Update(int id)
        {
            var model = new PersonalFormViewModel()
            {
                Departments = db.Department1.ToList(),
                Personal = db.Personal.Find(id)
            };
            return View("PersonalForm", model);
        }
        public ActionResult Delete(int id)
        {
            var personalToDelete = db.Personal.Find(id);
            if (personalToDelete == null)
                return HttpNotFound();
            db.Personal.Remove(personalToDelete);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ListThePersonals(int id)
        {
            var model = db.Personal.Where(x=>x.DepartmentId==id).ToList();
            return PartialView(model);
        }
    }
}