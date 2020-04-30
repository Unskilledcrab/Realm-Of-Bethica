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

        public class SuggestionUpdate
        {
            public int SuggestionId { get; set; }
            public SuggestionStatus StatusUpdate { get; set; }
        }

        [HttpGet]
        public async Task<ActionResult<List<TrelloSuggestionModel>>> GetSuggestions()
        {
            try
            {
                var suggestions = await context
                    .TrelloSuggestionModel
                    .OrderByDescending(s => s.Id)
                    .Take(10)    
                    .ToListAsync()
                    .ConfigureAwait(false);
                return Ok(suggestions);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Could not retrieve trello suggestions");
            }
        }

        [HttpGet("status/{statusCode}")]
        public async Task<ActionResult<List<TrelloSuggestionModel>>> GetPendingSuggestions(SuggestionStatus suggestionStatus)
        {
            try
            {
                var suggestions = await context
                    .TrelloSuggestionModel
                    .Where(t => t.Status == suggestionStatus)
                    .OrderByDescending(s => s.Id)
                    .Take(10) 
                    .ToListAsync()
                    .ConfigureAwait(false);
                return Ok(suggestions);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Could not retrieve trello suggestions with status code {suggestionStatus}");
            }
        }

        [HttpGet("{id}")]
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

        [HttpGet("user/{mention}")]
        public async Task<ActionResult<List<TrelloSuggestionModel>>> GetSuggestionsByUserMention(string mention)
        {
            try
            {
                var suggestions = await context
                    .TrelloSuggestionModel
                    .Where(s => s.Sender == mention)
                    .OrderByDescending(s => s.Id)
                    .Take(10)
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

        [HttpPost("update")]
        public async Task<IActionResult> UpdateSuggestion([FromBody] SuggestionUpdate suggestionUpdate)
        {
            try
            {
                var suggestion = await context
                    .TrelloSuggestionModel
                    .FirstOrDefaultAsync(s => s.Id == suggestionUpdate.SuggestionId);
                suggestion.Status = suggestionUpdate.StatusUpdate;
                await context.SaveChangesAsync().ConfigureAwait(false);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Could not update trello suggestion {suggestionUpdate.SuggestionId}");
            }
        }
    }
}