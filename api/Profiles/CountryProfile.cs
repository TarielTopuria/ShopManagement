using AutoMapper;
using ProductManagementService.DTOs.CountryDTOs;
using ProductManagementService.Models;

namespace ProductManagementService.Profiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<Country, CountryResponseDTO>();
        }
    }
}
