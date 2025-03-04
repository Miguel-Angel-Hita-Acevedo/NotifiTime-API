using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotifiTime_API.domain.Enum;

namespace NotifiTime_API.domain.entities
{
    public interface ICalendarNotifiTime
    {
        // atributos
        public Guid getId();
        public string getName();
        public ICalendarNotifiTime setName(string newName);

        // conexión base de datos
        public void loadCalendarData(Guid id);

        // uso normal de la aplicación
        public ICalendarEvent createEvent(DateTime date, string name, TimeIteration timeIteration);
        public ICalendarEvent getEventById(Guid id);
        public ICalendarEvent[] sortEventsByDate(DateTime fromDate, DateTime toDate);
        public bool deleteEventById(Guid id);
    }
}