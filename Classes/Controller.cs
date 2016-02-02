using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Rnet.Classes
{
    public static class Controller
    {
        private static void Window()
        {
            Application.Run(new View());
        }
        /// <summary>
        /// The client currently accesed from the terminal
        /// </summary>
        public static Client ActiveClient { get; private set; }
        /// <summary>
        /// Gets the last input entered
        /// </summary>
        public static String LastInput { get; private set; }
        /// <summary>
        /// the default color for input messages
        /// </summary>
        public static ConsoleColor DefaultInputColor { get; set; }
        public static ConsoleColor DefaultSuccesColor {get; set;}
        public static ConsoleColor DefaultErrorColor {get; set;}
        public static ConsoleColor DefaultColor { get; set; }


        public static void Connect(Client client)
        {
            ActiveClient = client;
        }

        /// <summary>
        /// Writes active client and connected storage. saves input to LastInput
        /// </summary>
        public static void ReadInput()
        {
            if (ActiveClient != null)
            {
                if (ActiveClient.ConnectedTo != null)
                {
                    ConsoleHelper.Write(ActiveClient.ID + "@" + ActiveClient.ConnectedTo.ID + ">", DefaultInputColor);
                }
                else
                {
                    ConsoleHelper.Write(ActiveClient.ID + ">", DefaultInputColor);
                }                
            }
            else
            {
                ConsoleHelper.Write("Terminal>", DefaultInputColor);
            }
            LastInput = Console.ReadLine();
        }
        /// <summary>
        /// Shows a list of clients to connect the terminal to
        /// </summary>
        public static void ConnectClient()
        {
            ConsoleHelper.WriteLine("Select a client to connect to", ConsoleColor.Yellow);

            foreach (Client c in SS.Clients)
            {
                Console.WriteLine(c.ID);
            }

            ReadInput();

            if (LastInput == "exit")
            {
                ConsoleHelper.Wait("Program terminated, press any key to quit");
                Environment.Exit(0);                
            }

            foreach (Client c in SS.Clients)
            {
                if (c.ID == LastInput)
                {
                    ConsoleHelper.WriteLine("Connecting to " + c.ID, DefaultSuccesColor);
                    ActiveClient = c;
                    ConsoleHelper.WriteLine("Succesfully connected to " + c.ID, DefaultSuccesColor);
                    Welcome();
                    ClientMain();
                    return;
                }
            }
            ConsoleHelper.WriteLine("Could not find requested client", DefaultErrorColor);
            ConnectClient();
        }
        /// <summary>
        /// Disconnects the terminal from the current client. Doesn't log the client out of te storage, if any.
        /// </summary>
        public static void DisconnectClient()
        {
            ConsoleHelper.WriteLine("Disconnecting from " + ActiveClient.ID, DefaultSuccesColor);
            ActiveClient = null;
            ConsoleHelper.WriteLine("Disconnected", DefaultSuccesColor);
            ConnectClient();
        }
        /// <summary>
        /// Welcomes the user and lists the memory
        /// </summary>
        public static void Welcome()
        {
            Console.WriteLine("Welcome to " + ActiveClient.ID);
            if (ActiveClient.Memory != null)
            {
                Console.Write("Current file in memory: ");
                ConsoleHelper.WriteLine(ActiveClient.Memory.Name, ConsoleColor.Yellow);
            }
        }
        /// <summary>
        /// The main menu for a client
        /// </summary>
        public static void ClientMain()
        { 
            ReadInput();

            //all options
            if (LastInput == "c" || LastInput == "connect")
            {
                ConnectStorage();
                ClientMain();
                return;
            }
            if (LastInput == "disconnect" || LastInput == "dc")
            {
                DisconnectStorage();
            }
            else if (LastInput == "terminal" || LastInput == "term")
            {
                DisconnectClient();
                return;
            }
            else if (LastInput == "ls")
            {
                List();
                ClientMain();
                return;
            }
            else if (LastInput == "download" || LastInput == "dl")
            {
                DownloadFile();
                ClientMain();
                return;
            }
            else if (LastInput == "memory" || LastInput == "mem")
            {
                Memory();
                ClientMain();
                return;
            }
            else if (LastInput == "log")
            {
                Log();
                ClientMain();
                return;
            }
            else if (LastInput == "upload" || LastInput == "up")
            {
                Upload();
                ClientMain();
                return;
            }
            else if (LastInput == "view" || LastInput == "v")
            {
                View();
                ClientMain();
                return;
            }
            else if (LastInput == "test")
            {
                Test();
                ClientMain();
                return;
            }
            else if (LastInput == "dev")
            {
                Dev();
                ClientMain();
                return;
            }
            ClientMain();
        }
        /// <summary>
        /// Connect a client to a storage
        /// </summary>
        private static void ConnectStorage()
        {
            ConsoleHelper.WriteLine("Select a storage to connect to", ConsoleColor.Yellow);

            foreach (Storage s in SS.Storages)
            {
                Console.WriteLine(s.ID);
            }

            ReadInput();

            foreach (Storage s in SS.Storages)
            {
                if (s.ID == LastInput)
                {
                    ActiveClient.Connect(s);
                    return;
                }
            }
            ConsoleHelper.WriteLine("Could not find requested Storage", DefaultErrorColor);
            ConnectStorage();
        }
        /// <summary>
        /// Disconnects from the current storage
        /// </summary>
        private static void DisconnectStorage()
        {
            ActiveClient.Disconnect();
            ClientMain();
        }
        /// <summary>
        /// Lists the contents of the currently connected storage
        /// </summary>
        private static void List()
        {
            if (ActiveClient.ConnectedTo == null)
            {
                ConsoleHelper.WriteLine("Not connected to a storage", DefaultErrorColor);
                ClientMain();
                return;
            }
            else if (ActiveClient.ConnectedTo.Files.Count <= 0)
            {
                ConsoleHelper.WriteLine("Storage is empty", DefaultErrorColor);
                ClientMain();
                return;
            }

            foreach (File f in ActiveClient.ConnectedTo.Files)
            {
                Console.WriteLine(f.Name);
            }
            ClientMain();
        }
        private static void DownloadFile()
        {
            if (ActiveClient.ConnectedTo == null)
            {
                ConsoleHelper.WriteLine("Not connected to a storage", Controller.DefaultErrorColor);
                return;
            }

            ConsoleHelper.WriteLine("Download which file?", Controller.DefaultColor);
            Controller.ReadInput();

            ActiveClient.Download();
            ClientMain();
        }
        private static void Memory()
        {
            if (ActiveClient.Memory != null)
            {
                ConsoleHelper.WriteLine("Current file in memory: " + ActiveClient.Memory.Name, ConsoleColor.Yellow);
                return;
            }
            ConsoleHelper.WriteLine("Memory is empty", DefaultErrorColor);
        }
        private static void Log()
        {
            if (ActiveClient.ConnectedTo == null)
            {
                ConsoleHelper.WriteLine("Not connected to a storage", DefaultErrorColor);
                return;
            }
            ActiveClient.ConnectedTo.ViewLog(ActiveClient);
        }
        private static void Upload()
        {
            if (ActiveClient.ConnectedTo == null)
            {
                ConsoleHelper.WriteLine("Not connected to a storage", DefaultErrorColor);
                return;
            }
            if (ActiveClient.Memory == null)
            {
                ConsoleHelper.WriteLine("No file in memory", DefaultErrorColor);
                return;
            }

            ActiveClient.ConnectedTo.UploadFile(ActiveClient.Memory, ActiveClient);
        }
        private static void View()
        {
            if (ActiveClient.Memory == null)
            {
                ConsoleHelper.WriteLine("No file in memory", DefaultErrorColor);
                return;
            }

            ConsoleHelper.WriteLine("Viewing " + ActiveClient.Memory.Name, DefaultColor);
            ConsoleHelper.WriteLine(ActiveClient.Memory.Content, ConsoleColor.White);
            ConsoleHelper.WriteLine("End of file", DefaultColor);
        }
        private static void Test()
        {
            ConsoleHelper.WriteLine("Running test code", DefaultColor);
            Save.SaveAll();
        }
        private static void Dev()
        {
            ConsoleHelper.WriteLine("Opening dev window", DefaultColor);
            Thread formThread = new Thread(new ThreadStart(Window));
            formThread.Start();
            while (!formThread.IsAlive) ;
            Thread.Sleep(1);
        }
    }
}
