using azure_starter.model;
using Microsoft.EntityFrameworkCore;

namespace azure_starter.services
{
    public class ParticipantsDbContext:DbContext
    {
        public ParticipantsDbContext(DbContextOptions<ParticipantsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Participant> Participants { get; set; }
    }
}