using System.Data.SqlClient;
using server_api_demos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace server_api_demos.Services
{
    public class sqlTeacherRepo : ITeacherRepository
    {
        private string ConnectionString { get; set; }
        public sqlTeacherRepo() : this(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ExamDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {

        }
        public sqlTeacherRepo(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public List<TeachersModel> GetAllTeachers()
        {
            List<TeachersModel> teacherList = new List<TeachersModel>();
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                connection.Open();
                //Command (SQL QUEERY)
                SqlCommand allCommand = new SqlCommand("SELECT * FROM Teachers", connection);
                // READ ROW BY ROW READER
                using (var reader = allCommand.ExecuteReader())
                {
                    //Read ROW BY ROW
                    while (reader.Read())
                    {
                        TeachersModel teacherModel = new TeachersModel();
                        teacherModel.Id = reader.GetInt32(0);
                        teacherModel.Name = reader.GetString(1);
                        teacherModel.Surname = reader.GetString(2);
                        teacherList.Add(teacherModel);
                    }

                }

                 allCommand = new SqlCommand("SELECT * FROM Courses", connection);
                using (var reader = allCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string tempCourseName = reader.GetString(1);
                        var tempId = reader.GetInt32(2);
                        
                        foreach(TeachersModel t in teacherList) 
                        {
                            if (tempId==t.Id)
                                t.courses.Add(tempCourseName); // Does this work?????
                        }
                   
                    }

                }

            }
            return teacherList;

        }
        public TeachersModel GetTeacherById(int id)
        {
            TeachersModel teacher = null;
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                connection.Open();
                //Command (SQL QUEERY)
                SqlCommand allCommand = new SqlCommand("SELECT * FROM Teachers Where Id = " + id, connection);
                // READ ROW BY ROW READER
                using (var reader = allCommand.ExecuteReader())
                {
                    //Read ROW BY ROW
                    while (reader.Read())
                    {
                        teacher = new TeachersModel();
                        teacher.Id = reader.GetInt32(0);
                        teacher.Name = reader.GetString(1);
                        teacher.Surname = reader.GetString(2);
                    }

                }
            }
            return teacher;
        }



        public int AddTeacher(TeachersModel newTeacher) 
        {
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                connection.Open();
                //Command (SQL QUEERY)
                SqlCommand allCommand = new SqlCommand("INSERT INTO Teachers (Id,Name,Surname) VALUES (newTeacher.Id,newTeacher.Name,newTeacher.SurName)");
                // READ ROW BY ROW READER
               
            }
            return 1;
        }
        public bool DeleteTeacher(int id)
        {
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                connection.Open();
               
                SqlCommand allCommand = new SqlCommand("DELETE FROM Teachers WHERE Id = " + id, connection);
                return true;
            }

        }
        public bool UpdateTeacher(int id, TeachersModel teacher) 
        {
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                connection.Open();
                //Command (SQL QUEERY)
                SqlCommand allCommand = new SqlCommand("UPDATE Teachers SET Name = teacher.name,SurName=teacher.Surname WHERE Id = " + id, connection);
                // READ ROW BY ROW READER

            }
            return true;
        }
        

        public List<TeachersModel> GetTeachersByName(string name)
        {
            string FirstName = "'" + name + "'";
            List<TeachersModel> teacherList = new List<TeachersModel>();
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                connection.Open();
                //Command (SQL QUEERY)
               // string nameQuery = "SELECT * FROM Teachers WHERE Name = @FirstName";
               // SqlCommand allCommand = new SqlCommand(nameQuery, connection);
                SqlCommand allCommand = new SqlCommand("SELECT * FROM Teachers WHERE Name =" + FirstName, connection);
                // READ ROW BY ROW READER
                using (var reader = allCommand.ExecuteReader())
                {
                    //Read ROW BY ROW
                    while (reader.Read())
                    {
                        TeachersModel teacher = new TeachersModel();
                        teacher.Id = reader.GetInt32(0);
                        teacher.Name = reader.GetString(1);
                        teacher.Surname = reader.GetString(2);
                        teacherList.Add(teacher);
                    }
                }
            }
            return teacherList;
        }

        
        public List<TeachersModel> GetTeachersBySurName(string Surname)
        {
            List<TeachersModel> teacherList = new List<TeachersModel>();
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                connection.Open();
                //Command (SQL QUEERY)
                SqlCommand allCommand = new SqlCommand("SELECT * FROM Teachers Where SurName = " + Surname, connection);
                // READ ROW BY ROW READER
                using (var reader = allCommand.ExecuteReader())
                {
                    //Read ROW BY ROW
                    while (reader.Read())
                    {
                        TeachersModel teacher = new TeachersModel();
                        teacher.Id = reader.GetInt32(0);
                        teacher.Name = reader.GetString(1);
                        teacher.Surname = reader.GetString(2);
                    }

                }
            }
            return teacherList;
        }

        public List<string> GetCoursesList(int id)
        {
            List<string> courses = new List<string>();
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                connection.Open();
                //Command (SQL QUEERY)
                SqlCommand allCommand = new SqlCommand("SELECT * FROM Courses Where Id = " + id, connection);
                // READ ROW BY ROW READER
                using (var reader = allCommand.ExecuteReader())
                {
                    //Read ROW BY ROW
                    while (reader.Read())
                    {
                        string course = reader.GetString(1);
                    }

                }
            }
            return courses;

        }

        /*public List<int> GetTeachersWhoTeachCourse(string course)
        {
            List<TeachersModel> teachers = new List<TeachersModel>();
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                connection.Open();
                //Command (SQL QUEERY)
                SqlCommand allCommand = new SqlCommand("SELECT * FROM courses Where TeacherId = " + id, connection);
                // READ ROW BY ROW READER
                using (var reader = allCommand.ExecuteReader())
                {
                    //Read ROW BY ROW
                    while (reader.Read())
                    {
                        string course = reader.GetString(1);
                    }

                }
            }
            return courses;
        }*/

       
    }
}

