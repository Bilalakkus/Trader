using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trader.Domain.Models;
using Trader.Domain.Services;
using Trader.EfCore.Common;

namespace Trader.EfCore.Service
{
    public class GenericDataService<T> : IDataService<T> where T: DomainObject
    {
        private readonly TraderDbContextFactory _contextFactory;
        private readonly NonQueryDataService<T> _nonQueryDataService;

        public GenericDataService(TraderDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService=new NonQueryDataService<T>(contextFactory);
        }
        public async Task<T> Create(T Entity)
        {
            return await _nonQueryDataService.Create(Entity);
        }
        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }
        public async Task<T> Update(int id,T entity)
        {
            return await _nonQueryDataService.Update(id,entity);
        }
        public async Task<T> Get(int id)
        {
            using(TraderDbContext context = _contextFactory.CreateDbContext())
            {
                return await context.Set<T>().FirstOrDefaultAsync(e=>e.Id == id);
            }
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            using(TraderDbContext context = _contextFactory.CreateDbContext())
            {
                return  await context.Set<T>().ToListAsync();
            }
        }
    }
}
