using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Rnet.Classes
{
    internal static class Paths
    {
        public static string StoragePath { get { return @"D:\Random Stuff\Rnet\storages.txt"; } private set { ;} }
        public static string ClientPath { get { return @"D:\Random Stuff\Rnet\clients.txt"; } private set { ;} }        
        public static string FilePath { get { return @"D:\Random Stuff\Rnet\files.txt"; } private set { ;} }
    }

    /// <summary>
    /// Saves a snapshot of the network as a whole, and saves it to 3 files, clients.txt, storages.txt and files.txt. Note that a save completely overwrites a file. 
    /// </summary>
    public static class Save
    {
        public static void SaveStorages()
        {
            System.IO.File.Delete(Paths.StoragePath);
            foreach (Storage s in SS.Storages)
            {
                string ret = "";
                ret += s.ID;
                ret += "\r\n#LOG";

                foreach (string l in s.Log)
                {
                    ret += "\r\n" + l;
                }
                ret += "\r\n#END";
                System.IO.File.AppendAllText(Paths.StoragePath, ret + "\r\n");
            }
        }

        public static void SaveClients()
        {
            System.IO.File.Delete(Paths.ClientPath);
            foreach (Client c in SS.Clients)
            {
                string ret = "";
                ret += c.ID;

                if (c.ConnectedTo != null)
                {
                    ret += ",";
                    ret += c.ConnectedTo.ID;
                }
                else
                {
                    ret += ",";
                    ret += "null";
                }
                System.IO.File.AppendAllText(Paths.ClientPath, ret + "\r\n");
            }
        }

        public static void SaveFiles()
        {
            System.IO.File.Delete(Paths.FilePath);

            foreach (Storage s in SS.Storages)
            {                
                foreach (File f in s.Files)
                {
                    string ret = "";
                    ret += f.Name;
                    ret += "," + s.ID;
                    ret += "," + f.Created;
                    ret += "," + f.LastEdited;
                    ret += "," + f.Version;
                    ret += "\r\n#CONTENT";
                    ret += "\r\n" + f.Content;
                    ret += "\r\n#END";
                    System.IO.File.AppendAllText(Paths.FilePath, ret + "\r\n");
                }
            }
            foreach (Client c in SS.Clients)
            {                
                if (c.Memory != null)
                {
                    string ret = "";
                    ret += c.Memory.Name;
                    ret += "," + c.ID;
                    ret += "," + c.Memory.Created;
                    ret += "," + c.Memory.LastEdited;
                    ret += "," + c.Memory.Version;
                    ret += "\r\n#CONTENT";
                    ret += "\r\n" + c.Memory.Content;
                    ret += "\r\n#END";
                    System.IO.File.AppendAllText(Paths.FilePath, ret + "\r\n");
                }
            }
        }

        public static void SaveAll()
        {
            SaveStorages();
            SaveClients();
            SaveFiles();
        }
    }

    public static class Load
    {
        public static void LoadStorages()
        {
            Storage.NextAvailableID = 0;
            SS.Wipe();

            List<string> read = new List<string>();
            string line;

            if (!System.IO.File.Exists(Paths.StoragePath))
            {
                System.IO.File.Create(Paths.StoragePath);
                System.Threading.Thread.Sleep(100);
            }

            // Read the file and display it line by line.
            System.IO.StreamReader file =
               new System.IO.StreamReader(Paths.StoragePath);
            while ((line = file.ReadLine()) != null)
            {
                read.Add(line);
            }
            file.Close();

            int pos = 0; //0 = id, 2 = start log, -1 = end
            List<string> ret = new List<string>();
            foreach (string s in read)
            {
                if (s.Contains("s"))
                {
                    pos = 0;
                }
                else if (s.Contains("#LOG"))
                {
                    pos = 1;
                }

                if (pos > 1 && !s.Contains("#END"))
                {
                    ret.Clear();
                    ret.Add(s);
                }
                else if (s.Contains("#END"))
                {
                    pos = -1;
                    new Storage(ret);
                    ret.Clear();
                }
                
            }

        }

        public static void LoadClients()
        {

        }

        public static void LoadFiles()
        {

        }
    }
}
