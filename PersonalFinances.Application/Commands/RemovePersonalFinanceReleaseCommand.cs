using PersonalFinances.Domain.Entities;
using PersonalFinances.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Application.Commands
{
    public class RemovePersonalFinanceReleaseCommand
    {
        private readonly IPersonalFinanceRepository _personalFinanceRepository;

        public RemovePersonalFinanceReleaseCommand(IPersonalFinanceRepository personalFinanceRepository)
        {
            _personalFinanceRepository = personalFinanceRepository;
        }

        public async Task<bool> RemovePersonalFinanceRelease(PersonalFinance personalFinance)
        {
            return await _personalFinanceRepository.Remove(personalFinance);
        }
    }
}
