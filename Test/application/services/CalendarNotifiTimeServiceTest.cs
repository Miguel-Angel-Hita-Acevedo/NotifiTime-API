using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotifiTime_API.application.DTOs;
using NotifiTime_API.application.services;
using NotifiTime_API.domain.entities;
using NotifiTime_API.domain.Enum;
using Xunit;

namespace NotifiTime_API.Test.application
{
    public class CalendarNotifiTimeServiceTest
    {
        [Fact]
        public void CreateEvent_FullParametersOfEvent_ReturnFullParametersOnDto()
        {
            CalendarNotifiTime calendar = new CalendarNotifiTime("Test calendar");
            CalendarNotifiTimeService calendarService = new CalendarNotifiTimeService(calendar);

            EventCalendarDTO eventCalendarDto = calendarService.
                CreateEvent(
                    new DateTime(10, 10, 10),
                    "Test event",
                    TimeIteration.Annually
                );
            
            
            Assert.True(
                    eventCalendarDto.DateTime == new DateTime(10, 10, 10) &&
                    eventCalendarDto.Name == "Test event" &&
                    eventCalendarDto.TimeIteration == TimeIteration.Annually
                );
        }
    }
}