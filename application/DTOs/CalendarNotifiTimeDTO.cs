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
        private Dictionary<Guid, EventCalendarDTO> eventCalendarDictionary = new Dictionary<Guid, EventCalendarDTO>();
        private DateTime creationDate;

        public Guid Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public Dictionary<Guid, EventCalendarDTO> EventCalendarDictionary { get => eventCalendarDictionary; set => eventCalendarDictionary = value; }
        public DateTime CreationDate { get => creationDate; set => creationDate = value; }
    }
}