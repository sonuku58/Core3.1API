using AutoMapper;
using StudentAPI.Dto;
using StudentAPI.Model;
using StudentAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace StudentAPI.Controllers
{
    [ApiController]
    [Route("Student")]
    public class StudentController : Controller
    {       
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
      
        private readonly BaseStudentRepository studentRepository;
        public StudentController(ApplicationDbContext context,IMapper mapper,BaseStudentRepository _studentRepository)
        {
            this.context = context;
            this.mapper = mapper;
            this.studentRepository = _studentRepository; 
         
        }

        [HttpGet]
        public ActionResult<IEnumerable<StudentDto>> GetStudent()
        {
            var studentList = studentRepository.GetAllStudent();
            var allStudent = mapper.Map<List<StudentDto>>(studentList);
            return allStudent;
        }

        [HttpGet("{Id:int}", Name="GetStudent")]
        public  ActionResult<StudentDto>  GetStudentById(int Id)
        {
            var studentDetail = studentRepository.StudentById(Id);
            if(studentDetail==null)
            {
                //return RedirectToAction("Error", "Student");
                return Content(studentRepository.WrongRequest());
            }
            var studentById = mapper.Map<StudentDto>(studentDetail);          
            return studentById;
        }   
        
        [HttpPost]
        public ActionResult PostStudent([FromBody] StudentCreationDto studentCreation)
        {
            var student = mapper.Map<Student>(studentCreation);
            studentRepository.AddStudent(student);           
            return new CreatedAtRouteResult("GetStudent", new { Id = student.Id }, student);
        }

        [HttpPut("{Id:int}")] 
        public ActionResult ModifyStudent(int Id,[FromBody] StudentCreationDto studentCreation )
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

        [HttpPut]
        public ActionResult ModifyStudent([FromBody] StudentDto editStudent)
        {
            var exist = context.Students.FirstOrDefault(s => s.Id == editStudent.Id);
            if (exist == null)
            {
                return NotFound();
            }
            var student = mapper.Map<Student>(editStudent);
            studentRepository.UpdateStudent( student);
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
