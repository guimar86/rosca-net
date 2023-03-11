using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using azure_starter.model;
using azure_starter.services;
using Microsoft.AspNetCore.Mvc;

namespace azure_starter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantsController : ControllerBase
    {
        private readonly IParticipantService _participantService;

        public ParticipantsController(IParticipantService participantService)
        {
            _participantService = participantService;
        }

        // GET: api/participants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Participant>>> GetParticipants()
        {
            var participants = await _participantService.GetAllParticipants();
            return Ok(participants);
        }

        // GET: api/participants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Participant>> GetParticipant(Guid id)
        {
            var participant = await _participantService.GetParticipantById(id);

            if (participant == null)
            {
                return NotFound();
            }

            return Ok(participant);
        }

        // POST: api/participants
        [HttpPost]
        public async Task<ActionResult<Participant>> PostParticipant(Participant participant)
        {
            await _participantService.AddParticipant(participant);

            return CreatedAtAction(nameof(GetParticipant), new { id =participant.Id }, participant);
        }

        // PUT: api/participants/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParticipant(string id, Participant participant)
        {
            if (id != participant.Id.ToString())
            {
                return BadRequest();
            }

            await _participantService.UpdateParticipant(participant);

            return NoContent();
        }

        // DELETE: api/participants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipant(Guid id)
        {
            await _participantService.DeleteParticipant(id);

            return NoContent();
        }
    }
}
