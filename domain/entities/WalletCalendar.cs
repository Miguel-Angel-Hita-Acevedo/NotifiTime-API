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
                calendarDictionary.Add(currentCalendar.GetId(), currentCalendar);
            }
        }
        
        public Exception AddCalendarNotifiTime(CalendarNotifiTime newCalendarNotifiTime)
        {
            if(calendarDictionary.TryAdd(newCalendarNotifiTime.GetId(), (CalendarNotifiTime)newCalendarNotifiTime))
                return new Exception();
            return null;
        }

        public Exception DeleteCalendarNotifiTimeById(Guid id)
        {
            if(!calendarDictionary.Remove(id))
                return new Exception();
            return null;
        }

        public EventCalendar FindEventCalendarByIdOnAllCalendars(Guid eventId)
        {
            CalendarNotifiTime[] calendarArray = calendarDictionary.Values.ToArray();
            List<EventCalendar> eventCalendarList = new List<EventCalendar>();
            EventCalendar tempEventCalendar = null;
            int position = 0;
            while (position < calendarArray.Length && tempEventCalendar == null)
            {
                tempEventCalendar = calendarArray[position].GetEventById(eventId);
                position ++;
            }
            return tempEventCalendar;
        }

        public CalendarNotifiTime FindCalendarNotifiTimeById(Guid id)
        {
            CalendarNotifiTime calendarFound;
            bool found = calendarDictionary.TryGetValue(id, out calendarFound);
            return found ? calendarFound : null;
        }

        public CalendarNotifiTime[] FindCalendarNotifiTimeByName(string name)
        {
            CalendarNotifiTime[] calendarArray = calendarDictionary.Values.ToArray();
            List<CalendarNotifiTime> calendarFoundList = new List<CalendarNotifiTime>();
            foreach(CalendarNotifiTime calendarNotifiTime in calendarArray)
            {
                if(calendarNotifiTime.GetName().Equals(name))
                {
                    calendarFoundList.Add(calendarNotifiTime);
                }
            }
            return calendarFoundList.ToArray();
        }

        public CalendarNotifiTime[] GetCalendarNotifiTimeArray()
        {
            return calendarDictionary.Values.ToArray();
        }

        public CalendarNotifiTime[] SortCalendarNotifiTimeListByCreationDate(bool ascending)
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

        public CalendarNotifiTime[] SortCalendarNotifiTimeListByName(bool ascending)
        {
            List<CalendarNotifiTime> calendarDictionaryAsList = calendarDictionary.Values.ToList();
            
            calendarDictionaryAsList.Sort
            (
                (CalendarNotifiTime oneCalendar, CalendarNotifiTime otherCalendar) 
                    => otherCalendar.GetName().CompareTo(oneCalendar.GetName())
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