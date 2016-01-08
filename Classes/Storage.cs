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

        public Storage()
        {
            this.ID = "s" + Convert.ToString(NextAvailableID);
            NextAvailableID++;
            this.Files = new List<File>();
        }
    }
}
