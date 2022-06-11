using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wtalk.Core.Entities;

namespace Wtalk.Infrastracture.Data.Context
{
    public class DbWriteContext:WtalkContext
    {
        public DbWriteContext(DbContextOptions<DbWriteContext> options) : base(options)
        {

        }
        public override int SaveChanges()
        {
            UpdateDateTime();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            UpdateDateTime();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateDateTime()
        {
            var entries = ChangeTracker
                 .Entries()
                 .Where(e => e.Entity is ITrackable && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((ITrackable)entityEntry.Entity).UpdatedAt = DateTime.UtcNow;

                if (entityEntry.State == EntityState.Added)
                {
                    ((ITrackable)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
                }
            }

        }
    }
}
