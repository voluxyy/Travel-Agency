using LasserreDetresTravelAgency.Business.Dto;
using LasserreDetresTravelAgency.Data.Models;
using LasserreDetresTravelAgency.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LasserreDetresTravelAgency.Business.Service
{
    public class TravelTypeService : ITravelTypeService
    {
        private readonly ITravelTypeRepository TravelTypeRepository;

        public TravelTypeService(ITravelTypeRepository TravelTypeRepository)
        {
            this.TravelTypeRepository = TravelTypeRepository;
        }

        public async Task<TravelTypeDto> Add(TravelTypeDto dto)
        {
            TravelType TravelType = DtoToModel(dto);
            await TravelTypeRepository.Add(TravelType);
            TravelTypeDto TravelTypeDto = ModelToDto(TravelType);

            return TravelTypeDto;
        }

        public async Task<TravelTypeDto> Update(TravelTypeDto dto)
        {
            TravelType TravelType = DtoToModel(dto); 
            await TravelTypeRepository.Update(TravelType);
            TravelTypeDto TravelTypeDto = ModelToDto(TravelType);

            return TravelTypeDto;
        }

        public async Task<int> Delete(int id)
        {
            return await TravelTypeRepository.Delete(id);
        }

        public async Task<TravelTypeDto> Get(int id)
        {
            return ModelToDto(await TravelTypeRepository.Get(id));
        }

        public List<TravelTypeDto> GetAll()
        {
            List<TravelType> categories = TravelTypeRepository.GetAll();
            List<TravelTypeDto> categoriesDtos = ListModelToDto(categories);
            return categoriesDtos;
        }

        private List<TravelTypeDto> ListModelToDto(List<TravelType> categories)
        {
            List<TravelTypeDto> categoriesDtos = new List<TravelTypeDto>();
            foreach (TravelType cat in categories)
            {
                categoriesDtos.Add(ModelToDto(cat));
            }
            return categoriesDtos;
        }

        private TravelTypeDto ModelToDto(TravelType TravelType)
        {
            TravelTypeDto TravelTypeDto = new TravelTypeDto
            {
                Id = TravelType.Id,
                Title = TravelType.Title,
                Travels = (TravelType.Travels != null) ? TravelType.Travels : null,
            };

            return TravelTypeDto;
        }

        private TravelType DtoToModel(TravelTypeDto TravelTypeDto)
        {
            TravelType TravelType = new TravelType
            {
                Id = TravelTypeDto.Id,
                Title = TravelTypeDto.Title,
                Travels = null
            };

            return TravelType;
        }
    }
}
