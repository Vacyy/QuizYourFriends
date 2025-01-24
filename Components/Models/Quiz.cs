using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizYourFriendsWebApp
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Question>? Questions { get; set; }
        public Quiz()
        {
            Questions = new List<Question>();
        }

        public Quiz(string name, List<Question> questions)
        {
            Name = name;
            Questions = questions;
        }
    }
}
