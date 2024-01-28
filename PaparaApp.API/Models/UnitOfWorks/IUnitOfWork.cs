using Microsoft.EntityFrameworkCore.Storage;

namespace PaparaApp.API.Models.UnitOfWorks
{
    public interface IUnitOfWork
    {
        int Commit();
        Task<int> CommitAsync();

        IDbContextTransaction BeginTransaction();
    }
}