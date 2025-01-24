using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace QuizYourFriendsWebApp
{
    internal class QuizReader
    {
        private readonly ContextDB _context;

        public QuizReader(ContextDB context)
        {
            _context = context;
        }

        public async Task<List<Quiz>> ReadAllAsync()
        {
            try
            {
                {
                    return await _context.Quizzes
                        .Include(q => q.Questions)
                        .ThenInclude(q => q.Answers)
                        .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił błąd podczas odczytu quizów z bazy danych: {ex.Message}");
                return new List<Quiz>();
            }
        }
        public async Task<Quiz> ReadByIdAsync(int id, bool dropId = false)
        {
            try
            {

                Quiz quiz = await _context.Quizzes
                    .Where(q => q.Id == id)
                    .Include(q => q.Questions)
                    .ThenInclude(q => q.Answers)
                    .FirstOrDefaultAsync();
                if (quiz != null && dropId)
                {
                    quiz.Id = 0;
                    foreach (var question in quiz.Questions)
                    {
                        question.Id = 0;
                        foreach (var answer in question.Answers)
                        {
                            answer.Id = 0;
                        }
                    }
                }
                return quiz;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił błąd podczas odczytu nazw quizów z bazy danych: {ex.Message}");
                return new Quiz();
            }
        }
    }
}
