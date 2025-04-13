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
        public static EventCalendarDTO eventCalendarToDTO(IEventCalendar domainEventCalendar)
        {
            EventCalendarDTO eventCalendarDTO = new EventCalendarDTO();
            eventCalendarDTO.Id = domainEventCalendar.getId();
            eventCalendarDTO.Name = domainEventCalendar.getName();
            eventCalendarDTO.DateTime = domainEventCalendar.getDateTime();
            eventCalendarDTO.SupportedPlatformList = domainEventCalendar.getSupportedPlatformList();
            eventCalendarDTO.Message = domainEventCalendar.getMessage();
            eventCalendarDTO.TimeIteration = domainEventCalendar.getTimeIteration();
            return eventCalendarDTO;
        }
    }
}