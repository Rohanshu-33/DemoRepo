//#define DEBUG

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1_AdvanceC_
{
    internal class ConditionalCompilation
    {
        public static void ConditionalCompilationDemo()
        {
            #region Demo

            #if DEBUG
                Console.WriteLine("Debug mode is ON.");
            #else
            Console.WriteLine("Release mode is ON.");  // build -> configuration manager
            #endif
            
            Console.WriteLine("Program is running.");
            #endregion
        }
    }
}
