using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotifiTime_API.domain.entities;

namespace NotifiTime_API.application.Dtos
{
    public class CalendarNotifiTimeDto
    {
        
        private Guid id;
        private string name;
        private List<EventCalendarDto> eventCalendarList = new List<EventCalendarDto>();
        private DateTime creationDate;

        public Guid Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public List<EventCalendarDto> EventCalendarList { get => eventCalendarList; set => eventCalendarList = value; }
        public DateTime CreationDate { get => creationDate; set => creationDate = value; }
    }
}