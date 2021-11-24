using AutoMapper;
using core3._1api.DTOs;
using core3._1api.Model;
using core3._1api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace core3._1api.Controllers
{
    [ApiController]
    [Route("api/student")]

    public class StudentController : Controller
    {
        
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IStudentRepository studentRepository;

        public StudentController(ApplicationDbContext context,IMapper mapper,IStudentRepository _studentRepository)
        {
            this.context = context;
            this.mapper = mapper;
            this.studentRepository = _studentRepository;
        }

        [HttpGet]
        public ActionResult<List<StudentDTO>> GetStudent()
        {
            var student = studentRepository.GetAllStudent();

            var studentList = mapper.Map<List<StudentDTO>>(student);

            return studentList;
        }

        [HttpGet("{Id:int}", Name="getStudent")]
        public  ActionResult<StudentDTO> GetStudentById(int Id)
        {
            var studentbyid = studentRepository.StudentById(Id);
            var studentDTO = mapper.Map<StudentDTO>(studentbyid);
            return studentDTO;
        }

     

        [HttpPost]
        public ActionResult PostStudent([FromBody] studentCreationDTO studentcreation)
        {
            var student = mapper.Map<Student>(studentcreation);
            studentRepository.AddStudent(student);
            //var studentDTO = mapper.Map<StudentDTO>(student);
            return new CreatedAtRouteResult("getStudent", new { Id = student.Id }, student);
        }

        [HttpPut("{Id:int}")]
        public ActionResult ModifyStudent(int Id,[FromBody] studentCreationDTO studentCreation )
        {
            var exist = context.Students.FirstOrDefault(s => s.Id == Id); 

            if (exist == null)
            {
                return NotFound();
            }
            
            var student = mapper.Map<Student>(studentCreation);

            studentRepository.UpdateStudent(Id, student);
            return Ok();

            


        }

       

        [HttpDelete("{Id:int}")]
        public ActionResult DeleteStudent(int Id)
        {
            var exist = context.Students.FirstOrDefault(s => s.Id == Id); ;
          
            if (exist==null)
            {
                return NotFound();
            }
            studentRepository.RemoveStudent(exist);
            return NoContent();
        }




    }
}
