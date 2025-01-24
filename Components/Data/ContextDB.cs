using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace QuizYourFriendsWebApp
{
    internal class ContextDB : DbContext
    {
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=QuizDB;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Question>()
                .HasOne(q => q.Quiz)
                .WithMany(qz => qz.Questions)
                .HasForeignKey(q => q.QuizId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Answer>()
                .HasOne(a => a.Question)
                .WithMany(q => q.Answers)
                .HasForeignKey(a => a.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);

                SeedData(modelBuilder);
        }
        private void SeedData(ModelBuilder modelBuilder)
        {
            // Quiz
            var quiz1 = new Quiz { Id = 1, Name = "Matematyka" };
            var quiz2 = new Quiz { Id = 2, Name = "Historia" };

            // Questions dla quizu 1
            var question1 = new Question { Id = 1, Content = "Ile to 2 + 2?", QuizId = 1 };
            var question2 = new Question { Id = 2, Content = "Ile to 3 + 3?", QuizId = 1 };

            // Questions dla quizu 2
            var question3 = new Question { Id = 3, Content = "Kto był pierwszym królem Polski?", QuizId = 2 };

            // Answers dla pytania 1
            var answers1 = new[]
            {
            new Answer { Id = 1, Content = "3", Correct = false, QuestionId = 1 },
            new Answer { Id = 2, Content = "4", Correct = true, QuestionId = 1 },
            new Answer { Id = 3, Content = "5", Correct = false, QuestionId = 1 }
            };

            // Answers dla pytania 2
            var answers2 = new[]
            {
                    new Answer { Id = 4, Content = "5", Correct = false, QuestionId = 2 },
                    new Answer { Id = 5, Content = "6", Correct = true, QuestionId = 2 },
                    new Answer { Id = 6, Content = "7", Correct = false, QuestionId = 2 }
            };

            // Answers dla pytania 3
            var answers3 = new[]
            {
                    new Answer { Id = 7, Content = "Mieszko I", Correct = false, QuestionId = 3 },
                    new Answer { Id = 8, Content = "Bolesław Chrobry", Correct = true, QuestionId = 3 },
                    new Answer { Id = 9, Content = "Kazimierz Wielki", Correct = false, QuestionId = 3 }
            };

            // Dodanie danych do modelu
            modelBuilder.Entity<Quiz>().HasData(quiz1, quiz2);
            modelBuilder.Entity<Question>().HasData(question1, question2, question3);
            modelBuilder.Entity<Answer>().HasData(answers1);
            modelBuilder.Entity<Answer>().HasData(answers2);
            modelBuilder.Entity<Answer>().HasData(answers3);
        }
    }
}
