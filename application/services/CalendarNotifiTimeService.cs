using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotifiTime_API.application.DTOs;
using NotifiTime_API.application.Interfaces;

namespace NotifiTime_API.application.services
{
    public class CalendarNotifiTimeService : ICalendarNotifiTimeService
    {
        public CalendarNotifiTimeDTO addCalendarNotifiTime(CalendarNotifiTimeDTO newCalendarNotifiTime)
        {
            throw new NotImplementedException();
        }

        public CalendarNotifiTimeDTO createCalendarNotifiTime(string name)
        {
            throw new NotImplementedException();
        }

        public Exception deleteCalendarNotifiTimeById(Guid id)
        {
            throw new NotImplementedException();
        }

        public CalendarEventDTO findCalendarEventByIdOnAllCalendarse(Guid eventId)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}