using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rnet.Classes
{
    public class File
    {
        /// <summary>
        /// The global maximum characters a file can contain. Any edit that would go over this will fail. Note the a storage unit can have a custom maximum, which is locally enforced
        /// </summary>
        public static int MaxChar { get; private set; }

        public string name { get; private set;}
        public string content { get; private set; }
        public DateTime created { get; private set; }
        public DateTime lastEdited { get; private set; }

        public File(string name)
        {
            this.name = name;
            this.created = DateTime.Now;
            this.lastEdited = DateTime.Now;
        }
        public File(string name, string content)
        {
            this.name = name;
            this.content = content;
            this.created = DateTime.Now;
            this.lastEdited = DateTime.Now;
        }

        /// <summary>
        /// Completely rewrites the content of a file
        /// </summary>
        /// <param name="content"></param>
        public void Overwrite(string content)
        {
            if (content.Length > MaxChar)
            {
                throw new FileTooBigException("The filesize would be too big");
            }
            else
            {
                this.content = content;
                this.lastEdited = DateTime.Now;
            }
        }

        /// <summary>
        /// appends the given content on a new line
        /// </summary>
        /// <param name="content"></param>
        public void Append(string content)
        {
            string newContent = this.content + "\r\n" + content;

            if (newContent.Length > MaxChar)
            {
                throw new FileTooBigException("The filesize would be too big");
            }
            else
            {
                this.content = newContent;
                this.lastEdited = DateTime.Now;
            }
        }
    }
}
