using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotifiTime_API.domain.Interfaces;

namespace NotifiTime_API.domain.entities
{
    public class WalletCalendar : IWalletCalendar
    {
        public Dictionary<Guid, ICalendarNotifiTime> calendarDictionary = new Dictionary<Guid, ICalendarNotifiTime>();
        
        public WalletCalendar()
        {
            
        }
        
        public WalletCalendar(ICalendarNotifiTime[] newCalendarNotifiTimeArray)
        {
            foreach(ICalendarNotifiTime currentCalendar in newCalendarNotifiTimeArray)
            {
                calendarDictionary.Add(currentCalendar.getId(), currentCalendar);
            }
        }
    
        public bool addCalendarNotifiTime(ICalendarNotifiTime newCalendarNotifiTime)
        {
            return calendarDictionary.TryAdd(newCalendarNotifiTime.getId(), newCalendarNotifiTime);
        }

        public bool deleteCalendarNotifiTimeById(Guid id)
        {
            return calendarDictionary.Remove(id);
        }

        public IEventCalendar findEventsCalendarByIdOnAllCalendars(Guid eventId)
        {
            ICalendarNotifiTime[] calendarArray = calendarDictionary.Values.ToArray();
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
            
            calendarDictionaryAsList.Sort
            (
                (ICalendarNotifiTime oneCalendar, ICalendarNotifiTime otherCalendar) 
                    => otherCalendar.getCreationDate().CompareTo(oneCalendar.getCreationDate())
            );
            ICalendarNotifiTime[] sortedCalendarByCreationDate = calendarDictionaryAsList.ToArray();
            
            if (ascending)
            {
                Array.Reverse(sortedCalendarByCreationDate);
            }
            
            return sortedCalendarByCreationDate;
        }

        public ICalendarNotifiTime[] sortCalendarNotifiTimeListByName(bool ascending)
        {
            List<ICalendarNotifiTime> calendarDictionaryAsList = calendarDictionary.Values.ToList();
            
            calendarDictionaryAsList.Sort
            (
                (ICalendarNotifiTime oneCalendar, ICalendarNotifiTime otherCalendar) 
                    => otherCalendar.getName().CompareTo(oneCalendar.getName())
            );
            ICalendarNotifiTime[] sortedCalendarByCreationDate = calendarDictionaryAsList.ToArray();
            
            if (ascending)
            {
                Array.Reverse(sortedCalendarByCreationDate);
            }
            
            return sortedCalendarByCreationDate;
        }
    }
}