using Microsoft.AspNetCore.Mvc;
using server_api_demos.Models;
using server_api_demos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace server_api_demos.Controllers
{
    [Route("exam")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private sqlExamRepo repo = new sqlExamRepo();

        // GET: api/<ExamController>
        [HttpGet]
        public IEnumerable<ExamModel> ListAllExams()
        {
            return repo.GetAllExams();
        }

        // GET api/<ExamController>/5
        [HttpGet("GetById{id}")]
        public ExamModel GetById(int id)
        {
            return repo.GetExamById(id);
        }

        
        //add exam
        [HttpPost]
        public int Post(ExamModel exam)
        {
            int id = repo.AddExam(exam);
            return id;
        }

        // PUT api/<ExamController>/5]
        //update exam
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ExamModel exam)
        {
            repo.UpdateExam(id, exam);
        }

        [HttpDelete("Delete{id}")]
        public bool Delete(int id)
        {
            bool deleted = repo.DeleteExam(id);
            return deleted;
        }

       [HttpGet("GetAllExamsByTeacherId{id}")]
       public List<ExamModel> GetAllExamsByTeacherId(int id)
        {
            repo = new sqlExamRepo();
            return repo.GetAllExamsByTeacherId(id);
        }

       [HttpGet("GetExambyTitle{title}")]
       public ExamModel GetAllExamsByTitle(string title)
        {
            repo = new sqlExamRepo();
            return repo.GetExamWithTitle(title);
        } 


    }
}
