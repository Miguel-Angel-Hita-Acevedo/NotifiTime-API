using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotifiTime_API.domain.Enum;
using NotifiTime_API.domain.entities;
using Xunit;

namespace NotifiTime_API.Test
{
    public class CalendarNotifiTimeTest
    {
        [Fact]
        public void createCalendarByName()
        {
            string name = "Test calendar";
            CalendarNotifiTime testCalendar = new CalendarNotifiTime(name);
            Assert.Equal(testCalendar.getName(), name);
        }
        
        [Fact]
        public void createEventOnCalendar()
        {
            string name = "Test calendar";
            CalendarNotifiTime testCalendar = new CalendarNotifiTime(name);
            ICalendarEvent testEvent = testCalendar.createEvent(
                new DateTime(2024, 3, 7, 14, 45, 0),
                "Test event",
                TimeIteration.None
            );
            Assert.NotNull(testCalendar.getEventById(testEvent.getId()));
        }
    }
}