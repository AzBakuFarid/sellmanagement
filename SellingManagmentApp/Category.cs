using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellingManagmentApp
{
   public class Category
    {
        private static int counter;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }

        public Category(string n,   string p)
        {
            counter++;
            Name = n;
            Id = counter;
            Photo = p;

        }
    }
}
