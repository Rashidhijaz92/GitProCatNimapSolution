using ProCateNimapInfoTech.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProCateNimapInfoTech.Controllers
{
    public class SimpleProductMasterController : Controller
    {
        // GET: SimpleProductMaster
        public ActionResult Index()
        {
            return View();
        }

        NimapContext db = new NimapContext();
        

        public ActionResult ProductDetails()
        {

            //List<Category> categories = db.CategoriesTable.ToList();

            //return View(db.CategoriesTable.Where(x => x.CategoryName == search || search == null));
            var productsss = db.ProductsTable.ToList();
            return View(productsss);


        }


        // GET SimpleCatMasterCRUD
        public ActionResult CreateProduct()

        {
            return View("CreateUpdateProduct");
        }
        [HttpPost]
        public ActionResult CreateProduct(Product pro)
        {
            if (ModelState.IsValid == true)
            {
                db.ProductsTable.Add(pro);

                int a = db.SaveChanges();
                if (a > 0)
                {
                    ViewBag.CreateMessage = ("<script>alert('Data Saved')</script>");
                    return RedirectToAction("ProductDetails");
                }
                else
                {
                    ViewBag.CreateMessage = ("<script>alert('Data not Saved')</script>");

                }
            }
            return RedirectToAction("ProductDetails");



        }

        public ActionResult Edit(int Id)
        {

            var row = db.ProductsTable.Where(modal => modal.PK_ProductId== Id).FirstOrDefault();
            return View(row);

            //var row = db.CategoriesTable.FirstOrDefault(modal => modal.PK_CategoryId == Id);
            //return View(row);
        }
        [HttpPost]
        public ActionResult Edit(Product Pro)
        {
            db.Entry(Pro).State = EntityState.Modified;
             db.SaveChanges();
            //if (b > 0)
            //{
            //    ViewBag.UpdateMessage = ("<script>alert('Data Updated')</script>");
            //    return RedirectToAction("ProductDetails");
            //}
            //else
            //{
            //    ViewBag.UpdateMessage = ("<script>alert('Data not Update')</script>");

            //}
            return RedirectToAction("ProductDetails");
        }


        public ActionResult Delete(int id)
        {
            var category = db.ProductsTable.Find(id);
            return View(category);
        }

        [HttpPost, ActionName("Delete")]

        public ActionResult DeleteConfirmed(int id)
        {
            var Productss = db.ProductsTable.Find(id);
            db.ProductsTable.Remove(Productss);
            db.SaveChanges();
            return RedirectToAction(nameof(ProductDetails));
        }

    }
}





