using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAPI.Dto
{
    public class StudentDto:StudentCreationDto
    {
        public int Id { get; set; }
    }
}
