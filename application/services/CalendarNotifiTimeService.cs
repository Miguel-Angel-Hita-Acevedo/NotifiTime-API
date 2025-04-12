using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotifiTime_API.application.DTOs;
using NotifiTime_API.application.Interfaces;
using NotifiTime_API.application.mappers;
using NotifiTime_API.domain.entities;

namespace NotifiTime_API.application.services
{
    public class CalendarNotifiTimeService : ICalendarNotifiTimeService
    {
        Dictionary<Guid, CalendarNotifiTimeDTO> calendarDictionary = new Dictionary<Guid, CalendarNotifiTimeDTO>();

        public CalendarNotifiTimeService()
        {
            updateCalendarsOfUser();
        }
        
        public Exception addCalendarNotifiTime(CalendarNotifiTimeDTO newCalendarNotifiTime)
        {
            try
            {
                if(!calendarDictionary.ContainsKey(newCalendarNotifiTime.Id))
                {
                    calendarDictionary.Add(newCalendarNotifiTime.Id, newCalendarNotifiTime);
                }
            } catch(Exception ex)
            {
                return ex;
            }
            return null;
        }

        public CalendarNotifiTimeDTO createCalendarNotifiTime(string name)
        {
            CalendarNotifiTimeDTO newCalendarNotifiTime = null;
            try
            {
                CalendarNotifiTimeDTO newCalendarNotifitimeDTO = new CalendarNotifiTimeDTO();
                CalendarNotifiTimeMapper.calendarNotifiTimeToDTO(new CalendarNotifiTime(name));
                calendarDictionary.Add(newCalendarNotifitimeDTO.Id, newCalendarNotifitimeDTO);
            } catch(Exception ex)
            {
                return null;
            }
            return newCalendarNotifiTime;
        }

        public Exception deleteCalendarNotifiTimeById(Guid id)
        {
            try
            {
                if(!calendarDictionary.ContainsKey(id))
                {
                    calendarDictionary.Remove(id);
                }
            } catch(Exception ex)
            {
                return ex;
            }
            return null;
        }

// PENDIENTE DE TERMINAR CALENDAR EVENTSSERVICE
        public CalendarEventDTO findCalendarEventByIdOnAllCalendars(Guid eventId)
        {
            List<CalendarEventDTO> calendarsEventFound = new List<CalendarEventDTO>();
            CalendarNotifiTimeDTO[] calendarsNotifiTimeArray = calendarDictionary.Values.ToArray();
            foreach(CalendarNotifiTimeDTO currentCalendar in calendarsNotifiTimeArray)
            {
                // pending finish of calendareventsservice
            }
            return null;
        }

        public CalendarNotifiTimeDTO findCalendarNotifiTimeById(Guid id)
        {
            throw new NotImplementedException();
        }

        public CalendarNotifiTimeDTO[] findCalendarNotifiTimeByName(string name)
        {
            throw new NotImplementedException();
        }

        public CalendarNotifiTimeDTO[] getCalendarNotifiTimeArray()
        {
            throw new NotImplementedException();
        }

        public CalendarNotifiTimeDTO[] sortCalendarNotifiTimeListByCreationDate(bool ascending)
        {
            throw new NotImplementedException();
        }

        public CalendarNotifiTimeDTO[] sortCalendarNotifiTimeListByName(bool ascending)
        {
            throw new NotImplementedException();
        }

        public Exception updateCalendarsOfUser()
        {
            calendarDictionary = new Dictionary<Guid, CalendarNotifiTimeDTO>();
            // update of calendarDictionary from database if is data saved previusly
            throw new NotImplementedException();
        }
    }
}