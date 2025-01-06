using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1_PC
{

    // generic class
    class GenericClass<T>
    {
        internal T var1;
        public GenericClass(T var1)
        {
            this.var1 = var1;
        }

        public T Get()
        {
            return this.var1;
        }
    }

    internal class Generics
    {

        // generic method
        public static void Add<T>(T a)
        {
            Console.WriteLine($"Value of variable is {a}");
        }

        // inheriting a generic class

        public static void GenericsDemo()
        {
            // generic method demo
            //Add(1);
            //Add("hi");
            //Add(1.1);

            // generic class demo
            GenericClass<int> obj1 = new GenericClass<int>(2);
            GenericClass<string> obj2 = new GenericClass<string>("hello");
            GenericClass<char> obj3 = new GenericClass<char>('Z');
            Console.WriteLine(obj1.Get());
            Console.WriteLine(obj2.Get());
            Console.WriteLine(obj3.Get());
        }
    }

}
