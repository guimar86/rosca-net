using azure_starter.services;
using Microsoft.EntityFrameworkCore;

namespace azure_starter_test
{
    public class InMemoryDbContextFactory
    {
        public ParticipantsDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<ParticipantsDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            var dbContext = new ParticipantsDbContext(options);
           
            dbContext.Database.EnsureCreated();

            return dbContext;
        }

        public void ClearInMemoryDbContext(ParticipantsDbContext _context)
        {
            _context.Database.EnsureDeleted();
        }
    }
}