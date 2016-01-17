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

        public string Name { get; private set;}
        public string Content { get; private set; }
        public DateTime Created { get; private set; }
        public DateTime LastEdited { get; private set; }
        /// <summary>
        /// This file's universal version number. Use version++ when updating
        /// </summary>
        public int Version { get; private set; }

        public File(string name)
        {
            this.Name = name;
            this.Created = DateTime.Now;
            this.LastEdited = DateTime.Now;
            this.Version = 1;
        }
        public File(string name, string content)
        {
            this.Name = name;
            this.Content = content;
            this.Created = DateTime.Now;
            this.LastEdited = DateTime.Now;
            this.Version = 1;
        }
        /// <summary>
        /// Returns a copy of the given file, also keeps the version number
        /// </summary>
        /// <param name="file">File to copy</param>
        public File(File file)
        {
            this.Name = file.Name;
            this.Content = file.Content;
            this.Created = file.Created;
            this.LastEdited = file.LastEdited;
            this.Version = file.Version;
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
                this.Content = content;
                this.LastEdited = DateTime.Now;
            }
        }
        /// <summary>
        /// appends the given content on a new line
        /// </summary>
        /// <param name="content"></param>
        public void Append(string content)
        {
            string newContent = this.Content + "\r\n" + content;

            if (newContent.Length > MaxChar)
            {
                throw new FileTooBigException("The filesize would be too big");
            }
            else
            {
                this.Content = newContent;
                this.LastEdited = DateTime.Now;
            }
        }
        public void Update(File file)
        {
            this.Content = file.Content;
            this.LastEdited = DateTime.Now;
            this.Version++;
        }
        /// <summary>
        /// Sets the version back to 1, for when uploading to a new storage
        /// </summary>
        public void VersionReset()
        {
            this.Version = 1;
        }
    }
}
