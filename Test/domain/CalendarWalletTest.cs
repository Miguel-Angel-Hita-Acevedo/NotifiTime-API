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
        public void AddCalendarNotifiTimeToEmptyDictionaryReturnTrue()
        {
            WalletCalendar walletCalendar = new WalletCalendar();
            CalendarNotifiTime calendarNotifiTime = new CalendarNotifiTime("test calendar");
            
            bool created = walletCalendar.AddCalendarNotifiTime(calendarNotifiTime) != null;
            
            Assert.True(created);
        }
        
        [Fact]
        public void AddCalendarNotifiTimeToDictionaryWithExistingGuidReturnFalse()
        {
            WalletCalendar walletCalendar = new WalletCalendar();
            CalendarNotifiTime firstCalendarNotifiTime = new CalendarNotifiTime("first test calendar");
            CalendarNotifiTime secondCalendarNotifiTime = new CalendarNotifiTime(
                firstCalendarNotifiTime.GetId(), 
                "second test calendar",
                (new Dictionary<Guid, EventCalendar>()),
                firstCalendarNotifiTime.getCreationDate()
            );
            
            walletCalendar.AddCalendarNotifiTime(firstCalendarNotifiTime);
            bool created = walletCalendar.AddCalendarNotifiTime(secondCalendarNotifiTime) != null;
            
            Assert.False(created);
        }
        
        [Fact]
        public void AddCalendarNotifiTimeToDictionaryWithOneDifferentElementReturnTrue()
        {
            WalletCalendar walletCalendar = new WalletCalendar();
            CalendarNotifiTime firstCalendarNotifiTime = new CalendarNotifiTime("first test calendar");
            CalendarNotifiTime secondCalendarNotifiTime = new CalendarNotifiTime("second test calendar");
            
            walletCalendar.AddCalendarNotifiTime(firstCalendarNotifiTime);
            bool created = walletCalendar.AddCalendarNotifiTime(secondCalendarNotifiTime) != null;
            
            Assert.True(created);
        }
        
        [Fact]
        public void DeleteCalendarNotifiTimeByIdThatExistsReturnTrue()
        {
            WalletCalendar walletCalendar = new WalletCalendar();
            CalendarNotifiTime calendarNotifiTime = new CalendarNotifiTime("test calendar");
            
            walletCalendar.AddCalendarNotifiTime(calendarNotifiTime);
            bool deleted = walletCalendar.DeleteCalendarNotifiTimeById(calendarNotifiTime.GetId()) == null;
            
            Assert.True(deleted);
        }
        
        [Fact]
        public void DeleteCalendarNotifiTimeByIdThatDoesntExistsReturnFalse()
        {
            WalletCalendar walletCalendar = new WalletCalendar();
            CalendarNotifiTime firstCalendarNotifiTime = new CalendarNotifiTime("first test calendar");
            CalendarNotifiTime secondCalendarNotifiTime = new CalendarNotifiTime("second test calendar");
            
            walletCalendar.AddCalendarNotifiTime(firstCalendarNotifiTime);
            
            bool deleted = walletCalendar.DeleteCalendarNotifiTimeById(secondCalendarNotifiTime.GetId()) == null;
            
            Assert.False(deleted);
        }
        
        [Fact]
        public void findEventsCalendarByIdOn3CalendarsThatExists()
        {
            WalletCalendar walletCalendar = new WalletCalendar();
            CalendarNotifiTime firstCalendarNotifiTime = new CalendarNotifiTime("first test calendar");
            CalendarNotifiTime secondCalendarNotifiTime = new CalendarNotifiTime("second test calendar");
            CalendarNotifiTime thirdCalendarNotifiTime = new CalendarNotifiTime("third test calendar");
            
            firstCalendarNotifiTime.CreateEvent(DateTime.Now, "first event", TimeIteration.None);
            firstCalendarNotifiTime.CreateEvent(DateTime.Now, "second event", TimeIteration.None);
            
            walletCalendar.AddCalendarNotifiTime(firstCalendarNotifiTime);
            walletCalendar.AddCalendarNotifiTime(secondCalendarNotifiTime);
            walletCalendar.AddCalendarNotifiTime(thirdCalendarNotifiTime);
            
            EventCalendar eventCalendarToFind = thirdCalendarNotifiTime.CreateEvent(DateTime.Now, "third event", TimeIteration.None);
            
            EventCalendar found = walletCalendar.FindEventCalendarByIdOnAllCalendars(eventCalendarToFind.GetId());
            
            if(found != null)
            {
                Assert.Equivalent(found, eventCalendarToFind.GetId());
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
            
            firstCalendarNotifiTime.CreateEvent(DateTime.Now, "event", TimeIteration.None);
            
            walletCalendar.AddCalendarNotifiTime(firstCalendarNotifiTime);
            walletCalendar.AddCalendarNotifiTime(secondCalendarNotifiTime);
            walletCalendar.AddCalendarNotifiTime(thirdCalendarNotifiTime);
            
            EventCalendar eventCalendarToFind = new EventCalendar();
            
            EventCalendar found = walletCalendar.FindEventCalendarByIdOnAllCalendars(eventCalendarToFind.GetId());
            
            Assert.Null(found);
        }
        
        [Fact]
        public void FindCalendarNotifiTimeByIdThatExistsReturnElement()
        {
            WalletCalendar walletCalendar = new WalletCalendar();
            CalendarNotifiTime firstCalendarNotifiTime = new CalendarNotifiTime("first test calendar");
            CalendarNotifiTime secondCalendarNotifiTime = new CalendarNotifiTime("second test calendar");
            CalendarNotifiTime thirdCalendarNotifiTime = new CalendarNotifiTime("third test calendar");
            
            walletCalendar.AddCalendarNotifiTime(firstCalendarNotifiTime);
            walletCalendar.AddCalendarNotifiTime(secondCalendarNotifiTime);
            walletCalendar.AddCalendarNotifiTime(thirdCalendarNotifiTime);
            
            CalendarNotifiTime calendarFound = walletCalendar.FindCalendarNotifiTimeById(secondCalendarNotifiTime.GetId());
            
            Assert.Equivalent(calendarFound, secondCalendarNotifiTime);
        }
        
        [Fact]
        public void FindCalendarNotifiTimeByIdThatDoesntExistsReturnNull()
        {
            WalletCalendar walletCalendar = new WalletCalendar();
            CalendarNotifiTime firstCalendarNotifiTime = new CalendarNotifiTime("first test calendar");
            CalendarNotifiTime secondCalendarNotifiTime = new CalendarNotifiTime("second test calendar");
            CalendarNotifiTime thirdCalendarNotifiTime = new CalendarNotifiTime("third test calendar");
            
            walletCalendar.AddCalendarNotifiTime(firstCalendarNotifiTime);
            walletCalendar.AddCalendarNotifiTime(secondCalendarNotifiTime);
            
            CalendarNotifiTime calendarFound = walletCalendar.FindCalendarNotifiTimeById(thirdCalendarNotifiTime.GetId());
            
            Assert.Null(calendarFound);
        }
        
        [Fact]
        public void FindCalendarNotifiTimeByNameThatExistsReturnElement()
        {
            WalletCalendar walletCalendar = new WalletCalendar();
            CalendarNotifiTime firstCalendarNotifiTime = new CalendarNotifiTime("first test calendar");
            CalendarNotifiTime secondCalendarNotifiTime = new CalendarNotifiTime("second test calendar");
            CalendarNotifiTime thirdCalendarNotifiTime = new CalendarNotifiTime("third test calendar");
            
            walletCalendar.AddCalendarNotifiTime(firstCalendarNotifiTime);
            walletCalendar.AddCalendarNotifiTime(secondCalendarNotifiTime);
            walletCalendar.AddCalendarNotifiTime(thirdCalendarNotifiTime);
            
            CalendarNotifiTime[] calendarArrayFound = walletCalendar.FindCalendarNotifiTimeByName(secondCalendarNotifiTime.GetName());
            
            if(calendarArrayFound != null && calendarArrayFound.Length > 0)
            {
                Assert.Equivalent(calendarArrayFound[0], secondCalendarNotifiTime);
            }else
            {
                Assert.Fail();
            }
        }
        
        [Fact]
        public void FindCalendarNotifiTimeByNameThatDoesntExistsReturnNull()
        {
            WalletCalendar walletCalendar = new WalletCalendar();
            CalendarNotifiTime firstCalendarNotifiTime = new CalendarNotifiTime("first test calendar");
            CalendarNotifiTime secondCalendarNotifiTime = new CalendarNotifiTime("second test calendar");
            CalendarNotifiTime thirdCalendarNotifiTime = new CalendarNotifiTime("third test calendar");
            
            walletCalendar.AddCalendarNotifiTime(firstCalendarNotifiTime);
            walletCalendar.AddCalendarNotifiTime(thirdCalendarNotifiTime);
            
            CalendarNotifiTime[] calendarArrayFound = walletCalendar.FindCalendarNotifiTimeByName(secondCalendarNotifiTime.GetName());
            
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
            
            walletCalendar.AddCalendarNotifiTime(firstCalendarNotifiTime);
            walletCalendar.AddCalendarNotifiTime(secondCalendarNotifiTime);
            walletCalendar.AddCalendarNotifiTime(thirdCalendarNotifiTime);
            
            CalendarNotifiTime[] calendarArrayFound = walletCalendar.SortCalendarNotifiTimeListByCreationDate(true);
            
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
            
            walletCalendar.AddCalendarNotifiTime(firstCalendarNotifiTime);
            walletCalendar.AddCalendarNotifiTime(secondCalendarNotifiTime);
            walletCalendar.AddCalendarNotifiTime(thirdCalendarNotifiTime);
            
            CalendarNotifiTime[] calendarArrayFound = walletCalendar.SortCalendarNotifiTimeListByCreationDate(false);
            
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
            
            walletCalendar.AddCalendarNotifiTime(secondCalendarNotifiTime);
            walletCalendar.AddCalendarNotifiTime(thirdCalendarNotifiTime);
            walletCalendar.AddCalendarNotifiTime(firstCalendarNotifiTime);
            
            CalendarNotifiTime[] calendarArrayFound = walletCalendar.SortCalendarNotifiTimeListByName(true);
            
            if(calendarArrayFound != null && calendarArrayFound.Length > 0)
            {
                Assert.Equivalent(calendarArrayFound[0].GetName(), firstCalendarNotifiTime.GetName());
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
            
            walletCalendar.AddCalendarNotifiTime(firstCalendarNotifiTime);
            walletCalendar.AddCalendarNotifiTime(secondCalendarNotifiTime);
            walletCalendar.AddCalendarNotifiTime(thirdCalendarNotifiTime);
            
            CalendarNotifiTime[] calendarArrayFound = walletCalendar.SortCalendarNotifiTimeListByName(false);
            
            if(calendarArrayFound != null && calendarArrayFound.Length > 0)
            {
                Assert.Equivalent(calendarArrayFound[0].GetName(), thirdCalendarNotifiTime.GetName());
            }else
            {
                Assert.Fail();
            }
        }
    }
}