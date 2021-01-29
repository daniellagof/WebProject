using Microsoft.AspNetCore.Mvc;
using server_api_demos.Models;
using server_api_demos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server_api_demos.Controllers
{
    [Route("teacher")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private sqlTeacherRepo repo1 = null;
        private TeacherRepository repo = null;

        //GET()  htt.../teacher/
        public IEnumerable<TeachersModel> GET()
        {
            repo1 = new sqlTeacherRepo();
            return repo1.GetAllTeachers();
        }

        [HttpPut ("{id}")]
        public void AddTeacher(int id, [FromBody] TeachersModel teacher) 
        {
            repo1 = new sqlTeacherRepo();
            repo1.AddTeacher(teacher);
        }

        

        //GET url: teacher/1
        [HttpGet("{id}")]
        public TeachersModel GetTeacherById(int id)
        {
            repo1 = new sqlTeacherRepo();
            return repo1.GetTeacherById(id);
        }
        // teacher/GetByFirstNameTamar
        [HttpGet("GetByFirstName{name}")]
        public List<TeachersModel> GetTeachersByName(string name)
        {
            
            repo1 = new sqlTeacherRepo();
            return repo1.GetTeachersByName(name);
        }

        // teacher/GetTeachersBySurNameCohen
        [HttpGet("GetTeachersBySurName{Surname}")]
        public List<TeachersModel> GetTeachersBySurName(string Surname)
        {
            repo1 = new sqlTeacherRepo();
            return repo1.GetTeachersBySurName(Surname);
        }
        
        /// <summary>
        /// //////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetTeachersByCourse{id}")]
         public List<string> GetCoursesOfTeacher(int id)
        {
            repo1 = new sqlTeacherRepo();
            return repo1.GetCoursesList(id);
            
        }

       /* [HttpGet("GetTeachersWhoTeachCourse{course}")]
         public List<int> GetTeachersOfCourse(string course)
        {
            repo = new TeacherRepository();

            return repo.GetTeachersWhoTeachCourse(course);
            
        }*/
    }
}