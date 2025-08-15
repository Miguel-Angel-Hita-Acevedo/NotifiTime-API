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
        private CalendarNotifiTime calendarNotifiTime;
        
        public CalendarNotifiTimeService(CalendarNotifiTime calendarNotifiTime)
        {
            this.calendarNotifiTime = calendarNotifiTime;
        }
        
        public CalendarNotifiTimeDTO GetDto()
        {
            return CalendarNotifiTimeMapper.CalendarNotifiTimeToDTO(calendarNotifiTime);
        }
    
        public int EventsCalendarLength()
        {
            return calendarNotifiTime.EventsCalendarLength();
        }

        public EventCalendarDTO AddEvent(EventCalendarDTO eventCalendarDto)
        {
            calendarNotifiTime.AddEvent(EventCalendarMapper.EventCalendarDtoToDomainObject(eventCalendarDto));
            return eventCalendarDto;
        }
        
        public CalendarNotifiTimeDTO UpdateName(string newName)
        {
            calendarNotifiTime.SetName(newName);
            return GetDto();
        }

        public bool DeleteEventById(Guid id)
        {
            return calendarNotifiTime.DeleteEventById(id);
        }

        public EventCalendarDTO GetEventById(Guid id)
        {
            EventCalendar eventCalendar = (EventCalendar)calendarNotifiTime.GetEventById(id);
            return EventCalendarMapper.EventCalendarToDTO (eventCalendar);
        }

        public EventCalendarDTO[] SortEventsByDate(DateTime fromDate, DateTime toDate, bool ascending)
        {
            EventCalendar[] eventCalendar = (EventCalendar[])calendarNotifiTime.SortEventsByDate(fromDate, toDate, ascending);
            List<EventCalendarDTO> returnEventCalendarDTO = new List<EventCalendarDTO>();
            foreach(EventCalendar currentEventCalendar in eventCalendar)
            {
                returnEventCalendarDTO.Add(EventCalendarMapper.EventCalendarToDTO(currentEventCalendar));
            }
            return returnEventCalendarDTO.ToArray();
        }
        
        public EventCalendarDTO[] GetAllEvents()
        {
            return EventCalendarMapper.EventCalendarArrayToDtoArray(calendarNotifiTime.GetAllEvents());
        }
        
        public EventCalendarDTO UpdateEvent(EventCalendarDTO eventCalendarDto)
        {
            EventCalendar eventCalendar = EventCalendarMapper.EventCalendarDtoToDomainObject(eventCalendarDto);
            eventCalendar = calendarNotifiTime.UpdateEventById(eventCalendar);
            if(eventCalendar == null)
            {
                return null;
            }
            eventCalendarDto = EventCalendarMapper.EventCalendarToDTO(eventCalendar);
            return eventCalendarDto;
        }
    }
}