using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesDirectories
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Source source = new Source();
            source.GetFilesFoldersDirectory();
            Console.ReadLine();
        }
    }
}
