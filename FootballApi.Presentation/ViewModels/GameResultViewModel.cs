using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using DataAnnotationsExtensions;

namespace FootballApi.Presentation.ViewModels
{
    public class GameResultViewModel
    {
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public int HomeGoals { get; set; }
        public int AwayGoals { get; set; }
        public string Result { get; set; }
    }

    public class PostGameResultViewModel
    {
        [Required]
        [Min(0)]
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