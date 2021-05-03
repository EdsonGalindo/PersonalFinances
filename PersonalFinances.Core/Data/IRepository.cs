using System;
using PersonalFinances.Core.DomainObjects;

namespace PersonalFinances.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
