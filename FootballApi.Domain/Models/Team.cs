using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using DataAnnotationsExtensions;

namespace FootballApi.Domain.Models
{
    public class Team
    {
        public string Name { get; set; }

        [Min(0)]
        public int Score { get; set; }
        [Min(0)]
        public int GamesPlayed { get; set; }
        [Min(0)]
        public int GoalsScored { get; set; }
        [Min(0)]
        public int GoalsLost { get; set; }

        public int GoalsDifference => GoalsScored - GoalsDifference;

        //public virtual ICollection<GameResult> GameResults { get; set; } 

        public Team(string name)
        {
            Name = name;
        }
    }
}