using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1_PC
{
    internal class StreamReaderDemo
    {
        public static void StreamReaderDemoMethod()
        {
            string filePath = "./file2.txt";
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                writer.Write("Hello world.");
                writer.WriteLine("Line1");
                writer.WriteLine("Line2");
                writer.WriteLine("Line3");
            }
            Console.WriteLine("Data written to file successfully.");
            using (StreamReader reader = new StreamReader(filePath))
            {
                string l1 = reader.ReadLine();
                string content = reader.ReadToEnd();
                Console.WriteLine(l1 + "\ncontentvalue:" + content + " " + reader.EndOfStream);
            }
            Console.WriteLine("Data read from the file successfully.");

        }
    }
}
