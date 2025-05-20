using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

using Models;
using Views;
using Repository;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Collections.Concurrent;

namespace Controllers
{
    public class OrderController
    {
        private List<Order> orderList = new List<Order>();
        private ClientController cController;
        private ProductController pController;
        
        public OrderController()
        {
            cController = new ClientController();
            pController = new ProductController();
            LoadOrders();
        }

        private void LoadOrders()
        {
            orderList = Repository<Order>.ObtenerTodos(Path.Combine("Repository", "Data", "ordenes"));
        }

        private void SaveOrders()
        {
            Repository<Order>.GuardarLista(Path.Combine("Repository", "Data", "ordenes"), orderList);
        }

        //Metodo para crear una orden
        public void CreateOrder()
        {
            var cliente = cController.loadClient();
            if (cliente == null)
            {
                OrderView.ShowMsg("[ERROR] No hay clientes ingresados.");
            }
            var productos = pController.loadProduct();
            if (productos == null)
            {
                OrderView.ShowMsg("[ERROR] Lista de productos vacia.");
            }

            Order newOrder = new Order()
            {
                Client = cliente
            };

            newOrder.producList = productos;
            
            orderList.Add(newOrder);

            SaveOrders();

            OrderView.ShowMsg("Ordern creada y guardada.");
        }

        //Metodo para actualizar una orden
        public void UpdateOrder()
        {
            Console.Write("Ingrese el ID de la orden a actualizar: ");
            int index = int.Parse(Console.ReadLine());

            if (index < 0 || index >= orderList.Count)
            {
                OrderView.ShowMsg("ID invalido.");
                return;
            }

            var newClient = cController.loadClient();
            var newProduct = pController.loadProduct();

            orderList[index].Client = newClient;
            orderList[index].producList = newProduct;

            SaveOrders();

            OrderView.ShowMsg("Orden actualizada");
        }

        //Metodo para eliminar orden
        public void DeleteOrder()
        {
            Console.Write("Ingrese el ID de la orden a eliminar");
            int index = int.Parse(Console.ReadLine());

            if (index < 0 || index >= orderList.Count)
            {
                OrderView.ShowMsg("ID invalido");
                return;
            }

            orderList.RemoveAt(index);

            SaveOrders();

            OrderView.ShowMsg("Orden eliminada.");
        }

        //Metodo para ver lista de ordenes
        public void ViewList()
        {
            OrderView.ShowMsg("Lista de ordenes...");
            OrderView.ShowMsg("=======================");
            if (orderList.Count == 0)
            {
                OrderView.ShowMsg("No hay ordenes cargadas");
                return;
            }

            int index = 0;
            foreach ( var o in orderList)
            {
                Console.WriteLine($"Order N°: {index}");
                cController.showClient(o.Client);
                Console.WriteLine(":::::::::::::Client Product:::::::::::");
                pController.showProduct(o.producList);
                OrderView.ShowMsg($"Total: {o.CalculateTotal()} || Total mas IVA: {o.TotalIVA()}");
            }
        }
    }
}
