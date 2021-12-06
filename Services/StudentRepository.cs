using AutoMapper;
using StudentAPI.Dto;
using StudentAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAPI.Services
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public StudentRepository( ApplicationDbContext _context,IMapper _mapper )
        {
            this.context = _context;
            this.mapper= _mapper;                
        }
        public  IEnumerable<StudentDto> GetAllStudent()
        {
            var allStudent = context.Students.AsNoTracking().ToList();
            var listOfStudent = mapper.Map<IEnumerable<StudentDto>>(allStudent);
            return listOfStudent;
        }
        public Student StudentById(int Id)
        {
            return  context.Students.FirstOrDefault(x => x.Id == Id);
        }
        public void AddStudent(Student student)
        {
            context.Add(student);
            context.SaveChanges();
        }
        public void UpdateStudent(int Id,Student student)
        {           
            var students = context.Students.FirstOrDefault(s => s.Id == Id);
            students.FirstName = student.FirstName;
            students.LastName = student.LastName;
            students.Gender = student.Gender;
            students.Salary = student.Salary;
            context.SaveChanges();
        }
        public void UpdateStudent(Student student)
        {
            var students = context.Students.FirstOrDefault(s => s.Id == student.Id);
            students.FirstName = student.FirstName;
            students.LastName = student.LastName;
            students.Gender = student.Gender;
            students.Salary = student.Salary;
            context.SaveChanges();
        }
        public void RemoveStudent(Student student)
        {
            context.Remove(student);
            context.SaveChanges();
        }        
    }
}
