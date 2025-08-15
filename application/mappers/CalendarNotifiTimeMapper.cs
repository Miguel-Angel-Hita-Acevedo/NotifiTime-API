using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotifiTime_API.application.Dtos;
using NotifiTime_API.application.services;
using NotifiTime_API.domain.entities;

namespace NotifiTime_API.application.mappers
{
    public static class CalendarNotifiTimeMapper
    {
        public static CalendarNotifiTimeDto CalendarNotifiTimeToDto(CalendarNotifiTime domainCalendarNotifiTime)
        {
            CalendarNotifiTimeDto calendarNotifiTimeDto = new CalendarNotifiTimeDto();
            calendarNotifiTimeDto.Id = domainCalendarNotifiTime.GetId();
            calendarNotifiTimeDto.Name = domainCalendarNotifiTime.GetName();
            calendarNotifiTimeDto.EventCalendarList = EventCalendarMapper.EventCalendarArrayToDtoArray(domainCalendarNotifiTime.GetAllEvents()).ToList();
            calendarNotifiTimeDto.CreationDate = domainCalendarNotifiTime.getCreationDate();
            return calendarNotifiTimeDto;
        }
        
        public static CalendarNotifiTimeDto[] CalendarNotifiTimesToDtoArray(CalendarNotifiTime[] domainCalendarNotifiTimeArray)
        {
            List<CalendarNotifiTimeDto> calendarNotifiTimeDtoList = new List<CalendarNotifiTimeDto>();
            foreach(CalendarNotifiTime calendarNotifiTime in domainCalendarNotifiTimeArray)
            {
                calendarNotifiTimeDtoList.Add(
                    CalendarNotifiTimeToDto(
                        calendarNotifiTime
                    )
                );
            }
            return calendarNotifiTimeDtoList.ToArray();
        }
        
        public static CalendarNotifiTime CalendarNotifiTimeDtoToDomainObject(CalendarNotifiTimeDto calendarDto)
        {
            Dictionary<Guid, EventCalendar> eventCalendarsDictionary = new Dictionary<Guid, EventCalendar>();
            foreach(EventCalendarDto currentEventDto in calendarDto.EventCalendarList)
            {
                eventCalendarsDictionary.Add(
                    currentEventDto.Id,
                    EventCalendarMapper.EventCalendarDtoToDomainObject(currentEventDto)
                );
            }
            CalendarNotifiTime calendarNotifiTime = new CalendarNotifiTime(
                calendarDto.Id,
                calendarDto.Name,
                eventCalendarsDictionary,
                calendarDto.CreationDate
            );
            return calendarNotifiTime;
        }

        public static CalendarNotifiTime[] CalendarNotifiTimesDtoToDomainObjectArray(CalendarNotifiTimeDto[] domainCalendarNotifiTimeDtoArray)
        {
            List<CalendarNotifiTime> calendarNotifiTimeList = new List<CalendarNotifiTime>();
            foreach(CalendarNotifiTimeDto calendarNotifiTimeDto in domainCalendarNotifiTimeDtoArray)
            {
                calendarNotifiTimeList.Add(
                    CalendarNotifiTimeDtoToDomainObject(
                        calendarNotifiTimeDto
                    )
                );
            }
            return calendarNotifiTimeList.ToArray();
        }
        
        public static CalendarNotifiTimeService[] DomainCalendarArrayToCalendarServiceArray(CalendarNotifiTime[] calendarNotifiTimeArray)
        {
            List<CalendarNotifiTimeService> calendarNotifiTimeServiceList = new List<CalendarNotifiTimeService>();
            foreach(CalendarNotifiTime currentCalendar in calendarNotifiTimeArray)
            {
                calendarNotifiTimeServiceList.Add(new CalendarNotifiTimeService(currentCalendar));
            }
            return calendarNotifiTimeServiceList.ToArray();
        }
        
        public static CalendarNotifiTimeDto[] CalendarServiceArrayToCalendarDtoArray(CalendarNotifiTimeService[] calendarNotifiTimeServiceArray)
        {
            List<CalendarNotifiTimeDto> calendarNotifiTimeDtoList = new List<CalendarNotifiTimeDto>();
            foreach(CalendarNotifiTimeService currentCalendarService in calendarNotifiTimeServiceArray)
            {
                calendarNotifiTimeDtoList.Add(currentCalendarService.GetDto());
            }
            return calendarNotifiTimeDtoList.ToArray();
        }
    }
}