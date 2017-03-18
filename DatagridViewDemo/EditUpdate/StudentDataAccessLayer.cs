using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DatagridViewDemo.EditUpdate
{
    public class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }

    }

    public class StudentDataAccessLayer
    {

        public static List<Student> GetAllStudents()
        {
            List<Student> studentList = new List<Student>();

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("Select * from Students", con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Student student = new Student();
                    student.ID = Convert.ToInt32(rdr["ID"]);
                    student.FirstName = rdr["FirstName"].ToString();
                    student.LastName = rdr["LastName"].ToString();
                    student.Gender = rdr["Gender"].ToString();

                    studentList.Add(student);

                }
                return studentList;

            }
        }

            public static int UpdateStudentRecord(int original_ID, string original_FirstName, string original_LastName, string original_Gender, string FirstName, string LastName, string Gender,int ID)
            {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
                {
                    string queryString = "update Students SET FirstName=@FirstName,LastName =@LastName,Gender=@Gender Where FirstName=@original_FirstName AND LastName =@original_LastName AND Gender=@original_Gender AND ID=@original_ID";

                SqlCommand cmd = new SqlCommand(queryString, con);

                SqlParameter newFirstName = new SqlParameter("@FirstName", FirstName);
                SqlParameter newLastName = new SqlParameter("@LastName", LastName);
                SqlParameter newGender = new SqlParameter("@Gender", Gender);
                SqlParameter paramFirstName = new SqlParameter("@original_FirstName",original_FirstName);
                SqlParameter paramLastName = new SqlParameter("@original_LastName",original_LastName);

                SqlParameter paramGender = new SqlParameter("@original_Gender",original_Gender);
                SqlParameter paramId = new SqlParameter("@original_ID", original_ID);

                cmd.Parameters.Add(newFirstName);
                cmd.Parameters.Add(newLastName);
                cmd.Parameters.Add(newGender);
                cmd.Parameters.Add(paramFirstName);
                cmd.Parameters.Add(paramLastName);
                cmd.Parameters.Add(paramGender);
                cmd.Parameters.Add(paramId);


                con.Open();
                return cmd.ExecuteNonQuery();

                    

                }
            }

        }    
    }

    
