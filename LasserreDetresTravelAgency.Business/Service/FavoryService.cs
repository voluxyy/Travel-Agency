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
    public class FavoryService : IFavoryService
    {
        private readonly IFavoryRepository favoryRepository;

        public FavoryService(IFavoryRepository favory)
        {
            this.favoryRepository = favory;
        }

        public async Task<FavoryDto> Add(FavoryDto dto)
        {
            Favory favory = DtoToModel(dto);
            await favoryRepository.Add(favory);
            FavoryDto favoryDto = ModelToDto(favory);
            return favoryDto;
        }

        public async Task<FavoryDto> Update(FavoryDto dto)
        {
            Favory favorty = DtoToModel(dto);
            await favoryRepository.Update(favorty);
            FavoryDto favoryDto = ModelToDto(favorty);
            return favoryDto;
        }

        public async Task<int> Delete(int id)
        {
            return await favoryRepository.Delete(id);
        }

        public async Task<FavoryDto> Get(int id)
        {
            return ModelToDto(await favoryRepository.Get(id));
        }

        public List<FavoryDto> GetAll()
        {
            List<Favory> favories = favoryRepository.GetAll();
            List<FavoryDto> favoriesDto = ListModelToDto(favories);
            return favoriesDto;
        }

        private List<FavoryDto> ListModelToDto(List<Favory> favory)
        {
            List<FavoryDto> favoriesDto = new List<FavoryDto>();
            foreach (Favory fab in favory)
            {
                favoriesDto.Add(ModelToDto(fab));
            }
            return favoriesDto;
        }

        private FavoryDto ModelToDto(Favory Favory)
        {
            FavoryDto FavoryDto = new FavoryDto
            {
                Id = Favory.Id,
                UserId = Favory.UserId,
                DestinationId = Favory.DestinationId,
            };
            return FavoryDto;
        }
        
        private Favory DtoToModel(FavoryDto FavoryDto)
        {
            Favory Favory = new Favory()
            {
                Id = FavoryDto.Id,
                UserId = FavoryDto.UserId,
                DestinationId = FavoryDto.DestinationId,
            };
            return Favory;
        }
    }
}