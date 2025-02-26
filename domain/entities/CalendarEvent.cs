using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SequentialGuid;
using NotifiTime_API.domain.Enum;

namespace NotifiTime_API.domain.entities
{
    public class CalendarEvent : ICalendarEvent
    {
        private readonly Guid id;
        private string name;
        private DateTime dateTime;
        private List<SuportedPlatform> suportedPlatformList;
        private string message;
        private TimeIteration timeIteration;

        public CalendarEvent(){
            id = SequentialGuidGenerator.Instance.NewGuid();
        }

        public DateTime getDateTime()
        {
            throw new NotImplementedException();
        }

        public Guid getId()
        {
            throw new NotImplementedException();
        }

        public string getMessage()
        {
            throw new NotImplementedException();
        }

        public string getName()
        {
            throw new NotImplementedException();
        }

        public List<SuportedPlatform> getSuportedPlatformList()
        {
            throw new NotImplementedException();
        }

        public TimeIteration getTimeIteration()
        {
            throw new NotImplementedException();
        }

        public ICalendarEvent setDateTime(DateTime newDateTime)
        {
            throw new NotImplementedException();
        }

        public ICalendarEvent setMessage(string newMessage)
        {
            throw new NotImplementedException();
        }

        public ICalendarEvent setName(string newName)
        {
            throw new NotImplementedException();
        }

        public ICalendarEvent setSuportedPlatformList(List<SuportedPlatform> suportedPlatformList)
        {
            throw new NotImplementedException();
        }

        public ICalendarEvent setTimeIteration(TimeIteration newTimeIteration)
        {
            throw new NotImplementedException();
        }

        public ICalendarEvent addSuportedPlatform(SuportedPlatform newSuportedPlatform)
        {
            throw new NotImplementedException();
        }
    }
}