using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotifiTime_API.application.DTOs;
using NotifiTime_API.application.mappers;
using NotifiTime_API.application.services;
using NotifiTime_API.domain.entities;
using NotifiTime_API.infrastructure.entities;

namespace NotifiTime_API.infrastructure.configuration
{
    public class WalletConfiguration
    {
        private WalletCalendarService walletCalendarService;
        
        public WalletConfiguration()
        {
            ICalendarNotifiTime calendar = new CalendarNotifiTime(Guid.Parse("08ddcebf-049e-32de-f96a-8e59b0051f19"), "Default calendar", new Dictionary<Guid, EventCalendar>(), DateTime.Today);
            walletCalendarService = new WalletCalendarService([CalendarNotifiTimeMapper.calendarNotifiTimeToDTO(calendar)]);
        }
        
        public CalendarNotifiTimeDTO[] GetAllCalendars()
        {
            return CalendarNotifiTimeMapper.CalendarServiceArrayToCalendarDtoArray(walletCalendarService.getCalendarNotifiTimeArray());
        }
        
        public EventCalendarDTO[] GetEventsInCalendar(Guid calendarId)
        {
            CalendarNotifiTimeService calendarFound = walletCalendarService.findCalendarNotifiTimeById(calendarId);
            return calendarFound != null ? calendarFound.GetAllEvents() : null;
        }
    }
}