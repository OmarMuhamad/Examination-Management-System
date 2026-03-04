using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_7___Examination_Management_System
{
    internal class PracticeExam : Exam
    {
        public PracticeExam(int time, int numberOfQuestions, List<Question> questions, Dictionary<Question, Answer> questionAnswerDictionary, Subject subject, ExamMode examMode)
        : base(time, numberOfQuestions, questions, questionAnswerDictionary, subject, examMode) { }

        public override void ShowExam()
        {
            Console.WriteLine("=== Practice Exam ===");
            foreach (Question question in Questions)
            {
                question.Display();
            }
        }
        public override void Finish()
        {
            base.Finish(); 

            Console.WriteLine("=== Exam Results ===");
            int totalScore = 0;

            foreach (var entry in QuestionAnswerDictionary)
            {
                Question question = entry.Key;
                Answer studentAnswer = entry.Value;

                Console.WriteLine($"Q: {question.Body}");
                Console.WriteLine($"Your Answer:    {studentAnswer.Text}");
                Console.WriteLine($"Correct Answer: {question.CorrectAnswer.Text}");

                if (question.CheckAnswer(studentAnswer))
                {
                    totalScore += question.Marks;
                    Console.WriteLine("Correct!");
                }
                else
                {
                    Console.WriteLine("Wrong!");
                }
                Console.WriteLine("------------------");
            }
            Console.WriteLine($"Final Grade: {totalScore}");
        }
    }
}
