using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_7___Examination_Management_System
{
    internal class ChooseAll : Question
    {
        public List<Answer> CorrectAnswers { get; set; }
        public ChooseAll(string header, string body, int marks, List<Answer> correctAnswers) : base(header, body, marks)
        {
            CorrectAnswers = correctAnswers;
        }
        public override bool CheckAnswer(Answer studentAnswer)
        {
            return CorrectAnswer.Equals(studentAnswer);
        }
        public bool CheckAnswers(List<Answer> studentAnswers)
        {
            if (studentAnswers.Count != CorrectAnswers.Count)
            {
                return false;
            }
            foreach (Answer answer in studentAnswers)
            {
                if (!CorrectAnswers.Contains(answer)) return false;
            }
            return true;
        }
        public override void Display()
        {
            Console.WriteLine($"{Header}: {Body} (Select All that apply)");
            foreach (Answer answer in AnswerList.answers)
                Console.WriteLine($"{answer.Id}. {answer.Text}");
        }
    }
}
