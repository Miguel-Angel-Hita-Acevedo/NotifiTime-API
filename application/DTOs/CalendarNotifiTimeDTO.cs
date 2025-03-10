using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotifiTime_API.domain.entities;

namespace NotifiTime_API.application.DTOs
{
    public class CalendarNotifiTimeDTO
    {
        
        private Guid id;
        private string name;
        private Dictionary<Guid, CalendarEvent> calendarEventDictionary;

        public Guid Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public Dictionary<Guid, CalendarEvent> CalendarEventDictionary { get => calendarEventDictionary; set => calendarEventDictionary = value; }
    }
}