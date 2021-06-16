using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using InternetScore.Models;

namespace InternetScore.Controllers
{
    public class InternetController : Controller
    {
        ScoreContext db = new ScoreContext();
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category).OrderBy(p => p.Category.Name);
            return View(products.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "My Homework InternetScores";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "My contact Pages";

            return View();
        }
        public ActionResult CategoryDetails()
        {
            var category = db.Categoryes.Include(t=>t.Products).OrderBy(t=>t.Name);

            return View(category.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            Product product = new Product();
            SelectList categoryes = new SelectList(db.Categoryes, "Id", "Name");
            ViewBag.Categoryes = categoryes;
            return View(product);
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {

            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id==null)
            {
                HttpNotFound();
            }
            Product product = db.Products.Find(id);
            if(product!=null)
            {
                SelectList categoryes = new SelectList(db.Categoryes, "Id", "Name", product.Id);
                ViewBag.Categoryes = categoryes;
                return View(product);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int? id)
        {
            Product product = db.Products.Find(id);
            if(product!=null)
            {
                db.Products.Remove(product);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCategory(Category category)
        {
            db.Categoryes.Add(category);
            db.SaveChanges();
            return RedirectToAction("CategoryDetails");
        }
        public ActionResult DeleteCategory(int id)
        {
            Category category = db.Categoryes.Find(id);
            if (category != null)
            {
                db.Categoryes.Remove(category);
                db.SaveChanges();
            }
            return RedirectToAction("CategoryDetails");
        }
        [HttpGet]
        public ActionResult EditCategory(int? id)
        {
            if(id==null)
            {
                return HttpNotFound();
            }
            Category category = db.Categoryes.Find(id);
            return View(category);
        }
        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            db.Entry(category).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("CategoryDetails");
        }
        public ActionResult CatalogProducts(int? category, int? price)
        {
            IQueryable<Product> products = db.Products.Include(p => p.Category);
            if (category!=null && category!=0)
            {
                products = products.Where(p => p.CategoryId == category);
            }
            if(price!=0)
            {
                products = products.Where(p => p.Price == price);
            }
            List<Category> categories = db.Categoryes.ToList();
            categories.Insert(0, new Category { Name = "All", Id = 0 });
            ProductsListViewModel plvm = new ProductsListViewModel
            {
                Products = products.ToList(),
                Categoryes = new SelectList(categories, "Id", "Name"),
                Price = new SelectList(new List<string>()
                {
               "All",
               "<50",
               "<100",
               "<150",
               "<200",
               "<300"
                })
            };
            return View(plvm);
        }
    }
}