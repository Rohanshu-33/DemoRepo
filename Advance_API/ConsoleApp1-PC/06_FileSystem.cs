using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1_PC
{
    internal class FileSystem
    {
        public static void FileSystemDemo()
        {
            // FileInfo
            FileInfo fi = new FileInfo("file1.txt");
            Console.WriteLine(fi.Exists);
            Console.WriteLine(fi.FullName);
            Console.WriteLine(fi.IsReadOnly);
            Console.WriteLine(fi.Name);
            Console.WriteLine(fi.Extension);
            Console.WriteLine(fi.CreationTime);
            Console.WriteLine(fi.CreationTimeUtc);
            Console.WriteLine(fi.Directory);
            Console.WriteLine(fi.DirectoryName);
            Console.WriteLine(fi.LastAccessTime);
            Console.WriteLine(fi.LastWriteTime);
            Console.WriteLine(fi.Length);

            string newFileName = "renamed_example.txt";
            fi.MoveTo(newFileName);

            string copyPath = "copied_example.txt";
            fi.CopyTo(copyPath, overwrite: true);

            fi.Delete();
        }
    }
}
