using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Models;
using Views;

namespace Controllers
{
    public class ProductController
    {
        //Metodo para cargar productos
        public List<Product> loadProduct() => ProductView.InputProduct();

        //Metodo para ver lista de productos
        public void showProduct(List<Product> list) => ProductView.ShowProduct(list);
    }
}
