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
    public class TravelsService : ITravelsService
    {
        private readonly ITravelsRepository travelsRepository;

        public TravelsService(ITravelsRepository travelsRepository)
        {
            this.travelsRepository = travelsRepository;
        }

        public async Task<TravelsDto> Add(TravelsDto dto)
        {
            Travels travels = DtoToModel(dto);
            await travelsRepository.Add(travels);
            TravelsDto travelsDto = ModelToDto(travels);

            return travelsDto;
        }

        public async Task<TravelsDto> Update(TravelsDto dto)
        {
            Travels travels = DtoToModel(dto);
            await travelsRepository.Update(travels);
            TravelsDto travelsDto = ModelToDto(travels);

            return travelsDto;
        }

        public async Task<int> Delete(int id)
        {
            return await travelsRepository.Delete(id);
        }

        public async Task<TravelsDto> Get(int id)
        {
            return ModelToDto(await travelsRepository.Get(id));
        }

        public List<TravelsDto> GetAll()
        {
            List<Travels> travels = travelsRepository.GetAll();
            List<TravelsDto> travelsDto = ListModelToDto(travels);
            return travelsDto;
        }

        public List<TravelsDto> GetAllFutureTravels()
        {
            List<Travels> travels = travelsRepository.GetAllFutureTravels();
            return ListModelToDto(travels);
        }

        public List<TravelsDto> GetAllPastTravels()
        {
            List<Travels> travels = travelsRepository.GetAllPastTravels();
            return ListModelToDto(travels);
        }

        private List<TravelsDto> ListModelToDto(List<Travels> travels)
        {
            List<TravelsDto> travelsDto = new List<TravelsDto>();
            foreach (Travels trav in travels)
            {
                travelsDto.Add(ModelToDto(trav));
            }
            return travelsDto;
        }

        private TravelsDto ModelToDto(Travels travels)
        {
            TravelsDto travelsDto = new TravelsDto
            {
                Id = travels.Id,
                UserId = travels.UserId,
                DestinationId = travels.DestinationId,
                DateStart = travels.DateStart,
                DateEnd = travels.DateEnd,
                TravelTypeId = travels.TravelTypeId
            };

            return travelsDto;
        }

        private Travels DtoToModel(TravelsDto travelsDto)
        {
            Travels travels = new Travels
            {
                Id = travelsDto.Id,
                UserId = travelsDto.UserId,
                DestinationId = travelsDto.DestinationId,
                DateStart = travelsDto.DateStart,
                DateEnd = travelsDto.DateEnd,
                TravelTypeId = travelsDto.TravelTypeId
            };

            return travels;
        }
    }
}