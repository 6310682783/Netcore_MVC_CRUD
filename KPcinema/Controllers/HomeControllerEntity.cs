using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KPcinema.Models;

namespace KPcinema.Controllers
{
    public class MovieControllerEntity : Controller
    {
        //prop
        private readonly DataContext _dataContext;
        //const
        public MovieControllerEntity(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        // GET: MovieController
        public ActionResult Index()
        {
            var movies = _dataContext.Movie.ToList();
            return View(movies);
        }

        // GET: MovieController/Details/5
        public ActionResult Details(int id)
        {
            var movie = _dataContext.Movie.Find(id);
            return View(movie);
        }

        // GET: MovieController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MovieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie model)
        {
            try
            {
                var entity = _dataContext.Movie.Add(model);
                _dataContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MovieController/Edit/5
        public ActionResult Edit(int id)
        {
            var movie = _dataContext.Movie.Find(id);
            return View(movie);
        }

        // POST: MovieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Movie model)
        {
            try
            {
                var entity = _dataContext.Movie.Update(model);
                _dataContext.SaveChanges();
                return RedirectToAction("Index");
            }

            catch
            {
                return View();
            }
        }

        // POST: MovieController/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                var entity = _dataContext.Movie.Remove(new Movie() { id = id });
                _dataContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
