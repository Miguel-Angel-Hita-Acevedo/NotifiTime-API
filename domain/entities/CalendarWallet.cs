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
            ICalendarEvent tempCalendarEvent;
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
            ICalendarNotifiTime calendarFound;
            bool found = calendarDictionary.TryGetValue(id, out calendarFound);
            return found ? calendarFound : null;
        }

        public ICalendarNotifiTime[] findCalendarNotifiTimeByName(string name)
        {
            ICalendarNotifiTime[] calendarArray = calendarDictionary.Values.ToArray();
            List<ICalendarNotifiTime> calendarFoundList = new List<ICalendarNotifiTime>();
            foreach(ICalendarNotifiTime calendarNotifiTime in calendarArray)
            {
                if(calendarNotifiTime.getName().Equals(name))
                {
                    calendarFoundList.Add(calendarNotifiTime);
                }
            }
            return calendarFoundList.ToArray();
        }

        public ICalendarNotifiTime[] getCalendarNotifiTimeArray()
        {
            return calendarDictionary.Values.ToArray();
        }

        public ICalendarNotifiTime[] sortCalendarNotifiTimeListByCreationDate(bool ascending)
        {
            List<ICalendarNotifiTime> calendarDictionaryAsList = calendarDictionary.Values.ToList();
            
            calendarDictionaryAsList.Sort(
                (ICalendarNotifiTime oneCalendar, ICalendarNotifiTime otherCalendar) 
                    => otherCalendar.getCreationDate().CompareTo(oneCalendar.getCreationDate()));
            ICalendarNotifiTime[] sortedCalendarByCreationDate = calendarDictionaryAsList.ToArray();
            
            if (ascending)
            {
                Array.Reverse(sortedCalendarByCreationDate);
            }
            
            return sortedCalendarByCreationDate;
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