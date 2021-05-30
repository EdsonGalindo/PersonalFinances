using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Application.Services
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
