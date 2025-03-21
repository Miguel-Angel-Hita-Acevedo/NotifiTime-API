using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotifiTime_API.domain.entities;
using NotifiTime_API.domain.Interfaces;
using Xunit;

namespace NotifiTime_API.Test.domain
{
    public class CalendarWalletTest
    {
        [Fact]
        public void addCalendarNotifiTimeToEmptyDictionaryReturnTrue()
        {
            ICalendarWallet calendarWallet = new CalendarWallet();
            ICalendarNotifiTime calendarNotifiTime = new CalendarNotifiTime("test calendar");
            
            bool created = calendarWallet.addCalendarNotifiTime(calendarNotifiTime);
            
            Assert.True(created);
        }
        
        [Fact]
        public void addCalendarNotifiTimeToDictionaryWithExistingGuidReturnFalse()
        {
            ICalendarWallet calendarWallet = new CalendarWallet();
            ICalendarNotifiTime firstCalendarNotifiTime = new CalendarNotifiTime("first test calendar");
            ICalendarNotifiTime secondCalendarNotifiTime = new CalendarNotifiTime(
                firstCalendarNotifiTime.getId(), 
                "second test calendar",
                (new Dictionary<Guid, CalendarEvent>()),
                firstCalendarNotifiTime.getCreationDate()
            );
            
            calendarWallet.addCalendarNotifiTime(firstCalendarNotifiTime);
            bool created = calendarWallet.addCalendarNotifiTime(secondCalendarNotifiTime);
            
            Assert.False(created);
        }
        
        [Fact]
        public void addCalendarNotifiTimeToDictionaryWithOneDifferentElementReturnTrue()
        {
            
        }
        
        [Fact]
        public void deleteCalendarNotifiTimeByIdThatExistsReturnTrue()
        {
            
        }
        
        [Fact]
        public void deleteCalendarNotifiTimeByIdThatDoesntExistsReturnFalse()
        {
            
        }
        
        [Fact]
        public void findCalendarEventsByIdOn3CalendarsThatExists()
        {
            
        }
        
        [Fact]
        public void findCalendarEventsByIdOn3CalendarsThatDoesntExists()
        {
            
        }
        
        [Fact]
        public void findCalendarEventsByIdOn3CalendarsAndFound2EventsOnDifferentCalendars()
        {
            
        }
        
        [Fact]
        public void findCalendarNotifiTimeByIdThatExistsReturnElement()
        {
            
        }
        
        [Fact]
        public void findCalendarNotifiTimeByIdThatDoesntExistsReturnNull()
        {
            
        }
        
        [Fact]
        public void findCalendarNotifiTimeByNameThatExistsReturnElement()
        {
            
        }
        
        [Fact]
        public void findCalendarNotifiTimeByNameThatDoesntExistsReturnNull()
        {
            
        }

        [Fact]
        public void sortCalendarNotifiTimeByCreationDateAscending()
        {
            
        }
        
        [Fact]
        public void sortCalendarNotifiTimeByCreationDateDescending()
        {
            
        }
        
        [Fact]
        public void sortCalendarNotifiTimeByNameAscending()
        {
            
        }
        
        [Fact]
        public void sortCalendarNotifiTimeByNameDescending()
        {
            
        }
    }
}