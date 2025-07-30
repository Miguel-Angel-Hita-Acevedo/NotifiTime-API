using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotifiTime_API.application.DTOs;
using NotifiTime_API.application.mappers;
using NotifiTime_API.application.services;
using NotifiTime_API.domain.entities;
using NotifiTime_API.domain.Enum;
using NotifiTime_API.infrastructure.entities;

namespace NotifiTime_API.infrastructure.configuration
{
    public class WalletConfiguration
    {
        private WalletCalendarService walletCalendarService;

        public WalletConfiguration()
        {
            // TEST MOCK
            Dictionary<Guid, EventCalendar> CalendarUnoDictionary = new Dictionary<Guid, EventCalendar>();
            CalendarUnoDictionary.Add(
                        Guid.Parse("68486927-fee3-4140-9656-6a2d04c09669"),
                        new EventCalendar(
                            Guid.Parse("68486927-fee3-4140-9656-6a2d04c09669"),
                            "Evento 1",
                            DateTime.Today,
                            new List<SupportedPlatform>(),
                            "Felicidades este es el primer mensaje!",
                            TimeIteration.Monthly
                        ));
            CalendarUnoDictionary.Add(
                        Guid.Parse("c1569f58-d7d6-4219-927a-8a1eae075fca"),
                        new EventCalendar(
                            Guid.Parse("c1569f58-d7d6-4219-927a-8a1eae075fca"),
                            "Evento 2",
                            DateTime.Today,
                            new List<SupportedPlatform>(),
                            "Felicidades este es el segundo mensaje!",
                            TimeIteration.Monthly
                        ));
            CalendarUnoDictionary.Add(
                        Guid.Parse("fde5f6b2-b063-43a7-b40a-25e453c30419"),
                        new EventCalendar(
                            Guid.Parse("fde5f6b2-b063-43a7-b40a-25e453c30419"),
                            "Evento 3",
                            DateTime.Today,
                            new List<SupportedPlatform>(),
                            "Felicidades este es el tercer mensaje!",
                            TimeIteration.Monthly
                        ));
            
            Dictionary<Guid, EventCalendar> CalendarDosDictionary = new Dictionary<Guid, EventCalendar>();
            CalendarDosDictionary.Add(
                        Guid.Parse("a14d22e6-73f7-45a1-aa34-3c302a6b9a8e"),
                        new EventCalendar(
                            Guid.Parse("a14d22e6-73f7-45a1-aa34-3c302a6b9a8e"),
                            "Evento 4",
                            DateTime.Today,
                            new List<SupportedPlatform>(),
                            "Felicidades este es el cuarto mensaje!",
                            TimeIteration.Monthly
                        ));
            CalendarDosDictionary.Add(
                        Guid.Parse("a07844b3-628f-45e9-986c-7b6c86f4b9a1"),
                        new EventCalendar(
                            Guid.Parse("a07844b3-628f-45e9-986c-7b6c86f4b9a1"),
                            "Evento 5",
                            DateTime.Today,
                            new List<SupportedPlatform>(),
                            "Felicidades este es el quinto mensaje!",
                            TimeIteration.Monthly
                        ));
            CalendarDosDictionary.Add(
                        Guid.Parse("ab842f8c-2130-4c3c-a7b5-2c6dfedcaac0"),
                        new EventCalendar(
                            Guid.Parse("ab842f8c-2130-4c3c-a7b5-2c6dfedcaac0"),
                            "Evento 6",
                            DateTime.Today,
                            new List<SupportedPlatform>(),
                            "Felicidades este es el sexto mensaje!",
                            TimeIteration.Monthly
                        ));
                        
            ICalendarNotifiTime mockCalendarUno = new CalendarNotifiTime(
                    Guid.Parse("fff295d3-850a-4d3c-b43e-f98adcd55d48"),
                    "Mock Calendar 1",
                    CalendarUnoDictionary,
                    DateTime.Today
            );
            ICalendarNotifiTime mockCalendarDos = new CalendarNotifiTime(
                    Guid.Parse("2ac7b6c3-2c4d-43cb-a4f4-832858f17523"),
                    "Mock Calendar 2",
                    CalendarDosDictionary, 
                    DateTime.Today
            );
            walletCalendarService = new WalletCalendarService(
                [
                    CalendarNotifiTimeMapper.calendarNotifiTimeToDTO(mockCalendarUno),
                    CalendarNotifiTimeMapper.calendarNotifiTimeToDTO(mockCalendarDos)
                ]);
        }
        
        public CalendarNotifiTimeDTO[] GetAllCalendars()
        {
            return CalendarNotifiTimeMapper.CalendarServiceArrayToCalendarDtoArray(walletCalendarService.getCalendarNotifiTimeArray());
        }
        
        public EventCalendarDTO[] GetEventsInCalendar(Guid calendarId)
        {
            CalendarNotifiTimeService calendarFound = walletCalendarService.findCalendarNotifiTimeById(calendarId);
            return calendarFound != null ? calendarFound.GetAllEvents() : null;
        }
    }
}