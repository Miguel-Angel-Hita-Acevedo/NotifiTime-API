using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotifiTime_API.application.Dtos;
using NotifiTime_API.application.services;
using NotifiTime_API.domain.entities;
using NotifiTime_API.domain.Enum;
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
            eventCalendarDto.Id = new Guid();
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
    }
}