using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotifiTime_API.domain.Enum;

namespace NotifiTime_API.domain.entities
{
    public interface ICalendarEvent
    {
        // atributos
        public Guid getId();
        public string getName();
        public DateTime getDateTime();
        public TimeIteration getTimeIteration();
        public List<SuportedPlatform> getSuportedPlatformList();
        public string getMessage();
        public ICalendarEvent setName(string newName);
        public ICalendarEvent setDateTime(DateTime newDateTime);
        public ICalendarEvent setTimeIteration(TimeIteration newTimeIteration);
        public ICalendarEvent setSuportedPlatformList(List<SuportedPlatform> suportedPlatformList);
        public ICalendarEvent addSuportedPlatform(SuportedPlatform newSuportedPlatform);
        public ICalendarEvent setMessage(string newMessage);
    }
}