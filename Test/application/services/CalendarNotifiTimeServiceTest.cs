using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotifiTime_API.application.Dtos;
using NotifiTime_API.application.services;
using NotifiTime_API.domain.entities;
using NotifiTime_API.domain.Enum;
using SequentialGuid;
using Xunit;

namespace NotifiTime_API.Test.application
{
    public class CalendarNotifiTimeServiceTest
    {
        [Fact]
        public void GetEventById_FullParametersOfEvent_ReturnFullParametersOnDtoFound()
        {
            CalendarNotifiTime calendar = new CalendarNotifiTime("Test calendar");
            CalendarNotifiTimeService calendarService = new CalendarNotifiTimeService(calendar);

            EventCalendarDto eventCalendarDto = new EventCalendarDto();
            eventCalendarDto.Id = SequentialGuidGenerator.Instance.NewGuid();
            eventCalendarDto.DateTime = new DateTime(10, 10, 10);
            eventCalendarDto.Name = "Test event";
            eventCalendarDto.Message = "Message test event";
            eventCalendarDto.TimeIteration = TimeIteration.Annually;

            calendarService.AddEvent(eventCalendarDto);

            EventCalendarDto eventCalendarDtoFound = calendarService.GetEventById(eventCalendarDto.Id);
            
            Assert.True(
                    eventCalendarDto.DateTime == eventCalendarDtoFound.DateTime &&
                    eventCalendarDto.Name == eventCalendarDtoFound.Name &&
                    eventCalendarDto.Message == eventCalendarDtoFound.Message &&
                    eventCalendarDto.TimeIteration == eventCalendarDtoFound.TimeIteration
                );
        }
        
        [Fact]
        public void DeleteEventById_3Events_Returns2()
        {
            CalendarNotifiTime calendar = new CalendarNotifiTime("Test calendar");
            CalendarNotifiTimeService calendarService = new CalendarNotifiTimeService(calendar);

            EventCalendarDto eventCalendarDtoOne = new EventCalendarDto();
            eventCalendarDtoOne.Id = SequentialGuidGenerator.Instance.NewGuid();
            eventCalendarDtoOne.DateTime = new DateTime(10, 10, 10);
            eventCalendarDtoOne.Name = "Test event One";
            eventCalendarDtoOne.Message = "Message test event One";
            eventCalendarDtoOne.TimeIteration = TimeIteration.Annually;
            calendarService.AddEvent(eventCalendarDtoOne);

            EventCalendarDto eventCalendarDtoTwo = new EventCalendarDto();
            eventCalendarDtoTwo.Id = SequentialGuidGenerator.Instance.NewGuid();
            eventCalendarDtoTwo.DateTime = new DateTime(10, 10, 10);
            eventCalendarDtoTwo.Name = "Test event Two";
            eventCalendarDtoTwo.Message = "Message test event Two";
            eventCalendarDtoTwo.TimeIteration = TimeIteration.Annually;
            calendarService.AddEvent(eventCalendarDtoTwo);
            
            EventCalendarDto eventCalendarDtoThree = new EventCalendarDto();
            eventCalendarDtoThree.Id = SequentialGuidGenerator.Instance.NewGuid();
            eventCalendarDtoThree.DateTime = new DateTime(10, 10, 10);
            eventCalendarDtoThree.Name = "Test event Three";
            eventCalendarDtoThree.Message = "Message test event Three";
            eventCalendarDtoThree.TimeIteration = TimeIteration.Annually;
            calendarService.AddEvent(eventCalendarDtoThree);

            calendarService.DeleteEventById(eventCalendarDtoOne.Id);
            
            Assert.True(calendarService.EventsCalendarLength() == 2);
        }
        
        [Fact]
        public void SortEventsByDate_3Events_CorrectOrder()
        {
            CalendarNotifiTime calendar = new CalendarNotifiTime("Test calendar");
            CalendarNotifiTimeService calendarService = new CalendarNotifiTimeService(calendar);

            EventCalendarDto eventCalendarDtoOne = new EventCalendarDto();
            eventCalendarDtoOne.Id = SequentialGuidGenerator.Instance.NewGuid();
            eventCalendarDtoOne.DateTime = new DateTime(2010, 10, 10);
            eventCalendarDtoOne.Name = "Test event One";
            eventCalendarDtoOne.Message = "Message test event One";
            eventCalendarDtoOne.TimeIteration = TimeIteration.Annually;
            calendarService.AddEvent(eventCalendarDtoOne);

            EventCalendarDto eventCalendarDtoTwo = new EventCalendarDto();
            eventCalendarDtoTwo.Id = SequentialGuidGenerator.Instance.NewGuid();
            eventCalendarDtoTwo.DateTime = new DateTime(2011, 10, 10);
            eventCalendarDtoTwo.Name = "Test event Two";
            eventCalendarDtoTwo.Message = "Message test event Two";
            eventCalendarDtoTwo.TimeIteration = TimeIteration.Annually;
            calendarService.AddEvent(eventCalendarDtoTwo);
            
            EventCalendarDto eventCalendarDtoThree = new EventCalendarDto();
            eventCalendarDtoThree.Id = SequentialGuidGenerator.Instance.NewGuid();
            eventCalendarDtoThree.DateTime = new DateTime(2010, 11, 10);
            eventCalendarDtoThree.Name = "Test event Three";
            eventCalendarDtoThree.Message = "Message test event Three";
            eventCalendarDtoThree.TimeIteration = TimeIteration.Annually;
            calendarService.AddEvent(eventCalendarDtoThree);

            EventCalendarDto[] eventCalendarDtoArraySort = calendarService.SortEventsByDate(DateTime.MinValue, DateTime.MaxValue, false);
            
            Assert.Equal(eventCalendarDtoArraySort[0].Name, eventCalendarDtoTwo.Name);
        }
        
        [Fact]
        public void GetAllEvents_3Events_AllIdsOnOutput()
        {
            CalendarNotifiTime calendar = new CalendarNotifiTime("Test calendar");
            CalendarNotifiTimeService calendarService = new CalendarNotifiTimeService(calendar);

            EventCalendarDto eventCalendarDtoOne = new EventCalendarDto();
            eventCalendarDtoOne.Id = SequentialGuidGenerator.Instance.NewGuid();
            eventCalendarDtoOne.DateTime = new DateTime(10, 10, 10);
            eventCalendarDtoOne.Name = "Test event One";
            eventCalendarDtoOne.Message = "Message test event One";
            eventCalendarDtoOne.TimeIteration = TimeIteration.Annually;
            calendarService.AddEvent(eventCalendarDtoOne);

            EventCalendarDto eventCalendarDtoTwo = new EventCalendarDto();
            eventCalendarDtoTwo.Id = SequentialGuidGenerator.Instance.NewGuid();
            eventCalendarDtoTwo.DateTime = new DateTime(10, 10, 10);
            eventCalendarDtoTwo.Name = "Test event Two";
            eventCalendarDtoTwo.Message = "Message test event Two";
            eventCalendarDtoTwo.TimeIteration = TimeIteration.Annually;
            calendarService.AddEvent(eventCalendarDtoTwo);
            
            EventCalendarDto eventCalendarDtoThree = new EventCalendarDto();
            eventCalendarDtoThree.Id = SequentialGuidGenerator.Instance.NewGuid();
            eventCalendarDtoThree.DateTime = new DateTime(10, 10, 10);
            eventCalendarDtoThree.Name = "Test event Three";
            eventCalendarDtoThree.Message = "Message test event Three";
            eventCalendarDtoThree.TimeIteration = TimeIteration.Annually;
            calendarService.AddEvent(eventCalendarDtoThree);

            EventCalendarDto[] eventCalendarDtoArray = calendarService.GetAllEvents();
            
            Assert.True(eventCalendarDtoArray.Length == 3);
        }
        
        [Fact]
        public void UpdateEvent_FullParametersOfEvent_ReturnFullParametersOnDtoFoundWithChanges()
        {
            CalendarNotifiTime calendar = new CalendarNotifiTime("Test calendar");
            CalendarNotifiTimeService calendarService = new CalendarNotifiTimeService(calendar);
            DateTime EVENTDATECHANGED = new DateTime(2000, 11, 12);
            string EVENTNAMECHANGED = "Test event CHANGED!";
            string EVENTMESSAGECHANGED = "Test message CHANGED!";
            TimeIteration EVENTTIMEITERATIONCHANGED = TimeIteration.Monthly;

            EventCalendarDto eventCalendarDto = new EventCalendarDto();
            eventCalendarDto.Id = SequentialGuidGenerator.Instance.NewGuid();
            eventCalendarDto.DateTime = new DateTime(10, 10, 10);
            eventCalendarDto.Name = "Test event";
            eventCalendarDto.Message = "Message test event";
            eventCalendarDto.TimeIteration = TimeIteration.Annually;

            calendarService.AddEvent(eventCalendarDto);

            eventCalendarDto.DateTime = EVENTDATECHANGED;
            eventCalendarDto.Name = EVENTNAMECHANGED;
            eventCalendarDto.Message = EVENTMESSAGECHANGED;
            eventCalendarDto.TimeIteration = EVENTTIMEITERATIONCHANGED;

            calendarService.UpdateEvent(eventCalendarDto);
            EventCalendarDto eventCalendarDtoFound = calendarService.GetEventById(eventCalendarDto.Id);
            
            Assert.True(
                eventCalendarDtoFound.DateTime.Equals(EVENTDATECHANGED) &&
                eventCalendarDtoFound.Name.Equals(EVENTNAMECHANGED) &&
                eventCalendarDtoFound.Message.Equals(EVENTMESSAGECHANGED) &&
                eventCalendarDtoFound.TimeIteration.Equals(EVENTTIMEITERATIONCHANGED)
            );
        }
        
        [Fact]
        public void UpdateEvent_1Parameter_ReturnAllFieldsTheSameAndValueChanged()
        {
            CalendarNotifiTime calendar = new CalendarNotifiTime("Test calendar");
            CalendarNotifiTimeService calendarService = new CalendarNotifiTimeService(calendar);
            string EVENTNAMECHANGED = "Test event CHANGED!";

            EventCalendarDto eventCalendarDto = new EventCalendarDto();
            eventCalendarDto.Id = SequentialGuidGenerator.Instance.NewGuid();
            eventCalendarDto.DateTime = new DateTime(10, 10, 10);
            eventCalendarDto.Name = "Test event";
            eventCalendarDto.Message = "Message test event";
            eventCalendarDto.TimeIteration = TimeIteration.Annually;

            calendarService.AddEvent(eventCalendarDto);

            eventCalendarDto.Name = EVENTNAMECHANGED;

            calendarService.UpdateEvent(eventCalendarDto);
            EventCalendarDto eventCalendarDtoFound = calendarService.GetEventById(eventCalendarDto.Id);
            
            Assert.True(
                eventCalendarDtoFound.DateTime.Equals(eventCalendarDto.DateTime) &&
                eventCalendarDtoFound.Name.Equals(EVENTNAMECHANGED) &&
                eventCalendarDtoFound.Message.Equals(eventCalendarDto.Message) &&
                eventCalendarDtoFound.TimeIteration.Equals(eventCalendarDto.TimeIteration)
            );
        }
        
    }
}