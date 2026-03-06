using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_7___Examination_Management_System
{
    internal class FinalExam : Exam
    {
        public FinalExam(int time, int numberOfQuestions, List<Question> questions, Dictionary<Question, List<Answer>> questionAnswerDictionary, Subject subject, ExamMode examMode)
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
            using (StreamWriter writer = new StreamWriter($"FinalExamResult_{this.Subject.Name}.txt", append: false))
            {  
                base.Finish();

                Console.WriteLine("=== Exam Results ===");
                writer.WriteLine("=== Exam Results ===");
                int totalScore = 0;

                foreach (var entry in QuestionAnswerDictionary)
                {
                    Question question = entry.Key;
                    List<Answer> studentAnswers = entry.Value;

                    Console.WriteLine($"{question.Header}: {question.Body}");
                    writer.WriteLine($"{question.Header}: {question.Body}");

                    if (question is ChooseAll chooseAll)
                    {
                        Console.WriteLine($"Your Answers: {string.Join(", ", studentAnswers.Select(a => a.Text))}");
                        writer.WriteLine($"Your Answers: {string.Join(", ", studentAnswers.Select(a => a.Text))}");
                    }
                    else
                    {
                        Console.WriteLine($"Your Answer: {studentAnswers[0].Text}");
                        writer.WriteLine($"Your Answer: {studentAnswers[0].Text}");
                    }
                    Console.WriteLine("------------------");
                    writer.WriteLine("------------------");
                }
            }
            
        }
    }
}
