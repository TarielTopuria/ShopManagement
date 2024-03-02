using AutoMapper;
using ProductManagementService.DTOs.CountryDTOs;
using ProductManagementService.Models;
using ProductManagementService.Services.Interfaces;
using ProductManagementService.UnitOfWork.Interfaces;

namespace ProductManagementService.Services.Implementations
{
    public class CountryService(IUnitOfWork unitOfWork, IMapper mapper) : ICountryService
    {
        private readonly IUnitOfWork unitOfWork = unitOfWork;
        private readonly IMapper mapper = mapper;

        public async Task<IEnumerable<CountryResponseDTO>> GetAllCountriesAsync()
        {
            try
            {
                return mapper.Map<List<CountryResponseDTO>>(await unitOfWork.Countries.GetAllAsync());
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception($"Error occurred in getting all countries: {ex.Message}", ex);
            }
        }

        public async Task<CountryResponseDTO> CreateCountryAsync(CountryRequestDTO country)
        {
            ArgumentNullException.ThrowIfNull(country);

            try
            {
                var newCountry = mapper.Map<Country>(country);
                await unitOfWork.Countries.InsertAsync(newCountry);
                await unitOfWork.SaveAsync();
                var response = mapper.Map<CountryResponseDTO>(newCountry);
                return response;
            }
            catch (Exception ex)
            {
                // Log the exception as needed
                throw new Exception($"Error occurred while creating country: {ex.Message}", ex);
            }
        }
    }
}
