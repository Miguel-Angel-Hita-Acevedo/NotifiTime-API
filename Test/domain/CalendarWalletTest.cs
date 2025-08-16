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
        public void AddCalendarNotifiTime_EmptyDictionary_ReturnTrue()
        {
            WalletCalendar walletCalendar = new WalletCalendar();
            CalendarNotifiTime calendarNotifiTime = new CalendarNotifiTime("test calendar");
            
            bool created = walletCalendar.AddCalendarNotifiTime(calendarNotifiTime) != null;
            
            Assert.True(created);
        }
        
        [Fact]
        public void AddCalendarNotifiTime_DictionaryWithExistingGuid_ReturnFalse()
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
        public void AddCalendarNotifiTime_DictionaryWithOneDifferentElement_ReturnTrue()
        {
            WalletCalendar walletCalendar = new WalletCalendar();
            CalendarNotifiTime firstCalendarNotifiTime = new CalendarNotifiTime("first test calendar");
            CalendarNotifiTime secondCalendarNotifiTime = new CalendarNotifiTime("second test calendar");
            
            walletCalendar.AddCalendarNotifiTime(firstCalendarNotifiTime);
            bool created = walletCalendar.AddCalendarNotifiTime(secondCalendarNotifiTime) != null;
            
            Assert.True(created);
        }
        
        [Fact]
        public void DeleteCalendarNotifiTimeById_Exists_ReturnTrue()
        {
            WalletCalendar walletCalendar = new WalletCalendar();
            CalendarNotifiTime calendarNotifiTime = new CalendarNotifiTime("test calendar");
            
            walletCalendar.AddCalendarNotifiTime(calendarNotifiTime);
            bool deleted = walletCalendar.DeleteCalendarNotifiTimeById(calendarNotifiTime.GetId()) == null;
            
            Assert.True(deleted);
        }
        
        [Fact]
        public void DeleteCalendarNotifiTimeById_DoesntExists_ReturnFalse()
        {
            WalletCalendar walletCalendar = new WalletCalendar();
            CalendarNotifiTime firstCalendarNotifiTime = new CalendarNotifiTime("first test calendar");
            CalendarNotifiTime secondCalendarNotifiTime = new CalendarNotifiTime("second test calendar");
            
            walletCalendar.AddCalendarNotifiTime(firstCalendarNotifiTime);
            
            bool deleted = walletCalendar.DeleteCalendarNotifiTimeById(secondCalendarNotifiTime.GetId()) == null;
            
            Assert.False(deleted);
        }
        
        [Fact]
        public void findEventsCalendarById_3CalendarsThatExists_ReturnTrue()
        {
            WalletCalendar walletCalendar = new WalletCalendar();
            CalendarNotifiTime firstCalendarNotifiTime = new CalendarNotifiTime("first test calendar");
            CalendarNotifiTime secondCalendarNotifiTime = new CalendarNotifiTime("second test calendar");
            CalendarNotifiTime thirdCalendarNotifiTime = new CalendarNotifiTime("third test calendar");

            EventCalendar firstEvent = new EventCalendar();
            firstEvent.SetDateTime(DateTime.Now);
            firstEvent.SetName("first event");
            
            firstCalendarNotifiTime.AddEvent(firstEvent);
            
            EventCalendar secondEvent = new EventCalendar();
            secondEvent.SetDateTime(DateTime.Now);
            secondEvent.SetName("second event");
            
            firstCalendarNotifiTime.AddEvent(secondEvent);
            
            EventCalendar thirdEvent = new EventCalendar();
            thirdEvent.SetDateTime(DateTime.Now);
            thirdEvent.SetName("third event");
            
            walletCalendar.AddCalendarNotifiTime(firstCalendarNotifiTime);
            walletCalendar.AddCalendarNotifiTime(secondCalendarNotifiTime);
            walletCalendar.AddCalendarNotifiTime(thirdCalendarNotifiTime);
            
            EventCalendar eventCalendarToFind = thirdCalendarNotifiTime.AddEvent(thirdEvent);
            
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
        public void findEventsCalendarById_3CalendarsThatDoesntExists_ReturnFalse()
        {
            
            WalletCalendar walletCalendar = new WalletCalendar();
            CalendarNotifiTime firstCalendarNotifiTime = new CalendarNotifiTime("first test calendar");
            CalendarNotifiTime secondCalendarNotifiTime = new CalendarNotifiTime("second test calendar");
            CalendarNotifiTime thirdCalendarNotifiTime = new CalendarNotifiTime("third test calendar");
            
            EventCalendar firstEvent = new EventCalendar();
            firstEvent.SetDateTime(DateTime.Now);
            firstEvent.SetName("first event");
            
            firstCalendarNotifiTime.AddEvent(firstEvent);
            
            walletCalendar.AddCalendarNotifiTime(firstCalendarNotifiTime);
            walletCalendar.AddCalendarNotifiTime(secondCalendarNotifiTime);
            walletCalendar.AddCalendarNotifiTime(thirdCalendarNotifiTime);
            
            EventCalendar eventCalendarToFind = new EventCalendar();
            
            EventCalendar found = walletCalendar.FindEventCalendarByIdOnAllCalendars(eventCalendarToFind.GetId());
            
            Assert.Null(found);
        }
        
        [Fact]
        public void FindCalendarNotifiTimeById_ExistsOn3Elements_ReturnElement()
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
        public void FindCalendarNotifiTimeById_DoesntExists_ReturnNull()
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
        public void FindCalendarNotifiTimeByName_ExistsOn3Elements_ReturnElement()
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
        public void FindCalendarNotifiTimeByName_DoesntExists_ReturnNull()
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
        public void SortCalendarNotifiTimeByCreationDate_Ascending3Elements_FirstPositionRight()
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
        public void SortCalendarNotifiTimeByCreationDate_Descending3Elements_FirstPositionRight()
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
        public void SortCalendarNotifiTimeByName_Ascending3Elements_FirstPositionRight()
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
        public void SortCalendarNotifiTimeByName_Descending3Elements_FirstPositionRight()
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