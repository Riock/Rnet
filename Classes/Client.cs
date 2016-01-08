using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rnet.Classes
{
    public class Client
    {
        public static int NextAvailableID { get; set; }

        public string ID { get; private set; }
        /// <summary>
        /// The file currently in memory, only this file is available for manipulation
        /// </summary>
        public File Memory { get; private set; }
        public Storage ConnectedTo { get; private set; }

        public Client()
        {
            this.ID = "c" + Convert.ToString(NextAvailableID);
            NextAvailableID++;
        }

        /// <summary>
        /// Connects this client to a storage
        /// </summary>
        /// <param name="storage">The storage to connect too</param>
        public void Connect(Storage storage)
        {
            if (this.ConnectedTo != null)
            {
                ConsoleHelper.WriteLine("Disconnecting from " + this.ConnectedTo.ID, ConsoleColor.Green);
            }
            this.ConnectedTo = storage;
            ConsoleHelper.WriteLine("Connected to " + storage.ID, ConsoleColor.Green);
        }
        /// <summary>
        /// Disconnects the client from its connected storage
        /// </summary>
        public void Disconnect()
        {
            if (this.ConnectedTo == null)
            {
                ConsoleHelper.WriteLine("Not connected to a storage", Controller.DefaultErrorColor);
                return;
            }

            ConsoleHelper.WriteLine("Disconnecting from " + this.ConnectedTo.ID, ConsoleColor.Green);
            this.ConnectedTo = null;
            ConsoleHelper.WriteLine("Disconnected succesfully" , ConsoleColor.Green);
        }
    }
}
