using ASP.NET_StudentRegisrty.Data;
using ASP.NET_StudentRegisrty.Models;
using ASP.NET_StudentRegisrty.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ASP.NET_StudentRegisrty.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudent studentRep;
        private readonly ApplicationDbContext applicationDbContext;

        public StudentController(IStudent studentRep, ApplicationDbContext applicationDbContext)
        {
            this.studentRep = studentRep;
            this.applicationDbContext = applicationDbContext;
        }

        // GET: StudentController
        public ActionResult Index()
        {
            return View(studentRep.GetAll());
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View(studentRep.GetById(id));
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(/*[Bind("StudentId, FirstName, LastName")]*/Student student)
        {
            try
            {
                if (ModelState.IsValid) 
                { 
                    applicationDbContext.Add(student);
                    applicationDbContext.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                else { return View(); }
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StudentViewModel studentVM = new StudentViewModel();
            studentVM.Student = applicationDbContext.Students.Find(id);
            studentVM.CurrentUser = new CurrentUser() { UserName = Environment.UserName };
            if (studentVM.Student == null)
            {
                return NotFound();
            }
            return View(studentVM);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, StudentViewModel studentVM)
        {
            if (id != studentVM.Student.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    applicationDbContext.Update(studentVM.Student);
                    applicationDbContext.SaveChanges();
                }
                catch (Exception)
                {
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(studentVM);
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null || applicationDbContext.Students == null)
            {
                return NotFound();
            }

            var student = applicationDbContext.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: StudentController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var student = applicationDbContext.Students.Find(id);
            if (ModelState.IsValid)
            {
                try
                {
                    applicationDbContext.Remove(student);
                    applicationDbContext.SaveChanges();
                }
                catch (Exception)
                {
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }        
    }
}
