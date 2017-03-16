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
    }
}