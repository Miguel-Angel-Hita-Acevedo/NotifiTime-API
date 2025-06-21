using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotifiTime_API.application.DTOs;
using NotifiTime_API.application.mappers;
using NotifiTime_API.domain.entities;

namespace NotifiTime_API.application.services
{
    public class WalletCalendarService
    {
        // Dictionary<Guid, CalendarNotifiTimeDTO> calendarDictionary = new Dictionary<Guid, CalendarNotifiTimeDTO>();
        private WalletCalendar walletCalendar;

        public WalletCalendarService(CalendarNotifiTimeDTO[] calendarNotifiTimeDtoArray)
        {
            walletCalendar = new WalletCalendar();
            updateCalendarsOfUser(calendarNotifiTimeDtoArray);
        }
        
        public Exception addCalendarNotifiTime(CalendarNotifiTimeDTO newCalendarNotifiTime)
        {
            return walletCalendar.addCalendarNotifiTime(
                CalendarNotifiTimeMapper.calendarNotifiTimeDTOToDomainObject(
                    newCalendarNotifiTime
                )
            );
        }

        public CalendarNotifiTimeDTO createCalendarNotifiTime(string name)
        {
            CalendarNotifiTime calendarNotifiTime = new CalendarNotifiTime(name);
            walletCalendar.addCalendarNotifiTime(calendarNotifiTime);
            return CalendarNotifiTimeMapper.calendarNotifiTimeToDTO(calendarNotifiTime);
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

        public CalendarNotifiTimeDTO findCalendarNotifiTimeById(Guid id)
        {
            CalendarNotifiTime calendarNotifiTime 
                = (CalendarNotifiTime)walletCalendar.findCalendarNotifiTimeById(id);
            return CalendarNotifiTimeMapper.calendarNotifiTimeToDTO(calendarNotifiTime);
        }

        public CalendarNotifiTimeDTO[] findCalendarNotifiTimeByName(string name)
        {
            CalendarNotifiTime[] calendarNotifiTimeArray 
                = (CalendarNotifiTime[])walletCalendar.findCalendarNotifiTimeByName(name);
            return CalendarNotifiTimeMapper.calendarNotifiTimesToDtoArray(calendarNotifiTimeArray);
        }

        public CalendarNotifiTimeDTO[] getCalendarNotifiTimeArray()
        {
            CalendarNotifiTime[] calendarNotifiTimeArray = (CalendarNotifiTime[])walletCalendar.getCalendarNotifiTimeArray();
            return CalendarNotifiTimeMapper.calendarNotifiTimesToDtoArray(calendarNotifiTimeArray);
        }

        public CalendarNotifiTimeDTO[] sortCalendarNotifiTimeListByCreationDate(bool ascending)
        {
            CalendarNotifiTime[] calendarNotifiTimeArray = (CalendarNotifiTime[])walletCalendar.sortCalendarNotifiTimeListByCreationDate(ascending);
            return CalendarNotifiTimeMapper.calendarNotifiTimesToDtoArray(calendarNotifiTimeArray);
        }

        public CalendarNotifiTimeDTO[] sortCalendarNotifiTimeListByName(bool ascending)
        {
            CalendarNotifiTime[] calendarNotifiTimeArray = (CalendarNotifiTime[])walletCalendar.sortCalendarNotifiTimeListByName(ascending);
            return CalendarNotifiTimeMapper.calendarNotifiTimesToDtoArray(calendarNotifiTimeArray);
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