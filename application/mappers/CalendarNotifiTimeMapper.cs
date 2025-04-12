using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotifiTime_API.application.DTOs;
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
    }
}