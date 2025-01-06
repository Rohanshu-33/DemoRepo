using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1_AdvanceC_
{

    static class StaticClass
    {
        /*
         contains only static members. no instance variables allowed.
         no instances of such classes.
         static classes are sealed, so can't be inherited.
         only static constructor are allowed.
        */
        public static string user;
        static void GreetUser()
        {
            Console.WriteLine($"Hello {user}");
        }

        // constructor
        static StaticClass()
        {
            // no parameters allowed as these are called automatically
            // are called only once in their lifetime
            Console.WriteLine("Static Constructor");
            user = "rohanshu";
        }
    }

    public class TypesOfClass
    {
        public static void Display()
        {
            StaticClass.user = "Rohanshu Banodha";
            StaticClass.GreetUser();
        }
    }

}
