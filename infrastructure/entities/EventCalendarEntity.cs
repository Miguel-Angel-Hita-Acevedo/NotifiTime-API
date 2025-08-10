using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotifiTime_API.domain.entities;

namespace NotifiTime_API.infrastructure.entities
{
    public class EventCalendarEntity
    {
        private Guid id;
        private string name;
        private DateTime dateTime;
        private List<string> supportedPlatformList; // need cast to enum
        private string message;
        private string timeIteration; // need cast to enum (Annually,Monthly,Weekly,Daily,None)

        public EventCalendarEntity(Guid id, 
                                    string name, 
                                    DateTime dateTime, 
                                    List<string> supportedPlatformList, 
                                    string message, 
                                    string timeIteration
                                )
        {
            Id = id;
            Name = name;
            DateTime = dateTime;
            SupportedPlatformList = supportedPlatformList;
            Message = message;
            TimeIteration = timeIteration;
        }
        
        public static EventCalendarEntity FromDomainModel(EventCalendar eventCalendar)
        {
            return new EventCalendarEntity(
                eventCalendar.GetId(),
                eventCalendar.GetName(),
                eventCalendar.GetDateTime(),
                eventCalendar.GetSupportedPlatformListToStringList(),
                eventCalendar.GetMessage(),
                eventCalendar.GetTimeIterationToString()
            );
        }
        
        public EventCalendar ToDomainModel()
        {
            return new EventCalendar(id, name, dateTime, supportedPlatformList, message, timeIteration);
        }

        public Guid Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public DateTime DateTime { get => dateTime; set => dateTime = value; }
        public List<string> SupportedPlatformList { get => supportedPlatformList; set => supportedPlatformList = value; }
        public string Message { get => message; set => message = value; }
        public string TimeIteration { get => timeIteration; set => timeIteration = value; }
    }
}