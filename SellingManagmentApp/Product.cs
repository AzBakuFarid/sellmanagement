using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellingManagmentApp
{
    public class Product
    {
        private static int counter;
        public string Name { get; set; }
        public int Barcode { get; set; }
        public int Id { get; set; }
        public Category category;
        public double Price { get; set; }
        public int ItemCount { get; set; }
        public int selledCount { get; set; } = 0;
        public double SellPrice { get; set; } = 0;

        public Product(string n, int b, Category c, double p, int ic) {
            counter++;
            Name = n;
            Barcode = b;
            Id = counter;
            category = c;
            Price = p;
            ItemCount = ic;
        }
    }
}
