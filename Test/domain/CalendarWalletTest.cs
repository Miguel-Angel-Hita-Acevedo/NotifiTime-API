using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotifiTime_API.domain.entities;
using NotifiTime_API.domain.Enum;
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
            ICalendarWallet calendarWallet = new CalendarWallet();
            ICalendarNotifiTime firstCalendarNotifiTime = new CalendarNotifiTime("first test calendar");
            ICalendarNotifiTime secondCalendarNotifiTime = new CalendarNotifiTime("second test calendar");
            
            calendarWallet.addCalendarNotifiTime(firstCalendarNotifiTime);
            bool created = calendarWallet.addCalendarNotifiTime(secondCalendarNotifiTime);
            
            Assert.True(created);
        }
        
        [Fact]
        public void deleteCalendarNotifiTimeByIdThatExistsReturnTrue()
        {
            ICalendarWallet calendarWallet = new CalendarWallet();
            ICalendarNotifiTime calendarNotifiTime = new CalendarNotifiTime("test calendar");
            
            calendarWallet.addCalendarNotifiTime(calendarNotifiTime);
            bool deleted = calendarWallet.deleteCalendarNotifiTimeById(calendarNotifiTime.getId());
            
            Assert.True(deleted);
        }
        
        [Fact]
        public void deleteCalendarNotifiTimeByIdThatDoesntExistsReturnFalse()
        {
            ICalendarWallet calendarWallet = new CalendarWallet();
            ICalendarNotifiTime firstCalendarNotifiTime = new CalendarNotifiTime("first test calendar");
            ICalendarNotifiTime secondCalendarNotifiTime = new CalendarNotifiTime("second test calendar");
            
            calendarWallet.addCalendarNotifiTime(firstCalendarNotifiTime);
            
            bool deleted = calendarWallet.deleteCalendarNotifiTimeById(secondCalendarNotifiTime.getId());
            
            Assert.False(deleted);
        }
        
        [Fact]
        public void findCalendarEventsByIdOn3CalendarsThatExists()
        {
            ICalendarWallet calendarWallet = new CalendarWallet();
            ICalendarNotifiTime firstCalendarNotifiTime = new CalendarNotifiTime("first test calendar");
            ICalendarNotifiTime secondCalendarNotifiTime = new CalendarNotifiTime("second test calendar");
            ICalendarNotifiTime thirdCalendarNotifiTime = new CalendarNotifiTime("third test calendar");
            
            firstCalendarNotifiTime.createEvent(DateTime.Now, "first event", TimeIteration.None);
            firstCalendarNotifiTime.createEvent(DateTime.Now, "second event", TimeIteration.None);
            
            calendarWallet.addCalendarNotifiTime(firstCalendarNotifiTime);
            calendarWallet.addCalendarNotifiTime(secondCalendarNotifiTime);
            calendarWallet.addCalendarNotifiTime(thirdCalendarNotifiTime);
            
            ICalendarEvent calendarEventToFind = thirdCalendarNotifiTime.createEvent(DateTime.Now, "third event", TimeIteration.None);
            
            ICalendarEvent found = calendarWallet.findCalendarEventsByIdOnAllCalendars(calendarEventToFind.getId());
            
            if(found != null)
            {
                Assert.Equivalent(found, calendarEventToFind.getId());
            }else
            {
                Assert.Fail();
            }
        }
        
        [Fact]
        public void findCalendarEventsByIdOn3CalendarsThatDoesntExists()
        {
            
            ICalendarWallet calendarWallet = new CalendarWallet();
            ICalendarNotifiTime firstCalendarNotifiTime = new CalendarNotifiTime("first test calendar");
            ICalendarNotifiTime secondCalendarNotifiTime = new CalendarNotifiTime("second test calendar");
            ICalendarNotifiTime thirdCalendarNotifiTime = new CalendarNotifiTime("third test calendar");
            
            firstCalendarNotifiTime.createEvent(DateTime.Now, "event", TimeIteration.None);
            
            calendarWallet.addCalendarNotifiTime(firstCalendarNotifiTime);
            calendarWallet.addCalendarNotifiTime(secondCalendarNotifiTime);
            calendarWallet.addCalendarNotifiTime(thirdCalendarNotifiTime);
            
            ICalendarEvent calendarEventToFind = new CalendarEvent();
            
            ICalendarEvent found = calendarWallet.findCalendarEventsByIdOnAllCalendars(calendarEventToFind.getId());
            
            Assert.Null(found);
        }
        
        [Fact]
        public void findCalendarNotifiTimeByIdThatExistsReturnElement()
        {
            ICalendarWallet calendarWallet = new CalendarWallet();
            ICalendarNotifiTime firstCalendarNotifiTime = new CalendarNotifiTime("first test calendar");
            ICalendarNotifiTime secondCalendarNotifiTime = new CalendarNotifiTime("second test calendar");
            ICalendarNotifiTime thirdCalendarNotifiTime = new CalendarNotifiTime("third test calendar");
            
            calendarWallet.addCalendarNotifiTime(firstCalendarNotifiTime);
            calendarWallet.addCalendarNotifiTime(secondCalendarNotifiTime);
            calendarWallet.addCalendarNotifiTime(thirdCalendarNotifiTime);
            
            ICalendarNotifiTime calendarFound = calendarWallet.findCalendarNotifiTimeById(secondCalendarNotifiTime.getId());
            
            Assert.Equivalent(calendarFound, secondCalendarNotifiTime);
        }
        
        [Fact]
        public void findCalendarNotifiTimeByIdThatDoesntExistsReturnNull()
        {
            ICalendarWallet calendarWallet = new CalendarWallet();
            ICalendarNotifiTime firstCalendarNotifiTime = new CalendarNotifiTime("first test calendar");
            ICalendarNotifiTime secondCalendarNotifiTime = new CalendarNotifiTime("second test calendar");
            ICalendarNotifiTime thirdCalendarNotifiTime = new CalendarNotifiTime("third test calendar");
            
            calendarWallet.addCalendarNotifiTime(firstCalendarNotifiTime);
            calendarWallet.addCalendarNotifiTime(secondCalendarNotifiTime);
            
            ICalendarNotifiTime calendarFound = calendarWallet.findCalendarNotifiTimeById(thirdCalendarNotifiTime.getId());
            
            Assert.Null(calendarFound);
        }
        
        [Fact]
        public void findCalendarNotifiTimeByNameThatExistsReturnElement()
        {
            ICalendarWallet calendarWallet = new CalendarWallet();
            ICalendarNotifiTime firstCalendarNotifiTime = new CalendarNotifiTime("first test calendar");
            ICalendarNotifiTime secondCalendarNotifiTime = new CalendarNotifiTime("second test calendar");
            ICalendarNotifiTime thirdCalendarNotifiTime = new CalendarNotifiTime("third test calendar");
            
            calendarWallet.addCalendarNotifiTime(firstCalendarNotifiTime);
            calendarWallet.addCalendarNotifiTime(secondCalendarNotifiTime);
            calendarWallet.addCalendarNotifiTime(thirdCalendarNotifiTime);
            
            ICalendarNotifiTime[] calendarArrayFound = calendarWallet.findCalendarNotifiTimeByName(secondCalendarNotifiTime.getName());
            
            if(calendarArrayFound != null && calendarArrayFound.Length > 0)
            {
                Assert.Equivalent(calendarArrayFound[0], secondCalendarNotifiTime);
            }else
            {
                Assert.Fail();
            }
        }
        
        [Fact]
        public void findCalendarNotifiTimeByNameThatDoesntExistsReturnNull()
        {
            ICalendarWallet calendarWallet = new CalendarWallet();
            ICalendarNotifiTime firstCalendarNotifiTime = new CalendarNotifiTime("first test calendar");
            ICalendarNotifiTime secondCalendarNotifiTime = new CalendarNotifiTime("second test calendar");
            ICalendarNotifiTime thirdCalendarNotifiTime = new CalendarNotifiTime("third test calendar");
            
            calendarWallet.addCalendarNotifiTime(firstCalendarNotifiTime);
            calendarWallet.addCalendarNotifiTime(thirdCalendarNotifiTime);
            
            ICalendarNotifiTime[] calendarArrayFound = calendarWallet.findCalendarNotifiTimeByName(secondCalendarNotifiTime.getName());
            
            Assert.Empty(calendarArrayFound);
        }

        [Fact]
        public void sortCalendarNotifiTimeByCreationDateAscending()
        {
        /*
            ICalendarWallet calendarWallet = new CalendarWallet();
            ICalendarNotifiTime firstCalendarNotifiTime = new CalendarNotifiTime(
                new Guid(), "first test calendar", new Dictionary<Guid, CalendarEvent>(),
                new DateTime(2004, 1, 1));
            ICalendarNotifiTime secondCalendarNotifiTime = new CalendarNotifiTime(
                new Guid(), "second test calendar", new Dictionary<Guid, CalendarEvent>(),
                new DateTime(2006, 2, 1));
            ICalendarNotifiTime thirdCalendarNotifiTime = new CalendarNotifiTime(
                new Guid(), "third test calendar", new Dictionary<Guid, CalendarEvent>(),
                new DateTime(2000, 2, 2));
            
            calendarWallet.addCalendarNotifiTime(firstCalendarNotifiTime);
            calendarWallet.addCalendarNotifiTime(secondCalendarNotifiTime);
            calendarWallet.addCalendarNotifiTime(thirdCalendarNotifiTime);
            
            ICalendarNotifiTime[] calendarArrayFound = calendarWallet.sortCalendarNotifiTimeListByCreationDate(true);
            
            if(calendarArrayFound != null && calendarArrayFound.Length > 0)
            {
                Assert.Equivalent(calendarArrayFound[0].getCreationDate(), secondCalendarNotifiTime.getCreationDate());
            }else
            {
                Assert.Fail();
            }
            */
        }
        
        [Fact]
        public void sortCalendarNotifiTimeByCreationDateDescending()
        {
        /*
            ICalendarWallet calendarWallet = new CalendarWallet();
            ICalendarNotifiTime firstCalendarNotifiTime = new CalendarNotifiTime(
                new Guid(), "first test calendar", new Dictionary<Guid, CalendarEvent>(),
                new DateTime(2004, 1, 1));
            ICalendarNotifiTime secondCalendarNotifiTime = new CalendarNotifiTime(
                new Guid(), "second test calendar", new Dictionary<Guid, CalendarEvent>(),
                new DateTime(2006, 2, 1));
            ICalendarNotifiTime thirdCalendarNotifiTime = new CalendarNotifiTime(
                new Guid(), "third test calendar", new Dictionary<Guid, CalendarEvent>(),
                new DateTime(2000, 2, 2));
            
            calendarWallet.addCalendarNotifiTime(firstCalendarNotifiTime);
            calendarWallet.addCalendarNotifiTime(secondCalendarNotifiTime);
            calendarWallet.addCalendarNotifiTime(thirdCalendarNotifiTime);
            
            ICalendarNotifiTime[] calendarArrayFound = calendarWallet.sortCalendarNotifiTimeListByCreationDate(false);
            
            if(calendarArrayFound != null && calendarArrayFound.Length > 0)
            {
                Assert.Equivalent(calendarArrayFound[0].getCreationDate(), thirdCalendarNotifiTime.getCreationDate());
            }else
            {
                Assert.Fail();
            }*/
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