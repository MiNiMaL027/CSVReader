using AutoMapper;
using Task_Domain.DTOModels;
using Task_Domain.Models;

namespace Task_Service.Mapper
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile() 
        {
            CreateProjection<DtoPerson, Person>();

            CreateMap<DtoPerson,Person>().ReverseMap();
        }
    }
}
