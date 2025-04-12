using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotifiTime_API.application.DTOs;
using NotifiTime_API.domain.entities;

namespace NotifiTime_API.application.mappers
{
    public static class CalendarEventMapper
    {
        public static CalendarEventDTO calendarEventToDTO(ICalendarEvent domainCalendarEvent)
        {
            CalendarEventDTO calendarEventDTO = new CalendarEventDTO();
            calendarEventDTO.Id = domainCalendarEvent.getId();
            calendarEventDTO.Name = domainCalendarEvent.getName();
            calendarEventDTO.DateTime = domainCalendarEvent.getDateTime();
            calendarEventDTO.SupportedPlatformList = domainCalendarEvent.getSupportedPlatformList();
            calendarEventDTO.Message = domainCalendarEvent.getMessage();
            calendarEventDTO.TimeIteration = domainCalendarEvent.getTimeIteration();
            return calendarEventDTO;
        }
    }
}