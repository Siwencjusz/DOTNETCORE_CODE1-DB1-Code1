using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace EFCORE
{
    public class DbFactory : IDesignTimeDbContextFactory<BloggingContext>
    {
        private BloggingContext _dbContext;
        private readonly DbContextOptionsBuilder<BloggingContext> _dbContextOptionsBuilder;
        
        public DbFactory()
        {
            _dbContextOptionsBuilder = new DbContextOptionsBuilder<BloggingContext>();
            _dbContextOptionsBuilder.UseSqlServer("Data Source =.\\sqlexpress;  Initial Catalog = BloggingContext; Trusted_Connection = True;  MultipleActiveResultSets=True;");
        }

        public DbFactory(IConfigurationRoot configuration )
        {
            _dbContextOptionsBuilder = new DbContextOptionsBuilder<BloggingContext>();
            _dbContextOptionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        public BloggingContext Init()
        {
            return _dbContext ?? (_dbContext = new BloggingContext(_dbContextOptionsBuilder.Options));
        }

        public BloggingContext CreateDbContext(string[] args)
        {
            return Init();
        }

        protected void DisposeCore()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
            }
        }
    }
}
