using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Controllers; 

namespace _1er_Parcial
{
    internal class Program
    {
        static void Main()
        {
            OrderController controller = new OrderController();

            

            bool salida = false;
            do
            {
                Console.WriteLine("Ingrese una opcion");
                Console.WriteLine("1: Create");
                Console.WriteLine("2: View");
                Console.WriteLine("3: Update");
                Console.WriteLine("4: Delete");
                Console.WriteLine("0: Salir");

                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    
                    case 1:
                        controller.CreateOrder();
                        break;
                    case 2:
                        controller.ViewList();
                        break;
                    case 3:
                        controller.UpdateOrder();
                        break;
                    case 4:
                        controller.DeleteOrder();
                        break;
                    case 0:
                        Console.WriteLine("Fin del programa");
                        salida = true;
                        break;
                }
            } while (!salida);

            
        }
    }
}
