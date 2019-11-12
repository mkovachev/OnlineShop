using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Data.Repository
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        private readonly OnlineShopDbContext context;

        public Repository(OnlineShopDbContext context)
        {
            this.context = context;
        }

        public IQueryable<T> All()
        {
            return context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            EntityEntry entry = context.Entry(entity);

            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                await context.Set<T>().AddAsync(entity);
            }
        }

        public void Update(T entity)
        {
            EntityEntry entry = context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                context.Set<T>().Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        void IRepository<T>.Add(T entity)
        {
            EntityEntry entry = context.Entry(entity);

            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                context.Set<T>().Add(entity);
            }
        }

        void IRepository<T>.Save()
        {
            context.SaveChanges();
        }
    }
}