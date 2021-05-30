using Microsoft.EntityFrameworkCore;
using PersonalFinances.Application.Services;
using PersonalFinances.Domain.Entities;
using PersonalFinances.Domain.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalFinances.Infra.DataAccess.Repositories
{
    public class PersonalFinanceRepository : IPersonalFinanceRepository
    {
        private readonly PersonalFinancesContext _personalFinancesContext;

        public PersonalFinanceRepository(PersonalFinancesContext personalFinancesContext)
            => this._personalFinancesContext = personalFinancesContext ??
                    throw new ArgumentNullException(nameof(personalFinancesContext));

        public async Task<bool> Add(PersonalFinance personalFinance)
        {
            _personalFinancesContext.Releases.AddRange(personalFinance.ReleaseItems);
            return await _personalFinancesContext.Commit();
        }

        public async Task<PersonalFinance> GetByReleaseId(int id)
        {
            var release = await _personalFinancesContext.Releases.FindAsync(id);

            return release != null ? new PersonalFinance(release) : null;
        }

        public async Task<PersonalFinance> GetByReleaseYearMonth(DateTime date)
        {
            var releases = await _personalFinancesContext.Releases.Where(r => r.Date >= date && r.Date <= date.AddMonths(1).AddDays(-1)).ToListAsync();

            return releases != null ? new PersonalFinance(releases) : null;
        }

        public async Task<bool> Remove(PersonalFinance personalFinance)
        {
            _personalFinancesContext.RemoveRange(personalFinance.ReleaseItems);
            return await _personalFinancesContext.Commit();
        }

        public void Dispose()
        {
            _personalFinancesContext.Dispose();
        }
    }
}
