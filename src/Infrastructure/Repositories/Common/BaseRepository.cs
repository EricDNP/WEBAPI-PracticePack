using Infrastructure.Context;
using Domain.Interfaces.Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Common
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IBase
    {
        private readonly IBaseDbContext _context;
        protected readonly DbSet<TEntity> _db;

        public BaseRepository(IBaseDbContext context)
        {
            _context = context;
            _db = context.Set<TEntity>();
        }

        public IQueryable<TEntity> Query()
        {
            return _db.AsQueryable();
        }

        public async Task<TEntity> Get(Guid id)
        {
            var entity = await _db.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (entity is null) throw new KeyNotFoundException($"{typeof(TEntity).Name} not found");
            return entity;
        }

        public async Task<TEntity> GetAsNoTraking(Guid id)
        {
            var entity = await _db.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
            if (entity is null) throw new Exception($"{nameof(TEntity)} not found");
            return entity;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            var result = await _db.AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _db.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Delete(Guid id)
        {
            var entity = await Get(id);
            var result = _db.Remove(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}
