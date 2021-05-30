using PersonalFinances.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Domain.Interfaces
{
    public interface IPersonalFinanceRepository
    {
        Task<PersonalFinance> GetByReleaseId(int id);
        Task<PersonalFinance> GetByReleaseYearMonth(DateTime date);
        Task<bool> Add(PersonalFinance personalFinance);
        Task<bool> Remove(PersonalFinance personalFinance);
        void Dispose();
    }
}
