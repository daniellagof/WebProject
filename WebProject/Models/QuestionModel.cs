using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server_api_demos.Models
{
    public class QuestionModel
    {
        public QuestionModel()
        {
            Choices = new List<string>();
        }
        
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public IList<string> Choices { get; set;}
        public string Answer{ get; set; }
        public int Points {get; set;}


    }
}
