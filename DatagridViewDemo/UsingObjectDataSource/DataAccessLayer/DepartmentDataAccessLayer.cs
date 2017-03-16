using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DatagridViewDemo.UsingObjectDataSource.DataAccessLayer
{
    public class Department
    {
        public int ID { get; set; }
        public string DepartmentName { get; set; }
    }

    public class DepartmentDataAccessLayer
    {
        public static List<Department> getAllDeparment()
        {
            List<Department> listDpt = new List<Department>();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {

                SqlCommand cmd = new SqlCommand("spGetDepartment", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Department dpt = new Department();
                    dpt.ID = Convert.ToInt32(rdr["ID"]);
                    dpt.DepartmentName = rdr["Name"].ToString();
                    listDpt.Add(dpt);
                }
                return listDpt;
            }
        }
    }
}