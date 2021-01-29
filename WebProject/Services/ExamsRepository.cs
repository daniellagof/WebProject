using server_api_demos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server_api_demos.Services
{
   
    public class ExamsRepository : IExamsRepository
    {
//        private string ConnectionString { get; set; }

        private static List<ExamModel> _allExams = null;

        
        public ExamsRepository()
        {
            _allExams = new List<ExamModel>();
            ExamsRepository.LoadMockData();
        }

        
        private static void LoadMockData()
        {
            ExamModel examMock = new ExamModel();
            examMock.Id = 1;//set
            examMock.TeachrId = 10;
            examMock.Title = "JS";
            examMock.DateStarted = DateTime.Now.AddDays(5);
            examMock.DurationMinutes = 30;
            examMock.Questions.Add(
             new QuestionModel()
             {
                 Id = 1,
                 QuestionText = "1 + 1 =",
                 Answer = "2",
                 Choices = new List<string> { "1", "3", "5", "2", "7" },
                 Points = 10
             }
            );

            examMock.Questions.Add(
            new QuestionModel()
            {
                Id = 2,
                QuestionText = "1 + _ = 4",
                Answer = "3",
                Choices = new List<string> { "1", "5", "3", "7", "10" },
                Points = 10
            }
           );

            _allExams.Add(examMock);


            ExamModel examMock2 = new ExamModel();
            examMock2.Id = 2;//set
            examMock2.TeachrId = 20;
            examMock2.Title = "c#";
            examMock2.DateStarted = DateTime.Now.AddDays(2);
            examMock2.DurationMinutes = 60;
            examMock2.Questions.Add(
             new QuestionModel()
             {
                 Id = 1,
                 QuestionText = "WHAT IS REPOSITORY?",
                 Answer = "2",
                 Choices = new List<string> { "DB ACCESS Pattern", "SPECIAL PROPERTY", "List Of Objects", "Methos in String Object" },
                 Points = 10
             }
            );

            _allExams.Add(examMock2);
        }

       
        public List<ExamModel> GetAllExams()
        {
            return _allExams;
        }

        
        
        public ExamModel GetExamById(int id)
        {
            foreach (ExamModel examItem in _allExams)
            {
                if (examItem.Id == id)
                    return examItem;
            }
            return null;
        }

        
        public List<ExamModel> GetAllExamsByTeacherId(int teacherId) 
        {
            var examsByTeacher = _allExams.Where(a => a.TeachrId == teacherId).ToList();
            return examsByTeacher;        
        }

       
        public ExamModel GetExamWithTitle(string title)
        {
            foreach(ExamModel exam in _allExams)
            {
                if(exam.Title == title)
                {
                    return exam;
                }
            }
            return null;
        }

        
        public ExamModel GetExamByIdWithQuestions(int id)
        {
            ExamModel e = new ExamModel();
            return e;
        }

       
       
        
        public int AddExam(ExamModel newExam)
        {
            _allExams.Add(newExam);
            return newExam.Id;
        }

       
        public bool DeleteExam(int id)
        {
            var temp = GetExamById(id);
            if (temp != null)
            {
                _allExams.Remove(temp);
                return true;
            }
            return false;

        }

        public bool UpdateExam(int id, ExamModel exam)
        {
            var temp = GetExamById(id);
            if (temp != null)
            {
                temp.Id = exam.Id;
                temp.Questions = exam.Questions;
                temp.TeachrId = exam.TeachrId;
                temp.Title = exam.Title;
                temp.DateStarted = exam.DateStarted;
                temp.DurationMinutes = exam.DurationMinutes;
                return true;
            }
            return false;
        }

    }
}
