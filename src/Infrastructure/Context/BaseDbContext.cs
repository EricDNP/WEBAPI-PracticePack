using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Configurations.Extensions;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Domain.Interfaces.Common;

namespace Infrastructure.Context
{

    public interface IBaseDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

    }

    public class BaseDbContext : DbContext, IBaseDbContext
    {
        protected readonly IHttpContextAccessor _context;

        public BaseDbContext(DbContextOptions options, IHttpContextAccessor context) : base(options)
        {
            _context = context;
        }

        private void SetAuditEntities()
        {
            var email = _context?.HttpContext?.User?.FindFirst(ClaimTypes.Email)?.Value ?? "Anonymous";

            foreach (var entry in ChangeTracker.Entries<IBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Deleted = false;
                        entry.Entity.CreatedDate = DateTimeOffset.UtcNow;
                        entry.Entity.CreatedBy = email;
                        break;

                    case EntityState.Modified:
                        entry.Property(x => x.CreatedDate).IsModified = false;
                        entry.Property(x => x.CreatedBy).IsModified = false;
                        entry.Entity.UpdatedDate = DateTimeOffset.UtcNow;
                        entry.Entity.UpdatedBy = email;
                        break;

                    case EntityState.Deleted:
                        entry.Property(x => x.CreatedDate).IsModified = false;
                        entry.Property(x => x.CreatedBy).IsModified = false;
                        entry.State = EntityState.Modified;
                        entry.Entity.Deleted = true;
                        entry.Entity.DeletedDate = DateTimeOffset.UtcNow;
                        entry.Entity.DeletedBy = email;
                        break;

                    default:
                        break;
                }
            }
        }

        public override int SaveChanges()
        {
            SetAuditEntities();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            SetAuditEntities();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetAuditEntities();
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var type in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(IBase).IsAssignableFrom(type.ClrType))
                    modelBuilder.SetSoftDeleteFilter(type.ClrType);
            }
        }
    }
}
