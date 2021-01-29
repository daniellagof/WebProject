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
        private ExamsRepository repo = null;

        // GET: api/<ExamController>
        [HttpGet]
        public IEnumerable<ExamModel> ListAllExams()
        {
            repo = new ExamsRepository();
            return repo.GetAllExams();
        }

        // GET api/<ExamController>/5
        [HttpGet("GetById{id}")]
        public ExamModel GetById(int id)
        {
            repo = new ExamsRepository();
            return repo.GetExamById(id);
        }

        // POST api/<ExamController>
        //add exam
        [HttpPost]
        public int Post([FromBody] ExamModel exam)
        {
            var newExm = repo.AddExam(exam);
            return newExm;
        }

        // PUT api/<ExamController>/5]
        //update exam
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ExamModel exam)
        {
            repo.UpdateExam(id, exam);
        }

        // DELETE api/<ExamController>/5
        [HttpDelete("Delete{id}")]
        public bool Delete(int id)
        {
            bool deleted = repo.DeleteExam(id);
            return deleted;
        }

       [HttpGet("GetAllExamsByTeacherId{id}")]
       public List<ExamModel> GetAllExamsByTeacherId(int id)
        {
            repo = new ExamsRepository();
            return repo.GetAllExamsByTeacherId(id);
        }

       [HttpGet("GetExambyTitle{title}")]
       public ExamModel GetAllExamsByTitle(string title)
        {
            repo = new ExamsRepository();
            return repo.GetExamWithTitle(title);
        } 


    }
}
