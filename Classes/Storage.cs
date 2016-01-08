using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rnet.Classes
{
    public class Storage
    {
        public static int NextAvailableID { get; set; }

        public string ID { get; private set; }
        public List<File> Files { get; private set; }
        /// <summary>
        /// The local maximum amount of characters a file can have. Note that the global limit will take priority
        /// </summary>
        public int MaxChar { get; private set; }
        /// <summary>
        /// A log of all actions performed on this storage. Format: dateTime - Client action
        /// </summary>
        public List<string> Log { get; private set; }

        public Storage()
        {
            this.ID = "s" + Convert.ToString(NextAvailableID);
            NextAvailableID++;
            this.Files = new List<File>();
            this.Log = new List<string>();
        }

        /// <summary>
        /// adds an connected entry to the log
        /// </summary>
        /// <param name="client">The client that connected to this storage</param>
        public void LogConnected(Client client)
        {
            this.Log.Add(DateTime.Now + " - " + client.ID + " Connected");
        }
        /// <summary>
        /// Adds a disconnected entry to the log
        /// </summary>
        /// <param name="client">The client that disconnected</param>
        public void LogDisconnected(Client client)
        {
            this.Log.Add(DateTime.Now + " - " + client.ID + " Disconnected");
        }
        /// <summary>
        /// Returns a copy of a file and makes a log entry
        /// </summary>
        /// <param name="file"></param>
        /// <returns>The downloaded file</returns>
        public File DownloadFile(File file, Client client)
        {
            ConsoleHelper.WriteLine("Copying " + file.name, Controller.DefaultColor);
            File ret = new File(file);
            this.Log.Add(DateTime.Now + " - " + client.ID + "initiated a download for " + file.name);
            ConsoleHelper.WriteLine("Succesfully copied " + file.name, Controller.DefaultSuccesColor);
            return ret;
        }
    }
}
