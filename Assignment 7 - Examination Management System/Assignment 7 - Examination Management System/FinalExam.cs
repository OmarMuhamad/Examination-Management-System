using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_7___Examination_Management_System
{
    internal class FinalExam : Exam
    {
        public FinalExam(int time, int numberOfQuestions, List<Question> questions, Dictionary<Question, Answer> questionAnswerDictionary, Subject subject, ExamMode examMode)
        : base(time, numberOfQuestions, questions, questionAnswerDictionary, subject, examMode) { }

        public override void ShowExam()
        {
            Console.WriteLine("=== Final Exam ===");
            foreach (Question question in Questions)
            {
                question.Display();
            }
        }
        public override void Finish()
        {
            base.Finish();
            Console.WriteLine("=== Exam Submitted ===");
            foreach (KeyValuePair<Question, Answer> entry in QuestionAnswerDictionary)
            {
                Question question = entry.Key;
                Answer studentAnswer = entry.Value;
                Console.WriteLine($"Q: {question.Body}");
                Console.WriteLine($"Your Answer: {studentAnswer.Text}");
                Console.WriteLine("------------------");
            }
        }
    }
}
