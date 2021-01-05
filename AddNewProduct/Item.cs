using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTest
{
    public class Item
    {
        public string stall {get; set;}
        public string brand { get; set; }
        public string name { get; set; }
        public string oldPrice { get; set; }
        public string price { get; set; }
        public string stock { get; set; }
        public string description { get; set; }
        public string file { get; set; }

        public Item(string stall, string brand, string name, string oldPrice, string price, string stock, string description, string file)
        {
            this.stall = stall;
            this.brand = brand;
            this.name = name;
            this.oldPrice = oldPrice;
            this.price = price;
            this.stock = stock;
            this.description = description;
            this.file = file;
        }
    }
}
