using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rnet.Classes
{
    public static class SS
    {     
        public static List<Client> Clients = new List<Client>();
        public static List<Storage> Storages = new List<Storage>();

        public static void Wipe()
        {
            //Clients.Clear();
            Storages.Clear();
        }
    }
}
