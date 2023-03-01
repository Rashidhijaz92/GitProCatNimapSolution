using ProCateNimapInfoTech.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProCateNimapInfoTech.Controllers
{
    public class ProductController : Controller
    {
        NimapContext db = new NimapContext();



        public ActionResult prodDetail()
        {

            var data = db.ProductsTable.ToList();

            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Product Product)
        {
            if (ModelState.IsValid == true)
            {
                db.ProductsTable.Add(Product);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    ViewBag.CreateMessage = ("<script>alert('Data Saved')</script>");
                    return RedirectToAction("prodDetail");
                }
                else
                {
                    ViewBag.CreateMessage = ("<script>alert('Data not Saved')</script>");

                }
            }
            return RedirectToAction("prodDetail");
        }
        public ActionResult Edit(int Id)
        {

            var row = db.ProductsTable.Where(modal => modal.PK_ProductId == Id).FirstOrDefault();
            return View(row);

        }
        [HttpPost]
        public ActionResult Edit(Product PID)
        {
            db.Entry(PID).State = EntityState.Modified;
            int b = db.SaveChanges();
            if (b > 0)
            {
                ViewBag.UpdateMessage = ("<script>alert('Data Updated')</script>");
                 return RedirectToAction("CatDetails");
            }
            else
            {
                ViewBag.UpdateMessage = ("<script>alert('Data not Update')</script>");

            }
            return RedirectToAction("prodDetail");
        }

        public ActionResult Delete(int ID)
        {
            var row = db.ProductsTable.Where(modal => modal.PK_ProductId == ID).FirstOrDefault();
            return View(row);

            //int empId = Convert.ToInt32(ID);
            //var data = db.ProductsTable.Find(empId);
            //return View(data);


        }



        [HttpPost]
        public ActionResult Delete(Category Cat)
        {
            db.Entry(Cat).State = EntityState.Deleted;
            int a = db.SaveChanges();



            if (a > 0)
            {
                ViewBag.DeleteMessage = ("<script>alert('Data deleted Successfully')</script>");

                //ModelState.Clear();
                return RedirectToAction("CatDetails");
            }
            else
            {
                ViewBag.deleteMessage = ("<script>alert('Data not delete')</script>");

            }
            return View();





        }






        //[HttpPost]
        //public string deleteProduct(int Id)
        //{

        //    string status = "";

        //    try
        //    {

        //        string strCon = @"data source=RASHIDSHAIKH;initial catalog=NimapDb;integrated security=true";


        //        SqlConnection con = new SqlConnection(strCon);
        //        string Query = "delete  from tblproducts where PK_ProductId=@PK_ProductId  ";
        //        SqlCommand cmd = new SqlCommand(Query, con);


        //        cmd.Parameters.AddWithValue("@PK_ProductId", Id);

        //        con.Open();

        //        int noOfRowAffected = cmd.ExecuteNonQuery();

        //        con.Close();

        //        if (noOfRowAffected > 0)
        //        {
        //            ViewBag.CreateMessage = ("<script>alert('Record Delete')</script>");
        //        }
        //        else
        //        {
        //            status = "Some error";
        //            ViewBag.CreateMessage = ("<script>alert('Record Not Delete')</script>");
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        status = "Some error";


        //    }
        //    return status;
        //}
    }
}