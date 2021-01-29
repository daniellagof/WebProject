using server_api_demos.Models;
using System.Collections.Generic;

namespace server_api_demos.Services
{
    public interface IExamsRepository
    {
        int AddExam(ExamModel newExam);
        bool DeleteExam(int id);
        List<ExamModel> GetAllExams();
        List<ExamModel> GetAllExamsByTeacherId(int teacherId);
        ExamModel GetExamWithTitle(string title);
        ExamModel GetExamById(int id);
        ExamModel GetExamByIdWithQuestions(int id);
        bool UpdateExam(int id, ExamModel exam);
    }
}