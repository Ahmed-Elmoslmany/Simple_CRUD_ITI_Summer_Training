using demo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;


namespace demo.Controllers
{
    public class ProductController : Controller
    {
        onlinecontext context = new onlinecontext();

   
        public ActionResult product()
        {
            List<Product> allproduct = context.products.ToList();

            List<Category> categorylist = context.Categories.ToList();
            ViewBag.categories = categorylist;

            return View("products", allproduct);
        }

        public ActionResult Delete(int? id)
        {
            Product deltedProduct = context.products.FirstOrDefault(x => x.Id == id);
            if (deltedProduct != null)
            {
                context.Entry(deltedProduct).State = EntityState.Deleted;
                context.SaveChanges();
            }

            List<Product> allproduct = context.products.ToList();

            List<Category> categorylist = context.Categories.ToList();
            ViewBag.categories = categorylist;

            return View("products", allproduct);

        }

        // Goto "Add page"
        public ActionResult Add()
        {
            List<Category> categorylist = context.Categories.ToList();

            return View("AddProduct", categorylist);
        }

        // Return with data from "Add page"
        public ActionResult AddNew( Product newP)
        {
            if (newP != null && newP.Price > 0)
            {
                context.products.Add(newP);
                context.SaveChanges();

            }

            List<Product> allproduct = context.products.ToList();

            List<Category> categorylist = context.Categories.ToList();
            ViewBag.categories = categorylist;

            return View("products", allproduct);

           


        }

        // Reverse list to get newest items
        public ActionResult Newest()
        {
            List<Product> allproduct = context.products.ToList();
            allproduct.Reverse();

            List<Category> categorylist = context.Categories.ToList();
            ViewBag.categories = categorylist;

            return View("products", allproduct);
        }



        [HttpGet]
        public ActionResult Update(int id)
        {
            Product P = context.products.FirstOrDefault(i => i.Id == id);

            List<Category> categorylist = context.Categories.ToList();
            
            ViewBag.categories = categorylist;
          



            return View(P);
        }



        [HttpPost]
        public ActionResult Update(int id, Product UpdProd)
        {
            Product p = context.products.FirstOrDefault(i => i.Id == id);

            p.Name = UpdProd.Name;
            p.Price = UpdProd.Price;
            p.details = UpdProd.details;
            p.Category_ID = UpdProd.Category_ID;
            context.SaveChanges();

            
            return RedirectToAction("product");

        }


        
        public ActionResult details(int? id)
        {
            Product product = context.products.FirstOrDefault(x => x.Id == id);

            return View("details", product);

        }


        public ActionResult selectby(int byCategory)
        {
           
          
                List<Category> categorylist = context.Categories.ToList();
                ViewBag.categories = categorylist;

                List<Product> allproduct = context.products.Where(x => x.Category_ID == byCategory).ToList();
                
                return View("products", allproduct);
            
            

        }

    }
}
