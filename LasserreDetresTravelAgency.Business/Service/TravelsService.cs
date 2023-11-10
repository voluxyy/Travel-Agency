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

        private List<TravelsDto> ListModelToDto(List<Travels> travels)
        {
            List<TravelsDto> travelsDto = new List<TravelsDto>();
            foreach (Travels trav in travels)
            {
                travelsDto.Add(ModelToDto(trav));
            }
            return travelsDto;
        }

        private TravelsDto ModelToDto(Travels Travels)
        {
            TravelsDto TravelsDto = new TravelsDto
            {
                Id = Travels.Id,
                UserId = Travels.UserId,
                DestinationId = Travels.DestinationId,
                DateStart = Travels.DateStart,
                DateEnd = Travels.DateEnd,
            };

            return TravelsDto;
        }

        private Travels DtoToModel(TravelsDto TravelsDto)
        {
            Travels Travels = new Travels
            {
                Id = TravelsDto.Id,
                UserId = TravelsDto.UserId,
                DestinationId = TravelsDto.DestinationId,
                DateStart = TravelsDto.DateStart,
                DateEnd = TravelsDto.DateEnd,
            };

            return Travels;
        }
    }
}
