using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotifiTime_API.application.DTOs;
using NotifiTime_API.application.mappers;
using NotifiTime_API.domain.entities;
using NotifiTime_API.domain.Enum;

namespace NotifiTime_API.application.services
{
    public class CalendarNotifiTimeService
    {
        private ICalendarNotifiTime calendarNotifiTime;
        
        public CalendarNotifiTimeService(ICalendarNotifiTime calendarNotifiTime)
        {
            this.calendarNotifiTime = calendarNotifiTime;
        }
        
        public CalendarNotifiTimeDTO GetDto()
        {
            return CalendarNotifiTimeMapper.calendarNotifiTimeToDTO(calendarNotifiTime);
        }
    
        public int eventsCalendarLength()
        {
            return calendarNotifiTime.eventsCalendarLength();
        }

        public EventCalendarDTO createEvent(DateTime date, string name, TimeIteration timeIteration)
        {
            EventCalendar eventCalendar = (EventCalendar)calendarNotifiTime.createEvent(date, name, timeIteration);
            return EventCalendarMapper.eventCalendarToDTO(eventCalendar);
        }
        
        public CalendarNotifiTimeDTO UpdateName(string newName)
        {
            calendarNotifiTime.setName(newName);
            return GetDto();
        }

        public bool deleteEventById(Guid id)
        {
            return calendarNotifiTime.deleteEventById(id);
        }

        public EventCalendarDTO getEventById(Guid id)
        {
            EventCalendar eventCalendar = (EventCalendar)calendarNotifiTime.getEventById(id);
            return EventCalendarMapper.eventCalendarToDTO (eventCalendar);
        }

        public EventCalendarDTO[] sortEventsByDate(DateTime fromDate, DateTime toDate, bool ascending)
        {
            EventCalendar[] eventCalendar = (EventCalendar[])calendarNotifiTime.sortEventsByDate(fromDate, toDate, ascending);
            List<EventCalendarDTO> returnEventCalendarDTO = new List<EventCalendarDTO>();
            foreach(EventCalendar currentEventCalendar in eventCalendar)
            {
                returnEventCalendarDTO.Add(EventCalendarMapper.eventCalendarToDTO(currentEventCalendar));
            }
            return returnEventCalendarDTO.ToArray();
        }
        
        public EventCalendarDTO[] GetAllEvents()
        {
            return EventCalendarMapper.eventCalendarArrayToDtoArray(calendarNotifiTime.GetAllEvents());
        }
    }
}