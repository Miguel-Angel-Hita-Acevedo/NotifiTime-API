using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SequentialGuid;
using NotifiTime_API.domain.Enum;
using System.Collections.Immutable;
using System.Runtime.InteropServices;
using System.Reflection.Metadata.Ecma335;

namespace NotifiTime_API.domain.entities
{
    public class CalendarNotifiTime
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

        public EventCalendar AddEvent(EventCalendar eventCalendar)
        {
            eventCalendarDictionary.TryAdd(eventCalendar.GetId(), eventCalendar);
            return eventCalendar;
        }

        public bool DeleteEventById(Guid id)
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

        public EventCalendar GetEventById(Guid id)
        {
            EventCalendar eventCalendarFound = null;
            try
            {
                eventCalendarDictionary.TryGetValue(id, out eventCalendarFound);
            } catch (ArgumentNullException exc) {}
            return eventCalendarFound;
        }

        public Guid GetId()
        {
            return id;
        }

        public string GetName()
        {
            return name;
        }

        public DateTime getCreationDate()
        {
            return creationDate;
        }
        
        public CalendarNotifiTime SetName(string newName)
        {
            name = newName;
            return this;
        }

        public EventCalendar[] SortEventsByDate(DateTime fromDate, DateTime toDate, bool ascending)
        {
            List<EventCalendar> eventCalendarDictionaryAsList = eventCalendarDictionary.Values.ToList<EventCalendar>();
            EventCalendar[] sortedEventsCalendarByDate;
            
            eventCalendarDictionaryAsList = eventCalendarDictionaryAsList.Where
            (
                currentEventCalendar => currentEventCalendar.GetDateTime() >= fromDate && currentEventCalendar.GetDateTime() <= toDate
            ).ToList();
            
            eventCalendarDictionaryAsList.Sort((EventCalendar oneEvent, EventCalendar otherEvent) => otherEvent.GetDateTime().CompareTo(oneEvent.GetDateTime()));
            sortedEventsCalendarByDate = eventCalendarDictionaryAsList.ToArray();
            
            if (ascending)
            {
                Array.Reverse(sortedEventsCalendarByDate);
            }
            return sortedEventsCalendarByDate;
        }
        
        public int EventsCalendarLength()
        {
            return eventCalendarDictionary.ToArray().Length;
        }
        
        public EventCalendar[] GetAllEvents()
        {
            return eventCalendarDictionary.Values.ToArray();
        }
        
        public EventCalendar UpdateEventById(EventCalendar eventCalendar)
        {
            try
            {
                eventCalendarDictionary[eventCalendar.GetId()].SetDateTime(eventCalendar.GetDateTime());
                eventCalendarDictionary[eventCalendar.GetId()].SetMessage(eventCalendar.GetMessage());
                eventCalendarDictionary[eventCalendar.GetId()].SetName(eventCalendar.GetName());
                eventCalendarDictionary[eventCalendar.GetId()].SetSupportedPlatformList(eventCalendar.GetSupportedPlatformList());
                eventCalendarDictionary[eventCalendar.GetId()].SetTimeIteration(eventCalendar.GetTimeIteration());
                return eventCalendarDictionary[eventCalendar.GetId()];
            } catch (Exception) 
            {
                return null;
            }
        }
    }
}