using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1_PC
{
    public interface IGenericInterface<T>
    {
        void Set(T value);
        T Get();
    }

    class StringClass : IGenericInterface<string>
    {
        string value;

        public void Set(string val)
        {
            value = val;
            Console.WriteLine($"\nString value is being set.");
        }

        public string Get()
        {
            return value;
        }
    }

    class IntClass : IGenericInterface<int>
    {
        int value;

        public void Set(int val)
        {
            value = val;
            Console.WriteLine($"\nInteger value is being set.");
        }

        public int Get()
        {
            return value;
        }
    }

    internal class GenericInterface
    {
        internal static void GenericInterfaceDemo()
        {
            IGenericInterface<string> s = new StringClass();
            s.Set("Hello, Generic Interface!");
            Console.WriteLine(s.Get());

            IGenericInterface<int> i = new IntClass();
            i.Set(42);
            Console.WriteLine(i.Get());
        }
        
    }
}
