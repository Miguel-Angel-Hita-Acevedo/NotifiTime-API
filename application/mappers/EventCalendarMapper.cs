using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotifiTime_API.application.Dtos;
using NotifiTime_API.domain.entities;

namespace NotifiTime_API.application.mappers
{
    public static class EventCalendarMapper
    {
        public static EventCalendarDto EventCalendarToDto(EventCalendar domainEventCalendar)
        {
            EventCalendarDto eventCalendarDto = new EventCalendarDto();
            eventCalendarDto.Id = domainEventCalendar.GetId();
            eventCalendarDto.Name = domainEventCalendar.GetName();
            eventCalendarDto.DateTime = domainEventCalendar.GetDateTime();
            eventCalendarDto.SupportedPlatformList = domainEventCalendar.GetSupportedPlatformList();
            eventCalendarDto.Message = domainEventCalendar.GetMessage();
            eventCalendarDto.TimeIteration = domainEventCalendar.GetTimeIteration();
            return eventCalendarDto;
        }
        
        public static EventCalendar EventCalendarDtoToDomainObject(EventCalendarDto eventCalendarDto)
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
        
        public static EventCalendarDto[] EventCalendarArrayToDtoArray(EventCalendar[] eventCalendarArray)
        {
            List<EventCalendarDto> eventCalendarDtoList = new List<EventCalendarDto>();
            foreach(EventCalendar currentEvent in eventCalendarArray)
            {
                eventCalendarDtoList.Add(
                    EventCalendarToDto(
                        currentEvent
                    )
                );
            }
            return eventCalendarDtoList.ToArray();
        }
    }
}