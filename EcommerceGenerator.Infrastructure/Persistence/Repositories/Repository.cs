using EcommerceGenerator.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EcommerceGenerator.Infrastructure.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly DbContext Context;
        public DbSet<T> Db;

        public Repository(DbContext Context)
        {

            this.Context = Context;
            Db = Context.Set<T>();

        }

        public async Task<T> Get(Expression<Func<T, bool>> expression)
        {
            return await Db.FirstOrDefaultAsync(expression);
        }

        public async Task<T> GetById(Guid Id)
        {
            return await Db.FindAsync(Id);
        }

        public async Task<bool> Exists(Expression<Func<T, bool>> expression)
        {
            return await Db.AnyAsync(expression);
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> expression)
        {
            return await Db.Where(expression).ToListAsync();
        }

        public async Task<List<T>> GetAll()
        {
            return await Db.ToListAsync();
        }

        public async Task<T> Add(T model)
        {

            await Db.AddAsync(model);
            await SaveChanges();

            return model;

        }

        public async Task Update(T model)
        {
            Db.Update(model);
            await SaveChanges();
        }

        public async Task SaveChanges()
        {
            await Context.SaveChangesAsync();
        }

        public async Task<int> CountByExpression(Expression<Func<T, bool>> expression)
        {
            return await Db.CountAsync(expression);
        }
    }
}
