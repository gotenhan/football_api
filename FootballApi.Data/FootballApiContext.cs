using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballApi.Domain.Models;

namespace FootballApi.Data
{
    public class FootballApiContext: DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<GameResult> GameResults { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>()
                .HasKey(t => t.Name)
                .Ignore(t => t.GoalsDifference);

            modelBuilder.Entity<GameResult>()
                .HasKey(gr => gr.Id);

            modelBuilder.Entity<GameResult>()
                .HasRequired(gr => gr.HomeTeam)
                .WithMany()
                .HasForeignKey(gr => gr.HomeTeamName)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GameResult>()
                .HasRequired(gr => gr.AwayTeam)
                .WithMany()
                .HasForeignKey(gr => gr.AwayTeamName)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GameResult>()
                .Property(gr => gr.GameWeek)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_GameWeek")));

            modelBuilder.Entity<GameResult>()
                .Property(gr => gr.GameWeek)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_GameResultUnique", 1) {IsUnique = true}));
            modelBuilder.Entity<GameResult>()
                .Property(gr => gr.HomeTeamName)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_GameResultUnique", 2) {IsUnique = true}));
            modelBuilder.Entity<GameResult>()
                .Property(gr => gr.AwayTeamName)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_GameResultUnique", 3) {IsUnique = true}));

            base.OnModelCreating(modelBuilder);
        }
    }
}
