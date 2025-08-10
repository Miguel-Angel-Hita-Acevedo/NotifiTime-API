using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotifiTime_API.application.DTOs;
using NotifiTime_API.application.mappers;
using NotifiTime_API.domain.entities;
using NotifiTime_API.domain.Interfaces;

namespace NotifiTime_API.application.services
{
    public class WalletCalendarService
    {
        // Dictionary<Guid, CalendarNotifiTimeDTO> calendarDictionary = new Dictionary<Guid, CalendarNotifiTimeDTO>();
        private WalletCalendar walletCalendar = null;
        
        public WalletCalendarService(IWalletRepository repository)
        {
            UpdateWalletCalendar(repository.GetWalletContent());
        }
        
        private async void UpdateWalletCalendar(Task<WalletCalendar> taskWalletCalendar)
        {
            walletCalendar = await taskWalletCalendar;
        }
        
        public Exception AddCalendarNotifiTime(CalendarNotifiTimeDTO newCalendarNotifiTime)
        {
            return walletCalendar.AddCalendarNotifiTime(
                CalendarNotifiTimeMapper.CalendarNotifiTimeDTOToDomainObject(
                    newCalendarNotifiTime
                )
            );
        }

        public CalendarNotifiTimeService CreateCalendarNotifiTime(string name)
        {
            CalendarNotifiTime calendarNotifiTime = new CalendarNotifiTime(name);
            walletCalendar.AddCalendarNotifiTime(calendarNotifiTime);
            return new CalendarNotifiTimeService(calendarNotifiTime);
        }

        public Exception DeleteCalendarNotifiTimeById(Guid id)
        {
            return walletCalendar.DeleteCalendarNotifiTimeById(id);
        }
        public EventCalendarDTO FindEventCalendarByIdOnAllCalendars(Guid eventId)
        {
            EventCalendar eventCalendar = (EventCalendar)walletCalendar.FindEventCalendarByIdOnAllCalendars(eventId);
            return EventCalendarMapper.EventCalendarToDTO(eventCalendar);
        }

        public CalendarNotifiTimeService FindCalendarNotifiTimeById(Guid id)
        {
            CalendarNotifiTime calendarNotifiTime 
                = (CalendarNotifiTime)walletCalendar.FindCalendarNotifiTimeById(id);
            return new CalendarNotifiTimeService(calendarNotifiTime);
        }

        public CalendarNotifiTimeService[] FindCalendarNotifiTimeByName(string name)
        {
            CalendarNotifiTime[] calendarNotifiTimeArray 
                = (CalendarNotifiTime[])walletCalendar.FindCalendarNotifiTimeByName(name);
            return CalendarNotifiTimeMapper.DomainCalendarArrayToCalendarServiceArray(calendarNotifiTimeArray);
        }

        public CalendarNotifiTimeService[] GetCalendarNotifiTimeArray()
        {
            CalendarNotifiTime[] calendarNotifiTimeArray = (CalendarNotifiTime[])walletCalendar.GetCalendarNotifiTimeArray();
            return CalendarNotifiTimeMapper.DomainCalendarArrayToCalendarServiceArray(calendarNotifiTimeArray);
        }

        public CalendarNotifiTimeService[] SortCalendarNotifiTimeListByCreationDate(bool ascending)
        {
            CalendarNotifiTime[] calendarNotifiTimeArray = (CalendarNotifiTime[])walletCalendar.SortCalendarNotifiTimeListByCreationDate(ascending);
            return CalendarNotifiTimeMapper.DomainCalendarArrayToCalendarServiceArray(calendarNotifiTimeArray);
        }

        public CalendarNotifiTimeService[] SortCalendarNotifiTimeListByName(bool ascending)
        {
            CalendarNotifiTime[] calendarNotifiTimeArray = (CalendarNotifiTime[])walletCalendar.SortCalendarNotifiTimeListByName(ascending);
            return CalendarNotifiTimeMapper.DomainCalendarArrayToCalendarServiceArray(calendarNotifiTimeArray);
        }

        public Exception UpdateCalendarsOfUser(CalendarNotifiTimeDTO[] calendarNotifiTimeDtoArray)
        {
            try
            {
                if(calendarNotifiTimeDtoArray != null)
                {
                    CalendarNotifiTime[] calendarNotifiTimes = CalendarNotifiTimeMapper.CalendarNotifiTimesDtoToDomainObjectArray(calendarNotifiTimeDtoArray);
                    walletCalendar = new WalletCalendar(calendarNotifiTimes);
                }
            } catch(Exception e)
            {
                return e;
            }
            return null;
        }
    }
}