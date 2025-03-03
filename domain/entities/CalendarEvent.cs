using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SequentialGuid;
using NotifiTime_API.domain.Enum;
using System.Runtime.Versioning;

namespace NotifiTime_API.domain.entities
{
    public class CalendarEvent : ICalendarEvent
    {
        private readonly Guid id;
        private string name;
        private DateTime dateTime;
        private List<SupportedPlatform> supportedPlatformList;
        private string message;
        private TimeIteration timeIteration;

        public CalendarEvent(){
            id = SequentialGuidGenerator.Instance.NewGuid();
        }

        public DateTime getDateTime()
        {
            return dateTime;
        }

        public Guid getId()
        {
            return id;
        }

        public string getMessage()
        {
            return message;
        }

        public string getName()
        {
            return name;
        }

        public List<SupportedPlatform> getSupportedPlatformList()
        {
            return supportedPlatformList;
        }

        public TimeIteration getTimeIteration()
        {
            return timeIteration;
        }

        public ICalendarEvent setDateTime(DateTime newDateTime)
        {
            dateTime = newDateTime;
            return this;
        }

        public ICalendarEvent setMessage(string newMessage)
        {
            message = newMessage;
            return this;
        }

        public ICalendarEvent setName(string newName)
        {
            name = newName;
            return this;
        }

        public ICalendarEvent setSupportedPlatformList(List<SupportedPlatform> newSupportedPlatformList)
        {
            supportedPlatformList = newSupportedPlatformList;
            return this;
        }

        public ICalendarEvent setTimeIteration(TimeIteration newTimeIteration)
        {
            timeIteration = newTimeIteration;
            return this;
        }

        public ICalendarEvent addSupportedPlatform(SupportedPlatform newSupportedPlatform)
        {
            supportedPlatformList.Add(newSupportedPlatform);
            return this;
        }
    }
}