using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotifiTime_API.application.DTOs;
using NotifiTime_API.domain.Enum;

namespace NotifiTime_API.application.Interfaces
{
    // To manage events inside a calendar
    public interface IEventsCalendarService
    {
        public EventCalendarDTO createEvent(DateTime date, string name, TimeIteration timeIteration);
        public EventCalendarDTO getEventById(Guid id);
        public EventCalendarDTO[] sortEventsByDate(DateTime fromDate, DateTime toDate, bool ascending);
        public bool deleteEventById(Guid id);
        public int eventsCalendarLength();
    }
}