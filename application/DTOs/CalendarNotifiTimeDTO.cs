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
        private List<EventCalendarDTO> eventCalendarList = new List<EventCalendarDTO>();
        private DateTime creationDate;

        public Guid Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public List<EventCalendarDTO> EventCalendarList { get => eventCalendarList; set => eventCalendarList = value; }
        public DateTime CreationDate { get => creationDate; set => creationDate = value; }
    }
}