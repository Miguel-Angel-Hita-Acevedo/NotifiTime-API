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
        public void CalendarNotifiTime_CreateCalendarByName_CorrectCalendarName()
        {
            string name = "Test calendar";
            CalendarNotifiTime testCalendar = new CalendarNotifiTime(name);
            Assert.Equal(testCalendar.GetName(), name);
        }

        [Fact]
        public void GetEventById_CreateEventAndFindIt_SameIdAsCreation()
        {
            string name = "Test calendar";
            CalendarNotifiTime testCalendar = new CalendarNotifiTime(name);
            
            List<SupportedPlatform> supportedPlatformList = new List<SupportedPlatform>();
            supportedPlatformList.Add(SupportedPlatform.Mail);
            EventCalendar testEvent = testCalendar.AddEvent( new EventCalendar(
                "Test event",
                new DateTime(2024, 3, 7, 14, 45, 0),
                supportedPlatformList,
                "Custom message",
                TimeIteration.None
            ));
            Assert.NotNull(testCalendar.GetEventById(testEvent.GetId()));
        }

        [Fact]
        public void DeleteEventById_Create3EventsAndDeleteOne_CalendarLengthEqual2()
        {
            CalendarNotifiTime testCalendar = new CalendarNotifiTime("Test calendar");

            List<SupportedPlatform> supportedPlatformList = new List<SupportedPlatform>();
            supportedPlatformList.Add(SupportedPlatform.Mail);
            testCalendar.AddEvent( new EventCalendar(
                "Test event 1",
                new DateTime(2024, 3, 7, 14, 45, 0),
                supportedPlatformList,
                "Custom message",
                TimeIteration.None
            ));

            EventCalendar testEvent = testCalendar.AddEvent( new EventCalendar(
                "Test event 2",
                new DateTime(2023, 4, 5, 0, 45, 0),
                supportedPlatformList,
                "Custom message",
                TimeIteration.None
            ));

            testCalendar.AddEvent( new EventCalendar(
                "Test event 3",
                new DateTime(2024, 1, 6, 16, 30, 0),
                supportedPlatformList,
                "Custom message",
                TimeIteration.None
            ));

            testCalendar.DeleteEventById(testEvent.GetId());

            Assert.True(testCalendar.EventsCalendarLength() == 2);
        }

        [Fact]
        public void DeleteEventById_Create3EventsAndDeleteOne_GetEventByIdReturnNull()
        {
            CalendarNotifiTime testCalendar = new CalendarNotifiTime("Test calendar");

            List<SupportedPlatform> supportedPlatformList = new List<SupportedPlatform>();
            supportedPlatformList.Add(SupportedPlatform.Mail);

            testCalendar.AddEvent( new EventCalendar(
                "Test event 1",
                new DateTime(2024, 3, 7, 14, 45, 0),
                supportedPlatformList,
                "Custom message",
                TimeIteration.None
            ));

            EventCalendar testEvent = testCalendar.AddEvent( new EventCalendar(
                "Test event 2",
                new DateTime(2023, 4, 5, 0, 45, 0),
                supportedPlatformList,
                "Custom message",
                TimeIteration.None
            ));

            testCalendar.AddEvent( new EventCalendar(
                "Test event 3",
                new DateTime(2024, 1, 6, 16, 30, 0),
                supportedPlatformList,
                "Custom message",
                TimeIteration.None
            ));

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
        public void SortEventsByDate_Create3EventsAndSortAscending_CorrectOrder()
        {
            CalendarNotifiTime testCalendar = new CalendarNotifiTime("Test calendar");

            List<SupportedPlatform> supportedPlatformList = new List<SupportedPlatform>();
            supportedPlatformList.Add(SupportedPlatform.Mail);

            testCalendar.AddEvent( new EventCalendar(
                "Test event 1",
                new DateTime(2024, 3, 7, 14, 45, 0),
                supportedPlatformList,
                "Custom message",
                TimeIteration.None
            ));

            testCalendar.AddEvent( new EventCalendar(
                "Test event 2",
                new DateTime(2023, 4, 5, 0, 45, 0),
                supportedPlatformList,
                "Custom message",
                TimeIteration.None
            ));

            testCalendar.AddEvent( new EventCalendar(
                "Test event 3",
                new DateTime(2024, 1, 6, 16, 30, 0),
                supportedPlatformList,
                "Custom message",
                TimeIteration.None
            ));

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
        public void SortEventsByDate_Create3EventsAndSortDescending_CorrectOrder()
        {
            CalendarNotifiTime testCalendar = new CalendarNotifiTime("Test calendar");

            List<SupportedPlatform> supportedPlatformList = new List<SupportedPlatform>();
            supportedPlatformList.Add(SupportedPlatform.Mail);

            testCalendar.AddEvent( new EventCalendar(
                "Test event 1",
                new DateTime(2024, 3, 7, 14, 45, 0),
                supportedPlatformList,
                "Custom message",
                TimeIteration.None
            ));

            testCalendar.AddEvent( new EventCalendar(
                "Test event 2",
                new DateTime(2023, 4, 5, 0, 45, 0),
                supportedPlatformList,
                "Custom message",
                TimeIteration.None
            ));

            testCalendar.AddEvent( new EventCalendar(
                "Test event 3",
                new DateTime(2024, 1, 6, 16, 30, 0),
                supportedPlatformList,
                "Custom message",
                TimeIteration.None
            ));

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
        public void SortEventsByDate_Create3EventsAndSortDescending_Found2Events()
        {
            CalendarNotifiTime testCalendar = new CalendarNotifiTime("Test calendar");

            List<SupportedPlatform> supportedPlatformList = new List<SupportedPlatform>();
            supportedPlatformList.Add(SupportedPlatform.Mail);

            testCalendar.AddEvent( new EventCalendar(
                "Test event 1",
                new DateTime(2024, 3, 7, 14, 45, 0),
                supportedPlatformList,
                "Custom message",
                TimeIteration.None
            ));

            testCalendar.AddEvent( new EventCalendar(
                "Test event 2",
                new DateTime(2023, 4, 5, 0, 45, 0),
                supportedPlatformList,
                "Custom message",
                TimeIteration.None
            ));

            testCalendar.AddEvent( new EventCalendar(
                "Test event 3",
                new DateTime(2024, 1, 6, 16, 30, 0),
                supportedPlatformList,
                "Custom message",
                TimeIteration.None
            ));

            EventCalendar[] eventsCalendarTestArray = testCalendar.SortEventsByDate(
                new DateTime(2024, 1, 1),
                new DateTime(9999, 1, 1),
                false
                );

            Assert.True(eventsCalendarTestArray.Length == 2);
        }

        [Fact]
        public void UpdateEventById_ChangeMessage_ReturnedEventHaveTheNewMessage()
        {
            CalendarNotifiTime testCalendar = new CalendarNotifiTime("Test calendar with event updated!");

            List<SupportedPlatform> supportedPlatformList = new List<SupportedPlatform>();
            supportedPlatformList.Add(SupportedPlatform.Mail);
            testCalendar.AddEvent( new EventCalendar(
                "Test event 1",
                new DateTime(2024, 3, 7, 14, 45, 0),
                supportedPlatformList,
                "Custom message",
                TimeIteration.None
            ));

            EventCalendar eventCalendar = (EventCalendar)testCalendar.AddEvent( new EventCalendar(
                "Test event 2",
                new DateTime(2023, 4, 5, 0, 45, 0),
                supportedPlatformList,
                "Custom message",
                TimeIteration.None
            ));

            testCalendar.AddEvent( new EventCalendar(
                "Test event 3",
                new DateTime(2024, 1, 6, 16, 30, 0),
                supportedPlatformList,
                "Custom message",
                TimeIteration.None
            ));

            eventCalendar.SetMessage("Texto cambiado!");

            EventCalendar updatedEventCalendar = testCalendar.UpdateEventById(eventCalendar);

            Assert.Equal(updatedEventCalendar.GetMessage(), "Texto cambiado!");
        }
        
        [Fact]
        public void UpdateEventById_ChangeMessage_FindEventAndHaveTheNewMessage()
        {
            CalendarNotifiTime testCalendar = new CalendarNotifiTime("Test calendar with event updated!");
            
            List<SupportedPlatform> supportedPlatformList = new List<SupportedPlatform>();
            supportedPlatformList.Add(SupportedPlatform.Mail);
            testCalendar.AddEvent( new EventCalendar(
                "Test event 1",
                new DateTime(2024, 3, 7, 14, 45, 0),
                supportedPlatformList,
                "Custom message",
                TimeIteration.None
            ));
            
            EventCalendar eventCalendar = (EventCalendar)testCalendar.AddEvent( new EventCalendar(
                "Test event 2",
                new DateTime(2023, 4, 5, 0, 45, 0),
                supportedPlatformList,
                "Custom message",
                TimeIteration.None
            ));
            
            testCalendar.AddEvent( new EventCalendar(
                "Test event 3",
                new DateTime(2024, 1, 6, 16, 30, 0),
                supportedPlatformList,
                "Custom message",
                TimeIteration.None
            ));
            
            eventCalendar.SetMessage("Texto cambiado!");

            testCalendar.UpdateEventById(eventCalendar);
            
            Assert.Equal(testCalendar.GetEventById(eventCalendar.GetId()).GetMessage(), "Texto cambiado!");
        }
    }
}