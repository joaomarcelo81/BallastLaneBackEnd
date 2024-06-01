using AutoMapper;
using BallastLaneBackEnd.Domain.DTO.Class;
using BallastLaneBackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallastLaneBackEnd.Application.Mappings
{
    public class ClassMapper : Profile
    {
        public ClassMapper()
        {
            CreateMap<Class, CreateClassRequest>().ReverseMap();
            CreateMap<Class, UpdateClassRequest>().ReverseMap();
            CreateMap<Class, ClassResponse>().ReverseMap();
        }
    }
}
