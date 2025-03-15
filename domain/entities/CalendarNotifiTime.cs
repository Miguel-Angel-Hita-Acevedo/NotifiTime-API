using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SequentialGuid;
using NotifiTime_API.domain.Enum;
using System.Collections.Immutable;
using System.Runtime.InteropServices;

namespace NotifiTime_API.domain.entities
{
    public class CalendarNotifiTime : ICalendarNotifiTime
    {
        private Guid id;
        private string name;
        private DateTime creationDate;
        private Dictionary<Guid, CalendarEvent> calendarEventDictionary;
        
        /// <summary>
        /// When user creates an empty calendar from an app connected to this api
        /// </summary>
        public CalendarNotifiTime(string name)
        {
            this.name = name;
            calendarEventDictionary = new Dictionary<Guid, CalendarEvent>();
            id = SequentialGuidGenerator.Instance.NewGuid();
            creationDate = DateTime.Now;
        }
        
        /// <summary>
        /// To load data from database, currently not implemented but thought to implement user separate
        /// </summary>
        public CalendarNotifiTime(Guid id, string name, Dictionary<Guid, CalendarEvent> calendarEventDictionary, DateTime creationDate)
        {
            this.id = id;
            this.name = name;
            this.calendarEventDictionary = calendarEventDictionary;
            this.creationDate = creationDate;
        }

        public ICalendarEvent createEvent(DateTime date, string name, TimeIteration timeIteration)
        {
            CalendarEvent calendarEvent = new CalendarEvent();
            calendarEvent.setDateTime(date).setName(name).setTimeIteration(timeIteration);
            calendarEventDictionary.TryAdd(calendarEvent.getId(), calendarEvent);
            return calendarEvent;
        }

        public bool deleteEventById(Guid id)
        {
            bool exist = false;
            try 
            {
                exist = calendarEventDictionary.ContainsKey(id);
                if(exist)
                {
                    calendarEventDictionary.Remove(id);
                }
            } 
            catch (Exception e)
            {
                exist = calendarEventDictionary.ContainsKey(id);
            }
            return !exist;
        }

        public ICalendarEvent getEventById(Guid id)
        {
            CalendarEvent calendarEventFound = null;
            try
            {
                calendarEventDictionary.TryGetValue(id, out calendarEventFound);
            } catch (ArgumentNullException exc) {}
            return calendarEventFound;
        }

        public Guid getId()
        {
            return id;
        }

        public string getName()
        {
            return name;
        }

        public DateTime getCreationDate()
        {
            return creationDate;
        }
        
        public ICalendarNotifiTime setName(string newName)
        {
            name = newName;
            return this;
        }

        public ICalendarEvent[] sortEventsByDate(DateTime fromDate, DateTime toDate, bool ascending)
        {
            List<ICalendarEvent> calendarEventDictionaryAsList = calendarEventDictionary.Values.ToList<ICalendarEvent>();
            ICalendarEvent[] sortedCalendarEventsByDate;
            
            calendarEventDictionaryAsList = calendarEventDictionaryAsList.Where
            (
                currentCalendarEvent => currentCalendarEvent.getDateTime() >= fromDate && currentCalendarEvent.getDateTime() <= toDate
            ).ToList();
            
            calendarEventDictionaryAsList.Sort((ICalendarEvent oneEvent, ICalendarEvent otherEvent) => otherEvent.getDateTime().CompareTo(oneEvent.getDateTime()));
            sortedCalendarEventsByDate = calendarEventDictionaryAsList.ToArray();
            
            if (ascending)
            {
                Array.Reverse(sortedCalendarEventsByDate);
            }
            return sortedCalendarEventsByDate;
        }
        
        public int calendarEventsLength()
        {
            return calendarEventDictionary.ToArray().Length;
        }
    }
}