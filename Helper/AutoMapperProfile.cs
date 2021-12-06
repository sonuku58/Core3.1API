using AutoMapper;
using StudentAPI.Dto;
using StudentAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAPI.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<StudentCreationDto, Student>();
        }
    }
}
