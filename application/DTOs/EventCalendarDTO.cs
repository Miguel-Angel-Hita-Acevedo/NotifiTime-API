using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotifiTime_API.domain.entities;
using NotifiTime_API.domain.Enum;

namespace NotifiTime_API.application.Dtos
{
    public class EventCalendarDto
    {
        private Guid id;
        private string name;
        private DateTime dateTime;
        private List<SupportedPlatform> supportedPlatformList;
        private string message;
        private TimeIteration timeIteration;
        
        public Guid Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public DateTime DateTime { get => dateTime; set => dateTime = value; }
        public List<SupportedPlatform> SupportedPlatformList { get => supportedPlatformList; set => supportedPlatformList = value; }
        public string Message { get => message; set => message = value; }
        public TimeIteration TimeIteration { get => timeIteration; set => timeIteration = value; }
    }
}