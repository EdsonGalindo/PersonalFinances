using PersonalFinances.Core.Data;
using PersonalFinances.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Domain.Interfaces
{
    public interface IPersonalFinanceRepository : IRepository<PersonalFinance>
    {
        Task<PersonalFinance> GetByReleaseId(Guid id);
        Task<PersonalFinance> GetByReleaseYearMonth(DateTime date);
    }
}
