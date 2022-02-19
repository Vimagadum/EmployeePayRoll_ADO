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
            // repo.GetAllEmployee();
            //repo.UpdateEmployeeSalary();
            //repo.GetEmployeeDetailsByDate();
           string F= @"SELECT gender,COUNT(Salary) AS TotalCount,SUM(Salary) AS TotalSum, 
                                   AVG(Salary) AS AverageValue, 
                                   MIN(Salary) AS MinValue, MAX(Salary) AS MaxValue
                                   FROM emp_payroll 
                                   WHERE Gender = 'F' GROUP BY Gender;";
            string M = @"SELECT gender,COUNT(Salary) AS TotalCount,SUM(Salary) AS TotalSum, 
                                   AVG(Salary) AS AverageValue, 
                                   MIN(Salary) AS MinValue, MAX(Salary) AS MaxValue
                                   FROM emp_payroll 
                                   WHERE Gender = 'M' GROUP BY Gender;";
            repo.UsingDatabaseFunction(F);
            repo.UsingDatabaseFunction(M);

            Console.ReadLine();
        }
    }
}
