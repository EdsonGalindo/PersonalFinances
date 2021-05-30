using AutoMapper;
using PersonalFinances.Application.Queries.ViewModels;
using PersonalFinances.Domain.Entities;
using PersonalFinances.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Application.Services
{
    public class ReleaseAppService : IReleaseAppService
    {
        private readonly IPersonalFinanceRepository _personalFinanceRepository;
        private readonly IMapper _mapper;

        public ReleaseAppService(IPersonalFinanceRepository personalFinanceRepository,
                                 IMapper mapper)
        {
            _personalFinanceRepository = personalFinanceRepository;
            _mapper = mapper;
        }

        public async Task<List<ReleaseViewModel>> GetReleases(string yearMonth)
        {
            var yearInt = 0;
            var monthInt = 0;

            int.TryParse(yearMonth.Substring(0, 4), out yearInt);
            int.TryParse(yearMonth.Substring(5, 2), out monthInt);
            var yearMonthDate = new DateTime(yearInt, monthInt, 1);

            var resultQuery = await _personalFinanceRepository.GetByReleaseYearMonth(yearMonthDate);

            var result = resultQuery != null ? _mapper.Map<List<ReleaseViewModel>>(resultQuery.ReleaseItems) : new List<ReleaseViewModel>();

            return result;
        }

        public async Task<bool> AddRelease(ReleaseViewModel releaseViewModel)
        {
            var release = _mapper.Map<Release>(releaseViewModel);
            var personalFinance = new PersonalFinance(release);
            
            var result = await _personalFinanceRepository.Add(personalFinance);

            return result;
        }

        public async Task<bool> AddReleaseList(List<ReleaseViewModel> releaseViewModels)
        {
            var release = _mapper.Map<List<Release>>(releaseViewModels);
            var personalFinance = new PersonalFinance(release);

            var result = await _personalFinanceRepository.Add(personalFinance);

            return result;
        }

        public async Task<bool> RemoveRelease(ReleaseViewModel releaseViewModel)
        {
            var release = _mapper.Map<Release>(releaseViewModel);
            var personalFinance = new PersonalFinance(release);

            var result = await _personalFinanceRepository.Remove(personalFinance);

            return result;
        }

        public void Dispose()
        {
            _personalFinanceRepository.Dispose();
        }
    }
}
