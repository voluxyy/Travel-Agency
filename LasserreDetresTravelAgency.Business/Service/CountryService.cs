using LasserreDetresTravelAgency.Data.Models;
using LasserreDetresTravelAgency.Data.Repositories;

namespace LasserreDetresTravelAgency.Business.Service
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository countryRepository;

        public CountryService(ICountryRepository repository)
        {
            this.countryRepository = repository;
        }

        public async Task<CountryDto> Add(CountryDto dto)
        {
            Country country = DtoToModel(dto);
            await countryRepository.Add(country);
            CountryDto countryDto = ModelToDto(country);

            return countryDto;
        }

        public async Task<CountryDto> Update(CountryDto dto)
        {
            Country country = DtoToModel(dto);
            await countryRepository.Update(country);
            CountryDto countryDto = ModelToDto(country);

            return countryDto;
        }

        public async Task<int> Delete(int id)
        {
            return await countryRepository.Delete(id);
        }

        public async Task<CountryDto> Get(int id)
        {
            return ModelToDto(await countryRepository.Get(id));
        }

        public List<CountryDto> GetAll()
        {
            List<Country> countries = countryRepository.GetAll();
            List<CountryDto> countriesDtos = ListModelToDto(countries);

            return countriesDtos;
        }

        private CountryDto ModelToDto(Country country)
        {
            CountryDto countryDto = new CountryDto
            {
                Id = country.Id,
                Title = country.Title,
                ContinentId = country.ContinentId
            };

            return countryDto;
        }

        private Country DtoToModel(CountryDto countryDto)
        {
            Country country = new Country
            {
                Id = countryDto.Id,
                Title = countryDto.Title,
                ContinentId = countryDto.ContinentId
            };

            return country;
        }

        private List<CountryDto> ListModelToDto(List<Country> countries)
        {
            List<CountryDto> countryDtos = new List<CountryDto>();

            foreach (Country dest in countries)
            {
                countryDtos.Add(ModelToDto(dest));
            }
            return countryDtos;
        }
    }
}