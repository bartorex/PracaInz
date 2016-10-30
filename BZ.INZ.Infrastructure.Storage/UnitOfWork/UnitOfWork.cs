using BZ.INZ.Infrastructure.Storage.Context;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BZ.INZ.Infrastructure.Storage.UnitOfWork {
    public class UnitOfWork : IUnitOfWork {
        private readonly ApplicationContext context;

        public UnitOfWork(ApplicationContext context) {
            this.context = context;
        }

        public async Task<T> Add<T>(T entity) where T : class {
            return await Task.FromResult(context.Set<T>().Add(entity));
        }

        public async Task Delete<T>(T entity) where T : class {
            await Task.Run(() =>{
                context.Set<T>().Remove(entity);
            });
        }

        public async Task<IQueryable> Query<T>() where T : class {
            return await Task.FromResult(context.Set<T>());
        }

        public async Task SaveChangesAsync() {
            await context.SaveChangesAsync();
        }

        public async Task Update<T>(T entity) where T : class {
            await Task.Run(()=> {
                context.Entry(entity).State = EntityState.Modified;
            });
        }
    }
}
