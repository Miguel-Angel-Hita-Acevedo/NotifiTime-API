using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotifiTime_API.application.DTOs;
using NotifiTime_API.application.services;
using NotifiTime_API.domain.entities;

namespace NotifiTime_API.application.mappers
{
    public static class CalendarNotifiTimeMapper
    {
        public static CalendarNotifiTimeDTO calendarNotifiTimeToDTO(ICalendarNotifiTime domainCalendarNotifiTime)
        {
            CalendarNotifiTimeDTO calendarNotifiTimeDTO = new CalendarNotifiTimeDTO();
            calendarNotifiTimeDTO.Id = domainCalendarNotifiTime.getId();
            calendarNotifiTimeDTO.Name = domainCalendarNotifiTime.getName();
            return calendarNotifiTimeDTO;
        }
        
        public static CalendarNotifiTimeDTO[] calendarNotifiTimesToDtoArray(ICalendarNotifiTime[] domainCalendarNotifiTimeArray)
        {
            List<CalendarNotifiTimeDTO> calendarNotifiTimeDTOList = new List<CalendarNotifiTimeDTO>();
            foreach(CalendarNotifiTime calendarNotifiTime in domainCalendarNotifiTimeArray)
            {
                calendarNotifiTimeDTOList.Add(
                    calendarNotifiTimeToDTO(
                        calendarNotifiTime
                    )
                );
            }
            return calendarNotifiTimeDTOList.ToArray();
        }
        
        public static CalendarNotifiTime calendarNotifiTimeDTOToDomainObject(CalendarNotifiTimeDTO calendarDto)
        {
            Dictionary<Guid, EventCalendar> eventCalendarsDictionary = new Dictionary<Guid, EventCalendar>();
            foreach(EventCalendarDTO currentEventDto in calendarDto.EventCalendarDictionary.Values)
            {
                eventCalendarsDictionary.Add(
                    currentEventDto.Id,
                    EventCalendarMapper.eventCalendarDtoToDomainObject(currentEventDto)
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

        public static CalendarNotifiTime[] calendarNotifiTimesDtoToDomainObjectArray(CalendarNotifiTimeDTO[] domainCalendarNotifiTimeDtoArray)
        {
            List<CalendarNotifiTime> calendarNotifiTimeList = new List<CalendarNotifiTime>();
            foreach(CalendarNotifiTimeDTO calendarNotifiTimeDto in domainCalendarNotifiTimeDtoArray)
            {
                calendarNotifiTimeList.Add(
                    calendarNotifiTimeDTOToDomainObject(
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
        
        public static CalendarNotifiTimeDTO[] CalendarServiceArrayToCalendarDtoArray(CalendarNotifiTimeService[] calendarNotifiTimeServiceArray)
        {
            List<CalendarNotifiTimeDTO> calendarNotifiTimeDtoList = new List<CalendarNotifiTimeDTO>();
            foreach(CalendarNotifiTimeService currentCalendarService in calendarNotifiTimeServiceArray)
            {
                calendarNotifiTimeDtoList.Add(currentCalendarService.GetDto());
            }
            return calendarNotifiTimeDtoList.ToArray();
        }
    }
}