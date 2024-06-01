using AutoMapper;
using BallastLaneBackEnd.Domain.DTO.Class;
using BallastLaneBackEnd.Domain.DTO.Teacher;
using BallastLaneBackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallastLaneBackEnd.Application.Mappings
{
    public class TeacherMapper : Profile
    {
        public TeacherMapper()
        {
            CreateMap<Teacher, CreateTeacherRequest>().ReverseMap();
            CreateMap<Teacher, UpdateTeacherRequest>().ReverseMap();
            CreateMap<Teacher, TeacherResponse>().ReverseMap();
        }
    }
}
