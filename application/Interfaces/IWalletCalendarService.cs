using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotifiTime_API.application.DTOs;
using NotifiTime_API.domain.Enum;

namespace NotifiTime_API.application.Interfaces
{
    // To manage calendars of one user
    public interface IWalletCalendarService
    {
        public Exception updateCalendarsOfUser(CalendarNotifiTimeDTO[] calendarNotifiTimeDtoArray);
        public CalendarNotifiTimeDTO createCalendarNotifiTime(string name);
        public Exception addCalendarNotifiTime(CalendarNotifiTimeDTO newCalendarNotifiTime);
        public CalendarNotifiTimeDTO[] getCalendarNotifiTimeArray();
        public CalendarNotifiTimeDTO[] sortCalendarNotifiTimeListByName(bool ascending);
        public CalendarNotifiTimeDTO[] sortCalendarNotifiTimeListByCreationDate(bool ascending);
        public CalendarNotifiTimeDTO findCalendarNotifiTimeById(Guid id);
        public CalendarNotifiTimeDTO[] findCalendarNotifiTimeByName(string name);
        public EventCalendarDTO findEventCalendarByIdOnAllCalendars(Guid eventId);
        public Exception deleteCalendarNotifiTimeById(Guid id);
    }
}