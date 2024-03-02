using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ProductManagementService.DTOs.CountryDTOs;
using ProductManagementService.Services.Interfaces;

namespace ProductManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController(ICountryService countryService) : ControllerBase
    {
        private readonly ICountryService countryService = countryService;

        [HttpGet]
        public async Task<IActionResult> GetAllCountries()
        {
            var countries = await countryService.GetAllCountriesAsync();
            return Ok(countries);
        }

        [HttpPost("createCountry")]
        public async Task<ActionResult<CountryResponseDTO>> CreateProduct(CountryRequestDTO country)
        {
            try
            {
                var newCountry = await countryService.CreateCountryAsync(country);
                return Ok(newCountry);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (BadHttpRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
