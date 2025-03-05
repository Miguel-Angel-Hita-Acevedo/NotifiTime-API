using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SequentialGuid;
using NotifiTime_API.domain.Enum;
using System.Collections.Immutable;

namespace NotifiTime_API.domain.entities
{
    public class CalendarNotifiTime : ICalendarNotifiTime
    {
        private Guid id;
        private string name;
        private Dictionary<Guid, CalendarEvent> calendarEventDictionary;
        
        /// <summary>
        /// When user creates an empty calendar from an app connected to this api
        /// </summary>
        public CalendarNotifiTime(string name)
        {
            this.name = name;
            calendarEventDictionary = new Dictionary<Guid, CalendarEvent>();
            id = SequentialGuidGenerator.Instance.NewGuid();
        }
        
        /// <summary>
        /// To load data from database, currently not implemented but thought to implement user separate
        /// </summary>
        public CalendarNotifiTime(Guid id, string name, Dictionary<Guid, CalendarEvent> calendarEventDictionary)
        {
            this.id = id;
            this.name = name;
            this.calendarEventDictionary = calendarEventDictionary;
        }

        public ICalendarEvent createEvent(DateTime date, string name, TimeIteration timeIteration)
        {
            CalendarEvent calendarEvent = new CalendarEvent();
            calendarEvent.setDateTime(date).setName(name).setTimeIteration(timeIteration);
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

        public ICalendarNotifiTime setName(string newName)
        {
            name = newName;
            return this;
        }

        public ICalendarEvent[] sortEventsByDate(DateTime fromDate, DateTime toDate)
        {
            ICalendarEvent[] calendarEventDictionaryAsArray = calendarEventDictionary.Values.ToArray();
            ICalendarEvent[] sortedCalendarEventsByDate = calendarEventDictionaryAsArray.Where
            (
                currentCalendarEvent => currentCalendarEvent.getDateTime() >= fromDate && currentCalendarEvent.getDateTime() <= toDate
            ).ToArray();
            return sortedCalendarEventsByDate;
        }
    }
}