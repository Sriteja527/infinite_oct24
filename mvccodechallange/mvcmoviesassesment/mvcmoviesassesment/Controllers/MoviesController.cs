using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcmoviesassesment.Models;
namespace mvcmoviesassesment.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        MoviesDBEntities md = new MoviesDBEntities();
        public ActionResult Index()
        {
            return View();
        }
        // GET: Movies/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Movie m)
        {
            md.Movies.Add(m);
            md.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            Movie s = md.Movies.Find(id);
            return View();
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteCategory(int id)
        {
            Movie s = md.Movies.Find(id);
            md.Movies.Remove(s);
            md.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}