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

        private int id;

        public string ID { get { return "s" + Convert.ToString(this.id); } private set { ;} }
        public List<File> Files { get; private set; }
        /// <summary>
        /// A log of all actions performed on this storage. Format: dateTime - Client action
        /// </summary>
        public List<string> Log { get; private set; }

        public Storage()
        {
            this.id = NextAvailableID;
            NextAvailableID++;
            this.Files = new List<File>();
            this.Log = new List<string>();
            this.Log.Add(DateTime.Now + " - Initiated");
        }
        public Storage(List<string> log)
        {
            this.id = NextAvailableID;
            NextAvailableID++;
            this.Files = new List<File>();
            this.Log = log;
            SS.Storages.Add(this);
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
            ConsoleHelper.WriteLine("Copying " + file.Name, Controller.DefaultColor);
            File ret = new File(file);
            this.Log.Add(DateTime.Now + " - " + client.ID + " initiated a download for " + file.Name);
            ConsoleHelper.WriteLine("Succesfully copied " + file.Name, Controller.DefaultSuccesColor);
            return ret;
        }
        /// <summary>
        /// Views the log
        /// </summary>
        /// <param name="client">The client that makes the request, for logging</param>
        public void ViewLog(Client client)
        {       
            foreach (string s in this.Log)
            {
                ConsoleHelper.WriteLine(s, Controller.DefaultColor);
            }
            ConsoleHelper.WriteLine("End of file", Controller.DefaultSuccesColor);

            this.Log.Add(DateTime.Now + " - " + client.ID + " viewed log");
        }
        /// <summary>
        /// Upload a file to the storage
        /// </summary>
        /// <param name="file"></param>
        /// <param name="client"></param>
        public void UploadFile(File file, Client client)
        {
            foreach (File f in this.Files)
            {
                if (f.Name == file.Name)
                {
                    ConsoleHelper.WriteLine("Uploading file", Controller.DefaultColor);
                    f.Update(file);
                    ConsoleHelper.WriteLine("Upload succesfull", Controller.DefaultSuccesColor);

                    Log.Add(DateTime.Now + " - " + client.ID + " uploaded " + file.Name + " version " + file.Version);
                    return;
                }
            }
            ConsoleHelper.WriteLine("Could not find file. Creating new file", Controller.DefaultColor);
            file.VersionReset();
            Files.Add(file);
            ConsoleHelper.WriteLine("Upload succesfull", Controller.DefaultSuccesColor);
            Log.Add(DateTime.Now + " - " + client.ID + " uploaded " + file.Name + " version " + file.Version);
        }
    }
}
