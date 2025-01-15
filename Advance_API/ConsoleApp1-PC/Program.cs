using System;
using ConsoleApp1_AdvanceC_;
using ConsoleApp1_PC;
using EmployeeDB;
class Program
{
    static void Main(String[] args)
    {
        Console.WriteLine("Start of Main Program.\n");
        Breakpoints.BreakPointsDemo();
        //ConditionalCompilation.ConditionalCompilationDemo();

        //Dummy1.Display();  // static class demo

        //Dummy2 tmp = new Dummy2();  // abstract class demo
        //tmp.GreetUser();

        //Employee emp = new Employee(); // partial class demo

        //SealedClass sl = new SealedClass(); // sealed class demo

        //Generics.GenericsDemo();  // generic method and class demo

        //GenericInterface.GenericInterfaceDemo(); // generic interface demo

        //FileSystem.FileSystemDemo(); // fileinfo class demo

        //StreamReaderDemo.StreamReaderDemoMethod(); // stream reader n writer

        //DirectoryAndPathDemo.DirectoryAndPathDemoMethod(); // directory and path demo

        //JSONSerialzeDeserialize.JSONSerializeDeserializeDemo();

        //XMLSerializeDeserialize.XMLSerializeDeserializeDemo();

        //Lambdas.LambdasDemo();

        //ExtensionMethods.ExtensionMethodsDemo();

        Console.WriteLine("\nEnd of Main Program.");
    }
}