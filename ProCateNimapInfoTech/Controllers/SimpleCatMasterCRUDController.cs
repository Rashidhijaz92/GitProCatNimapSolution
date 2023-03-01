using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProCateNimapInfoTech.Models;
using PagedList;
using PagedList.Mvc;

namespace ProCateNimapInfoTech.Controllers
{
    public class SimpleCatMasterCRUDController : Controller
    {


        NimapContext db = new NimapContext();

        //public IActionResult Index(int page = 1, int pageSize = 10)
        //{
        //    // Get the total number of products
        //    var totalcategory = db.CategoriesTable.Count();

        //    // Calculate the number of pages
        //    var totalPages = (int)Math.Ceiling((decimal)totalcategory / pageSize);

        //    // Get the products for the current page
        //    var categories = db.CategoriesTable
        //        .OrderBy(p => p.PK_CategoryId)
        //        .Skip((page - 1) * pageSize)
        //        .Take(pageSize)
        //        .ToList();
            
        //    ViewBag.Page = page;
        //    ViewBag.PageSize = pageSize;
        //    ViewBag.TotalPages = totalPages;
        //    ViewBag.TotalProducts = totalcategory;
        //    return View(Category);
        //}

        public ActionResult Details(string searchBy, string search, int? page)
        {
          
                //List<Category> categories = db.CategoriesTable.ToList();

                //return View(db.CategoriesTable.Where(x => x.CategoryName == search || search == null));


                var categories = db.CategoriesTable.ToList();
                return View(categories);

       
        }


        // GET SimpleCatMasterCRUD
        public ActionResult CreateCat()


        {
            return View("CreateCatUpdateCat");
        }
        [HttpPost]
        public ActionResult CreateCat(Category Cat)
        {
            if (ModelState.IsValid == true)
            {
                db.CategoriesTable.Add(Cat);

                int a = db.SaveChanges();
                if (a > 0)
                {
                    ViewBag.CreateMessage = ("<script>alert('Data Saved')</script>");
                    return RedirectToAction("Details");
                }
                else
                {
                    ViewBag.CreateMessage = ("<script>alert('Data not Saved')</script>");

                }
            }
            return RedirectToAction("Details");
        

       
        }
        public ActionResult Edit(int Id)
        {

            var row = db.CategoriesTable.Where(modal => modal.PK_CategoryId == Id).FirstOrDefault();
            return View(row);

            //var row = db.CategoriesTable.FirstOrDefault(modal => modal.PK_CategoryId == Id);
            //return View(row);
        }
        [HttpPost]
        public ActionResult Edit(Category CID)
        {
            db.Entry(CID).State = EntityState.Modified;
            int b = db.SaveChanges();
            if (b > 0)
            {
                ViewBag.UpdateMessage = ("<script>alert('Data Updated')</script>");
                return RedirectToAction("Details");
            }
            else
            {
                ViewBag.UpdateMessage = ("<script>alert('Data not Update')</script>");

            }
            return RedirectToAction("Details");
        }


        public ActionResult Delete(int id)
        {
            var category = db.CategoriesTable.Find(id);
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var category = db.CategoriesTable.Find(id);
            db.CategoriesTable.Remove(category);
            db.SaveChanges();
            return RedirectToAction(nameof(Details));
        }

    }
}