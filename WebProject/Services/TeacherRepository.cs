using server_api_demos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace server_api_demos.Services
{

    public class TeacherRepository : ITeacherRepository
    {
        private static List<TeachersModel> _allTeachers = null;

        public TeacherRepository()
        {
            _allTeachers = new List<TeachersModel>();
            TeacherRepository.LoadMockData();
        }
        private static void LoadMockData()
        {
            TeachersModel teacherMock = new TeachersModel();
            {
            teacherMock.Id = 3064;
            teacherMock.Name = "Tamar";
            teacherMock.Surname = "Zemach";
            teacherMock.courses.Add("Calculus2"); // is this really how you add a course?
            teacherMock.courses.Add("Real Time");
            teacherMock.courses.Add("Operating Systems");
            };
            _allTeachers.Add(teacherMock);

            TeachersModel teacherMock1 = new TeachersModel();
            {
            teacherMock1.Id = 30644;
            teacherMock1.Name = "Tamar";
            teacherMock1.Surname = "Cohen";
            teacherMock1.courses.Add("Migdar"); // is this really how you add a course?
            teacherMock1.courses.Add("Law");
            teacherMock1.courses.Add("Calculus2");
            };
            _allTeachers.Add(teacherMock1);

        }
        public TeachersModel GetTeacherById(int id)
        {
            foreach (TeachersModel teacher in _allTeachers)
            {
                if (teacher.Id == id)
                    return teacher;
            }
            return null;
        }
        public List<TeachersModel> GetAllTeachers() // get all teachers
        {
            return _allTeachers;
        }
        public List<TeachersModel> GetTeachersByName(string name)
         {
            List<TeachersModel> teacherWithThisName = new List<TeachersModel>();
            foreach(TeachersModel teacher in _allTeachers){
                if(name == teacher.Name){
                   teacherWithThisName.Add(teacher); 
                }
            }
            return teacherWithThisName; 
         } 
        
        
        public List<TeachersModel> GetTeachersBySurName(string Surname)
        {
            List<TeachersModel> teacherWithThisSurName = new List<TeachersModel>();
            foreach(TeachersModel teacher in _allTeachers){
                if(Surname == teacher.Surname){
                    teacherWithThisSurName.Add(teacher); 
                }
            }
            return teacherWithThisSurName; 
        } 
      

        public List<String> GetCoursesList(int id) 
        {
            return GetTeacherById(id).courses;
        }

        public List<int> GetTeachersWhoTeachCourse(string course)
        {
            List<int> teacherlist = new List<int>(); 
            foreach(TeachersModel teacher in _allTeachers){
                for(int i=0; i<teacher.courses.Count(); i++){
                    if (course == teacher.courses[i]){
                         teacherlist.Add(teacher.Id);
                    }
                }
            }
            return teacherlist;

        }
        
        public int AddTeacher(TeachersModel newTeacher)
        {
            _allTeachers.Add(newTeacher);
            return newTeacher.Id;
        }

        public bool DeleteTeacher(int id)
        {
             var temp = GetTeacherById(id);
            if (temp != null)
            {
                _allTeachers.Remove(temp);
                return true;
            }
            return false;
        }
        
        public bool UpdateTeacher(int id, TeachersModel teacher){
            var temp = GetTeacherById(id);
            if (temp != null)
            {
                temp.Id = teacher.Id;
                temp.Name = teacher.Name;
                temp.Surname = teacher.Surname;
                //need to copy the list of courses 
                return true;
            }
            return false;
        }



    }


}