using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotifiTime_API.domain.Enum;
using NotifiTime_API.domain.entities;
using Xunit;
using System.Reflection.Metadata.Ecma335;

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
        public void createEventOnCalendarAndFindById()
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
        
        [Fact]
        public void createEventOnCalendarAndDeleteAnEvent()
        {
            CalendarNotifiTime testCalendar = new CalendarNotifiTime("Test calendar");
            
            testCalendar.createEvent(
                new DateTime(2024, 3, 7, 14, 45, 0),
                "Test event 1",
                TimeIteration.None
            );
            
            ICalendarEvent testEvent = testCalendar.createEvent(
                new DateTime(2023, 4, 5, 0, 45, 0),
                "Test event 2",
                TimeIteration.None
            );
            
            testCalendar.createEvent(
                new DateTime(2024, 1, 6, 16, 30, 0),
                "Test event 3",
                TimeIteration.None
            );
            
            testCalendar.deleteEventById(testEvent.getId());
            
            Assert.True(testCalendar.calendarEventsLength() == 2);
        }
    }
}