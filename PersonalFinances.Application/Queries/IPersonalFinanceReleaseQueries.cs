using PersonalFinances.Application.Queries.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Application.Queries
{
    public interface IPersonalFinanceReleaseQueries
    {
        Task<PersonalFinanceViewModel> GetPersonalFinanceReleases(DateTime yearMonth);
    }
}
