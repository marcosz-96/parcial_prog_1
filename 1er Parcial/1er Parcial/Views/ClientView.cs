using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Models;

namespace Views
{
    public class ClientView
    {
        public static Client InputClient()
        {
            try
            {
                Console.Write("Client name: ");
                string name = ValidInput();
                Console.Write("Last name client: ");
                string lastName = ValidInput();
                Console.Write("DNI: ");
                string dni = ValidInput();
                Console.Write("Adress: ");
                string adress = ValidInput();
                Console.Write("Email: ");
                string email = ValidInput();

                return new Client(name, lastName, dni, adress, email);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] No se pudo ingresar los datos del cliente: {ex.Message}");
                return null;
            }
        }

        //Metodo para mostrar los datos del cliente 
        public static void ShowClient(Client c)
        {
            Console.WriteLine($"{c.Name} {c.LastName} | DNI: {c.DNI} | Adress: {c.Adress} | Email: {c.Email}");
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
