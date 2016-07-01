using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAnnotationsExtensions;

namespace FootballApi.Domain.Models
{
    public class Game
    {
        [Key]
        public int? Id { get; set; }

        [Required]
        [Min(0)]
        public int GameWeek { get; set; }

        [Required]
        public string HomeTeamId { get; set; }
        [Required]
        public Team HomeTeam { get; set; }

        [Required]
        public string AwayTeamName { get; set; }
        [Required]
        public Team AwayTeam { get; set; }

        [Required]
        [Min(0)]
        public int HomeGoals { get; set; }

        [Required]
        [Min(0)]
        public int AwayGoals { get; set; }
    }
}