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
    public class EventService : IEventService
    {
        private readonly IEventRepository eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            this.eventRepository = eventRepository;
        }

        public async Task<EventDto> Add(EventDto dto)
        {
            Event evenement = DtoToModel(dto);
            await eventRepository.Add(evenement);
            EventDto eventDto = ModelToDto(evenement);

            return eventDto;
        }

        public async Task<EventDto> Update(EventDto dto)
        {
            Event evenement = DtoToModel(dto);
            await eventRepository.Update(evenement);
            EventDto eventDto = ModelToDto(evenement);

            return eventDto;
        }

        public async Task<int> Delete(int id)
        {
            return await eventRepository.Delete(id);
        }

        public async Task<EventDto> Get(int id)
        {
            return ModelToDto(await eventRepository.Get(id));
        }

        public List<EventDto> GetAll()
        {
            List<Event> evenement = eventRepository.GetAll();
            List<EventDto> evenementDto = ListModelToDto(evenement);

            return evenementDto;
        }

        private List<EventDto> ListModelToDto(List<Event> evenement)
        {
            List<EventDto> eventDto = new List<EventDto>();

            foreach (Event events in evenement)
            {
                eventDto.Add(ModelToDto(events));
            }
            return eventDto;
        }

        private EventDto ModelToDto(Event Evenement)
        {
            EventDto EventDto = new EventDto
            {
                Id = Evenement.Id,
                Title = Evenement.Title,
                Description = Evenement.Description,
                Destinations = (Evenement.Destinations != null) ? Evenement.Destinations : null ,
            };

            return EventDto;
        }

        private Event DtoToModel(EventDto EventDto)
        {
            Event Event = new Event
            {
                Id = EventDto.Id,
                Title = EventDto.Title,
                Description = EventDto.Description,
                Destinations = null,
            };

            return Event;
        }
    }
}
