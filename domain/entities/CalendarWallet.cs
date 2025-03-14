using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotifiTime_API.domain.Interfaces;

namespace NotifiTime_API.domain.entities
{
    public class CalendarWallet : ICalendarWallet
    {
        public Dictionary<Guid, ICalendarNotifiTime> calendarDictionary = new Dictionary<Guid, ICalendarNotifiTime>();
        
        public CalendarWallet()
        {
            
        }
    
        public bool addCalendarNotifiTime(ICalendarNotifiTime newCalendarNotifiTime)
        {
            return calendarDictionary.TryAdd(newCalendarNotifiTime.getId(), newCalendarNotifiTime);
        }

        public bool deleteCalendarNotifiTimeById(Guid id)
        {
            return calendarDictionary.Remove(id);
        }

        public ICalendarEvent[] findCalendarEventsByIdOnAllCalendars(Guid eventId)
        {
            ICalendarNotifiTime[] calendarArray = calendarDictionary.Values.ToArray();
            List<ICalendarEvent> calendarEventList = new List<ICalendarEvent>();
            ICalendarEvent tempCalendarEvent = null;
            foreach(ICalendarNotifiTime calendarNotifiTime in calendarArray)
            {
                tempCalendarEvent = calendarNotifiTime.getEventById(eventId);
                if(tempCalendarEvent != null)
                {
                    calendarEventList.Add(tempCalendarEvent);
                }
            }
            return calendarEventList.ToArray();
        }

        public ICalendarNotifiTime findCalendarNotifiTimeById(Guid id)
        {
            throw new NotImplementedException();
        }

        public ICalendarNotifiTime[] findCalendarNotifiTimeByName(string name)
        {
            throw new NotImplementedException();
        }

        public ICalendarNotifiTime[] getCalendarNotifiTimeArray()
        {
            throw new NotImplementedException();
        }

        public ICalendarNotifiTime[] sortCalendarNotifiTimeListByCreationDate(bool ascending)
        {
            throw new NotImplementedException();
        }

        public ICalendarNotifiTime[] sortCalendarNotifiTimeListByName(bool ascending)
        {
            throw new NotImplementedException();
        }

        public Exception updateCalendarsNotifiTime()
        {
            throw new NotImplementedException();
        }
    }
}