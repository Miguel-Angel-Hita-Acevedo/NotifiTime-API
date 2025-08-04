using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotifiTime_API.domain.entities;

namespace NotifiTime_API.domain.Interfaces
{
    public interface IWalletRepository
    {
        public Task<WalletCalendar> GetWalletContent();
    }
}