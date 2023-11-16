using LasserreDetresTravelAgency.Data.Models;
using LasserreDetresTravelAgency.Data.Repositories;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LasserreDetresTravelAgency.Business.Service
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository CountryRepository;
        public CountryService(ICountryRepository repository)
        {
            this.CountryRepository = repository;
        }

        public async Task<CountryDto> Add(CountryDto dto)
        {
            Country country = DtoToModel(dto);
            await CountryRepository.Add(country);
            CountryDto countryDto = ModelToDto(country);

            return countryDto;
        }

        public async Task<CountryDto> Update(CountryDto dto)
        {
            Country country = DtoToModel(dto);
            await CountryRepository.Update(country);
            CountryDto countryDto = ModelToDto(country);

            return countryDto;
        }

        public async Task<int> Delete(int id)
        {
            return await CountryRepository.Delete(id);
        }

        public async Task<CountryDto> Get(int id)
        {
            return ModelToDto(await CountryRepository.Get(id));
        }

        public List<CountryDto> GetAll()
        {
            List<Country> countrys = CountryRepository.GetAll();
            List<CountryDto> countrysDtos = ListModelToDto(countrys);

            return countrysDtos;
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

        private List<CountryDto> ListModelToDto(List<Country> countrys)
        {
            List<CountryDto> countryDtos = new List<CountryDto>();

            foreach (Country dest in countrys)
            {
                countryDtos.Add(ModelToDto(dest));
            }
            return countryDtos;
        }
    }
}
