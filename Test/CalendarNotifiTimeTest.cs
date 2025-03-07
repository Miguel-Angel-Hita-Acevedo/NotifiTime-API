using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotifiTime_API.domain.entities;
using Xunit;

namespace NotifiTime_API.Test
{
    public class CalendarNotifiTimeTest
    {
        [Fact]
        public void calendarCreationByName()
        {
            string name = "Test calendar";
            CalendarNotifiTime testCalendar = new CalendarNotifiTime(name);
            Assert.Equal(testCalendar.getName(), name);
        }
    }
}