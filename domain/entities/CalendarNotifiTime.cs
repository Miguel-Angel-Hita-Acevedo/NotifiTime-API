using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotifiTime_API.domain.Enum;

namespace NotifiTime_API.domain.entities
{
    public class CalendarNotifiTime : ICalendarNotifiTime
    {
        public ICalendarEvent createEvent(DateTime date, string name, TimeIteration timeIteration)
        {
            throw new NotImplementedException();
        }

        public ICalendarEvent deleteEventById(int id)
        {
            throw new NotImplementedException();
        }

        public ICalendarEvent getEventById(int id)
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