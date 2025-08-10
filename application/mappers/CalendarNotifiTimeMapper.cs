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
        public static CalendarNotifiTimeDTO CalendarNotifiTimeToDTO(CalendarNotifiTime domainCalendarNotifiTime)
        {
            CalendarNotifiTimeDTO calendarNotifiTimeDTO = new CalendarNotifiTimeDTO();
            calendarNotifiTimeDTO.Id = domainCalendarNotifiTime.GetId();
            calendarNotifiTimeDTO.Name = domainCalendarNotifiTime.GetName();
            calendarNotifiTimeDTO.EventCalendarList = EventCalendarMapper.EventCalendarArrayToDtoArray(domainCalendarNotifiTime.GetAllEvents()).ToList();
            calendarNotifiTimeDTO.CreationDate = domainCalendarNotifiTime.getCreationDate();
            return calendarNotifiTimeDTO;
        }
        
        public static CalendarNotifiTimeDTO[] CalendarNotifiTimesToDtoArray(CalendarNotifiTime[] domainCalendarNotifiTimeArray)
        {
            List<CalendarNotifiTimeDTO> calendarNotifiTimeDTOList = new List<CalendarNotifiTimeDTO>();
            foreach(CalendarNotifiTime calendarNotifiTime in domainCalendarNotifiTimeArray)
            {
                calendarNotifiTimeDTOList.Add(
                    CalendarNotifiTimeToDTO(
                        calendarNotifiTime
                    )
                );
            }
            return calendarNotifiTimeDTOList.ToArray();
        }
        
        public static CalendarNotifiTime CalendarNotifiTimeDTOToDomainObject(CalendarNotifiTimeDTO calendarDto)
        {
            Dictionary<Guid, EventCalendar> eventCalendarsDictionary = new Dictionary<Guid, EventCalendar>();
            foreach(EventCalendarDTO currentEventDto in calendarDto.EventCalendarList)
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

        public static CalendarNotifiTime[] CalendarNotifiTimesDtoToDomainObjectArray(CalendarNotifiTimeDTO[] domainCalendarNotifiTimeDtoArray)
        {
            List<CalendarNotifiTime> calendarNotifiTimeList = new List<CalendarNotifiTime>();
            foreach(CalendarNotifiTimeDTO calendarNotifiTimeDto in domainCalendarNotifiTimeDtoArray)
            {
                calendarNotifiTimeList.Add(
                    CalendarNotifiTimeDTOToDomainObject(
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