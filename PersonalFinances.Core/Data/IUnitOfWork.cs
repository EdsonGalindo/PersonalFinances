using System.Threading.Tasks;

namespace PersonalFinances.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
