using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotifiTime_API.domain.Enum;

namespace NotifiTime_API.domain.entities
{
    public interface IEventCalendar
    {
        // atributos
        public Guid getId();
        public string getName();
        public DateTime getDateTime();
        public TimeIteration getTimeIteration();
        public List<SupportedPlatform> getSupportedPlatformList();
        public string getMessage();
        public IEventCalendar setName(string newName);
        public IEventCalendar setDateTime(DateTime newDateTime);
        public IEventCalendar setTimeIteration(TimeIteration newTimeIteration);
        public IEventCalendar setSupportedPlatformList(List<SupportedPlatform> supportedPlatformList);
        public IEventCalendar addSupportedPlatform(SupportedPlatform newSupportedPlatform);
        public IEventCalendar setMessage(string newMessage);
    }
}