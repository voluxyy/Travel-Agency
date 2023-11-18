using LasserreDetresTravelAgency.Data.Models;
using LasserreDetresTravelAgency.Data.Repositories;

namespace LasserreDetresTravelAgency.Business.Service
{
    public class ContinentService : IContinentService
    {
        private readonly IContinentRepository continentRepository;

        public ContinentService(IContinentRepository repository)
        {
            this.continentRepository = repository;
        }

        public async Task<ContinentDto> Add(ContinentDto dto)
        {
            Continent continent = DtoToModel(dto);
            await continentRepository.Add(continent);
            ContinentDto continentDto = ModelToDto(continent);

            return continentDto;
        }

        public async Task<ContinentDto> Update(ContinentDto dto)
        {
            Continent continent = DtoToModel(dto);
            await continentRepository.Update(continent);
            ContinentDto continentDto = ModelToDto(continent);

            return continentDto;
        }

        public async Task<int> Delete(int id)
        {
            return await continentRepository.Delete(id);
        }

        public async Task<ContinentDto> Get(int id)
        {
            return ModelToDto(await continentRepository.Get(id));
        }

        public List<ContinentDto> GetAll()
        {
            List<Continent> continents = continentRepository.GetAll();
            List<ContinentDto> continentsDtos = ListModelToDto(continents);

            return continentsDtos;
        }

        private ContinentDto ModelToDto(Continent continent)
        {
            ContinentDto continentDto = new ContinentDto
            {
                Id = continent.Id,
                Title = continent.Title,
            };

            return continentDto;
        }

        private Continent DtoToModel(ContinentDto continentDto)
        {
            Continent continent = new Continent
            {
                Id = continentDto.Id,
                Title = continentDto.Title,
            };

            return continent;
        }

        private List<ContinentDto> ListModelToDto(List<Continent> continents)
        {
            List<ContinentDto> continentDtos = new List<ContinentDto>();

            foreach (Continent dest in continents)
            {
                continentDtos.Add(ModelToDto(dest));
            }
            return continentDtos;
        }
    }
}