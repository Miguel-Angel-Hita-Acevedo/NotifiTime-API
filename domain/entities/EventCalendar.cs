using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SequentialGuid;
using NotifiTime_API.domain.Enum;
using System.Runtime.Versioning;

namespace NotifiTime_API.domain.entities
{
    public class EventCalendar : IEventCalendar
    {
        private readonly Guid id;
        private string name;
        private DateTime dateTime;
        private List<SupportedPlatform> supportedPlatformList;
        private string message;
        private TimeIteration timeIteration;

        public EventCalendar(){
            id = SequentialGuidGenerator.Instance.NewGuid();
        }
        
        public EventCalendar(Guid id, string name, DateTime dateTime, List<SupportedPlatform> supportedPlatformList, string message, TimeIteration timeIteration)
        {
            this.id = id;
            this.name = name;
            this.dateTime = dateTime;
            this.supportedPlatformList = supportedPlatformList;
            this.message = message;
            this.timeIteration = timeIteration;
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
        
        public List<string> getSupportedPlatformListToStringArray()
        {
            List<string> supportedPlatformListStringArray = new List<string>();
            foreach(SupportedPlatform currentSupportedPlatform in supportedPlatformList)
            {
                supportedPlatformListStringArray.Add(currentSupportedPlatform.ToString());
            }
            return supportedPlatformListStringArray;
        }

        public TimeIteration getTimeIteration()
        {
            return timeIteration;
        }
        
        public string getTimeIterationToString()
        {
            return timeIteration.ToString();
        }

        public IEventCalendar setDateTime(DateTime newDateTime)
        {
            dateTime = newDateTime;
            return this;
        }

        public IEventCalendar setMessage(string newMessage)
        {
            message = newMessage;
            return this;
        }

        public IEventCalendar setName(string newName)
        {
            name = newName;
            return this;
        }

        public IEventCalendar setSupportedPlatformList(List<SupportedPlatform> newSupportedPlatformList)
        {
            supportedPlatformList = newSupportedPlatformList;
            return this;
        }

        public IEventCalendar setTimeIteration(TimeIteration newTimeIteration)
        {
            timeIteration = newTimeIteration;
            return this;
        }

        public IEventCalendar addSupportedPlatform(SupportedPlatform newSupportedPlatform)
        {
            supportedPlatformList.Add(newSupportedPlatform);
            return this;
        }
    }
}