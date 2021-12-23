using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAPI.Dto
{
    public class StudentDto:Person
    {   
     
        public int Salary { get; set; }
        public override string GetFullName()
        {
            return "Mr." + " " + FirstName + " " + LastName;
        }
        public string FullName
        {
            get
            {
                return GetFullName();
            }
        }

    }
}
