using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace DatagridViewDemo.UsingObjectDataSource.DataAccessLayer
{
    public class Employee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DepartmentName { get; set; }
        public string Salary { get; set; }
        public string Gender { get; set; }
    }

    public class EmployeeDataAccessLayer
    {
        public static List<Employee> GetAllEmployeeByDeparmentId(int DeptId)
        {
            List<Employee> emplist = new List<Employee>();

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetEmployeeByDepartmentId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter DepartmentID = new SqlParameter("@DepartmentID",DeptId);
                cmd.Parameters.Add(DepartmentID);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                
                while(rdr.Read())
                {
                    Employee emp = new Employee();
                    emp.ID = Convert.ToInt32(rdr["ID"]);
                    emp.FirstName = rdr["FirstName"].ToString();
                    emp.LastName = rdr["LastName"].ToString();
                    emp.Salary = rdr["Salary"].ToString();
                    emp.DepartmentName = rdr["DepartmentName"].ToString();
                    emp.Gender = rdr["Gender"].ToString();
                    emplist.Add(emp);
                }
                return (emplist);
           }
        }

        // added Delete functionality

        // note name of the method parameter should be same as the column name in the table
        //else exception will be thrown
        public static void deleteEmployeeRecord(int orignal_ID,string orignal_FirstName, string orignal_LastName, string orignal_Salary, string orignal_DepartmentName, string orignal_Gender)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                string queryString = "Delete from Employees where ID=@ID AND FirstName=@FirstName AND LastName=@LastName " +
                                       "AND Salary=@Salary AND Gender=@Gender";
                SqlCommand cmd = new SqlCommand(queryString, con);
                SqlParameter paramID = new SqlParameter("@ID", orignal_ID);
                cmd.Parameters.Add(paramID);

                
                SqlParameter paramName = new SqlParameter("@FirstName", orignal_FirstName);
                cmd.Parameters.Add(paramName);

                SqlParameter paramLastName = new SqlParameter("@LastName", orignal_LastName);
                cmd.Parameters.Add(paramLastName);

                SqlParameter paramSalary = new SqlParameter("@Salary", orignal_Salary);
                cmd.Parameters.Add(paramSalary);

                SqlParameter paramDepartmentName = new SqlParameter("@DepartmentName", orignal_DepartmentName);
                cmd.Parameters.Add(paramDepartmentName);

                SqlParameter paramGender = new SqlParameter("@Gender", orignal_Gender);
                cmd.Parameters.Add(paramGender);

                con.Open();
                cmd.ExecuteNonQuery();


            }
        }
    }

   
}