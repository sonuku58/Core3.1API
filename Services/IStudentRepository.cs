using StudentAPI.Dto;
using StudentAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace StudentAPI.Services
{
     public interface IStudentRepository
    {
        IEnumerable<StudentDto> GetAllStudent();
        Student StudentById(int Id);
        void AddStudent(Student student);
        void UpdateStudent(int Id,Student student);
        void UpdateStudent(Student student);
        void RemoveStudent( Student student);
    }
}
