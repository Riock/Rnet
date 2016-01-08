using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rnet.Classes
{
    public static class AddData
    {
        public static void Run()
        {
            int clients = 3;
            int storages = 5;

            //clients
            for (int i = 0; i < clients; i++)
            {
                SS.Clients.Add(new Client());
            }

            //storages
            for (int i = 0; i < storages; i++)
            {
                SS.Storages.Add(new Storage());
            }

            //add files
            SS.Storages[0].Files.Add(new File("Welcome", "Welcome to Rnet, have fun!"));
        }
    }
}
