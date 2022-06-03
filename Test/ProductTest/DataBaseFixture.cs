using System;
using Infra.Data.Sql.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Test.ProductTest
{
    public class DataBaseFixture : IDisposable
    {
        public AppDbContext DbContext;

        public DataBaseFixture()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                               .UseInMemoryDatabase(databaseName: "MovieListDatabase")
                               .Options;
            DbContext = new AppDbContext(options);
        }

        public void Dispose()
        {
            
        }
    }
}
