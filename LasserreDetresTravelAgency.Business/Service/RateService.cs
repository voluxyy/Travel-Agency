using LasserreDetresTravelAgency.Data.Models;
using LasserreDetresTravelAgency.Data.Repositories;
using Microsoft.Identity.Client;
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
    public class RateService : IRateService
    {
        private readonly IRateRepository rateRepository;

        public RateService(IRateRepository rateRepository)
        {
            this.rateRepository = rateRepository;
        }

        public async Task<RateDto> Add(RateDto dto)
        {
            Rate rate = DtoToModel(dto);
            await rateRepository.Add(rate);
            RateDto rateDto = ModelToDto(rate);

            return rateDto;
        }

        public async Task<int> Delete(int id)
        {
            return await rateRepository.Delete(id);
        }

        public async Task<RateDto> Get(int id)
        {
            return ModelToDto(await rateRepository.Get(id));
        }

        public List<RateDto> GetAll()
        {
            return ListModelToDto(rateRepository.GetAll());
        }

        public async Task<RateDto> Update(RateDto dto)
        {
            Rate rate = DtoToModel(dto);
            await rateRepository.Update(rate);
            RateDto rateDto = ModelToDto(rate);
            
            return rateDto;
        }

        private Rate DtoToModel(RateDto dto)
        {
            Rate rate = new Rate{
                Id = dto.Id,
                Number = dto.Number,
                UserId = dto.UserId,
                DestinationId = dto.DestinationId,
            };

            return rate;
        }

        private RateDto ModelToDto(Rate rate)
        {
            RateDto rateDto = new RateDto{
                Id = rate.Id,
                Number = rate.Number,
                UserId = rate.UserId,
                DestinationId = rate.DestinationId,
            };

            return rateDto;
        }

        private List<RateDto> ListModelToDto(List<Rate> rates)
        {
            List<RateDto> rateDtos = new List<RateDto>();

            foreach (Rate rate in rates)
            {
                rateDtos.Add(ModelToDto(rate));
            }
            return rateDtos;
        }
    }
}
