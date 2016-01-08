using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rnet.Classes
{
    /// <summary>
    /// File is/would be too big, could not perform the operation
    /// </summary>
    public class FileTooBigException :Exception
    {
        public FileTooBigException()
        {

        }

        public FileTooBigException(string message)
            : base(message)
        {

        }
    }
}
