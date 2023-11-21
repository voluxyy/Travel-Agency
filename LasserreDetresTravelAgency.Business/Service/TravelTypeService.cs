using LasserreDetresTravelAgency.Business.Dto;
using LasserreDetresTravelAgency.Data.Models;
using LasserreDetresTravelAgency.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LasserreDetresTravelAgency.Business.Service
{
    public class TravelTypeService : ITravelTypeService
    {
        private readonly ITravelTypeRepository travelTypeRepository;

        public TravelTypeService(ITravelTypeRepository travelTypeRepository)
        {
            this.travelTypeRepository = travelTypeRepository;
        }

        public async Task<TravelTypeDto> Add(TravelTypeDto dto)
        {
            TravelType travelType = DtoToModel(dto);
            await travelTypeRepository.Add(travelType);
            TravelTypeDto travelTypeDto = ModelToDto(travelType);

            return travelTypeDto;
        }

        public async Task<TravelTypeDto> Update(TravelTypeDto dto)
        {
            TravelType travelType = DtoToModel(dto);
            await travelTypeRepository.Update(travelType);
            TravelTypeDto travelTypeDto = ModelToDto(travelType);

            return travelTypeDto;
        }

        public async Task<int> Delete(int id)
        {
            return await travelTypeRepository.Delete(id);
        }

        public async Task<TravelTypeDto> Get(int id)
        {
            return ModelToDto(await travelTypeRepository.Get(id));
        }

        public List<TravelTypeDto> GetAll()
        {
            List<TravelType> travelTypes = travelTypeRepository.GetAll();
            List<TravelTypeDto> travelTypesDtos = ListModelToDto(travelTypes);
            return travelTypesDtos;
        }

        private List<TravelTypeDto> ListModelToDto(List<TravelType> travelTypes)
        {
            List<TravelTypeDto> travelTypesDtos = new List<TravelTypeDto>();
            foreach (TravelType cat in travelTypes)
            {
                travelTypesDtos.Add(ModelToDto(cat));
            }
            return travelTypesDtos;
        }

        private TravelTypeDto ModelToDto(TravelType travelType)
        {
            TravelTypeDto travelTypeDto = new TravelTypeDto
            {
                Id = travelType.Id,
                Title = travelType.Title,
            };

            return travelTypeDto;
        }

        private TravelType DtoToModel(TravelTypeDto travelTypeDto)
        {
            TravelType travelType = new TravelType
            {
                Id = travelTypeDto.Id,
                Title = travelTypeDto.Title,
                Travels = null
            };

            return travelType;
        }
    }
}