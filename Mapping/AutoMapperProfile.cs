using API_PRO.Data.Models;
using AutoMapper;
using API_PRO.Models;

namespace API_PRO.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Exam, ExamDto>();
            CreateMap<ExamDto, Exam>();
            CreateMap<Subject, SubjectDto>();
            CreateMap<SubjectDto, Subject>();
            CreateMap<Users, UserDto>();
            CreateMap<UserDto, Users>();
        }
    }

}
