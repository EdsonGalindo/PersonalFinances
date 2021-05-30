using PersonalFinances.Application.Queries.ViewModels;
using PersonalFinances.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Application.Queries
{
    public class PersonalFinanceReleaseQueries : IPersonalFinanceReleaseQueries
    {
        private readonly IPersonalFinanceRepository _personalFinanceRepository;

        public PersonalFinanceReleaseQueries(IPersonalFinanceRepository personalFinanceRepository)
        {
            _personalFinanceRepository = personalFinanceRepository;
        }

        public async Task<PersonalFinanceViewModel> GetPersonalFinanceReleases(DateTime yearMonth)
        {
            var personalFinanceReleases = await _personalFinanceRepository.GetByReleaseYearMonth(yearMonth);

            if (personalFinanceReleases == null) return null;

            var personalFinance = new PersonalFinanceViewModel();

            foreach (var item in personalFinanceReleases.ReleaseItems)
            {
                personalFinance.Releases.Add(new ReleaseViewModel
                {
                    Id = item.Id,
                    Date = item.Date,
                    Value = item.Value,
                    Description = item.Description,
                    Account = item.Account,
                    Type = item.Type
                });
            }

            return personalFinance;
        }
    }
}
