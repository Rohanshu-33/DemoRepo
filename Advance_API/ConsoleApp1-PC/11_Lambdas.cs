using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1_PC
{
    internal class Lambdas
    {
        public static void LambdasDemo()
        {
            List<int> l = new List<int> { 1,2,3,4,5,6};

            // func have return type.
            Func<int, bool> IsEven = e => e % 2 == 0;

            l.Where(IsEven).ToList().ForEach(e => Console.WriteLine(e));

            // action don't have return type.
            Action<int> Square = e =>
            {
                Console.WriteLine(e + " " + (e * e) + " " + (e * e * e));
            };

            l.ForEach(e => Square(e));
        }
    }
}
