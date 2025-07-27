using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotifiTime_API.application.DTOs;
using NotifiTime_API.application.mappers;
using NotifiTime_API.application.services;
using NotifiTime_API.domain.entities;

namespace NotifiTime_API.infrastructure.configuration
{
    public class WalletConfiguration
    {
        private WalletCalendarService walletCalendarService;
        
        public WalletConfiguration()
        {
            ICalendarNotifiTime calendar = new CalendarNotifiTime("Default calendar");
            walletCalendarService = new WalletCalendarService([CalendarNotifiTimeMapper.calendarNotifiTimeToDTO(calendar)]);
        }
    }
}