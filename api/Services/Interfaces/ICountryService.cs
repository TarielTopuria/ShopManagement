using ProductManagementService.DTOs.CountryDTOs;

namespace ProductManagementService.Services.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryResponseDTO>> GetAllCountriesAsync();
        Task<CountryResponseDTO> CreateCountryAsync(CountryRequestDTO country);
    }
}
