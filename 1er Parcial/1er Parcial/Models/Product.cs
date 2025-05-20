using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Desc { get; set; }

        public Product() { }

        public Product(string name, double price, string desc)
        {
            Name = name;
            Price = price;
            Desc = desc;
        }

        //Metodo para agregar IVA a los productos
        public double FinalPrice() => Price * 1.21;
    }
}
