using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProCateNimapInfoTech.Models;
using System.Data.Entity;
namespace ProCateNimapInfoTech.Controllers
{
    //I Do my Best Thanks Rashid shaikh...

    //the logic behind pagination i know in web form we use joins  TO SHOW BOTH TABLES record and it


    /*Select P.Id AS ProductId, P. Name AS ProductName, C.Id AS CategoryId, 
     * C.Name AS CategoryName From Product P Inner Join Category C
     * ON P.pRODUCTId = C.CategoryId*/


    //LIKE THAT

    public class CreateController : Controller
    {
        NimapContext db = new NimapContext();
        public ActionResult CatDetails()
        {
           
            var data = db.CategoriesTable.ToList();

            return View(data);
        }

        public ActionResult Create()
        {
            return View("data");
        }

        [HttpPost]
        public ActionResult Create( Category Cat)
        {
            if (ModelState.IsValid == true)
            {
                db.CategoriesTable.Add(Cat);
               int a= db.SaveChanges();
                if (a > 0)
                {
                    ViewBag.CreateMessage=("<script>alert('Data Saved')</script>");
                    return RedirectToAction("CatDetails");
                }
                else
                {
                    ViewBag.CreateMessage = ("<script>alert('Data not Saved')</script>");

                }
            }
            return View();
        }

        public ActionResult Edit(int Id)
        {

            var row = db.CategoriesTable.Where(modal => modal.PK_CategoryId == Id).FirstOrDefault();
            return View(row);

        }
        [HttpPost]
        public ActionResult Edit(Category Cat)
        {
            db.Entry(Cat).State = EntityState.Modified;
            int b=db.SaveChanges();
            if (b > 0)
            {
                ViewBag.UpdateMessage = ("<script>alert('Data Updated')</script>");
                return RedirectToAction("CatDetails");
            }
            else
            {
                ViewBag.UpdateMessage = ("<script>alert('Data not Update')</script>");

            }
            return View();
        }


        public ActionResult Delete(string ID)
        {
            //var row = db.CategoriesTable.Where(modal => modal.PK_CategoryId == ID).FirstOrDefault();
            //return View(row);

            int empId = Convert.ToInt32(ID);
            var data = db.CategoriesTable.Find(empId);
            return View(data);


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





        //[HttpDelete]
        //public int Delete(int Id)
        //{
        //    string strCon = @"data source=RASHIDSHAIKH;initial catalog=NimapDb;integrated security=true";
        //    using (SqlConnection con = new SqlConnection(strCon))
        //    {
        //        con.Open();
        //        string query = "Delete from tblCategories where PK_CategoryId=@PK_CategoryId";
        //        SqlCommand cmd = new SqlCommand(query, con);
        //        cmd.Parameters.AddWithValue("@PK_CategoryId", Id);
        //      
        //    }
        //}



        

    }
}