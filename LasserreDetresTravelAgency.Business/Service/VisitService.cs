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
    public class VisitService : IVisitService
    {
        private readonly IVisitRepository visitRepository;
        public VisitService(IVisitRepository repository)
        {
            this.visitRepository = repository;
        }

        public async Task<VisitDto> Add(VisitDto dto)
        {
            Visit visit = DtoToModel(dto);
            await visitRepository.Add(visit);
            VisitDto visitDto = ModelToDto(visit);

            return visitDto;
        }

        public async Task<VisitDto> Update(VisitDto dto)
        {
            Visit visit = DtoToModel(dto);
            await visitRepository.Update(visit);
            VisitDto visitDto = ModelToDto(visit);

            return visitDto;
        }

        public async Task<int> Delete(int id)
        {
            return await visitRepository.Delete(id);
        }

        public async Task<VisitDto> Get(int id)
        {
            return ModelToDto(await visitRepository.Get(id));
        }

        public List<VisitDto> GetAll()
        {
            List<Visit> visits = visitRepository.GetAll();
            List<VisitDto> visitDtos = ListModelToDto(visits);

            return visitDtos;
        }

        private VisitDto ModelToDto(Visit visit)
        {
            VisitDto visitDto = new VisitDto
            {
                Id = visit.Id,
                
                UserId = visit.UserId,
                DestinationId = visit.DestinationId
            };

            return visitDto;
        }

        private Visit DtoToModel(VisitDto visitDto)
        {
            Visit visit = new Visit
            {
                Id = visitDto.Id,
                
                UserId = visitDto.UserId,
                DestinationId = visitDto.DestinationId
            };

            return visit;
        }

        private List<VisitDto> ListModelToDto(List<Visit> visits)
        {
            List<VisitDto> visitDtos = new List<VisitDto>();

            foreach (Visit dest in visits)
            {
                visitDtos.Add(ModelToDto(dest));
            }
            return visitDtos;
        }
    }
}
