using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotifiTime_API.domain.Interfaces;

namespace NotifiTime_API.domain.entities
{
    public class WalletCalendar : IWalletCalendar
    {
        public Dictionary<Guid, CalendarNotifiTime> calendarDictionary = new Dictionary<Guid, CalendarNotifiTime>();
        
        public WalletCalendar()
        {
            
        }
        
        public WalletCalendar(ICalendarNotifiTime[] newCalendarNotifiTimeArray)
        {
            foreach(CalendarNotifiTime currentCalendar in newCalendarNotifiTimeArray)
            {
                calendarDictionary.Add(currentCalendar.getId(), currentCalendar);
            }
        }
    
        public Exception addCalendarNotifiTime(ICalendarNotifiTime newCalendarNotifiTime)
        {
            if(calendarDictionary.TryAdd(newCalendarNotifiTime.getId(), (CalendarNotifiTime)newCalendarNotifiTime))
                return new Exception();
            return null;
        }

        public Exception deleteCalendarNotifiTimeById(Guid id)
        {
            if(!calendarDictionary.Remove(id))
                return new Exception();
            return null;
        }

        public IEventCalendar findEventCalendarByIdOnAllCalendars(Guid eventId)
        {
            CalendarNotifiTime[] calendarArray = calendarDictionary.Values.ToArray();
            List<IEventCalendar> eventCalendarList = new List<IEventCalendar>();
            IEventCalendar tempEventCalendar = null;
            int position = 0;
            while (position < calendarArray.Length && tempEventCalendar == null)
            {
                tempEventCalendar = calendarArray[position].getEventById(eventId);
                position ++;
            }
            return tempEventCalendar;
        }

        public ICalendarNotifiTime findCalendarNotifiTimeById(Guid id)
        {
            CalendarNotifiTime calendarFound;
            bool found = calendarDictionary.TryGetValue(id, out calendarFound);
            return found ? calendarFound : null;
        }

        public ICalendarNotifiTime[] findCalendarNotifiTimeByName(string name)
        {
            CalendarNotifiTime[] calendarArray = calendarDictionary.Values.ToArray();
            List<CalendarNotifiTime> calendarFoundList = new List<CalendarNotifiTime>();
            foreach(CalendarNotifiTime calendarNotifiTime in calendarArray)
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
            List<CalendarNotifiTime> calendarDictionaryAsList = calendarDictionary.Values.ToList();
            
            calendarDictionaryAsList.Sort
            (
                (CalendarNotifiTime oneCalendar, CalendarNotifiTime otherCalendar) 
                    => otherCalendar.getCreationDate().CompareTo(oneCalendar.getCreationDate())
            );
            CalendarNotifiTime[] sortedCalendarByCreationDate = calendarDictionaryAsList.ToArray();
            
            if (ascending)
            {
                Array.Reverse(sortedCalendarByCreationDate);
            }
            
            return sortedCalendarByCreationDate;
        }

        public ICalendarNotifiTime[] sortCalendarNotifiTimeListByName(bool ascending)
        {
            List<CalendarNotifiTime> calendarDictionaryAsList = calendarDictionary.Values.ToList();
            
            calendarDictionaryAsList.Sort
            (
                (CalendarNotifiTime oneCalendar, CalendarNotifiTime otherCalendar) 
                    => otherCalendar.getName().CompareTo(oneCalendar.getName())
            );
            CalendarNotifiTime[] sortedCalendarByCreationDate = calendarDictionaryAsList.ToArray();
            
            if (ascending)
            {
                Array.Reverse(sortedCalendarByCreationDate);
            }
            
            return sortedCalendarByCreationDate;
        }
    }
}