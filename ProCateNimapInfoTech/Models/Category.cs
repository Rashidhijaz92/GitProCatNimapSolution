using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProCateNimapInfoTech.Models
{
    [Table("tblCategories")]
    public class Category
    {   [Key]
        public int PK_CategoryId { get; set; }
        public String CategoryName { get; set; }






        //public List<Category> GetList
        //{

        //    get

        //    {

        //        return new List<Category>()

        //        {

        //            new Category() { PK_CategoryId = 1, CategoryName = "p1" },

        //            new Category() { PK_CategoryId = 2, CategoryName = "p2" },

        //            new Category() { PK_CategoryId = 3, CategoryName = "p3" },

        //            new Category() { PK_CategoryId = 4, CategoryName = "p4" },

        //            new Category() { PK_CategoryId = 5, CategoryName = "p5" },

        //            new Category() { PK_CategoryId = 6, CategoryName = "p6" },

        //            new Category() { PK_CategoryId = 7, CategoryName = "p7" },

        //            new Category() { PK_CategoryId = 8, CategoryName = "p8" },

        //            new Category() { PK_CategoryId = 9, CategoryName = "p9" },

        //            new Category() { PK_CategoryId = 10, CategoryName = "p10" },

        //        };

        //    }

        //}

    }
}