using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProCateNimapInfoTech.Models
{
    [Table("tblproducts")]
    public class Product
    {
        [Key]
        public int PK_ProductId { get; set; }
        public String ProdctName { get; set; }
        public int Price { get; set; }

        //FK of category Table
        public Category category { get; set; }
    }
}