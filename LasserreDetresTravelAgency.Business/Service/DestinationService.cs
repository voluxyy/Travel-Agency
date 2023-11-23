using LasserreDetresTravelAgency.Data.Models;
using LasserreDetresTravelAgency.Data.Repositories;

namespace LasserreDetresTravelAgency.Business.Service
{
    public class DestinationService : IDestinationService
    {
        private readonly IDestinationRepository destinationRepository;
        private readonly IVisitRepository visitRepository;

        public DestinationService(IDestinationRepository desination, IVisitRepository visit)
        {
            this.destinationRepository = desination;
            this.visitRepository = visit;
        }

        public async Task<DestinationDto> Add(DestinationDto dto)
        {
            Destination destination = DtoToModel(dto);
            await destinationRepository.Add(destination);
            DestinationDto destinationDto = ModelToDto(destination);

            return destinationDto;
        }

        public async Task<DestinationDto> Update(DestinationDto dto)
        {
            Destination destination = DtoToModel(dto);
            await destinationRepository.Update(destination);
            DestinationDto destinationDto = ModelToDto(destination);

            return destinationDto;
        }

        public async Task<int> Delete(int id)
        {
            return await destinationRepository.Delete(id);
        }

        public async Task<DestinationDto> Get(int id)
        {
            return ModelToDto(await destinationRepository.Get(id));
        }

        public List<DestinationDto> GetAll()
        {
            List<Destination> destinations = destinationRepository.GetAll();
            List<DestinationDto> destinationsDtos = ListModelToDto(destinations);

            return destinationsDtos;
        }

        public List<DestinationDto> GetAllVisited()
        {
            List<Visit> visited = visitRepository.GetAll();
            List<DestinationDto> destinations = new List<DestinationDto>();
            foreach (Visit visit in visited)
            {
                destinations.Add(ModelToDto(destinationRepository.Get(visit.DestinationId).Result));
            }
            return destinations;
        }

        public List<DestinationDto> GetAllDestinationByUserAndCategory(int userId, int CategoryId)
        {
            List<Visit> visits = visitRepository.GetByUserId(userId);
            List<Destination> destinations = destinationRepository.GetAll();
            List<DestinationDto> destinationDtos = new List<DestinationDto>();

            foreach (Destination destination in destinations)
            {
                if (destination.CategoryId == CategoryId)
                {
                    foreach (Visit visit in visits)
                    {
                        if (visit.DestinationId == destination.Id)
                        {
                            destinationDtos.Add(ModelToDto(destination));
                        }
                    }
                }
            }

            return destinationDtos;
        }

        private DestinationDto ModelToDto(Destination destination)
        {
            DestinationDto destinationDto = new DestinationDto
            {
                Id = destination.Id,
                CategoryId = destination.CategoryId,
                CountryId = destination.CountryId,
                City = destination.City,
                Capital = destination.Capital,
                ToDo = destination.ToDo.Split(", ")
            };

            return destinationDto;
        }

        private Destination DtoToModel(DestinationDto destinationDto)
        {
            Destination destination = new Destination
            {
                Id = destinationDto.Id,
                CategoryId = destinationDto.CategoryId,
                CountryId = destinationDto.CountryId,
                City = destinationDto.City,
                Capital = destinationDto.Capital,
                ToDo = string.Join(", ", destinationDto.ToDo)
            };

            return destination;
        }

        private List<DestinationDto> ListModelToDto(List<Destination> destinations)
        {
            List<DestinationDto> destinationDtos = new List<DestinationDto>();

            foreach (Destination dest in destinations)
            {
                destinationDtos.Add(ModelToDto(dest));
            }
            return destinationDtos;
        }
    }
}