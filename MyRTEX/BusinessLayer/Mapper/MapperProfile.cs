using AutoMapper;
using MyRTEX.BusinessLayer.DTOs;
using MyRTEX.DataLayer.Models;

namespace MyRTEX.BusinessLayer.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<EmployeeDTO, Employee>();
        }

    }
}
