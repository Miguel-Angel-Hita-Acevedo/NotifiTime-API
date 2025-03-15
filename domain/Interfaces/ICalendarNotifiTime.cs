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
        public ICalendarEvent createEvent(DateTime date, string name, TimeIteration timeIteration);
        public ICalendarEvent getEventById(Guid id);
        public ICalendarEvent[] sortEventsByDate(DateTime fromDate, DateTime toDate, bool ascending);
        public bool deleteEventById(Guid id);
        public int calendarEventsLength();
    }
}