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
            Assert.Equal(testCalendar.GetName(), name);
        }

        [Fact]
        public void CreateEventOnCalendarAndFindById()
        {
            string name = "Test calendar";
            CalendarNotifiTime testCalendar = new CalendarNotifiTime(name);
            EventCalendar testEvent = testCalendar.CreateEvent(
                new DateTime(2024, 3, 7, 14, 45, 0),
                "Test event",
                TimeIteration.None
            );
            Assert.NotNull(testCalendar.GetEventById(testEvent.GetId()));
        }

        [Fact]
        public void CreateEventOnCalendarAndDeleteAnEvent()
        {
            CalendarNotifiTime testCalendar = new CalendarNotifiTime("Test calendar");

            testCalendar.CreateEvent(
                new DateTime(2024, 3, 7, 14, 45, 0),
                "Test event 1",
                TimeIteration.None
            );

            EventCalendar testEvent = testCalendar.CreateEvent(
                new DateTime(2023, 4, 5, 0, 45, 0),
                "Test event 2",
                TimeIteration.None
            );

            testCalendar.CreateEvent(
                new DateTime(2024, 1, 6, 16, 30, 0),
                "Test event 3",
                TimeIteration.None
            );

            testCalendar.DeleteEventById(testEvent.GetId());

            Assert.True(testCalendar.EventsCalendarLength() == 2);
        }

        [Fact]
        public void CreateEventsOnCalendarAndCheckIfDeletedIsCorrect()
        {
            CalendarNotifiTime testCalendar = new CalendarNotifiTime("Test calendar");

            testCalendar.CreateEvent(
                new DateTime(2024, 3, 7, 14, 45, 0),
                "Test event 1",
                TimeIteration.None
            );

            EventCalendar testEvent = testCalendar.CreateEvent(
                new DateTime(2023, 4, 5, 0, 45, 0),
                "Test event 2",
                TimeIteration.None
            );

            testCalendar.CreateEvent(
                new DateTime(2024, 1, 6, 16, 30, 0),
                "Test event 3",
                TimeIteration.None
            );

            if (testCalendar.GetEventById(testEvent.GetId()) != null)
            {
                testCalendar.DeleteEventById(testEvent.GetId());
                Assert.Null(testCalendar.GetEventById(testEvent.GetId()));
            }
            else
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void SortEventsByDateDescending()
        {
            CalendarNotifiTime testCalendar = new CalendarNotifiTime("Test calendar");

            testCalendar.CreateEvent(
                new DateTime(2024, 3, 7, 14, 45, 0),
                "Test event 1",
                TimeIteration.None
            );

            testCalendar.CreateEvent(
                new DateTime(2023, 4, 5, 0, 45, 0),
                "Test event 2",
                TimeIteration.None
            );

            testCalendar.CreateEvent(
                new DateTime(2024, 1, 6, 16, 30, 0),
                "Test event 3",
                TimeIteration.None
            );

            EventCalendar[] testEventSortedArray = testCalendar.SortEventsByDate(
                new DateTime(1, 1, 1),
                new DateTime(9999, 1, 1),
                false
                );

            Assert.True(
                testEventSortedArray[0].GetDateTime() > testEventSortedArray[1].GetDateTime() &&
                testEventSortedArray[1].GetDateTime() > testEventSortedArray[2].GetDateTime()
                );
        }

        [Fact]
        public void SortEventsByDateAscending()
        {
            CalendarNotifiTime testCalendar = new CalendarNotifiTime("Test calendar");

            testCalendar.CreateEvent(
                new DateTime(2024, 3, 7, 14, 45, 0),
                "Test event 1",
                TimeIteration.None
            );

            testCalendar.CreateEvent(
                new DateTime(2023, 4, 5, 0, 45, 0),
                "Test event 2",
                TimeIteration.None
            );

            testCalendar.CreateEvent(
                new DateTime(2024, 1, 6, 16, 30, 0),
                "Test event 3",
                TimeIteration.None
            );

            EventCalendar[] testEventSortedArray = testCalendar.SortEventsByDate(
                new DateTime(1, 1, 1),
                new DateTime(9999, 1, 1),
                true
                );

            Assert.True(
                testEventSortedArray[0].GetDateTime() < testEventSortedArray[1].GetDateTime() &&
                testEventSortedArray[1].GetDateTime() < testEventSortedArray[2].GetDateTime()
                );
        }

        [Fact]
        public void SortEventsByDateWithSomeEventsOutOfRange()
        {
            CalendarNotifiTime testCalendar = new CalendarNotifiTime("Test calendar");

            testCalendar.CreateEvent(
                new DateTime(2024, 3, 7, 14, 45, 0),
                "Test event 1",
                TimeIteration.None
            );

            testCalendar.CreateEvent(
                new DateTime(2023, 4, 5, 0, 45, 0),
                "Test event 2",
                TimeIteration.None
            );

            testCalendar.CreateEvent(
                new DateTime(2024, 1, 6, 16, 30, 0),
                "Test event 3",
                TimeIteration.None
            );

            EventCalendar[] eventsCalendarTestArray = testCalendar.SortEventsByDate(
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

            testCalendar.CreateEvent(
                new DateTime(2024, 3, 7, 14, 45, 0),
                "Test event 1",
                TimeIteration.None
            );

            EventCalendar eventCalendar = (EventCalendar)testCalendar.CreateEvent(
                new DateTime(2023, 4, 5, 0, 45, 0),
                "Test event 2",
                TimeIteration.None
            );

            testCalendar.CreateEvent(
                new DateTime(2024, 1, 6, 16, 30, 0),
                "Test event 3",
                TimeIteration.None
            );

            eventCalendar.SetMessage("Texto cambiado!");

            EventCalendar updatedEventCalendar = testCalendar.UpdateEventById(eventCalendar);

            Assert.Equal(updatedEventCalendar.GetMessage(), "Texto cambiado!");
        }
        
        [Fact]
        public void UpdateEventByIdMessageUpdatedAndFindById()
        {
            CalendarNotifiTime testCalendar = new CalendarNotifiTime("Test calendar with event updated!");
            
            testCalendar.CreateEvent(
                new DateTime(2024, 3, 7, 14, 45, 0),
                "Test event 1",
                TimeIteration.None
            );
            
            EventCalendar eventCalendar = (EventCalendar)testCalendar.CreateEvent(
                new DateTime(2023, 4, 5, 0, 45, 0),
                "Test event 2",
                TimeIteration.None
            );
            
            testCalendar.CreateEvent(
                new DateTime(2024, 1, 6, 16, 30, 0),
                "Test event 3",
                TimeIteration.None
            );
            
            eventCalendar.SetMessage("Texto cambiado!");

            testCalendar.UpdateEventById(eventCalendar);
            
            Assert.Equal(testCalendar.GetEventById(eventCalendar.GetId()).GetMessage(), "Texto cambiado!");
        }
    }
}