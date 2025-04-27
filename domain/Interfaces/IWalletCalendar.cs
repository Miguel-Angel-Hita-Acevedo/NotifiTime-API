using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotifiTime_API.domain.entities;

namespace NotifiTime_API.domain.Interfaces
{
    public interface IWalletCalendar
    {
        public bool addCalendarNotifiTime(ICalendarNotifiTime newCalendarNotifiTime);
        public bool deleteCalendarNotifiTimeById(Guid id);
        public IEventCalendar findEventCalendarByIdOnAllCalendars(Guid eventId);
        public ICalendarNotifiTime findCalendarNotifiTimeById(Guid id);
        public ICalendarNotifiTime[] findCalendarNotifiTimeByName(string name);
        public ICalendarNotifiTime[] getCalendarNotifiTimeArray();
        public ICalendarNotifiTime[] sortCalendarNotifiTimeListByCreationDate(bool ascending);
        public ICalendarNotifiTime[] sortCalendarNotifiTimeListByName(bool ascending);
    }
}