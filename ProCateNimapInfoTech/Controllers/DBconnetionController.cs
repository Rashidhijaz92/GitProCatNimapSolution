using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProCateNimapInfoTech.Models;


namespace ProCateNimapInfoTech.Controllers
{
    public class DBconnetionController : Controller
    {
        
        public ActionResult Index()
        {
            NimapContext db = new NimapContext();
            db.CategoriesTable.ToList();
            db.ProductsTable.ToList();
            

            return View();
        }
    }
}