using System.Data.SqlClient;
using server_api_demos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace server_api_demos.Services
{
    public class sqlExamRepo : IExamsRepository
    {

        private string ConnectionString { get; set; }
        public sqlExamRepo() : this(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ExamDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {

        }

        public sqlExamRepo(string connectionString)
        {
            this.ConnectionString = connectionString;
        }


        public List<ExamModel> GetAllExams()
        {
            List<ExamModel> examsList = new List<ExamModel>();
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                connection.Open();
                //Command (SQL QUEERY)
                SqlCommand allCommand = new SqlCommand("SELECT * FROM Exams", connection);
                // READ ROW BY ROW READER
                using (var reader = allCommand.ExecuteReader())
                {
                    //Read ROW BY ROW
                    while (reader.Read())
                    {
                        ExamModel examModel = new ExamModel();
                        examModel.Id = reader.GetInt32(0);
                        examModel.Title = reader.GetString(1);
                        examModel.DateStarted = reader.GetDateTime(2);
                        examModel.DurationMinutes = reader.GetInt32(3);
                        examModel.TeachrId = reader.GetInt32(4);
                        examsList.Add(examModel);
                    }
                }
            }
            return examsList;
        }

        public ExamModel GetExamById(int Id)
        {
            ExamModel examModel = null;
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                connection.Open();
                //Command (SQL QUEERY)
                SqlCommand allCommand = new SqlCommand("SELECT * FROM Exams WHERE Id =" + Id, connection);
                // READ ROW BY ROW READER
                using (var reader = allCommand.ExecuteReader())
                {
                    //Read ROW BY ROW
                    while (reader.Read())
                    {
                        examModel = new ExamModel();
                        examModel.Id = reader.GetInt32(0);
                        examModel.Title = reader.GetString(1);
                        examModel.TeachrId = reader.GetInt32(2);
                        examModel.DurationMinutes = reader.GetInt32(3);
                        examModel.DateStarted = reader.GetDateTime(4);
                    }
                }
            }

            return examModel;
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="newExam"></param>
        /// <returns></returns>
        public int AddExam(ExamModel newExam)
        {
           // ExamModel examModel = null;
            SqlConnection connection = null;
            int newId = -1;
            try
            {
                //01 Create Connection
                using (connection = new SqlConnection(this.ConnectionString))
                {
                    //02 Open Connection
                    connection.Open();

                    //string timeText =  newExam.DateStarted.ToString("yyyy-MM-dd HH:mm:ss");
                    // //Command (SQL QUEERY)
                    // string addExam = "INSERT INTO Exams (Title, DateStarted, DurationMinutes ,TeacherId)" +
                    //                  $" VALUES ('{newExam.Title}','{timeText}',{newExam.DurationMinutes},{newExam.TeachrId})";

                    string addExam = "INSERT INTO Exams (Title, DateStarted, DurationMinutes ,TeacherId)" +
                                     " VALUES (@Title,@DateStarted,@DurationMinutes,@TeacherId); " +
                                     "SELECT SCOPE_IDENTITY()";
                    SqlCommand addCopmmand = new SqlCommand(addExam, connection);
                    addCopmmand.Parameters.AddWithValue("@Title", newExam.Title);
                    addCopmmand.Parameters.AddWithValue("@DateStarted", newExam.DateStarted);
                    addCopmmand.Parameters.AddWithValue("@DurationMinutes", newExam.DurationMinutes);
                    addCopmmand.Parameters.AddWithValue("@TeacherId", newExam.TeachrId);

                    newId = Convert.ToInt32(addCopmmand.ExecuteScalar());

                }

                return newId;

            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }



        public bool DeleteExam(int id)
        {
            SqlConnection connection = null;
            bool isDeleted = false;
            try
            {
                //01 Create Connection
                using (connection = new SqlConnection(this.ConnectionString))
                {
                    //02 Open Connection
                    connection.Open();
                    string deleteQuery = "DELETE FROM Exams WHERE Id = @Id";
                    SqlCommand DeleteCommand = new SqlCommand(deleteQuery, connection);
                    DeleteCommand.Parameters.AddWithValue("@Id", id);

                    int roesAffected = DeleteCommand.ExecuteNonQuery();
                    if (roesAffected > 0)
                        isDeleted = true;
                }

                return isDeleted;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        public bool UpdateExam(int id, ExamModel examToUpdate)
        {
                SqlConnection connection = null;
                bool isUpdated = false;
                try
                {
                    //01 Create Connection
                    using (connection = new SqlConnection(this.ConnectionString))
                    {
                        //02 Open Connection
                        connection.Open();

                        string updatedQuery = "UPDATE Exams SET " +
                                              "Title = @Title, " +
                                              "DateStarted = @DateStarted, " +
                                              "DurationMinutes = @DurationMinutes," +
                                              "TeacherId = @TeacherId " +
                                              "WHERE Id = @Id";

                        SqlCommand updateCommand = new SqlCommand(updatedQuery, connection);
                        updateCommand.Parameters.AddWithValue("@Id", examToUpdate.Id);
                        updateCommand.Parameters.AddWithValue("@Title", examToUpdate.Title);
                        updateCommand.Parameters.AddWithValue("@DateStarted", examToUpdate.DateStarted);
                        updateCommand.Parameters.AddWithValue("@DurationMinutes", examToUpdate.DurationMinutes);
                        updateCommand.Parameters.AddWithValue("@TeacherId", examToUpdate.TeachrId);

                        int roesAffected = updateCommand.ExecuteNonQuery();
                        if (roesAffected > 0)
                            isUpdated = true; ;

                    }

                    return isUpdated;
                }
                catch (Exception ex)
                {
                    return false;
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                }
            }

        public ExamModel GetExamByIdWithQuestions(int id)
        {
            throw new NotImplementedException();
        }
        public List<ExamModel> GetAllExamsByTitle(string subTitle)
        {
            throw new NotImplementedException();
        }

        public ExamModel GetExamWithTitle(string title)
        {
            throw new NotImplementedException();
        }
        public List<ExamModel> GetAllExamsByTeacherId(int teacherId)
        {
            throw new NotImplementedException();
        }


    }
    
}
