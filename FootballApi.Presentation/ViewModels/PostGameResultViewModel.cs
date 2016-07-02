using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions;

namespace FootballApi.Presentation.ViewModels
{
    public class PostGameResultViewModel
    {
        [Required]
        [Min(0), Max(38)]
        public int GameWeek { get; set; }

        [Required]
        [StringLength(200)]
        public string HomeTeam { get; set; }

        [StringLength(200)]
        public string AwayTeam { get; set; }

        [Required]
        [Min(0)]
        public int HomeGoals { get; set; }

        [Required]
        [Min(0)]
        public int AwayGoals { get; set; }
    }
}