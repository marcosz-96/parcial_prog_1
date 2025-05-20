using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Client
    {
        public string Name { get; set; }
        public string LastName {  get; set; }
        public string DNI { get; set; }
        public string Adress { get; set; }
        public string Email {  get; set; }

        public Client() { }

        public Client(string name, string lastName, string dni, string adress, string email)
        {
            Name = name;
            LastName = lastName;
            DNI = dni;
            Adress = adress;
            Email = email;
        }
    }
}
