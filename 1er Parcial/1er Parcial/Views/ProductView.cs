using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Models;

namespace Views
{
    public class ProductView
    {
        //Metodo para ingresar productos a la lista
        public static List<Product> InputProduct()
        {
            List<Product> list = new List<Product>();
            string input;

            do
            {
                try
                {
                    Console.Write("Product name: ");
                    string name = ValidInput();
                    Console.Write("Price: ");
                    double price = double.Parse(ValidInput(true));
                    Console.Write("Description: ");
                    string desc = ValidInput();

                    list.Add(new Product(name, price, desc));
                }
                catch (FormatException)
                {
                    Console.WriteLine("[ERROR] EL precio tiene que ser un numero valido");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[ERROR] No se pudo ingresar los datos del producto: {ex.Message}");
                }

                Console.Write("New product? (y/n)");
                input = ValidInput().ToLower();
            } while (input == "y");
            return list;
        }

        //Metodo para mostrar lista de productos
        public static void ShowProduct(List<Product> list)
        {
            foreach (var p in list)
            {
                Console.WriteLine($"{p.Name} - {p.Price: 0.00} - {p.Desc}");
            }
        }

        //Metodo para validar datos de entrada
        public static string ValidInput(bool isNumeric = false, bool isEmail = false)
        {
            bool validGood = false; string userInput;
            do
            {
                userInput = Console.ReadLine();
                if (isNumeric && double.TryParse(userInput, out double parsedValue) && !string.IsNullOrEmpty(userInput))
                {
                    validGood = true;
                }
                else if (!isNumeric && !string.IsNullOrEmpty(userInput) && !isEmail)
                {
                    validGood = true;
                }
                else if (!isNumeric && !string.IsNullOrEmpty(userInput) && isEmail && userInput.Contains("@"))
                {
                    validGood = true;
                }
                else
                {
                    Console.WriteLine("Dato inválido. Intente nuevamente");
                }
            } while (!validGood);
            return userInput;
        }
    }
}
