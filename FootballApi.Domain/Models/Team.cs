using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballApi.Domain.Models
{
    public class Team
    {
        [Key, StringLength(200)]
        public string Name { get; set; }

        public int Score { get; set; }
        public int GamesPlayed { get; set; }
        public int GoalsScored { get; set; }
        public int GoalsLost { get; set; }

        [NotMapped]
        public int GoalsDifference => GoalsScored - GoalsDifference;
    }
}