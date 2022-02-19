using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_PayRoll__
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sql database connectivity!");
            EmployeeRepo repo = new EmployeeRepo();
            repo.GetAllEmployee();
            repo.UpdateEmployeeSalary();
            repo.GetEmployeeDetailsByDate();
            Console.ReadLine();
        }
    }
}
