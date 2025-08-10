using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotifiTime_API.application.DTOs;
using NotifiTime_API.domain.entities;

namespace NotifiTime_API.application.mappers
{
    public static class EventCalendarMapper
    {
        public static EventCalendarDTO EventCalendarToDTO(EventCalendar domainEventCalendar)
        {
            EventCalendarDTO eventCalendarDTO = new EventCalendarDTO();
            eventCalendarDTO.Id = domainEventCalendar.GetId();
            eventCalendarDTO.Name = domainEventCalendar.GetName();
            eventCalendarDTO.DateTime = domainEventCalendar.GetDateTime();
            eventCalendarDTO.SupportedPlatformList = domainEventCalendar.GetSupportedPlatformList();
            eventCalendarDTO.Message = domainEventCalendar.GetMessage();
            eventCalendarDTO.TimeIteration = domainEventCalendar.GetTimeIteration();
            return eventCalendarDTO;
        }
        
        public static EventCalendar EventCalendarDtoToDomainObject(EventCalendarDTO eventCalendarDto)
        {
            EventCalendar eventCalendar = new EventCalendar(
                eventCalendarDto.Id,
                eventCalendarDto.Name,
                eventCalendarDto.DateTime,
                eventCalendarDto.SupportedPlatformList,
                eventCalendarDto.Message,
                eventCalendarDto.TimeIteration
            );
            return eventCalendar;
        }
        
        public static EventCalendarDTO[] EventCalendarArrayToDtoArray(EventCalendar[] eventCalendarArray)
        {
            List<EventCalendarDTO> eventCalendarDTOList = new List<EventCalendarDTO>();
            foreach(EventCalendar currentEvent in eventCalendarArray)
            {
                eventCalendarDTOList.Add(
                    EventCalendarToDTO(
                        currentEvent
                    )
                );
            }
            return eventCalendarDTOList.ToArray();
        }
    }
}