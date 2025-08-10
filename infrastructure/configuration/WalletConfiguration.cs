using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotifiTime_API.application.DTOs;
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
        
        public CalendarNotifiTimeDTO[] GetAllCalendars()
        {
            return CalendarNotifiTimeMapper.CalendarServiceArrayToCalendarDtoArray(walletCalendarService.GetCalendarNotifiTimeArray());
        }
        
        public EventCalendarDTO[] GetEventsInCalendar(Guid calendarId)
        {
            CalendarNotifiTimeService calendarFound = walletCalendarService.FindCalendarNotifiTimeById(calendarId);
            return calendarFound != null ? calendarFound.GetAllEvents() : null;
        }
        
        public CalendarNotifiTimeDTO UpdateCalendarName(Guid calendarId, string newName)
        {
            CalendarNotifiTimeService calendarFound = walletCalendarService.FindCalendarNotifiTimeById(calendarId);
            CalendarNotifiTimeDTO returnCalendarDto = null;
            if(calendarFound != null)
            {
                returnCalendarDto = calendarFound.UpdateName(newName);
            }
            return returnCalendarDto;
        }
        
        public EventCalendarDTO UpdateEventCalendar(Guid calendarId, EventCalendarDTO eventCalendarDto)
        {
            CalendarNotifiTimeService calendarService = walletCalendarService.FindCalendarNotifiTimeById(calendarId);
            return calendarService.UpdateEvent(eventCalendarDto);
        }
    }
}