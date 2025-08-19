using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotifiTime_API.application.Dtos;
using NotifiTime_API.application.mappers;
using NotifiTime_API.application.services;
using NotifiTime_API.domain.entities;
using NotifiTime_API.domain.Enum;
using SequentialGuid;
using Xunit;

namespace NotifiTime_API.Test.application.mappers
{
    public class CalendarNotifiTimeMapperTest
    {
        [Fact]
        public void CalendarNotifiTimeToDto_CalendarWithFullAttributes_ReturnDtoCorrectAttributes()
        {
            CalendarNotifiTime calendarNotifiTime = new CalendarNotifiTime("Calendar name");
            EventCalendar eventCalendar = new EventCalendar();

            eventCalendar.SetDateTime(new DateTime(2010, 1, 1));
            eventCalendar.SetMessage("Event Calendar Message");
            eventCalendar.SetName("Event Calendar Name");
            eventCalendar.SetSupportedPlatformList(new[] { SupportedPlatform.Mail }.ToList());
            eventCalendar.SetTimeIteration(TimeIteration.Annually);

            calendarNotifiTime.AddEvent(eventCalendar);

            CalendarNotifiTimeDto calendarNotifiTimeDto = CalendarNotifiTimeMapper.CalendarNotifiTimeToDto(calendarNotifiTime);

            Assert.True(
                calendarNotifiTimeDto.CreationDate == calendarNotifiTime.getCreationDate() &&
                calendarNotifiTimeDto.Name == calendarNotifiTime.GetName() &&
                calendarNotifiTimeDto.Id == calendarNotifiTime.GetId() &&
                calendarNotifiTimeDto.EventCalendarList[0].Id == eventCalendar.GetId() &&
                calendarNotifiTimeDto.EventCalendarList[0].Name == eventCalendar.GetName() &&
                calendarNotifiTimeDto.EventCalendarList[0].DateTime == eventCalendar.GetDateTime() &&
                calendarNotifiTimeDto.EventCalendarList[0].SupportedPlatformList == eventCalendar.GetSupportedPlatformList() &&
                calendarNotifiTimeDto.EventCalendarList[0].TimeIteration == eventCalendar.GetTimeIteration() &&
                calendarNotifiTimeDto.EventCalendarList[0].Message == eventCalendar.GetMessage()
            );
        }
        
        [Fact]
        public void CalendarNotifiTimeToDto_CalendarWithSomeAttributesNull_ReturnDtoCorrectAttributes()
        {
            CalendarNotifiTime calendarNotifiTime = new CalendarNotifiTime("Calendar name");
            EventCalendar eventCalendar = new EventCalendar();

            eventCalendar.SetDateTime(new DateTime(2010, 1, 1));
            eventCalendar.SetName("Event Calendar Name");

            calendarNotifiTime.AddEvent(eventCalendar);

            CalendarNotifiTimeDto calendarNotifiTimeDto = CalendarNotifiTimeMapper.CalendarNotifiTimeToDto(calendarNotifiTime);

            Assert.True(
                calendarNotifiTimeDto.CreationDate == calendarNotifiTime.getCreationDate() &&
                calendarNotifiTimeDto.Name == calendarNotifiTime.GetName() &&
                calendarNotifiTimeDto.Id == calendarNotifiTime.GetId() &&
                calendarNotifiTimeDto.EventCalendarList[0].Id == eventCalendar.GetId() &&
                calendarNotifiTimeDto.EventCalendarList[0].Name == eventCalendar.GetName() &&
                calendarNotifiTimeDto.EventCalendarList[0].DateTime == eventCalendar.GetDateTime() &&
                calendarNotifiTimeDto.EventCalendarList[0].SupportedPlatformList == eventCalendar.GetSupportedPlatformList() &&
                calendarNotifiTimeDto.EventCalendarList[0].TimeIteration == eventCalendar.GetTimeIteration() &&
                calendarNotifiTimeDto.EventCalendarList[0].Message == eventCalendar.GetMessage()
            );
        }
        
        [Fact]
        public void CalendarNotifiTimesToDtoArray_2Calendars_ReturnDtoArrayCorrectAttributes()
        {
            CalendarNotifiTime calendarNotifiTimeOne = new CalendarNotifiTime("Calendar name One");
            CalendarNotifiTime calendarNotifiTimeTwo = new CalendarNotifiTime("Calendar name Two");
            EventCalendar eventCalendar = new EventCalendar();

            eventCalendar.SetDateTime(new DateTime(2010, 1, 1));
            eventCalendar.SetMessage("Event Calendar Message");
            eventCalendar.SetName("Event Calendar Name");
            eventCalendar.SetSupportedPlatformList(new[] { SupportedPlatform.Mail }.ToList());
            eventCalendar.SetTimeIteration(TimeIteration.Annually);

            calendarNotifiTimeOne.AddEvent(eventCalendar);

            CalendarNotifiTimeDto[] calendarNotifiTimeDtoArray = CalendarNotifiTimeMapper.CalendarNotifiTimesToDtoArray(new[]{ calendarNotifiTimeOne, calendarNotifiTimeTwo });

            Assert.True(
                calendarNotifiTimeDtoArray[0].CreationDate == calendarNotifiTimeOne.getCreationDate() &&
                calendarNotifiTimeDtoArray[0].Name == calendarNotifiTimeOne.GetName() &&
                calendarNotifiTimeDtoArray[0].Id == calendarNotifiTimeOne.GetId() &&
                calendarNotifiTimeDtoArray[1].CreationDate == calendarNotifiTimeTwo.getCreationDate() &&
                calendarNotifiTimeDtoArray[1].Name == calendarNotifiTimeTwo.GetName() &&
                calendarNotifiTimeDtoArray[1].Id == calendarNotifiTimeTwo.GetId() &&
                calendarNotifiTimeDtoArray[0].EventCalendarList[0].Id == eventCalendar.GetId() &&
                calendarNotifiTimeDtoArray[0].EventCalendarList[0].Name == eventCalendar.GetName() &&
                calendarNotifiTimeDtoArray[0].EventCalendarList[0].DateTime == eventCalendar.GetDateTime() &&
                calendarNotifiTimeDtoArray[0].EventCalendarList[0].SupportedPlatformList == eventCalendar.GetSupportedPlatformList() &&
                calendarNotifiTimeDtoArray[0].EventCalendarList[0].TimeIteration == eventCalendar.GetTimeIteration() &&
                calendarNotifiTimeDtoArray[0].EventCalendarList[0].Message == eventCalendar.GetMessage()
            );
        }
        
        [Fact]
        public void CalendarNotifiTimeDtoToDomainObject_CalendarDtoWithFullAttributes_ReturnDomainObject()
        {
            CalendarNotifiTimeDto calendarNotifiTimeDto = new CalendarNotifiTimeDto();
            EventCalendarDto eventCalendarDto = new EventCalendarDto();

            
            eventCalendarDto.Id = SequentialGuidGenerator.Instance.NewGuid();
            eventCalendarDto.DateTime = new DateTime(2010, 1, 1);
            eventCalendarDto.Name = "Event Calendar Name";
            eventCalendarDto.Message = "dto message";

            calendarNotifiTimeDto.EventCalendarList = new[] { eventCalendarDto }.ToList();
            calendarNotifiTimeDto.Id = SequentialGuidGenerator.Instance.NewGuid();
            calendarNotifiTimeDto.Name = "Calendar name";

            CalendarNotifiTime calendarNotifiTime = CalendarNotifiTimeMapper.CalendarNotifiTimeDtoToDomainObject(calendarNotifiTimeDto);
            EventCalendar[] eventCalendarArray = calendarNotifiTime.GetAllEvents();

            Assert.True(
                calendarNotifiTimeDto.CreationDate == calendarNotifiTime.getCreationDate() &&
                calendarNotifiTimeDto.Name == calendarNotifiTime.GetName() &&
                calendarNotifiTimeDto.Id == calendarNotifiTime.GetId() &&
                eventCalendarDto.Id == eventCalendarArray[0].GetId() &&
                eventCalendarDto.Name == eventCalendarArray[0].GetName() &&
                eventCalendarDto.DateTime == eventCalendarArray[0].GetDateTime() &&
                eventCalendarDto.SupportedPlatformList == eventCalendarArray[0].GetSupportedPlatformList() &&
                eventCalendarDto.TimeIteration == eventCalendarArray[0].GetTimeIteration() &&
                eventCalendarDto.Message == eventCalendarArray[0].GetMessage()
            );
        }
        
        [Fact]
        public void CalendarNotifiTimeDtoToDomainObject_CalendarWithSomeAttributesNull_ReturnDomainObject()
        {
            CalendarNotifiTimeDto calendarNotifiTimeDto = new CalendarNotifiTimeDto();
            EventCalendarDto eventCalendarDto = new EventCalendarDto();
            
            eventCalendarDto.Id = SequentialGuidGenerator.Instance.NewGuid();
            eventCalendarDto.DateTime = new DateTime(2010, 1, 1);
            eventCalendarDto.Name = null;
            eventCalendarDto.Message = null;

            calendarNotifiTimeDto.EventCalendarList = new[] { eventCalendarDto }.ToList();
            calendarNotifiTimeDto.Id = SequentialGuidGenerator.Instance.NewGuid();
            calendarNotifiTimeDto.Name = null;

            CalendarNotifiTime calendarNotifiTime = CalendarNotifiTimeMapper.CalendarNotifiTimeDtoToDomainObject(calendarNotifiTimeDto);
            EventCalendar[] eventCalendarArray = calendarNotifiTime.GetAllEvents();

            Assert.True(
                calendarNotifiTimeDto.CreationDate == calendarNotifiTime.getCreationDate() &&
                calendarNotifiTimeDto.Name == calendarNotifiTime.GetName() &&
                calendarNotifiTimeDto.Id == calendarNotifiTime.GetId() &&
                eventCalendarDto.Id == eventCalendarArray[0].GetId() &&
                eventCalendarDto.Name == eventCalendarArray[0].GetName() &&
                eventCalendarDto.DateTime == eventCalendarArray[0].GetDateTime() &&
                eventCalendarDto.SupportedPlatformList == eventCalendarArray[0].GetSupportedPlatformList() &&
                eventCalendarDto.TimeIteration == eventCalendarArray[0].GetTimeIteration() &&
                eventCalendarDto.Message == eventCalendarArray[0].GetMessage()
            );
        }
        
        [Fact]
        public void CalendarNotifiTimesDtoToDomainObjectArray_2Calendars_ReturnDtoArrayCorrectAttributes()
        {
            CalendarNotifiTimeDto calendarNotifiTimeDtoOne = new CalendarNotifiTimeDto();
            CalendarNotifiTimeDto calendarNotifiTimeDtoTwo = new CalendarNotifiTimeDto();
            EventCalendarDto eventCalendarDto = new EventCalendarDto();

            
            eventCalendarDto.Id = SequentialGuidGenerator.Instance.NewGuid();
            eventCalendarDto.DateTime = new DateTime(2010, 1, 1);
            eventCalendarDto.Name = "Event Calendar Name";
            eventCalendarDto.Message = "dto message";

            calendarNotifiTimeDtoOne.EventCalendarList = new[] { eventCalendarDto }.ToList();
            calendarNotifiTimeDtoOne.Id = SequentialGuidGenerator.Instance.NewGuid();
            calendarNotifiTimeDtoOne.Name = "Calendar name one";

            calendarNotifiTimeDtoTwo.Id = SequentialGuidGenerator.Instance.NewGuid();
            calendarNotifiTimeDtoTwo.Name = "Calendar name two";

            CalendarNotifiTime[] calendarNotifiTime = CalendarNotifiTimeMapper.CalendarNotifiTimesDtoToDomainObjectArray(new[] { calendarNotifiTimeDtoOne, calendarNotifiTimeDtoTwo });
            EventCalendar[] eventCalendarArray = calendarNotifiTime[0].GetAllEvents();

            Assert.True(
                calendarNotifiTimeDtoOne.CreationDate == calendarNotifiTime[0].getCreationDate() &&
                calendarNotifiTimeDtoOne.Name == calendarNotifiTime[0].GetName() &&
                calendarNotifiTimeDtoOne.Id == calendarNotifiTime[0].GetId() &&
                calendarNotifiTimeDtoTwo.CreationDate == calendarNotifiTime[1].getCreationDate() &&
                calendarNotifiTimeDtoTwo.Name == calendarNotifiTime[1].GetName() &&
                calendarNotifiTimeDtoTwo.Id == calendarNotifiTime[1].GetId() &&
                eventCalendarDto.Id == eventCalendarArray[0].GetId() &&
                eventCalendarDto.Name == eventCalendarArray[0].GetName() &&
                eventCalendarDto.DateTime == eventCalendarArray[0].GetDateTime() &&
                eventCalendarDto.SupportedPlatformList == eventCalendarArray[0].GetSupportedPlatformList() &&
                eventCalendarDto.TimeIteration == eventCalendarArray[0].GetTimeIteration() &&
                eventCalendarDto.Message == eventCalendarArray[0].GetMessage()
            );
        }
        
        [Fact]
        public void DomainCalendarArrayToCalendarServiceArray_2Calendars_ReturnDtoArrayCorrectAttributes()
        {
            CalendarNotifiTime calendarNotifiTimeOne = new CalendarNotifiTime("Calendar One");
            CalendarNotifiTime calendarNotifiTimeTwo = new CalendarNotifiTime("Calendar Two");
            EventCalendar eventCalendar = new EventCalendar();
            
            eventCalendar.SetDateTime(new DateTime(2010, 1, 1));
            eventCalendar.SetName("Event Calendar Name");
            eventCalendar.SetMessage("dto message");

            calendarNotifiTimeOne.AddEvent(eventCalendar);

            CalendarNotifiTimeService[] calendarNotifiTimeService = CalendarNotifiTimeMapper.DomainCalendarArrayToCalendarServiceArray(new[] { calendarNotifiTimeOne, calendarNotifiTimeTwo });
            EventCalendarDto eventCalendarDto = calendarNotifiTimeService[0].GetAllEvents()[0];

            Assert.True(
                calendarNotifiTimeService[0].GetDto().CreationDate == calendarNotifiTimeOne.getCreationDate() &&
                calendarNotifiTimeService[0].GetDto().Name == calendarNotifiTimeOne.GetName() &&
                calendarNotifiTimeService[0].GetDto().Id == calendarNotifiTimeOne.GetId() &&
                calendarNotifiTimeService[1].GetDto().CreationDate == calendarNotifiTimeTwo.getCreationDate() &&
                calendarNotifiTimeService[1].GetDto().Name == calendarNotifiTimeTwo.GetName() &&
                calendarNotifiTimeService[1].GetDto().Id == calendarNotifiTimeTwo.GetId() &&
                eventCalendarDto.Id == eventCalendar.GetId() &&
                eventCalendarDto.Name == eventCalendar.GetName() &&
                eventCalendarDto.DateTime == eventCalendar.GetDateTime() &&
                eventCalendarDto.SupportedPlatformList == eventCalendar.GetSupportedPlatformList() &&
                eventCalendarDto.TimeIteration == eventCalendar.GetTimeIteration() &&
                eventCalendarDto.Message == eventCalendar.GetMessage()
            );
        }
        
        [Fact]
        public void CalendarServiceArrayToCalendarDtoArray_2Calendars_ReturnDtoArrayCorrectAttributes()
        {
            CalendarNotifiTimeService calendarNotifiTimeOne = new CalendarNotifiTimeService(new CalendarNotifiTime("Calendar One"));
            CalendarNotifiTimeService calendarNotifiTimeTwo = new CalendarNotifiTimeService(new CalendarNotifiTime("Calendar Two"));
            EventCalendarDto eventCalendarDto = new EventCalendarDto();
            
            eventCalendarDto.Id = SequentialGuidGenerator.Instance.NewGuid();
            eventCalendarDto.DateTime = new DateTime(2010, 1, 1);
            eventCalendarDto.Name = "Event Calendar Name";
            eventCalendarDto.Message = "dto message";

            calendarNotifiTimeOne.AddEvent(eventCalendarDto);

            CalendarNotifiTimeDto[] calendarNotifiTimeDtoArray = CalendarNotifiTimeMapper.CalendarServiceArrayToCalendarDtoArray(new[] { calendarNotifiTimeOne, calendarNotifiTimeTwo });
            EventCalendarDto eventCalendarDtoFinal = calendarNotifiTimeDtoArray[0].EventCalendarList[0];

            Assert.True(
                calendarNotifiTimeDtoArray[0].CreationDate == calendarNotifiTimeOne.GetDto().CreationDate &&
                calendarNotifiTimeDtoArray[0].Name == calendarNotifiTimeOne.GetDto().Name &&
                calendarNotifiTimeDtoArray[0].Id == calendarNotifiTimeOne.GetDto().Id &&
                calendarNotifiTimeDtoArray[1].CreationDate == calendarNotifiTimeTwo.GetDto().CreationDate &&
                calendarNotifiTimeDtoArray[1].Name == calendarNotifiTimeTwo.GetDto().Name &&
                calendarNotifiTimeDtoArray[1].Id == calendarNotifiTimeTwo.GetDto().Id &&
                eventCalendarDtoFinal.Id == eventCalendarDto.Id &&
                eventCalendarDtoFinal.Name == eventCalendarDto.Name &&
                eventCalendarDtoFinal.DateTime == eventCalendarDto.DateTime &&
                eventCalendarDtoFinal.SupportedPlatformList == eventCalendarDto.SupportedPlatformList &&
                eventCalendarDtoFinal.TimeIteration == eventCalendarDto.TimeIteration &&
                eventCalendarDtoFinal.Message == eventCalendarDto.Message
            );
        }
    }
}