using AutoMapper;
using ProductManagementService.DTOs.ProductDTOs;
using ProductManagementService.Models;

namespace ProductManagementService.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductResponseDTO>()
                .ForMember(dto => dto.Country, opt => opt.MapFrom(src => src.Country.Name));
            CreateMap<ProductRequestDTO, Product>();
        }
    }
}
