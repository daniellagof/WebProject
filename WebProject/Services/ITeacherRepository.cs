using server_api_demos.Models;
using System.Collections.Generic;

namespace server_api_demos.Services
{
 public interface ITeacherRepository
    {
         int AddTeacher(TeachersModel newTeacher);
         bool DeleteTeacher(int id);
         bool UpdateTeacher(int id, TeachersModel teacher);
         TeachersModel GetTeacherById(int id);
         List<TeachersModel> GetAllTeachers(); // get all teachers
         List<TeachersModel> GetTeachersByName(string name); 
         List<TeachersModel> GetTeachersBySurName(string Surname);
         List<string> GetCoursesList(int id); // get the courses the teacher teachers
      //   List<int> GetTeachersWhoTeachCourse(string course);


    }


}