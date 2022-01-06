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
    public class StudentRepository : BaseStudentRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public StudentRepository( ApplicationDbContext _context,IMapper _mapper )
        {
            this.context = _context;
            this.mapper= _mapper;                
        }

        private IEnumerable<StudentDto> AllStudent()
        {
            var studentList = context.Students.AsNoTracking().ToList();
            var allStudentList = mapper.Map<IEnumerable<StudentDto>>(studentList);
            return allStudentList;
        }

        private Student StudentDetailById(int Id)
        {
            return context.Students.FirstOrDefault(x => x.Id == Id);
        }

        private void PostStudent(Student student)
        {
            context.Add(student);
            context.SaveChanges();
        }

        private void UpdateStudentDetail(int Id, Student student)
        {

            var students = context.Students.FirstOrDefault(s => s.Id == Id);
            students.FirstName = student.FirstName;
            students.LastName = student.LastName;
            students.Gender = student.Gender;
            students.Salary = student.Salary;
            context.SaveChanges();
        }

        private void UpdateStudentDetail(Student student)
        {
            var students = context.Students.FirstOrDefault(s => s.Id == student.Id);
            students.FirstName = student.FirstName;
            students.LastName = student.LastName;
            students.Gender = student.Gender;
            students.Salary = student.Salary;
            context.SaveChanges();
        }

        private void Remove(Student student)
        {
            context.Remove(student);
            context.SaveChanges();
        }
        public override IEnumerable<StudentDto> GetAllStudent()
        {
            return AllStudent();
        }
        public override Student StudentById(int Id)
        {
            return StudentDetailById(Id);
        }

        public override void AddStudent(Student student)
        {
            PostStudent(student);
        }

        public override void UpdateStudent(int Id, Student student)
        {
            UpdateStudentDetail(Id, student);
        }

        public override void UpdateStudent(Student student)
        {
            UpdateStudentDetail(student);
        }
        public override void RemoveStudent(Student student)
        {
            Remove(student);
        }

       
    }
}
