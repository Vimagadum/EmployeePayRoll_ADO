using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_PayRoll__
{
    public class EmployeeRepo
    {
        //connecting string
        public static string connectionString = @"Data Source=LAPTOP-DI3UPG04;Initial Catalog=Employee_payroll;Integrated Security=True";
        SqlConnection connection = null;

        public void GetAllEmployee()
        {
            try
            {
                //creating class object
                EmployeePayRoll employeePayroll = new EmployeePayRoll();
                using (connection = new SqlConnection(connectionString))
                {
                    string query = @"SELECT * FROM emp_payroll;";

                    //define SqlCommand Object
                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();
                    Console.WriteLine("connected");
                    SqlDataReader dr = cmd.ExecuteReader();
                    readDataRows(dr, employeePayroll);
                    dr.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                //close connection
                connection.Close();
            }
        }
        public int UpdateEmployeeSalary()
        {
            EmployeePayRoll emp = new EmployeePayRoll();
            emp.employeeName = "roshni";
            emp.basicPay = 300000;
            emp.department = "BackEnd";
            emp.address = "Belgaum";
            emp.phoneNumber = "912345678";
            emp.deductions = 5000;
            emp.taxablePay = 15000;
            emp.tax = 5000;
            emp.netPay = 275000;
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand("StoreUpdateSalary", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Name", emp.employeeName);
                    sqlCommand.Parameters.AddWithValue("@BasicPay", emp.basicPay);
                    sqlCommand.Parameters.AddWithValue("@department", emp.department);
                    sqlCommand.Parameters.AddWithValue("@address", emp.address);
                    sqlCommand.Parameters.AddWithValue("@PhoneNumber", emp.phoneNumber);
                    sqlCommand.Parameters.AddWithValue("@Deduction", emp.deductions);
                    sqlCommand.Parameters.AddWithValue("@TaxablePay", emp.taxablePay);
                    sqlCommand.Parameters.AddWithValue("@Tax", emp.tax);
                    sqlCommand.Parameters.AddWithValue("@NetPay", emp.netPay);


                    int result = sqlCommand.ExecuteNonQuery();
                    if (result == 1)
                        Console.WriteLine("Salary is updated...");
                    else
                        Console.WriteLine("Salary not updated!");
                    return result;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        static void readDataRows(SqlDataReader dr, EmployeePayRoll employeePayroll)
        {
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    employeePayroll.employeeId = dr.GetInt32(0);
                    employeePayroll.employeeName = dr.GetString(1);
                    employeePayroll.basicPay = dr.GetDecimal(2);
                    employeePayroll.startDate = dr.GetDateTime(3);
                    employeePayroll.Gender = dr.GetString(4);
                    employeePayroll.phoneNumber = dr.GetString(5);
                    employeePayroll.address = dr.GetString(6);
                    employeePayroll.department = dr.GetString(7);
                    employeePayroll.deductions = dr.GetDecimal(8);
                    employeePayroll.taxablePay = dr.GetDecimal(9);
                    employeePayroll.tax = dr.GetDecimal(10);
                    employeePayroll.netPay = dr.GetDecimal(11);

                    //Display retrieved record
                    Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}", employeePayroll.employeeId, employeePayroll.employeeName, employeePayroll.phoneNumber, employeePayroll.address, employeePayroll.department, employeePayroll.Gender, employeePayroll.basicPay, employeePayroll.deductions, employeePayroll.taxablePay, employeePayroll.tax, employeePayroll.netPay);
                    Console.WriteLine("\n");
                }
            }
            else
            {
                Console.WriteLine("No data found!");
            }

        }
        public void GetEmployeeDetailsByDate()
        {
            EmployeePayRoll employee = new EmployeePayRoll();
            DateTime startDate = new DateTime(2015, 01, 02);
            DateTime endDate = new DateTime(2020, 04, 15);
            try
            {
                //establish connection
                using (connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand("StoreGetDataByDateRange", connection);
                    //stored procedure
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    //pass parameters
                    sqlCommand.Parameters.AddWithValue("@StartDate", startDate);
                    sqlCommand.Parameters.AddWithValue("@EndDate", endDate);
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    //read all rows & display data
                    readDataRows(reader, employee);
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                //close connection
                connection.Close();
            }
        }

    }
}
