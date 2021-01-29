using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server_api_demos.Models
{
    public class TeachersModel
    {
     public TeachersModel()
        {
            courses = new List<string>();
        }
    
        public int Id {get; set;}
        public string Name {get; set;}
        public string Surname {get; set;}
        //public string course {get;set;} 
        public List<string> courses { get; set; } // courses the teacher teaches


    }
}
