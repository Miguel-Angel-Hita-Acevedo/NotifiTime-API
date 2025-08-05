using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotifiTime_API.domain.Enum;

namespace NotifiTime_API.domain.entities
{
    public interface ICalendarNotifiTime
    {
        // atributos
        public Guid getId();
        public string getName();
        public DateTime getCreationDate();
        public ICalendarNotifiTime setName(string newName);
        public IEventCalendar createEvent(DateTime date, string name, TimeIteration timeIteration);
        public IEventCalendar getEventById(Guid id);
        public IEventCalendar[] sortEventsByDate(DateTime fromDate, DateTime toDate, bool ascending);
        public bool deleteEventById(Guid id);
        public int eventsCalendarLength();
        public IEventCalendar[] GetAllEvents();
        public EventCalendar UpdateEventById(EventCalendar eventCalendar);
    }
}