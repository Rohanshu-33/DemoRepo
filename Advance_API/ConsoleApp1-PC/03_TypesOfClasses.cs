using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1_AdvanceC_
{

    // static class
    /*
     contains only static members. no instance variables allowed.
     no instances of such classes.
     static classes are sealed, so can't be inherited.
     only static constructor are allowed.
    */
    static class StaticClass
    {
        public static string user;
        internal static void GreetUser()
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

    // internal class
    internal class Dummy1
    {
        public static void Display()
        {
            //StaticClass.user = "Rohanshu Banodha";
            //StaticClass.GreetUser();
        }
    }


    // abstract class
    public abstract class AbstractClass
    {
        /*
         class declared using abstract keyword or contains abstract methods.
         no instance of such class but can have a reference to child.
         both abstract and non abstract methods.
         these cannot be sealed classes.
         can inherit one class and one or more interfaces.
         deriving class must define all abstract members of base.
         abstract methods can't have private as access modifier.
         can have instance variables.
         can have constructors.
         can be use to provide a common definition for all child classes.
        */

        public abstract void GreetUser();

        public AbstractClass()
        {
            // it will be called by child instance's constructor.
            Console.WriteLine("Abstract default constructor.");
        }
    }

    public class Dummy2 : AbstractClass
    {
        public override void GreetUser()
        {
            Console.WriteLine("Hello.");
        }

        internal Dummy2() : base()
        {
            Console.WriteLine("Child default constructor.");
        }
    }


    // partial class
    /*
     in partial class, code can be written in two or more files.
     all parts of partial class should have same access modifier.
     all definitions must be in the same assembly.
     if any part of partial class is sealed or abstract, then all parts bcome that.
     any inheritance on any part is applied to all parts automatically.
     can be used if need to work parallely with same class but many members in it.
    */
    public partial class Employee
    {
        public int part1 = 3;
        public Employee()
        {
            Console.WriteLine("Partial class constructor.");
            part2 = 7;
        }
    }

     public partial class Employee
    {
        public int part2 = 5;
    }


    // sealed class
    /*
      no inheritance possible
      can't contain abstract methods.
      they are used to avoid further inheritance.
      can be instantiated.
    */
    sealed class SealedClass
    {
        int a = 5;
        public SealedClass()
        {
            Console.WriteLine("sealed class constructor.");
        }
    }

}
