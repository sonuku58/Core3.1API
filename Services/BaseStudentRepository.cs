using StudentAPI.Dto;
using StudentAPI.Model;
using System;
using System.Collections.Generic;



namespace StudentAPI.Services
{
     public abstract class BaseStudentRepository
    {
        public  string WrongRequest()
        {
            return "Sorry, we are not getting detail.....";
        }
        public abstract IEnumerable<StudentDto> GetAllStudent();
        public abstract Student StudentById(int Id);
        public abstract void AddStudent(Student student);
        public abstract void UpdateStudent(int Id,Student student);
        public abstract void UpdateStudent(Student student);
        public abstract void RemoveStudent( Student student);
       
    }
}
