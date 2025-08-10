using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using NotifiTime_API.domain.Interfaces;
using NotifiTime_API.infrastructure.repositories;

namespace NotifiTime_API.domain.entities
{
    public class WalletCalendar
    {
        public Dictionary<Guid, CalendarNotifiTime> calendarDictionary = new Dictionary<Guid, CalendarNotifiTime>();
        
        public WalletCalendar()
        {
        }
        
        public WalletCalendar(CalendarNotifiTime[] newCalendarNotifiTimeArray)
        {
            foreach(CalendarNotifiTime currentCalendar in newCalendarNotifiTimeArray)
            {
                calendarDictionary.Add(currentCalendar.getId(), currentCalendar);
            }
        }
        
        public Exception addCalendarNotifiTime(CalendarNotifiTime newCalendarNotifiTime)
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

        public EventCalendar findEventCalendarByIdOnAllCalendars(Guid eventId)
        {
            CalendarNotifiTime[] calendarArray = calendarDictionary.Values.ToArray();
            List<EventCalendar> eventCalendarList = new List<EventCalendar>();
            EventCalendar tempEventCalendar = null;
            int position = 0;
            while (position < calendarArray.Length && tempEventCalendar == null)
            {
                tempEventCalendar = calendarArray[position].getEventById(eventId);
                position ++;
            }
            return tempEventCalendar;
        }

        public CalendarNotifiTime findCalendarNotifiTimeById(Guid id)
        {
            CalendarNotifiTime calendarFound;
            bool found = calendarDictionary.TryGetValue(id, out calendarFound);
            return found ? calendarFound : null;
        }

        public CalendarNotifiTime[] findCalendarNotifiTimeByName(string name)
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

        public CalendarNotifiTime[] getCalendarNotifiTimeArray()
        {
            return calendarDictionary.Values.ToArray();
        }

        public CalendarNotifiTime[] sortCalendarNotifiTimeListByCreationDate(bool ascending)
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

        public CalendarNotifiTime[] sortCalendarNotifiTimeListByName(bool ascending)
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