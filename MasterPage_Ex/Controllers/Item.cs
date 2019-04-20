using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MasterPage_Ex.Models;

namespace MasterPage_Ex.Controllers
{
    public class Item
    {
        private ProductTable pr = new ProductTable();

        public ProductTable Pr
        {
            get { return pr; }
            set { pr = value; }
        }


        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

       
        
        public Item()
        { }

        public Item(ProductTable pr, int quantity)
        {
            this.pr = pr;
            this.quantity = quantity;
        }
    }
}