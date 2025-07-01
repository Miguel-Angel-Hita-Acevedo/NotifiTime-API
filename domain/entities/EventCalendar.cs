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

        //const conversions string-enum
        readonly Dictionary<string, SupportedPlatform> stringAndSupportedPlatformCast = new Dictionary<string, SupportedPlatform>()
            {
                ["mail"] = SupportedPlatform.Mail
            };
        readonly Dictionary<string, TimeIteration> stringAndTimeIterationCast = new Dictionary<string, TimeIteration>()
            {
                ["annually"] = TimeIteration.Annually,
                ["monthly"] = TimeIteration.Monthly,
                ["weekly,"] = TimeIteration.Weekly,
                ["daily,"] = TimeIteration.Daily,
                ["none"] = TimeIteration.None
            };
        
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
        
        public EventCalendar(Guid id, string name, DateTime dateTime, List<string> supportedPlatformStringList, string message, string timeIterationString)
        {
            this.id = id;
            this.name = name;
            this.dateTime = dateTime;
            this.supportedPlatformList = castStringListToSupportedPlatformsList(supportedPlatformStringList);
            this.message = message;
            this.timeIteration = castStringToTimeIteration(timeIterationString);
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
        
        public List<string> getSupportedPlatformListToStringList()
        {
            List<string> supportedPlatformListStringList = new List<string>();
            foreach(SupportedPlatform currentSupportedPlatform in supportedPlatformList)
            {
                supportedPlatformListStringList.Add(currentSupportedPlatform.ToString());
            }
            return supportedPlatformListStringList;
        }
        
        private List<SupportedPlatform> castStringListToSupportedPlatformsList(List<string> stringSupportedPlatformsList)
        {
            List<SupportedPlatform> supportedPlatformList = new List<SupportedPlatform>();
            
            foreach(string currentSupportedPlatformString in stringSupportedPlatformsList)
            {
                supportedPlatformList.Add(stringAndSupportedPlatformCast[currentSupportedPlatformString.ToLower()]);
            }
            return supportedPlatformList;
        }

        public TimeIteration getTimeIteration()
        {
            return timeIteration;
        }
        
        public string getTimeIterationToString()
        {
            return timeIteration.ToString();
        }
        
        private TimeIteration castStringToTimeIteration(string stringTimeIteration)
        {
            return stringAndTimeIterationCast[stringTimeIteration.ToLower()];
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