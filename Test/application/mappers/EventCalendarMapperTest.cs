using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotifiTime_API.application.Dtos;
using NotifiTime_API.application.mappers;
using NotifiTime_API.domain.entities;
using NotifiTime_API.domain.Enum;
using Xunit;

namespace NotifiTime_API.Test.application.mappers
{
    public class EventCalendarMapperTest
    {
        [Fact]
        public void EventCalendarToDto_EventCalendarWithAllValues_ReturnDto()
        {
            EventCalendar eventCalendar = new EventCalendar();

            eventCalendar.SetDateTime(new DateTime(2010, 1, 1));
            eventCalendar.SetMessage("Event Calendar Message");
            eventCalendar.SetName("Event Calendar Name");
            eventCalendar.SetSupportedPlatformList(new[] { SupportedPlatform.Mail }.ToList());
            eventCalendar.SetTimeIteration(TimeIteration.Annually);

            EventCalendarDto eventCalendarDto = EventCalendarMapper.EventCalendarToDto(eventCalendar);

            Assert.True(
                eventCalendar.GetDateTime() == eventCalendarDto.DateTime &&
                eventCalendar.GetMessage() == eventCalendarDto.Message &&
                eventCalendar.GetName() == eventCalendarDto.Name &&
                eventCalendar.GetSupportedPlatformList() == eventCalendarDto.SupportedPlatformList &&
                eventCalendar.GetTimeIteration() == eventCalendarDto.TimeIteration
            );
        }
        
        [Fact]
        public void EventCalendarToDto_EventCalendarWithSomeValuesNull_ReturnDto()
        {
            EventCalendar eventCalendar = new EventCalendar();

            eventCalendar.SetMessage("Event Calendar Message");
            eventCalendar.SetSupportedPlatformList(new[] { SupportedPlatform.Mail }.ToList());

            EventCalendarDto eventCalendarDto = EventCalendarMapper.EventCalendarToDto(eventCalendar);

            Assert.True(
                eventCalendar.GetDateTime() == eventCalendarDto.DateTime &&
                eventCalendar.GetMessage() == eventCalendarDto.Message &&
                eventCalendar.GetName() == eventCalendarDto.Name &&
                eventCalendar.GetSupportedPlatformList() == eventCalendarDto.SupportedPlatformList &&
                eventCalendar.GetTimeIteration() == eventCalendarDto.TimeIteration
            );
        }
        
        [Fact]
        public void EventCalendarDtoToDomainObject_EventCalendarDtoWithAllValues_ReturnDomainObject()
        {
            EventCalendarDto eventCalendarDto = new EventCalendarDto();

            eventCalendarDto.DateTime = new DateTime(2010, 1, 1);
            eventCalendarDto.Message = "Event Calendar Message";
            eventCalendarDto.Name = "Event Calendar Name";
            eventCalendarDto.SupportedPlatformList = new[] { SupportedPlatform.Mail }.ToList();
            eventCalendarDto.TimeIteration = TimeIteration.Annually;

            EventCalendar eventCalendar = EventCalendarMapper.EventCalendarDtoToDomainObject(eventCalendarDto);

            Assert.True(
                eventCalendar.GetDateTime() == eventCalendarDto.DateTime &&
                eventCalendar.GetMessage() == eventCalendarDto.Message &&
                eventCalendar.GetName() == eventCalendarDto.Name &&
                eventCalendar.GetSupportedPlatformList() == eventCalendarDto.SupportedPlatformList &&
                eventCalendar.GetTimeIteration() == eventCalendarDto.TimeIteration
            );
        }
        
        [Fact]
        public void EventCalendarDtoToDomainObject_EventCalendarDtoWithSomeValuesNull_ReturnDomainObject()
        {
            EventCalendarDto eventCalendarDto = new EventCalendarDto();

            eventCalendarDto.Message = "Event Calendar Message";

            EventCalendar eventCalendar = EventCalendarMapper.EventCalendarDtoToDomainObject(eventCalendarDto);

            Assert.True(
                eventCalendar.GetDateTime() == eventCalendarDto.DateTime &&
                eventCalendar.GetMessage() == eventCalendarDto.Message &&
                eventCalendar.GetName() == eventCalendarDto.Name &&
                eventCalendar.GetSupportedPlatformList() == eventCalendarDto.SupportedPlatformList &&
                eventCalendar.GetTimeIteration() == eventCalendarDto.TimeIteration
            );
        }
        
        [Fact]
        public void EventCalendarArrayToDtoArray_EventCalendarArrayWithAllValues_ReturnDomainObjectArray()
        {
            EventCalendar eventCalendarOne = new EventCalendar();
            EventCalendar eventCalendarTwo = new EventCalendar();

            eventCalendarOne.SetDateTime(new DateTime(2010, 1, 1));
            eventCalendarOne.SetMessage("Event Calendar Message One");
            eventCalendarOne.SetName("Event Calendar Name One");
            eventCalendarOne.SetSupportedPlatformList(new[] { SupportedPlatform.Mail }.ToList());
            eventCalendarOne.SetTimeIteration(TimeIteration.Annually);

            eventCalendarTwo.SetDateTime(new DateTime(2010, 2, 2));
            eventCalendarTwo.SetMessage("Event Calendar Message Two");
            eventCalendarTwo.SetName("Event Calendar Name Two");
            eventCalendarTwo.SetSupportedPlatformList(new[] { SupportedPlatform.Mail }.ToList());
            eventCalendarTwo.SetTimeIteration(TimeIteration.Annually);

            EventCalendarDto[] eventCalendarDto = EventCalendarMapper.EventCalendarArrayToDtoArray(
                new[] { eventCalendarOne, eventCalendarTwo }
            );

            Assert.True(
                eventCalendarOne.GetDateTime() == eventCalendarDto[0].DateTime &&
                eventCalendarOne.GetMessage() == eventCalendarDto[0].Message &&
                eventCalendarOne.GetName() == eventCalendarDto[0].Name &&
                eventCalendarOne.GetSupportedPlatformList() == eventCalendarDto[0].SupportedPlatformList &&
                eventCalendarOne.GetTimeIteration() == eventCalendarDto[0].TimeIteration &&
                eventCalendarTwo.GetDateTime() == eventCalendarDto[1].DateTime &&
                eventCalendarTwo.GetMessage() == eventCalendarDto[1].Message &&
                eventCalendarTwo.GetName() == eventCalendarDto[1].Name &&
                eventCalendarTwo.GetSupportedPlatformList() == eventCalendarDto[1].SupportedPlatformList &&
                eventCalendarTwo.GetTimeIteration() == eventCalendarDto[1].TimeIteration
            );
        }
    }
}