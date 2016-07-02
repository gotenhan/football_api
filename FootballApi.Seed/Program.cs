using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballApi.Data;
using FootballApi.Domain.Models;

namespace FootballApi.Seed
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(@"Seeding database");

            var teams = new Team[]
            {
                new Team("Arsenal"),
                new Team("Aston Villa"),
                new Team("AwayTeam"),
                new Team("Bournemouth"),
                new Team("Chelsea"),
                new Team("Crystal Palace"),
                new Team("Everton"),
                new Team("Leicester"),
                new Team("Liverpool"),
                new Team("Man City"),
                new Team("Man United"),
                new Team("Newcastle"),
                new Team("Norwich"),
                new Team("Southampton"),
                new Team("Stoke"),
                new Team("Sunderland"),
                new Team("Swansea"),
                new Team("Tottenham"),
                new Team("Watford"),
                new Team("West Brom"),
                new Team("West Ham"),
            };

            var dbContext = new FootballApiContext();
            dbContext.Teams.Load();
            foreach (var team in teams)
            {
                if (dbContext.Teams.Find(team.Name) != null)
                {
                    Console.WriteLine($"Team {team.Name} already exists, skipping");
                }
                else
                {
                    Console.WriteLine($"Adding {team.Name}");
                    dbContext.Teams.Add(team);
                }
            }

            dbContext.SaveChanges();

            Console.WriteLine("Press any key");
            Console.ReadKey();
        }
    }
}
