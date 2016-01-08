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
            this.ConnectedTo.LogConnected(this);
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
            this.ConnectedTo.LogDisconnected(this);
            this.ConnectedTo = null;
            ConsoleHelper.WriteLine("Disconnected succesfully" , ConsoleColor.Green);
        }
        /// <summary>
        /// Downloads a copy of a file to the local memory, replaces the current file in memomory
        /// </summary>
        /// <param name="file">The file to download</param>
        public void Download()
        {
            File file = null;            

            foreach (File f in this.ConnectedTo.Files)
            {
                if (f.name == Controller.LastInput)
                {
                    file = f;
                }
            }

            if (file == null)
            {
                ConsoleHelper.WriteLine(file.name + "does not exsist on " + this.ConnectedTo.ID, Controller.DefaultErrorColor);
                return;
            }

            if (Memory != null)
            {
                ConsoleHelper.WriteLine("Deleting " + Memory.name + " from memory", Controller.DefaultColor);
                Memory = null;
                ConsoleHelper.WriteLine("Memory succesfully cleared", Controller.DefaultSuccesColor);
            }

            ConsoleHelper.WriteLine("Requesting download for " + file.name, Controller.DefaultColor);
            foreach (File f in this.ConnectedTo.Files)
            {
                if (f.name == file.name)
                {
                    Memory = this.ConnectedTo.DownloadFile(f, this);
                    ConsoleHelper.WriteLine("Succesfully downloaded " + Memory.name, Controller.DefaultSuccesColor);
                    return;
                }                
            }
            ConsoleHelper.WriteLine(file.name + "does not exsist on " + this.ConnectedTo.ID, Controller.DefaultErrorColor);
        }
    }
}
