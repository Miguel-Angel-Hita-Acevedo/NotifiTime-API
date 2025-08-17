using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotifiTime_API.application.Dtos;
using NotifiTime_API.application.services;
using NotifiTime_API.domain.entities;
using NotifiTime_API.infrastructure.repositories;
using SequentialGuid;
using Xunit;

namespace NotifiTime_API.Test.application
{
    public class WalletCalendarServiceTest
    {
        [Fact]
        public void AddCalendarNotifiTime_ExistingCalendar_FoundCalendar()
        {
            WalletCalendarService walletCalendarService = new WalletCalendarService();
            CalendarNotifiTimeDto calendarNotifiTimeDto = new CalendarNotifiTimeDto();
            
            calendarNotifiTimeDto.Id = SequentialGuidGenerator.Instance.NewGuid();
            calendarNotifiTimeDto.Name = "Test calendar";

            walletCalendarService.AddCalendarNotifiTime(calendarNotifiTimeDto);

            CalendarNotifiTimeService calendarNotifiTimeService = walletCalendarService.FindCalendarNotifiTimeById(calendarNotifiTimeDto.Id);

            Assert.NotNull(calendarNotifiTimeService);
        }
        
        [Fact]
        public void CreateCalendarNotifiTime_NewCalendarInWallet_FoundCalendar()
        {
            WalletCalendarService walletCalendarService = new WalletCalendarService();

            CalendarNotifiTimeService calendarNotifiTimeService = walletCalendarService.CreateCalendarNotifiTime("Test calendar");

            CalendarNotifiTimeService calendarNotifiTimeServiceFound = walletCalendarService.FindCalendarNotifiTimeById(calendarNotifiTimeService.GetDto().Id);
            
            Assert.NotNull(calendarNotifiTimeServiceFound);
        }
        
        [Fact]
        public void DeleteCalendarNotifiTimeById_3Calendar_Have2Calendars()
        {
            WalletCalendarService walletCalendarService = new WalletCalendarService();
            CalendarNotifiTimeDto calendarNotifiTimeDtoOne = new CalendarNotifiTimeDto();
            CalendarNotifiTimeDto calendarNotifiTimeDtoTwo = new CalendarNotifiTimeDto();
            CalendarNotifiTimeDto calendarNotifiTimeDtoThree = new CalendarNotifiTimeDto();
            
            calendarNotifiTimeDtoOne.Id = SequentialGuidGenerator.Instance.NewGuid();
            calendarNotifiTimeDtoOne.Name = "Test calendar";
            walletCalendarService.AddCalendarNotifiTime(calendarNotifiTimeDtoOne);
            
            calendarNotifiTimeDtoTwo.Id = SequentialGuidGenerator.Instance.NewGuid();
            calendarNotifiTimeDtoTwo.Name = "Test calendar";
            walletCalendarService.AddCalendarNotifiTime(calendarNotifiTimeDtoTwo);
            
            calendarNotifiTimeDtoThree.Id = SequentialGuidGenerator.Instance.NewGuid();
            calendarNotifiTimeDtoThree.Name = "Test calendar";
            walletCalendarService.AddCalendarNotifiTime(calendarNotifiTimeDtoThree);

            walletCalendarService.DeleteCalendarNotifiTimeById(calendarNotifiTimeDtoTwo.Id);

            Assert.True(walletCalendarService.GetCalendarNotifiTimeArray().Length == 2);
        }
        
        [Fact]
        public void FindEventCalendarByIdOnAllCalendars_2Calendars2EventsPerCalendar_FoundEventCalendar()
        {
            WalletCalendarService walletCalendarService = new WalletCalendarService();
            CalendarNotifiTimeDto calendarNotifiTimeDtoOne = new CalendarNotifiTimeDto();
            CalendarNotifiTimeDto calendarNotifiTimeDtoTwo = new CalendarNotifiTimeDto();

            EventCalendarDto eventCalendarDtoOne = new EventCalendarDto();
            EventCalendarDto eventCalendarDtoTwo = new EventCalendarDto();
            EventCalendarDto eventCalendarDtoThree = new EventCalendarDto();
            EventCalendarDto eventCalendarDtoFour = new EventCalendarDto();
            
            eventCalendarDtoOne.Id = SequentialGuidGenerator.Instance.NewGuid();
            eventCalendarDtoOne.Name = "Event One";
            eventCalendarDtoTwo.Id = SequentialGuidGenerator.Instance.NewGuid();
            eventCalendarDtoTwo.Name = "Event Two";
            
            calendarNotifiTimeDtoOne.Id = SequentialGuidGenerator.Instance.NewGuid();
            calendarNotifiTimeDtoOne.Name = "Test calendar One";
            calendarNotifiTimeDtoOne.EventCalendarList = new[]{
                eventCalendarDtoOne,
                eventCalendarDtoTwo
            }.ToList();
            
            walletCalendarService.AddCalendarNotifiTime(calendarNotifiTimeDtoOne);
            
            eventCalendarDtoThree.Id = SequentialGuidGenerator.Instance.NewGuid();
            eventCalendarDtoThree.Name = "Event Three";
            eventCalendarDtoFour.Id = SequentialGuidGenerator.Instance.NewGuid();
            eventCalendarDtoFour.Name = "Event Four";
            
            calendarNotifiTimeDtoTwo.Id = SequentialGuidGenerator.Instance.NewGuid();
            calendarNotifiTimeDtoTwo.Name = "Test calendar Two";
            calendarNotifiTimeDtoTwo.EventCalendarList = new[]{
                eventCalendarDtoThree,
                eventCalendarDtoFour
            }.ToList();
            
            walletCalendarService.AddCalendarNotifiTime(calendarNotifiTimeDtoTwo);

            EventCalendarDto eventCalendarDto = walletCalendarService.FindEventCalendarByIdOnAllCalendars(eventCalendarDtoTwo.Id);

            Assert.Equal(eventCalendarDto.Id, eventCalendarDtoTwo.Id);
        }
        
        [Fact]
        public void FindCalendarNotifiTimeById_3Calendars_FoundCalendar()
        {
            WalletCalendarService walletCalendarService = new WalletCalendarService();
            CalendarNotifiTimeDto calendarNotifiTimeDtoOne = new CalendarNotifiTimeDto();
            CalendarNotifiTimeDto calendarNotifiTimeDtoTwo = new CalendarNotifiTimeDto();
            CalendarNotifiTimeDto calendarNotifiTimeDtoThree = new CalendarNotifiTimeDto();
            
            calendarNotifiTimeDtoOne.Id = SequentialGuidGenerator.Instance.NewGuid();
            calendarNotifiTimeDtoOne.Name = "Test calendar";
            walletCalendarService.AddCalendarNotifiTime(calendarNotifiTimeDtoOne);
            
            calendarNotifiTimeDtoTwo.Id = SequentialGuidGenerator.Instance.NewGuid();
            calendarNotifiTimeDtoTwo.Name = "Test calendar";
            walletCalendarService.AddCalendarNotifiTime(calendarNotifiTimeDtoTwo);
            
            calendarNotifiTimeDtoThree.Id = SequentialGuidGenerator.Instance.NewGuid();
            calendarNotifiTimeDtoThree.Name = "Test calendar";
            walletCalendarService.AddCalendarNotifiTime(calendarNotifiTimeDtoThree);

            CalendarNotifiTimeService calendarNotifiTimeServiceFound = walletCalendarService.FindCalendarNotifiTimeById(calendarNotifiTimeDtoTwo.Id);

            Assert.NotNull(calendarNotifiTimeServiceFound);
        }
        
        [Fact]
        public void FindCalendarNotifiTimeByName_3Calendars_FoundOne()
        {
            WalletCalendarService walletCalendarService = new WalletCalendarService();
            CalendarNotifiTimeDto calendarNotifiTimeDtoOne = new CalendarNotifiTimeDto();
            CalendarNotifiTimeDto calendarNotifiTimeDtoTwo = new CalendarNotifiTimeDto();
            CalendarNotifiTimeDto calendarNotifiTimeDtoThree = new CalendarNotifiTimeDto();
            
            calendarNotifiTimeDtoOne.Id = SequentialGuidGenerator.Instance.NewGuid();
            calendarNotifiTimeDtoOne.Name = "Test calendar one";
            walletCalendarService.AddCalendarNotifiTime(calendarNotifiTimeDtoOne);
            
            calendarNotifiTimeDtoTwo.Id = SequentialGuidGenerator.Instance.NewGuid();
            calendarNotifiTimeDtoTwo.Name = "Test calendar another";
            walletCalendarService.AddCalendarNotifiTime(calendarNotifiTimeDtoTwo);
            
            calendarNotifiTimeDtoThree.Id = SequentialGuidGenerator.Instance.NewGuid();
            calendarNotifiTimeDtoThree.Name = "Test calendar another";
            walletCalendarService.AddCalendarNotifiTime(calendarNotifiTimeDtoThree);

            CalendarNotifiTimeService[] calendarNotifiTimeServiceFound = walletCalendarService.FindCalendarNotifiTimeByName(calendarNotifiTimeDtoOne.Name);

            Assert.True(calendarNotifiTimeServiceFound.Length == 1);
        }
        
        [Fact]
        public void FindCalendarNotifiTimeByName_3Calendars_FoundTwoWithSameName()
        {
            WalletCalendarService walletCalendarService = new WalletCalendarService();
            CalendarNotifiTimeDto calendarNotifiTimeDtoOne = new CalendarNotifiTimeDto();
            CalendarNotifiTimeDto calendarNotifiTimeDtoTwo = new CalendarNotifiTimeDto();
            CalendarNotifiTimeDto calendarNotifiTimeDtoThree = new CalendarNotifiTimeDto();
            
            calendarNotifiTimeDtoOne.Id = SequentialGuidGenerator.Instance.NewGuid();
            calendarNotifiTimeDtoOne.Name = "Test calendar one";
            walletCalendarService.AddCalendarNotifiTime(calendarNotifiTimeDtoOne);
            
            calendarNotifiTimeDtoTwo.Id = SequentialGuidGenerator.Instance.NewGuid();
            calendarNotifiTimeDtoTwo.Name = "Test calendar another";
            walletCalendarService.AddCalendarNotifiTime(calendarNotifiTimeDtoTwo);
            
            calendarNotifiTimeDtoThree.Id = SequentialGuidGenerator.Instance.NewGuid();
            calendarNotifiTimeDtoThree.Name = "Test calendar another";
            walletCalendarService.AddCalendarNotifiTime(calendarNotifiTimeDtoThree);

            CalendarNotifiTimeService[] calendarNotifiTimeServiceFound = walletCalendarService.FindCalendarNotifiTimeByName(calendarNotifiTimeDtoTwo.Name);

            Assert.True(calendarNotifiTimeServiceFound.Length == 2);
        }
        
        [Fact]
        public void SortCalendarNotifiTimeListByCreationDate_3Calendars_CorrectOrder()
        {
            WalletCalendarService walletCalendarService = new WalletCalendarService();
            CalendarNotifiTimeDto calendarNotifiTimeDtoOne = new CalendarNotifiTimeDto();
            CalendarNotifiTimeDto calendarNotifiTimeDtoTwo = new CalendarNotifiTimeDto();
            CalendarNotifiTimeDto calendarNotifiTimeDtoThree = new CalendarNotifiTimeDto();
            
            calendarNotifiTimeDtoOne.Id = SequentialGuidGenerator.Instance.NewGuid();
            calendarNotifiTimeDtoOne.Name = "Test calendar first";
            calendarNotifiTimeDtoOne.CreationDate = new DateTime(2010, 10, 13);
            walletCalendarService.AddCalendarNotifiTime(calendarNotifiTimeDtoOne);
            
            calendarNotifiTimeDtoTwo.Id = SequentialGuidGenerator.Instance.NewGuid();
            calendarNotifiTimeDtoTwo.Name = "Test calendar second";
            calendarNotifiTimeDtoTwo.CreationDate = new DateTime(2010, 10, 11);
            walletCalendarService.AddCalendarNotifiTime(calendarNotifiTimeDtoTwo);
            
            calendarNotifiTimeDtoThree.Id = SequentialGuidGenerator.Instance.NewGuid();
            calendarNotifiTimeDtoThree.Name = "Test calendar third";
            calendarNotifiTimeDtoThree.CreationDate = new DateTime(2010, 10, 12);
            walletCalendarService.AddCalendarNotifiTime(calendarNotifiTimeDtoThree);

            CalendarNotifiTimeService[] calendarNotifiTimeServiceFound = walletCalendarService.SortCalendarNotifiTimeListByCreationDate(true);

            Assert.True(
                calendarNotifiTimeServiceFound[0].GetDto().Id == calendarNotifiTimeDtoTwo.Id &&
                calendarNotifiTimeServiceFound[1].GetDto().Id == calendarNotifiTimeDtoThree.Id
            );
        }
        
        [Fact]
        public void SortCalendarNotifiTimeListByName_3Calendars_CorrectOrder()
        {
            WalletCalendarService walletCalendarService = new WalletCalendarService();
            CalendarNotifiTimeDto calendarNotifiTimeDtoOne = new CalendarNotifiTimeDto();
            CalendarNotifiTimeDto calendarNotifiTimeDtoTwo = new CalendarNotifiTimeDto();
            CalendarNotifiTimeDto calendarNotifiTimeDtoThree = new CalendarNotifiTimeDto();
            
            calendarNotifiTimeDtoOne.Id = SequentialGuidGenerator.Instance.NewGuid();
            calendarNotifiTimeDtoOne.Name = "Test calendar b";
            walletCalendarService.AddCalendarNotifiTime(calendarNotifiTimeDtoOne);
            
            calendarNotifiTimeDtoTwo.Id = SequentialGuidGenerator.Instance.NewGuid();
            calendarNotifiTimeDtoTwo.Name = "Test calendar a";
            walletCalendarService.AddCalendarNotifiTime(calendarNotifiTimeDtoTwo);
            
            calendarNotifiTimeDtoThree.Id = SequentialGuidGenerator.Instance.NewGuid();
            calendarNotifiTimeDtoThree.Name = "Test calendar c";
            walletCalendarService.AddCalendarNotifiTime(calendarNotifiTimeDtoThree);

            CalendarNotifiTimeService[] calendarNotifiTimeServiceFound = walletCalendarService.SortCalendarNotifiTimeListByName(true);

            Assert.True(
                calendarNotifiTimeServiceFound[0].GetDto().Id == calendarNotifiTimeDtoTwo.Id &&
                calendarNotifiTimeServiceFound[1].GetDto().Id == calendarNotifiTimeDtoOne.Id
            );
        }
        
        [Fact]
        public void UpdateCalendarsOfUser_2CalendarsAndUpdateWithChanges_GetAllWithChanges()
        {
            WalletCalendarService walletCalendarService = new WalletCalendarService();
            CalendarNotifiTimeDto calendarNotifiTimeDtoOne = new CalendarNotifiTimeDto();
            CalendarNotifiTimeDto calendarNotifiTimeDtoTwo = new CalendarNotifiTimeDto();
            string FIRSTCALENDARNAMEUPDATED = "updated Test calendar first";
            string SECONDCALENDARNAMEUPDATED = "updated Test calendar second";
            
            // Adding
            calendarNotifiTimeDtoOne.Id = SequentialGuidGenerator.Instance.NewGuid();
            calendarNotifiTimeDtoOne.Name = "Test calendar first";
            walletCalendarService.AddCalendarNotifiTime(calendarNotifiTimeDtoOne);
            
            calendarNotifiTimeDtoTwo.Id = SequentialGuidGenerator.Instance.NewGuid();
            calendarNotifiTimeDtoTwo.Name = "Test calendar second";
            walletCalendarService.AddCalendarNotifiTime(calendarNotifiTimeDtoTwo);
            
            // Update objects
            calendarNotifiTimeDtoOne.Name = FIRSTCALENDARNAMEUPDATED;
            calendarNotifiTimeDtoTwo.Name = SECONDCALENDARNAMEUPDATED;
            
            walletCalendarService.UpdateCalendarsOfUser(
                new []{ calendarNotifiTimeDtoOne, calendarNotifiTimeDtoTwo }
            );
            CalendarNotifiTimeService[] calendarNotifiTimeServiceFound = walletCalendarService.GetCalendarNotifiTimeArray();

            Assert.True(
                calendarNotifiTimeServiceFound[0].GetDto().Name == FIRSTCALENDARNAMEUPDATED &&
                calendarNotifiTimeServiceFound[1].GetDto().Name == SECONDCALENDARNAMEUPDATED
            );
        }
    }
}