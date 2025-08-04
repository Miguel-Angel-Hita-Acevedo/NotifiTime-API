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
        
        public Exception addCalendarNotifiTime(CalendarNotifiTimeDTO newCalendarNotifiTime)
        {
            return walletCalendar.addCalendarNotifiTime(
                CalendarNotifiTimeMapper.calendarNotifiTimeDTOToDomainObject(
                    newCalendarNotifiTime
                )
            );
        }

        public CalendarNotifiTimeService createCalendarNotifiTime(string name)
        {
            CalendarNotifiTime calendarNotifiTime = new CalendarNotifiTime(name);
            walletCalendar.addCalendarNotifiTime(calendarNotifiTime);
            return new CalendarNotifiTimeService(calendarNotifiTime);
        }

        public Exception deleteCalendarNotifiTimeById(Guid id)
        {
            return walletCalendar.deleteCalendarNotifiTimeById(id);
        }
        public EventCalendarDTO findEventCalendarByIdOnAllCalendars(Guid eventId)
        {
            EventCalendar eventCalendar = (EventCalendar)walletCalendar.findEventCalendarByIdOnAllCalendars(eventId);
            return EventCalendarMapper.eventCalendarToDTO(eventCalendar);
        }

        public CalendarNotifiTimeService findCalendarNotifiTimeById(Guid id)
        {
            CalendarNotifiTime calendarNotifiTime 
                = (CalendarNotifiTime)walletCalendar.findCalendarNotifiTimeById(id);
            return new CalendarNotifiTimeService(calendarNotifiTime);
        }

        public CalendarNotifiTimeService[] findCalendarNotifiTimeByName(string name)
        {
            CalendarNotifiTime[] calendarNotifiTimeArray 
                = (CalendarNotifiTime[])walletCalendar.findCalendarNotifiTimeByName(name);
            return CalendarNotifiTimeMapper.DomainCalendarArrayToCalendarServiceArray(calendarNotifiTimeArray);
        }

        public CalendarNotifiTimeService[] getCalendarNotifiTimeArray()
        {
            CalendarNotifiTime[] calendarNotifiTimeArray = (CalendarNotifiTime[])walletCalendar.getCalendarNotifiTimeArray();
            return CalendarNotifiTimeMapper.DomainCalendarArrayToCalendarServiceArray(calendarNotifiTimeArray);
        }

        public CalendarNotifiTimeService[] sortCalendarNotifiTimeListByCreationDate(bool ascending)
        {
            CalendarNotifiTime[] calendarNotifiTimeArray = (CalendarNotifiTime[])walletCalendar.sortCalendarNotifiTimeListByCreationDate(ascending);
            return CalendarNotifiTimeMapper.DomainCalendarArrayToCalendarServiceArray(calendarNotifiTimeArray);
        }

        public CalendarNotifiTimeService[] sortCalendarNotifiTimeListByName(bool ascending)
        {
            CalendarNotifiTime[] calendarNotifiTimeArray = (CalendarNotifiTime[])walletCalendar.sortCalendarNotifiTimeListByName(ascending);
            return CalendarNotifiTimeMapper.DomainCalendarArrayToCalendarServiceArray(calendarNotifiTimeArray);
        }

        public Exception updateCalendarsOfUser(CalendarNotifiTimeDTO[] calendarNotifiTimeDtoArray)
        {
            try
            {
                if(calendarNotifiTimeDtoArray != null)
                {
                    CalendarNotifiTime[] calendarNotifiTimes = CalendarNotifiTimeMapper.calendarNotifiTimesDtoToDomainObjectArray(calendarNotifiTimeDtoArray);
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