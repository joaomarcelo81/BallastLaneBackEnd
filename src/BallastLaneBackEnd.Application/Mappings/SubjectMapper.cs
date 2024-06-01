using AutoMapper;
using BallastLaneBackEnd.Domain.DTO.Subject;
using BallastLaneBackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallastLaneBackEnd.Application.Mappings
{
    public class SubjectMapper : Profile
    {
        public SubjectMapper()
        {
            CreateMap<Subject, CreateSubjectRequest>().ReverseMap();
            CreateMap<Subject, UpdateSubjectRequest>().ReverseMap();
            CreateMap<Subject, SubjectResponse>().ReverseMap();
            CreateMap<Subject, SubjectRequest>().ReverseMap();
        }
    }
}
