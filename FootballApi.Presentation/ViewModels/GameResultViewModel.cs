using System.Runtime.CompilerServices;

namespace FootballApi.Presentation.ViewModels
{
    public class GameResultViewModel
    {
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public int HomeGoals { get; set; }
        public int AwayGoals { get; set; }

        public string Result => HomeGoals == AwayGoals
            ? "Draw"
            : (HomeGoals > AwayGoals ? "Home Win" : "Away Win");

    }
}