using EcommerceGenerator.Domain.Entites;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace EcommerceGenerator.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {

        Task<T> Get(Expression<Func<T, bool>> expression);
        Task<T> GetById(Guid Id);
        Task<bool> Exists(Expression<Func<T, bool>> expression);
        Task<List<T>> GetAll(Expression<Func<T, bool>> expression);
        Task<List<T>> GetAll();
        Task<int> CountByExpression(Expression<Func<T, bool>> expression);
        Task<T> Add(T model);
        Task Update(T model);
        Task SaveChanges();
        Task<IDbContextTransaction> BeginTransaction();
        Task CommitTransaction(IDbContextTransaction transaction);
        Task RollBackTransaction(IDbContextTransaction transaction);

    }
}
