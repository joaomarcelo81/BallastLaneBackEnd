using AutoMapper;
using BallastLaneBackEnd.Domain.DTO.Class;
using BallastLaneBackEnd.Domain.DTO.Student;
using BallastLaneBackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallastLaneBackEnd.Application.Mappings
{
    public class StudentMapper : Profile
    {
        public StudentMapper()
        {
            CreateMap<Student, CreateStudentRequest>().ReverseMap();
            CreateMap<Student, UpdateStudentRequest>().ReverseMap();
            CreateMap<Student, StudentResponse>().ReverseMap();
            CreateMap<Student, StudentRequest>().ReverseMap();
        }
    }
}