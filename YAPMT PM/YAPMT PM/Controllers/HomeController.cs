using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YAPMT_PM.Models;
using System.Data;
using System.Data.Entity;
using YAPMT_PM.DAL;

namespace YAPMT_PM.Controllers
{
    public class HomeController : Controller
    {
        private ProjectContext db = new ProjectContext();
      
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProjectsPartial()
        {
            List<Project> projects = new List<Project>();
            projects = db.Projects.ToList();

            return View(projects);
        }

        public ActionResult Projects()
        {
            return View();
        }

        public ActionResult UsersPartial()
        {
            return View(db.Users.ToList());
        }

        public ActionResult Users()
        {
            return View(db.Users.ToList());
        }

        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUser(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();

                List<Project> projects = new List<Project>();
                projects = db.Projects.ToList();

                return RedirectToAction("Users", projects);
            }

            return View(user);
        }

        public ActionResult DeleteProject(int id = 0)
        {
            Project project = db.Projects.Find(id);

            foreach (var item in project.Tasks.ToList())
            {
                db.Tasks.Remove(item);
            }
            db.Projects.Remove(project);
            db.SaveChanges();
            return RedirectToAction("Projects");
        }

        public ActionResult CreateTask(int id = 0)
        {
            ViewBag.ComboUsers = new SelectList(db.Users.ToList(), "ID", "UserName");
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTask(Task task)
        {
            if (ModelState.IsValid)
            {
                User usr = db.Users.Find(task.User.ID);
                task.User = usr;
                
                if(task.ExpirationDate <= DateTime.Now)
                    task.Status = StatusOfTask.Late;
                else
                    task.Status = StatusOfTask.Ok;

                db.Projects.Find(task.ID).Tasks.Add(task);                  
                db.SaveChanges();

                List<Project> projects = new List<Project>();
                projects = db.Projects.ToList();

                return RedirectToAction("Projects", projects);
            }
            ViewBag.ComboUsers = new SelectList(db.Users.ToList(), "ID", "UserName");
            return View(task);
        }

        public ActionResult Project(int id = 0)
        {
            Project project = db.Projects.Find(id);

            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Project project)
        {
            if (ModelState.IsValid)
            {
                db.Projects.Add(project);
                db.SaveChanges();

                List<Project> projects = new List<Project>();
                projects = db.Projects.ToList();

                return RedirectToAction("Projects",projects);
            }

            return View(project);
        }

        public string mudaStatusTask(int idtask, bool status)
        {
            Task task = new Task();
            task = db.Tasks.Find(idtask);


            if(task.Status.Equals(StatusOfTask.Late) && status)
                task.Status = StatusOfTask.LateConcluded;
            else if (task.Status.Equals(StatusOfTask.LateConcluded) && !status)
                task.Status = StatusOfTask.Late;
            else if(status)
                task.Status = StatusOfTask.Concluded;
            else
                task.Status = StatusOfTask.Ok;

            db.Entry(task).State = EntityState.Modified;
            db.SaveChanges();

            return "OK";
        }

        public string mudaStatusTaskAtrasadas()
        {
            List<Task> tasks = new List<Task>();
            tasks = db.Tasks.ToList();

            foreach(var item in tasks)
            {
                if ((item.ExpirationDate <= DateTime.Now))
                {
                    if (item.Status != (StatusOfTask.LateConcluded) || item.Status != (StatusOfTask.LateConcluded))
                    {
                        item.Status = StatusOfTask.Late;
                        db.Entry(item).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }

            return "OK";
        }


    }
}
