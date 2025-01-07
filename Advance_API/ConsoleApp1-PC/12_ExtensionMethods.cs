using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeDB;

namespace ConsoleApp1_PC
{
    public static class EmployeeExtension
    {
        public static string ShowDetailedSalary(this EmployeeDB.Employee empObj)
        {
            double pf = 2000.00;
            double stocks = 10000;
            double totalSalary = empObj.Salary + (pf + stocks) * 12;
            return $"Base Salary: {empObj.Salary}\nPF: {pf}\nStocks: {stocks}\nTotal Salary: {totalSalary}";
        }
    }

    internal class ExtensionMethods
    {
        internal static void ExtensionMethodsDemo()
        {
            EmployeeDB.Employee emp = new EmployeeDB.Employee(1, "rohanshu", 540000.00);
            emp.ShowDetails();
            Console.WriteLine(emp.ShowDetailedSalary());
        }
    }

}
