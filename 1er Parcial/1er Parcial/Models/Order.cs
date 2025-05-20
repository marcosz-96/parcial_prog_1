using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Order
    {
        public Client Client { get; set; }
        public List<Product> producList { get; set; } = new List<Product>();

        public Order() { }

        //Metodo para sumar el precio total de los productos
        public double CalculateTotal() => producList.Sum(p=> p.Price);

        //Metodo para agregar IVA al total de los productos
        public double TotalIVA() => producList.Sum(p=> p.FinalPrice());
    }
}
