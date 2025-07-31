using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NotifiTime_API.application.DTOs;
using NotifiTime_API.infrastructure.configuration;

namespace NotifiTime_API.infrastructure.adapters
{
    public class CalendarJsonAdapter
    {
        private WalletConfiguration walletConfiguration;
        public CalendarJsonAdapter()
        {
            walletConfiguration = new WalletConfiguration();
        }
        
        public string GetAllCalendars()
        {
            CalendarNotifiTimeDTO[] calendarNotifiTimeDtoArray = walletConfiguration.GetAllCalendars();
            string strobj = JsonConvert.SerializeObject(calendarNotifiTimeDtoArray, Formatting.Indented);
            return strobj;
        }
        
        public string GetEventsInCalendar(Guid calendarId)
        {
            EventCalendarDTO[] eventsOfCalendar = walletConfiguration.GetEventsInCalendar(calendarId);
            string strobj = JsonConvert.SerializeObject(eventsOfCalendar, Formatting.Indented);
            return strobj;
        }
        
        public string UpdateCalendarName(Guid calendarId, string newName)
        {
            CalendarNotifiTimeDTO eventsOfCalendar = walletConfiguration.UpdateCalendarName(calendarId, newName);
            string strobj = JsonConvert.SerializeObject(eventsOfCalendar, Formatting.Indented);
            return strobj;
        }
    }
}