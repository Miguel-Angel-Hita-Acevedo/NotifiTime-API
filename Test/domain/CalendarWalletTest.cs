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
    public class WalletCalendarTest
    {
        [Fact]
        public void addCalendarNotifiTimeToEmptyDictionaryReturnTrue()
        {
            WalletCalendar walletCalendar = new WalletCalendar();
            CalendarNotifiTime calendarNotifiTime = new CalendarNotifiTime("test calendar");
            
            bool created = walletCalendar.addCalendarNotifiTime(calendarNotifiTime) != null;
            
            Assert.True(created);
        }
        
        [Fact]
        public void addCalendarNotifiTimeToDictionaryWithExistingGuidReturnFalse()
        {
            WalletCalendar walletCalendar = new WalletCalendar();
            CalendarNotifiTime firstCalendarNotifiTime = new CalendarNotifiTime("first test calendar");
            CalendarNotifiTime secondCalendarNotifiTime = new CalendarNotifiTime(
                firstCalendarNotifiTime.getId(), 
                "second test calendar",
                (new Dictionary<Guid, EventCalendar>()),
                firstCalendarNotifiTime.getCreationDate()
            );
            
            walletCalendar.addCalendarNotifiTime(firstCalendarNotifiTime);
            bool created = walletCalendar.addCalendarNotifiTime(secondCalendarNotifiTime) != null;
            
            Assert.False(created);
        }
        
        [Fact]
        public void addCalendarNotifiTimeToDictionaryWithOneDifferentElementReturnTrue()
        {
            WalletCalendar walletCalendar = new WalletCalendar();
            CalendarNotifiTime firstCalendarNotifiTime = new CalendarNotifiTime("first test calendar");
            CalendarNotifiTime secondCalendarNotifiTime = new CalendarNotifiTime("second test calendar");
            
            walletCalendar.addCalendarNotifiTime(firstCalendarNotifiTime);
            bool created = walletCalendar.addCalendarNotifiTime(secondCalendarNotifiTime) != null;
            
            Assert.True(created);
        }
        
        [Fact]
        public void deleteCalendarNotifiTimeByIdThatExistsReturnTrue()
        {
            WalletCalendar walletCalendar = new WalletCalendar();
            CalendarNotifiTime calendarNotifiTime = new CalendarNotifiTime("test calendar");
            
            walletCalendar.addCalendarNotifiTime(calendarNotifiTime);
            bool deleted = walletCalendar.deleteCalendarNotifiTimeById(calendarNotifiTime.getId()) == null;
            
            Assert.True(deleted);
        }
        
        [Fact]
        public void deleteCalendarNotifiTimeByIdThatDoesntExistsReturnFalse()
        {
            WalletCalendar walletCalendar = new WalletCalendar();
            CalendarNotifiTime firstCalendarNotifiTime = new CalendarNotifiTime("first test calendar");
            CalendarNotifiTime secondCalendarNotifiTime = new CalendarNotifiTime("second test calendar");
            
            walletCalendar.addCalendarNotifiTime(firstCalendarNotifiTime);
            
            bool deleted = walletCalendar.deleteCalendarNotifiTimeById(secondCalendarNotifiTime.getId()) == null;
            
            Assert.False(deleted);
        }
        
        [Fact]
        public void findEventsCalendarByIdOn3CalendarsThatExists()
        {
            WalletCalendar walletCalendar = new WalletCalendar();
            CalendarNotifiTime firstCalendarNotifiTime = new CalendarNotifiTime("first test calendar");
            CalendarNotifiTime secondCalendarNotifiTime = new CalendarNotifiTime("second test calendar");
            CalendarNotifiTime thirdCalendarNotifiTime = new CalendarNotifiTime("third test calendar");
            
            firstCalendarNotifiTime.createEvent(DateTime.Now, "first event", TimeIteration.None);
            firstCalendarNotifiTime.createEvent(DateTime.Now, "second event", TimeIteration.None);
            
            walletCalendar.addCalendarNotifiTime(firstCalendarNotifiTime);
            walletCalendar.addCalendarNotifiTime(secondCalendarNotifiTime);
            walletCalendar.addCalendarNotifiTime(thirdCalendarNotifiTime);
            
            EventCalendar eventCalendarToFind = thirdCalendarNotifiTime.createEvent(DateTime.Now, "third event", TimeIteration.None);
            
            EventCalendar found = walletCalendar.findEventCalendarByIdOnAllCalendars(eventCalendarToFind.getId());
            
            if(found != null)
            {
                Assert.Equivalent(found, eventCalendarToFind.getId());
            }else
            {
                Assert.Fail();
            }
        }
        
        [Fact]
        public void findEventsCalendarByIdOn3CalendarsThatDoesntExists()
        {
            
            WalletCalendar walletCalendar = new WalletCalendar();
            CalendarNotifiTime firstCalendarNotifiTime = new CalendarNotifiTime("first test calendar");
            CalendarNotifiTime secondCalendarNotifiTime = new CalendarNotifiTime("second test calendar");
            CalendarNotifiTime thirdCalendarNotifiTime = new CalendarNotifiTime("third test calendar");
            
            firstCalendarNotifiTime.createEvent(DateTime.Now, "event", TimeIteration.None);
            
            walletCalendar.addCalendarNotifiTime(firstCalendarNotifiTime);
            walletCalendar.addCalendarNotifiTime(secondCalendarNotifiTime);
            walletCalendar.addCalendarNotifiTime(thirdCalendarNotifiTime);
            
            EventCalendar eventCalendarToFind = new EventCalendar();
            
            EventCalendar found = walletCalendar.findEventCalendarByIdOnAllCalendars(eventCalendarToFind.getId());
            
            Assert.Null(found);
        }
        
        [Fact]
        public void findCalendarNotifiTimeByIdThatExistsReturnElement()
        {
            WalletCalendar walletCalendar = new WalletCalendar();
            CalendarNotifiTime firstCalendarNotifiTime = new CalendarNotifiTime("first test calendar");
            CalendarNotifiTime secondCalendarNotifiTime = new CalendarNotifiTime("second test calendar");
            CalendarNotifiTime thirdCalendarNotifiTime = new CalendarNotifiTime("third test calendar");
            
            walletCalendar.addCalendarNotifiTime(firstCalendarNotifiTime);
            walletCalendar.addCalendarNotifiTime(secondCalendarNotifiTime);
            walletCalendar.addCalendarNotifiTime(thirdCalendarNotifiTime);
            
            CalendarNotifiTime calendarFound = walletCalendar.findCalendarNotifiTimeById(secondCalendarNotifiTime.getId());
            
            Assert.Equivalent(calendarFound, secondCalendarNotifiTime);
        }
        
        [Fact]
        public void findCalendarNotifiTimeByIdThatDoesntExistsReturnNull()
        {
            WalletCalendar walletCalendar = new WalletCalendar();
            CalendarNotifiTime firstCalendarNotifiTime = new CalendarNotifiTime("first test calendar");
            CalendarNotifiTime secondCalendarNotifiTime = new CalendarNotifiTime("second test calendar");
            CalendarNotifiTime thirdCalendarNotifiTime = new CalendarNotifiTime("third test calendar");
            
            walletCalendar.addCalendarNotifiTime(firstCalendarNotifiTime);
            walletCalendar.addCalendarNotifiTime(secondCalendarNotifiTime);
            
            CalendarNotifiTime calendarFound = walletCalendar.findCalendarNotifiTimeById(thirdCalendarNotifiTime.getId());
            
            Assert.Null(calendarFound);
        }
        
        [Fact]
        public void findCalendarNotifiTimeByNameThatExistsReturnElement()
        {
            WalletCalendar walletCalendar = new WalletCalendar();
            CalendarNotifiTime firstCalendarNotifiTime = new CalendarNotifiTime("first test calendar");
            CalendarNotifiTime secondCalendarNotifiTime = new CalendarNotifiTime("second test calendar");
            CalendarNotifiTime thirdCalendarNotifiTime = new CalendarNotifiTime("third test calendar");
            
            walletCalendar.addCalendarNotifiTime(firstCalendarNotifiTime);
            walletCalendar.addCalendarNotifiTime(secondCalendarNotifiTime);
            walletCalendar.addCalendarNotifiTime(thirdCalendarNotifiTime);
            
            CalendarNotifiTime[] calendarArrayFound = walletCalendar.findCalendarNotifiTimeByName(secondCalendarNotifiTime.getName());
            
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
            WalletCalendar walletCalendar = new WalletCalendar();
            CalendarNotifiTime firstCalendarNotifiTime = new CalendarNotifiTime("first test calendar");
            CalendarNotifiTime secondCalendarNotifiTime = new CalendarNotifiTime("second test calendar");
            CalendarNotifiTime thirdCalendarNotifiTime = new CalendarNotifiTime("third test calendar");
            
            walletCalendar.addCalendarNotifiTime(firstCalendarNotifiTime);
            walletCalendar.addCalendarNotifiTime(thirdCalendarNotifiTime);
            
            CalendarNotifiTime[] calendarArrayFound = walletCalendar.findCalendarNotifiTimeByName(secondCalendarNotifiTime.getName());
            
            Assert.Empty(calendarArrayFound);
        }

        [Fact]
        public void sortCalendarNotifiTimeByCreationDateAscending()
        {
            WalletCalendar walletCalendar = new WalletCalendar();
            CalendarNotifiTime firstCalendarNotifiTime = new CalendarNotifiTime(
                Guid.NewGuid(), "first test calendar", new Dictionary<Guid, EventCalendar>(),
                new DateTime(2004, 1, 1));
            CalendarNotifiTime secondCalendarNotifiTime = new CalendarNotifiTime(
                Guid.NewGuid(), "second test calendar", new Dictionary<Guid, EventCalendar>(),
                new DateTime(2006, 2, 1));
            CalendarNotifiTime thirdCalendarNotifiTime = new CalendarNotifiTime(
                Guid.NewGuid(), "third test calendar", new Dictionary<Guid, EventCalendar>(),
                new DateTime(2000, 2, 2));
            
            walletCalendar.addCalendarNotifiTime(firstCalendarNotifiTime);
            walletCalendar.addCalendarNotifiTime(secondCalendarNotifiTime);
            walletCalendar.addCalendarNotifiTime(thirdCalendarNotifiTime);
            
            CalendarNotifiTime[] calendarArrayFound = walletCalendar.sortCalendarNotifiTimeListByCreationDate(true);
            
            if(calendarArrayFound != null && calendarArrayFound.Length > 0)
            {
                Assert.Equivalent(thirdCalendarNotifiTime.getCreationDate(), calendarArrayFound[0].getCreationDate());
            }else
            {
                Assert.Fail();
            }
        }
        
        [Fact]
        public void sortCalendarNotifiTimeByCreationDateDescending()
        {
            WalletCalendar walletCalendar = new WalletCalendar();
            CalendarNotifiTime firstCalendarNotifiTime = new CalendarNotifiTime(
                Guid.NewGuid(), "first test calendar", new Dictionary<Guid, EventCalendar>(),
                new DateTime(2004, 1, 1));
            CalendarNotifiTime secondCalendarNotifiTime = new CalendarNotifiTime(
                Guid.NewGuid(), "second test calendar", new Dictionary<Guid, EventCalendar>(),
                new DateTime(2006, 2, 1));
            CalendarNotifiTime thirdCalendarNotifiTime = new CalendarNotifiTime(
                Guid.NewGuid(), "third test calendar", new Dictionary<Guid, EventCalendar>(),
                new DateTime(2000, 2, 2));
            
            walletCalendar.addCalendarNotifiTime(firstCalendarNotifiTime);
            walletCalendar.addCalendarNotifiTime(secondCalendarNotifiTime);
            walletCalendar.addCalendarNotifiTime(thirdCalendarNotifiTime);
            
            CalendarNotifiTime[] calendarArrayFound = walletCalendar.sortCalendarNotifiTimeListByCreationDate(false);
            
            if(calendarArrayFound != null && calendarArrayFound.Length > 0)
            {
                Assert.Equivalent(calendarArrayFound[0].getCreationDate(), secondCalendarNotifiTime.getCreationDate());
            }else
            {
                Assert.Fail();
            }
        }
        
        [Fact]
        public void sortCalendarNotifiTimeByNameAscending()
        {
            WalletCalendar walletCalendar = new WalletCalendar();
            CalendarNotifiTime firstCalendarNotifiTime = new CalendarNotifiTime(
                Guid.NewGuid(), "first test calendar", new Dictionary<Guid, EventCalendar>(),
                new DateTime(2004, 1, 1));
            CalendarNotifiTime secondCalendarNotifiTime = new CalendarNotifiTime(
                Guid.NewGuid(), "second test calendar", new Dictionary<Guid, EventCalendar>(),
                new DateTime(2006, 2, 1));
            CalendarNotifiTime thirdCalendarNotifiTime = new CalendarNotifiTime(
                Guid.NewGuid(), "third test calendar", new Dictionary<Guid, EventCalendar>(),
                new DateTime(2000, 2, 2));
            
            walletCalendar.addCalendarNotifiTime(secondCalendarNotifiTime);
            walletCalendar.addCalendarNotifiTime(thirdCalendarNotifiTime);
            walletCalendar.addCalendarNotifiTime(firstCalendarNotifiTime);
            
            CalendarNotifiTime[] calendarArrayFound = walletCalendar.sortCalendarNotifiTimeListByName(true);
            
            if(calendarArrayFound != null && calendarArrayFound.Length > 0)
            {
                Assert.Equivalent(calendarArrayFound[0].getName(), firstCalendarNotifiTime.getName());
            }else
            {
                Assert.Fail();
            }
        }
        
        [Fact]
        public void sortCalendarNotifiTimeByNameDescending()
        {
            WalletCalendar walletCalendar = new WalletCalendar();
            CalendarNotifiTime firstCalendarNotifiTime = new CalendarNotifiTime(
                Guid.NewGuid(), "first test calendar", new Dictionary<Guid, EventCalendar>(),
                new DateTime(2004, 1, 1));
            CalendarNotifiTime secondCalendarNotifiTime = new CalendarNotifiTime(
                Guid.NewGuid(), "second test calendar", new Dictionary<Guid, EventCalendar>(),
                new DateTime(2006, 2, 1));
            CalendarNotifiTime thirdCalendarNotifiTime = new CalendarNotifiTime(
                Guid.NewGuid(), "third test calendar", new Dictionary<Guid, EventCalendar>(),
                new DateTime(2000, 2, 2));
            
            walletCalendar.addCalendarNotifiTime(firstCalendarNotifiTime);
            walletCalendar.addCalendarNotifiTime(secondCalendarNotifiTime);
            walletCalendar.addCalendarNotifiTime(thirdCalendarNotifiTime);
            
            CalendarNotifiTime[] calendarArrayFound = walletCalendar.sortCalendarNotifiTimeListByName(false);
            
            if(calendarArrayFound != null && calendarArrayFound.Length > 0)
            {
                Assert.Equivalent(calendarArrayFound[0].getName(), thirdCalendarNotifiTime.getName());
            }else
            {
                Assert.Fail();
            }
        }
    }
}