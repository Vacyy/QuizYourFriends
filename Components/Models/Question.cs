using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizYourFriendsWebApp
{
    public class Question
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int QuizId { get; set; }
        public Quiz? Quiz { get; set; }
        public List<Answer>? Answers { get; set; }

        public Question()
        {
            Answers = new List<Answer>();
        }
        public Question(string content, List<Answer> answers)
        {
            Content = content;
            Answers = answers;
        }
    }
}
