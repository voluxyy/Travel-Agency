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
    public class ContinentService : IContinentService
    {
        private readonly IContinentRepository ContinentRepository;
        public ContinentService(IContinentRepository repository)
        {
            this.ContinentRepository = repository;
        }

        public async Task<ContinentDto> Add(ContinentDto dto)
        {
            Continent Continent = DtoToModel(dto);
            await ContinentRepository.Add(Continent);
            ContinentDto ContinentDto = ModelToDto(Continent);

            return ContinentDto;
        }

        public async Task<ContinentDto> Update(ContinentDto dto)
        {
            Continent Continent = DtoToModel(dto);
            await ContinentRepository.Update(Continent);
            ContinentDto ContinentDto = ModelToDto(Continent);

            return ContinentDto;
        }

        public async Task<int> Delete(int id)
        {
            return await ContinentRepository.Delete(id);
        }

        public async Task<ContinentDto> Get(int id)
        {
            return ModelToDto(await ContinentRepository.Get(id));
        }

        public List<ContinentDto> GetAll()
        {
            List<Continent> Continents = ContinentRepository.GetAll();
            List<ContinentDto> ContinentsDtos = ListModelToDto(Continents);

            return ContinentsDtos;
        }

        private ContinentDto ModelToDto(Continent Continent)
        {
            ContinentDto ContinentDto = new ContinentDto
            {
                Id = Continent.Id,
                Title = Continent.Title,
            };

            return ContinentDto;
        }

        private Continent DtoToModel(ContinentDto ContinentDto)
        {
            Continent Continent = new Continent
            {
                Id = ContinentDto.Id,
                Title = ContinentDto.Title,
            };

            return Continent;
        }

        private List<ContinentDto> ListModelToDto(List<Continent> Continents)
        {
            List<ContinentDto> ContinentDtos = new List<ContinentDto>();

            foreach (Continent dest in Continents)
            {
                ContinentDtos.Add(ModelToDto(dest));
            }
            return ContinentDtos;
        }
    }
}
