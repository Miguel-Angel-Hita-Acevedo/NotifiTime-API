using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotifiTime_API.infrastructure.entities
{
    public class CalendarNotifiTimeEntity
    {
        
        private Guid id;
        private string name;
        private Dictionary<Guid, EventCalendarEntity> eventCalendarDictionary;
        private DateTime creationDate;

        public Guid Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public Dictionary<Guid, EventCalendarEntity> EventCalendarDictionary { get => eventCalendarDictionary; set => eventCalendarDictionary = value; }
        public DateTime CreationDate { get => creationDate; set => creationDate = value; }
    }
}