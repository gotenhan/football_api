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
        [Min(0)]
        public int GamesWon { get; set; }
        [Min(0)]
        public int GamesLost { get; set; }
        [Min(0)]
        public int GamesDrawn { get; set; }

        public int GoalsDifference => GoalsScored - GoalsLost;

        public Team() { }
        public Team(string name)
        {
            Name = name;
        }
    }
}