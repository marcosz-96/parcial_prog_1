using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Models;
using Views;

namespace Controllers
{
    public class ClientController
    {
        //Metodo para ingresar clientes
        public Client loadClient() => ClientView.InputClient();

        //Metodo para mostrar clientes cargados
        public void showClient(Client c) => ClientView.ShowClient(c);
    }
}
