using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NotifiTime_API.application.Dtos;
using NotifiTime_API.infrastructure.configuration;

namespace NotifiTime_API.infrastructure.adapters
{
    public class CalendarJsonAdapter
    {
        private WalletConfiguration walletConfiguration;
        public CalendarJsonAdapter()
        {
            walletConfiguration = WalletConfiguration.GetWalletConfiguration();
        }
        
        public string GetAllCalendars()
        {
            CalendarNotifiTimeDto[] calendarNotifiTimeDtoArray = walletConfiguration.GetAllCalendars();
            string strobj = JsonConvert.SerializeObject(calendarNotifiTimeDtoArray, Formatting.Indented);
            return strobj;
        }
        
        public string GetEventsInCalendar(Guid calendarId)
        {
            EventCalendarDto[] eventsOfCalendar = walletConfiguration.GetEventsInCalendar(calendarId);
            string strobj = JsonConvert.SerializeObject(eventsOfCalendar, Formatting.Indented);
            return strobj;
        }
        
        public string UpdateCalendarName(Guid calendarId, string newName)
        {
            CalendarNotifiTimeDto eventsOfCalendar = walletConfiguration.UpdateCalendarName(calendarId, newName);
            string strobj = JsonConvert.SerializeObject(eventsOfCalendar, Formatting.Indented);
            return strobj;
        }
        
        public string UpdateEvent(Guid calendarId, EventCalendarDto eventCalendarDto)
        {
            EventCalendarDto eventCalendarDtoEdited = walletConfiguration.UpdateEventCalendar(calendarId, eventCalendarDto);
            string strobj = JsonConvert.SerializeObject(eventCalendarDtoEdited, Formatting.Indented);
            return strobj;
        }
    }
}