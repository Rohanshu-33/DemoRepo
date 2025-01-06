using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1_AdvanceC_
{
    internal class Breakpoints
    {
        /*
        Debug points - Breakpoints are markers in the code to pause execution of program during debugging.
        It allows us to inspect state of application at points to help fix issues.

        Types of breakpoints:
        1) Simple - stops execution whenever code hits that line.
        2) Conditional - stops only if specified condition is true.
        3) Hit count - stops execution after specified amount of hits.
        4) Tracepoint - outputs custom message to output window rather than pausing execution.
        5) Data - pauses when a variable field/property value changes.
        */
        public static void BreakPointsDemo()
        {
            // 1) Simple:
            int a = 4;
            int b = 6;
            Console.WriteLine("Before Add.");
            Console.WriteLine(Add(a, b));
            Console.WriteLine("After Add.");



            // 2) Conditional
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Iteration number: {i}");
            }

            // 3) Hit count
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Iteration number: {i}");
            }

            // 4) tracepoint
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Iteration number: {i}");
            }

            // 5) Data - sstart debug, go to watch window and inspect variables.

        }

        internal static int Add(int a, int b)
        {
            return a + b;
        }
    }
}
