using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_02
{
    internal abstract class Question
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Marks { get; set; }
        public List<Answer> Answers { get; set; } = new List<Answer>();
        public int CorrectAnswer { get; set; }

        public Question(string header, string body, int marks)
        {
            Header = header;
            Body = body;
            Marks = marks;
        }

        public abstract bool ValidateAnswer(object answer);
    }
}
