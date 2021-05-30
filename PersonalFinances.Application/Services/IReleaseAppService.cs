using PersonalFinances.Application.Queries.ViewModels;
using PersonalFinances.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Application.Services
{
    public interface IReleaseAppService : IDisposable
    {
        Task<bool> AddRelease(ReleaseViewModel releaseViewModel);

        Task<bool> AddReleaseList(List<ReleaseViewModel> releaseViewModels);

        Task<bool> RemoveRelease(ReleaseViewModel releaseViewModel);

        Task<List<ReleaseViewModel>> GetReleases(string yearMonth);
    }
}
