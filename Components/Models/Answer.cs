using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizYourFriendsWebApp
{
    public class Answer
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool Correct { get; set; }
        public int QuestionId { get; set; }
        public Question? Question { get; set; }
        public Answer() { }
        public Answer(string content, bool correct)
        {
            Content = content;
            Correct = correct;
        }
    }
}
