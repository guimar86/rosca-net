using System.Collections.Generic;
using System.Threading.Tasks;
using azure_starter.model;
using Microsoft.EntityFrameworkCore;

namespace azure_starter.services
{
    public class ParticipantService:IParticipantService
    {
        private readonly DbContext _dbContext;

        public ParticipantService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Participant>> GetAllParticipants()
        {
            return await _dbContext.Set<Participant>().ToListAsync();
        }

        public async Task<Participant> GetParticipantById(int id)
        {
            return await _dbContext.Set<Participant>().FindAsync(id);
        }

        public async Task AddParticipant(Participant participant)
        {
            await _dbContext.Set<Participant>().AddAsync(participant);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateParticipant(Participant participant)
        {
            _dbContext.Set<Participant>().Update(participant);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteParticipant(int id)
        {
            var participant = await GetParticipantById(id);
            if (participant != null)
            {
                _dbContext.Set<Participant>().Remove(participant);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}