using proj2_twai.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace proj2_twai.Controllers
{
    public class ListController : Controller
    {
        private StanowiskoContext sdb = new StanowiskoContext();
        private UserContext udb = new UserContext();

        public ActionResult Employee()
        {
            
            ViewBag.lista= udb.userc.ToList();
            return View();
          
        }

        public ActionResult Stanowiska()
        {
            ViewBag.slista = sdb.Stanowiskas.ToList();
            return View();
        }
        // GET: List
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (udb.userc.Find(id) != null)
            {
                udb.userc.Remove(udb.userc.Find(id));
                udb.SaveChanges();
                return Redirect("/List/Employee");
            }
            else
                return Redirect("/List/Employee");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {


            try
            {
                Session["editid"] = id;
                return View(udb.userc.Find(id));
            }
            catch
            {
                return Redirect("/List/Employee");

            }

        }

        [HttpPost]
        public ActionResult Edit(User u)
        {
            if (ModelState.IsValid)
            {


                udb.userc.Remove(udb.userc.Find(Session["editid"]));
                u.ID = (int)Session["editid"];


                udb.SaveChanges();
                udb.userc.Add(u);
                udb.SaveChanges();

                return Redirect("/List/Employee");
                
                
            }
            else
            {
                return View(u);
            }
        }

        [HttpPost]
        public ActionResult Add(User u)
        {
            if (ModelState.IsValid)
            {
                
                udb.userc.Add(u);
                udb.SaveChanges();
                return Redirect("/List/Employee");
            }
            else
            {
                return View();
            }
        }

        public ActionResult SAdd()
        {
            return View();
        }

        

        [HttpGet]
        public ActionResult SDelete(int id)
        {
            if (sdb.Stanowiskas.Find(id) != null)
            {
                sdb.Stanowiskas.Remove(sdb.Stanowiskas.Find(id));
                sdb.SaveChanges();
                return Redirect("/List/Stanowiska");
            }
            else
                return Redirect("/List/Stanowiska");

        }

        [HttpGet]
        public ActionResult SEdit(int id)
        {
            try
            {
                Session["editid"] = id;
                return View(sdb.Stanowiskas.Find(id));
            }
            catch
            {
                return Redirect("/List/Stanowiska");

            }
        }

        [HttpPost]
        public ActionResult SEdit(Stanowisko s)
        {
            if (ModelState.IsValid)
            {
                sdb.Stanowiskas.Remove(sdb.Stanowiskas.Find(Session["editid"]));
                s.ID = (int)Session["editid"];


                sdb.SaveChanges();
                sdb.Stanowiskas.Add(s);
                sdb.SaveChanges();

                return Redirect("/List/Stanowiska");


            }
            else
            {
                return View(s);
            }
        }

        [HttpPost]
        public ActionResult SAdd(Stanowisko s)
        {
            if (ModelState.IsValid)
            {
                sdb.Stanowiskas.Add(s);
                sdb.SaveChanges();
                return Redirect("/List/Stanowiska");
            }
            else
            {
                return View();
            }
        }

    }
}