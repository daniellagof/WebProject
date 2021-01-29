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
        public sqlExamRepo() : this(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ExamsDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
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

        public ExamModel GetExamById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ExamModel> GetAllExamsByTeacherId(int teacherId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newExam"></param>
        /// <returns></returns>
        public int AddExam(ExamModel newExam)
        {
            throw new NotImplementedException();
        }

        public bool DeleteExam(int id)
        {
            throw new NotImplementedException();
        }



        public List<ExamModel> GetAllExamsByTitle(string subTitle)
        {
            throw new NotImplementedException();
        }



        public ExamModel GetExamByIdWithQuestions(int id)
        {
            throw new NotImplementedException();
        }
        public bool UpdateExam(ExamModel newExam)
        {
            return false;
        }

        public ExamModel GetExamWithTitle(string title)
        {
            throw new NotImplementedException();
        }

        public bool UpdateExam(int id, ExamModel exam)
        {
            throw new NotImplementedException();
        }
    }
}
