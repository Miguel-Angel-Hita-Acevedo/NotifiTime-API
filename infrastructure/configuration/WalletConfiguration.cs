using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotifiTime_API.application.Dtos;
using NotifiTime_API.application.mappers;
using NotifiTime_API.application.services;
using NotifiTime_API.domain.entities;
using NotifiTime_API.domain.Enum;
using NotifiTime_API.domain.Interfaces;
using NotifiTime_API.infrastructure.entities;
using NotifiTime_API.infrastructure.repositories;

namespace NotifiTime_API.infrastructure.configuration
{
    public class WalletConfiguration
    {
        private WalletCalendarService walletCalendarService;
        private static WalletConfiguration singleton = null;

        private WalletConfiguration()
        {
        }
        
        public static WalletConfiguration GetWalletConfiguration()
        {
            if(singleton == null)
            {
                singleton = new WalletConfiguration();
            }
            return singleton;
        }
        
        public Exception Start()
        {
            walletCalendarService = new WalletCalendarService(new FakeWalletRepository());
            return null;
        }
        
        public Exception Close()
        {
            singleton = null;
            return null;
        }
        
        public CalendarNotifiTimeDto[] GetAllCalendars()
        {
            return CalendarNotifiTimeMapper.CalendarServiceArrayToCalendarDtoArray(walletCalendarService.GetCalendarNotifiTimeArray());
        }
        
        public EventCalendarDto[] GetEventsInCalendar(Guid calendarId)
        {
            CalendarNotifiTimeService calendarFound = walletCalendarService.FindCalendarNotifiTimeById(calendarId);
            return calendarFound != null ? calendarFound.GetAllEvents() : null;
        }
        
        public CalendarNotifiTimeDto UpdateCalendarName(Guid calendarId, string newName)
        {
            CalendarNotifiTimeService calendarFound = walletCalendarService.FindCalendarNotifiTimeById(calendarId);
            CalendarNotifiTimeDto returnCalendarDto = null;
            if(calendarFound != null)
            {
                returnCalendarDto = calendarFound.UpdateName(newName);
            }
            return returnCalendarDto;
        }
        
        public EventCalendarDto UpdateEventCalendar(Guid calendarId, EventCalendarDto eventCalendarDto)
        {
            CalendarNotifiTimeService calendarService = walletCalendarService.FindCalendarNotifiTimeById(calendarId);
            return calendarService.UpdateEvent(eventCalendarDto);
        }
    }
}