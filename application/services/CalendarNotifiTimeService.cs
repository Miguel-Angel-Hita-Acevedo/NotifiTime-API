using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotifiTime_API.application.Dtos;
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
        
        public CalendarNotifiTimeDto GetDto()
        {
            return CalendarNotifiTimeMapper.CalendarNotifiTimeToDto(calendarNotifiTime);
        }
    
        public int EventsCalendarLength()
        {
            return calendarNotifiTime.EventsCalendarLength();
        }

        public EventCalendarDto AddEvent(EventCalendarDto eventCalendarDto)
        {
            calendarNotifiTime.AddEvent(EventCalendarMapper.EventCalendarDtoToDomainObject(eventCalendarDto));
            return eventCalendarDto;
        }
        
        public CalendarNotifiTimeDto UpdateName(string newName)
        {
            calendarNotifiTime.SetName(newName);
            return GetDto();
        }

        public bool DeleteEventById(Guid id)
        {
            return calendarNotifiTime.DeleteEventById(id);
        }

        public EventCalendarDto GetEventById(Guid id)
        {
            EventCalendar eventCalendar = (EventCalendar)calendarNotifiTime.GetEventById(id);
            return EventCalendarMapper.EventCalendarToDto (eventCalendar);
        }

        public EventCalendarDto[] SortEventsByDate(DateTime fromDate, DateTime toDate, bool ascending)
        {
            EventCalendar[] eventCalendar = (EventCalendar[])calendarNotifiTime.SortEventsByDate(fromDate, toDate, ascending);
            List<EventCalendarDto> returnEventCalendarDto = new List<EventCalendarDto>();
            foreach(EventCalendar currentEventCalendar in eventCalendar)
            {
                returnEventCalendarDto.Add(EventCalendarMapper.EventCalendarToDto(currentEventCalendar));
            }
            return returnEventCalendarDto.ToArray();
        }
        
        public EventCalendarDto[] GetAllEvents()
        {
            return EventCalendarMapper.EventCalendarArrayToDtoArray(calendarNotifiTime.GetAllEvents());
        }
        
        public EventCalendarDto UpdateEvent(EventCalendarDto eventCalendarDto)
        {
            EventCalendar eventCalendar = EventCalendarMapper.EventCalendarDtoToDomainObject(eventCalendarDto);
            eventCalendar = calendarNotifiTime.UpdateEventById(eventCalendar);
            if(eventCalendar == null)
            {
                return null;
            }
            eventCalendarDto = EventCalendarMapper.EventCalendarToDto(eventCalendar);
            return eventCalendarDto;
        }
    }
}