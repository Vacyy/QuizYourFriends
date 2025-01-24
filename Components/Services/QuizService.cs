using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace QuizYourFriendsWebApp
{
    internal class QuizService
    {
        private readonly ContextDB _context;
        public QuizService(ContextDB context)
        {
            _context = context;
        }
        public void AddQuizWithCascade(Quiz quiz)
        {
            if (quiz == null)
                throw new ArgumentNullException(nameof(quiz));

            _context.Quizzes.Add(quiz);
            _context.SaveChanges();
        }
        public async Task DeleteQuiz(int quizId)
        {
                var quiz = (from q in _context.Quizzes
                            where q.Id == quizId
                            select q).FirstOrDefault();

                _context.Quizzes.Remove(quiz);
                _context.SaveChanges();
        }
        public void DeleteQuestion(string content)
        {
            Console.WriteLine(content);
            Console.ReadLine();
            var questionInDB = (from q in _context.Questions where q.Content == content select q).FirstOrDefault();
            Console.WriteLine(questionInDB);
            Console.ReadLine();
            _context.Questions.Remove(questionInDB);

            _context.SaveChanges();
        }
    }
}