using PersonalFinances.Domain.Entities;
using PersonalFinances.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Application.Commands
{
    public class AddPersonalFinanceReleaseCommand
    {
        private readonly IPersonalFinanceRepository _personalFinanceRepository;

        public AddPersonalFinanceReleaseCommand(IPersonalFinanceRepository personalFinanceRepository)
        {
            _personalFinanceRepository = personalFinanceRepository;
        }

        public async Task<bool> AddPersonalFinanceRelease(PersonalFinance personalFinance)
        {
            return await _personalFinanceRepository.Add(personalFinance);
        }
    }
}
