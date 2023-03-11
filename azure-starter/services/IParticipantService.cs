using System.Collections.Generic;
using System.Threading.Tasks;
using azure_starter.model;

namespace azure_starter.services
{
    public interface IParticipantService
    {
        Task<IEnumerable<Participant>> GetAllParticipants();
        Task<Participant> GetParticipantById(int id);
        Task AddParticipant(Participant participant);
        Task UpdateParticipant(Participant participant);
        Task DeleteParticipant(int id);
    }
}