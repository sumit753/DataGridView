using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DatagridViewDemo
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
    }
    public class DataAccessLayer
    {
        public static List<Student> GetAllStudents()
        {
            List<Student> StudentList = new List<Student>();

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("Select * from Students",con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Student student = new Student();

                    student.Id = Convert.ToInt32(rdr["Id"]);
                    string fName = (rdr["FirstName"]).ToString();
                    string lName = rdr["LastName"].ToString();
                    student.Name = fName + " " + lName;
                    student.Gender = rdr["Gender"].ToString();

                    StudentList.Add(student);
                }
                return StudentList;
            }
        }
    }
}