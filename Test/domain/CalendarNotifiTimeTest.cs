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
            IEventCalendar testEvent = testCalendar.createEvent(
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

            IEventCalendar testEvent = testCalendar.createEvent(
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

            Assert.True(testCalendar.eventsCalendarLength() == 2);
        }

        [Fact]
        public void createEventsOnCalendarAndCheckIfDeletedIsCorrect()
        {
            CalendarNotifiTime testCalendar = new CalendarNotifiTime("Test calendar");

            testCalendar.createEvent(
                new DateTime(2024, 3, 7, 14, 45, 0),
                "Test event 1",
                TimeIteration.None
            );

            IEventCalendar testEvent = testCalendar.createEvent(
                new DateTime(2023, 4, 5, 0, 45, 0),
                "Test event 2",
                TimeIteration.None
            );

            testCalendar.createEvent(
                new DateTime(2024, 1, 6, 16, 30, 0),
                "Test event 3",
                TimeIteration.None
            );

            if (testCalendar.getEventById(testEvent.getId()) != null)
            {
                testCalendar.deleteEventById(testEvent.getId());
                Assert.Null(testCalendar.getEventById(testEvent.getId()));
            }
            else
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void sortEventsByDateDescending()
        {
            CalendarNotifiTime testCalendar = new CalendarNotifiTime("Test calendar");

            testCalendar.createEvent(
                new DateTime(2024, 3, 7, 14, 45, 0),
                "Test event 1",
                TimeIteration.None
            );

            testCalendar.createEvent(
                new DateTime(2023, 4, 5, 0, 45, 0),
                "Test event 2",
                TimeIteration.None
            );

            testCalendar.createEvent(
                new DateTime(2024, 1, 6, 16, 30, 0),
                "Test event 3",
                TimeIteration.None
            );

            IEventCalendar[] testEventSortedArray = testCalendar.sortEventsByDate(
                new DateTime(1, 1, 1),
                new DateTime(9999, 1, 1),
                false
                );

            Assert.True(
                testEventSortedArray[0].getDateTime() > testEventSortedArray[1].getDateTime() &&
                testEventSortedArray[1].getDateTime() > testEventSortedArray[2].getDateTime()
                );
        }

        [Fact]
        public void sortEventsByDateAscending()
        {
            CalendarNotifiTime testCalendar = new CalendarNotifiTime("Test calendar");

            testCalendar.createEvent(
                new DateTime(2024, 3, 7, 14, 45, 0),
                "Test event 1",
                TimeIteration.None
            );

            testCalendar.createEvent(
                new DateTime(2023, 4, 5, 0, 45, 0),
                "Test event 2",
                TimeIteration.None
            );

            testCalendar.createEvent(
                new DateTime(2024, 1, 6, 16, 30, 0),
                "Test event 3",
                TimeIteration.None
            );

            IEventCalendar[] testEventSortedArray = testCalendar.sortEventsByDate(
                new DateTime(1, 1, 1),
                new DateTime(9999, 1, 1),
                true
                );

            Assert.True(
                testEventSortedArray[0].getDateTime() < testEventSortedArray[1].getDateTime() &&
                testEventSortedArray[1].getDateTime() < testEventSortedArray[2].getDateTime()
                );
        }

        [Fact]
        public void sortEventsByDateWithSomeEventsOutOfRange()
        {
            CalendarNotifiTime testCalendar = new CalendarNotifiTime("Test calendar");

            testCalendar.createEvent(
                new DateTime(2024, 3, 7, 14, 45, 0),
                "Test event 1",
                TimeIteration.None
            );

            testCalendar.createEvent(
                new DateTime(2023, 4, 5, 0, 45, 0),
                "Test event 2",
                TimeIteration.None
            );

            testCalendar.createEvent(
                new DateTime(2024, 1, 6, 16, 30, 0),
                "Test event 3",
                TimeIteration.None
            );

            IEventCalendar[] eventsCalendarTestArray = testCalendar.sortEventsByDate(
                new DateTime(2024, 1, 1),
                new DateTime(9999, 1, 1),
                false
                );

            Assert.True(eventsCalendarTestArray.Length == 2);
        }

        [Fact]
        public void UpdateEventByIdMessageUpdated()
        {
            CalendarNotifiTime testCalendar = new CalendarNotifiTime("Test calendar with event updated!");

            testCalendar.createEvent(
                new DateTime(2024, 3, 7, 14, 45, 0),
                "Test event 1",
                TimeIteration.None
            );

            EventCalendar eventCalendar = (EventCalendar)testCalendar.createEvent(
                new DateTime(2023, 4, 5, 0, 45, 0),
                "Test event 2",
                TimeIteration.None
            );

            testCalendar.createEvent(
                new DateTime(2024, 1, 6, 16, 30, 0),
                "Test event 3",
                TimeIteration.None
            );

            eventCalendar.setMessage("Texto cambiado!");

            IEventCalendar updatedEventCalendar = testCalendar.UpdateEventById(eventCalendar);

            Assert.Equal(updatedEventCalendar.getMessage(), "Texto cambiado!");
        }
        
        [Fact]
        public void UpdateEventByIdMessageUpdatedAndFindById()
        {
            CalendarNotifiTime testCalendar = new CalendarNotifiTime("Test calendar with event updated!");
            
            testCalendar.createEvent(
                new DateTime(2024, 3, 7, 14, 45, 0),
                "Test event 1",
                TimeIteration.None
            );
            
            EventCalendar eventCalendar = (EventCalendar)testCalendar.createEvent(
                new DateTime(2023, 4, 5, 0, 45, 0),
                "Test event 2",
                TimeIteration.None
            );
            
            testCalendar.createEvent(
                new DateTime(2024, 1, 6, 16, 30, 0),
                "Test event 3",
                TimeIteration.None
            );
            
            eventCalendar.setMessage("Texto cambiado!");

            testCalendar.UpdateEventById(eventCalendar);
            
            Assert.Equal(testCalendar.getEventById(eventCalendar.getId()).getMessage(), "Texto cambiado!");
        }
    }
}