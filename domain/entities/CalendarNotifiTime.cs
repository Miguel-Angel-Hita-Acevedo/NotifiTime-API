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
        private Dictionary<Guid, EventCalendar> eventCalendarDictionary;
        
        /// <summary>
        /// When user creates an empty calendar from an app connected to this api
        /// </summary>
        public CalendarNotifiTime(string name)
        {
            this.name = name;
            eventCalendarDictionary = new Dictionary<Guid, EventCalendar>();
            id = SequentialGuidGenerator.Instance.NewGuid();
            creationDate = DateTime.Now;
        }
        
        /// <summary>
        /// To load data from database, currently not implemented but thought to implement user separate
        /// </summary>
        public CalendarNotifiTime(Guid id, string name, Dictionary<Guid, EventCalendar> eventCalendarDictionary, DateTime creationDate)
        {
            this.id = id;
            this.name = name;
            this.eventCalendarDictionary = eventCalendarDictionary;
            this.creationDate = creationDate;
        }

        public IEventCalendar createEvent(DateTime date, string name, TimeIteration timeIteration)
        {
            EventCalendar eventCalendar = new EventCalendar();
            eventCalendar.setDateTime(date).setName(name).setTimeIteration(timeIteration);
            eventCalendarDictionary.TryAdd(eventCalendar.getId(), eventCalendar);
            return eventCalendar;
        }

        public bool deleteEventById(Guid id)
        {
            bool exist = false;
            try 
            {
                exist = eventCalendarDictionary.ContainsKey(id);
                if(exist)
                {
                    eventCalendarDictionary.Remove(id);
                }
            } 
            catch (Exception e)
            {
                exist = eventCalendarDictionary.ContainsKey(id);
            }
            return !exist;
        }

        public IEventCalendar getEventById(Guid id)
        {
            EventCalendar eventCalendarFound = null;
            try
            {
                eventCalendarDictionary.TryGetValue(id, out eventCalendarFound);
            } catch (ArgumentNullException exc) {}
            return eventCalendarFound;
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

        public IEventCalendar[] sortEventsByDate(DateTime fromDate, DateTime toDate, bool ascending)
        {
            List<IEventCalendar> eventCalendarDictionaryAsList = eventCalendarDictionary.Values.ToList<IEventCalendar>();
            IEventCalendar[] sortedEventsCalendarByDate;
            
            eventCalendarDictionaryAsList = eventCalendarDictionaryAsList.Where
            (
                currentEventCalendar => currentEventCalendar.getDateTime() >= fromDate && currentEventCalendar.getDateTime() <= toDate
            ).ToList();
            
            eventCalendarDictionaryAsList.Sort((IEventCalendar oneEvent, IEventCalendar otherEvent) => otherEvent.getDateTime().CompareTo(oneEvent.getDateTime()));
            sortedEventsCalendarByDate = eventCalendarDictionaryAsList.ToArray();
            
            if (ascending)
            {
                Array.Reverse(sortedEventsCalendarByDate);
            }
            return sortedEventsCalendarByDate;
        }
        
        public int eventsCalendarLength()
        {
            return eventCalendarDictionary.ToArray().Length;
        }
    }
}