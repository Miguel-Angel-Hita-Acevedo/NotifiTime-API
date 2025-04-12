using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotifiTime_API.application.DTOs;
using NotifiTime_API.application.Interfaces;
using NotifiTime_API.application.mappers;
using NotifiTime_API.domain.entities;
using NotifiTime_API.domain.Enum;

namespace NotifiTime_API.application.services
{
    public class CalendarEventsService : ICalendarEventsService
    {
        private CalendarNotifiTimeDTO calendarNotifiTimeDTO = new CalendarNotifiTimeDTO();
        
        public CalendarEventsService(ICalendarNotifiTime calendarNotifiTime)
        {
            CalendarNotifiTimeMapper.calendarNotifiTimeToDTO(calendarNotifiTime);
        }
    
        public int calendarEventsLength()
        {
            throw new NotImplementedException();
        }

        public CalendarEventDTO createEvent(DateTime date, string name, TimeIteration timeIteration)
        {
            throw new NotImplementedException();
        }

        public bool deleteEventById(Guid id)
        {
            throw new NotImplementedException();
        }

        public CalendarEventDTO getEventById(Guid id)
        {
            throw new NotImplementedException();
        }

        public CalendarEventDTO[] sortEventsByDate(DateTime fromDate, DateTime toDate, bool ascending)
        {
            throw new NotImplementedException();
        }
    }
}