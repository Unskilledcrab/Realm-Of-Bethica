using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROB.Web.Models
{
    public class TrelloSuggestionModel
    {
        public int Id { get; set; }
        public string Sender { get; set; }
        public string Suggestion { get; set; }
        public SuggestionStatus Status { get; set; }
    }

    public enum SuggestionStatus
    {
        Pending,
        Accepted,
        Rejected
    }
}
