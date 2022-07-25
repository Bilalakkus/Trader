using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trader.EfCore
{
    public class TraderDbContextFactory
    {
        public readonly Action<DbContextOptionsBuilder> _configureDbContext;

        public TraderDbContextFactory(Action<DbContextOptionsBuilder> configureDbContext)
        {
            _configureDbContext = configureDbContext;
        }
        public TraderDbContext CreateDbContext()
        {
            DbContextOptionsBuilder<TraderDbContext> options=new DbContextOptionsBuilder<TraderDbContext>();
            _configureDbContext(options);
            return new TraderDbContext(options.Options);
        }
    }
}
