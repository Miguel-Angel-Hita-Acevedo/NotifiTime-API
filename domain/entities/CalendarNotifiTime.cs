using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SequentialGuid;
using NotifiTime_API.domain.Enum;

namespace NotifiTime_API.domain.entities
{
    public class CalendarNotifiTime : ICalendarNotifiTime
    {
        private Guid id;
        private string name;
        private Dictionary<Guid, CalendarEvent> calendarEventDictionary;

        public CalendarNotifiTime(string name)
        {
            this.name = name;
            calendarEventDictionary = new Dictionary<Guid, CalendarEvent>();
            id = SequentialGuidGenerator.Instance.NewGuid();
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
            throw new NotImplementedException();
        }

        public Guid getId()
        {
            throw new NotImplementedException();
        }

        public string getName()
        {
            throw new NotImplementedException();
        }

        public void loadCalendarData(Guid id)
        {
            throw new NotImplementedException();
        }

        public ICalendarNotifiTime setName(string newName)
        {
            throw new NotImplementedException();
        }

        public ICalendarEvent[] sortEventsByDate(DateTime fromDate, DateTime toDate)
        {
            throw new NotImplementedException();
        }
    }
}