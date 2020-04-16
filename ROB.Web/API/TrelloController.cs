using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ROB.Web.Data;
using ROB.Web.Models;

namespace ROB.Web.API
{
    public class TrelloController : ApiControllerBase
    {
        private readonly ApplicationDbContext context;

        public TrelloController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TrelloSuggestionModel>>> GetSuggestions()
        {
            try
            {
                var suggestions = await context
                    .TrelloSuggestionModel
                    .ToListAsync()
                    .ConfigureAwait(false);
                return Ok(suggestions);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Could not retrieve trello suggestions");
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<TrelloSuggestionModel>> GetSuggestionById(int id)
        {
            try
            {
                var suggestion = await context
                    .TrelloSuggestionModel
                    .FirstOrDefaultAsync(s => s.Id == id)
                    .ConfigureAwait(false);
                return Ok(suggestion);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Could not retrieve trello suggestion {id}");
            }
        }

        [HttpGet]
        [Route("user/{mention}")]
        public async Task<ActionResult<List<TrelloSuggestionModel>>> GetSuggestionsByUserMention(string mention)
        {
            try
            {
                var suggestions = await context
                    .TrelloSuggestionModel
                    .Where(s => s.Sender == mention)
                    .ToListAsync()
                    .ConfigureAwait(false);
                return Ok(suggestions);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Could not retrieve trello suggestions for user {mention}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostSuggestion([FromBody] TrelloSuggestionModel suggestionModel)
        {
            try
            {
                suggestionModel.Status = SuggestionStatus.Pending;
                context.Add(suggestionModel);
                await context.SaveChangesAsync().ConfigureAwait(false);
                return CreatedAtAction(nameof(GetSuggestionById), new { id = suggestionModel.Id}, suggestionModel);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Could add trello suggestion");
            }
        }

        public class

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateSuggestion([FromBody] int suggestionId, SuggestionStatus status)
        {
            try
            {
                var suggestion = await context
                    .TrelloSuggestionModel
                    .FirstOrDefaultAsync(s => s.Id == suggestionId);
                suggestion.Status = status;
                await context.SaveChangesAsync().ConfigureAwait(false);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Could not update trello suggestion {suggestionId}");
            }
        }
    }
}