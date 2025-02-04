using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_02
{
    internal class TrueOrFalse :Question
    {
        public int CorrectAnswer { get; set; }
        public TrueOrFalse(string header, string body, int marks, int correctAnswer) : base(header, body, marks)
        {
            CorrectAnswer = correctAnswer;
        }
        public override bool ValidateAnswer(object answer)
        {
            return answer.Equals(CorrectAnswer);
        }
    }
}
