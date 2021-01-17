using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryForAdoNet
{
    class StudentDal
    {
        public List<Student> GetAllStudents()
        {
            SqlConnection connection = new SqlConnection(@"server=(localdb)\mssqllocaldb;initial catalog=Student;integrated security=true");
            if (connection.State==ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand("Select * from Students",connection);
            SqlDataReader reader = command.ExecuteReader();
            List<Student> students = new List<Student>();
            while (reader.Read())
            {
                Student student = new Student();
                student.Id = Convert.ToInt32(reader["Id"]);
                student.Name = Convert.ToString(reader["Name"]);
                student.Lastname = Convert.ToString(reader["Lastname"]);
                student.Point = Convert.ToInt32(reader["Point"]);
                students.Add(student);
            }
            return students;
        }
    }
}
