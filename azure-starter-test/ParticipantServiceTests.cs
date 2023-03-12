using System;
using System.Linq;
using System.Threading.Tasks;
using azure_starter.model;
using azure_starter.services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace azure_starter_test
{
    public class ParticipantServiceTests
    {
        private ParticipantsDbContext _dbContext;
        private InMemoryDbContextFactory factory;
        public ParticipantServiceTests()
        {
            factory = new InMemoryDbContextFactory();
        }
        
       
        
        [Fact]
        public async Task GetAllParticipants_ShouldReturnAllParticipants()
        {
            // Arrange
            var _dbContext = factory.CreateDbContext();
            factory.ClearInMemoryDbContext(_dbContext);
            await using (var context =_dbContext)
            {
                var participant1 = new Participant { Id = Guid.NewGuid(), Name = "John" };
                var participant2 = new Participant { Id = Guid.NewGuid(), Name = "Jane" };
                context.Participants.AddRange(participant1, participant2);
                await context.SaveChangesAsync();
            }
            var _dbContext2 = factory.CreateDbContext();
            await using (var context = _dbContext2)
            {
                var service = new ParticipantService(context);

                // Act
                var result = await service.GetAllParticipants();

                // Assert
                Assert.True(result.Any());
            }
        }

        [Fact]
        public async Task GetParticipantById_ShouldReturnParticipantWithGivenId()
        {
            // Arrange
            _dbContext = factory.CreateDbContext();
            factory.ClearInMemoryDbContext(_dbContext);
            await using (var context = _dbContext)
            {
                var participant1 = new Participant { Id = Guid.NewGuid(), Name = "John" };
                var participant2 = new Participant { Id = Guid.NewGuid(), Name = "Jane" };
                context.Participants.AddRange(participant1, participant2);
                await context.SaveChangesAsync();
            }
            _dbContext = factory.CreateDbContext();
            await using (var context = _dbContext)
            {
                _dbContext = factory.CreateDbContext();
                var service = new ParticipantService(context);

                // Act
                var result = await service.GetParticipantById(Guid.NewGuid());

                // Assert
                Assert.Null(result);

                // Act
                var existingParticipant = await context.Participants.FirstAsync();
                var existingParticipantId = existingParticipant.Id;
                var existingParticipantName = existingParticipant.Name;
                var existingParticipantResult = await service.GetParticipantById(existingParticipantId);

                // Assert
                Assert.Equal(existingParticipantId, existingParticipantResult.Id);
                Assert.Equal(existingParticipantName, existingParticipantResult.Name);
            }
        }

        [Fact]
        public async Task AddParticipant_ShouldAddParticipantToDatabase()
        {
            
            // Arrange
            _dbContext = factory.CreateDbContext();
            factory.ClearInMemoryDbContext(_dbContext);
            await using (var context = _dbContext)
            {
                var participant = new Participant { Id = Guid.NewGuid(), Name = "John" };
                var service = new ParticipantService(context);

                // Act
                await service.AddParticipant(participant);

                var result =  context.Participants.Count();
                // Assert
                Assert.True(result>0);
            }
        }

        [Fact]
        public async Task UpdateParticipant_ShouldUpdateExistingParticipant()
        {
            // Arrange
            _dbContext = factory.CreateDbContext();
            factory.ClearInMemoryDbContext(_dbContext);
            await using (var context = _dbContext)
            {
                var participant = new Participant { Id = Guid.NewGuid(), Name = "John" };
                context.Participants.Add(participant);
                await context.SaveChangesAsync();
            }
            _dbContext = factory.CreateDbContext();
            await using (var context = _dbContext)
            {
                var service = new ParticipantService(context);

                // Act
                var existingParticipant = await context.Participants.FirstAsync();
                existingParticipant.Name = "Jane";
                await service.UpdateParticipant(existingParticipant);

                // Assert
                Assert.Equal("Jane",  context.Participants.FirstAsync().Result.Name);
            }
        }

        [Fact]
        public async Task DeleteParticipant_ShouldRemoveParticipantFromDatabase()
        {
            // Arrange
            _dbContext = factory.CreateDbContext();
            factory.ClearInMemoryDbContext(_dbContext);
            await using (var context = _dbContext)
            {
                var participant = new Participant { Id = Guid.NewGuid(), Name = "John" };
                context.Participants.Add(participant);
                await context.SaveChangesAsync();
            }
            _dbContext = factory.CreateDbContext();
            await using (var context = _dbContext)
            {
                var service = new ParticipantService(context);

                // Act
                var existingParticipant = await context.Participants.FirstAsync();
                var idToCheck = existingParticipant.Id;
                await service.DeleteParticipant(existingParticipant.Id);
                var findDeletedParticipant = await service.GetParticipantById(idToCheck);
                // Assert
                Assert.Equal(null, findDeletedParticipant);
            }
        }
    }
}

