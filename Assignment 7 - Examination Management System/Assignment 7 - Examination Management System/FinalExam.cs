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
            using (StreamWriter writer = new StreamWriter($"FinalExamResult_{this.Subject.Name}.txt", append: false))
            {  
                base.Finish();

                Console.WriteLine("=== Exam Results ===");
                writer.WriteLine("=== Exam Results ===");
                int totalScore = 0;

                foreach (var entry in QuestionAnswerDictionary)
                {
                    Question question = entry.Key;
                    Answer studentAnswer = entry.Value;

                    Console.WriteLine($"{question.Header}: {question.Body}");
                    writer.WriteLine($"{question.Header}: {question.Body}");

                    if (question is ChooseAll chooseAll)
                    {
                        Console.WriteLine($"Your Answers: {string.Join(", ", studentAnswer.Text)}");
                        writer.WriteLine($"Your Answers: {string.Join(", ", studentAnswer.Text)}");
                    }
                    else
                    {
                        Console.WriteLine($"Your Answer: {studentAnswer.Text}");
                        writer.WriteLine($"Your Answer: {studentAnswer.Text}");
                    }
                    Console.WriteLine("------------------");
                    writer.WriteLine("------------------");
                }
            }
            
        }
    }
}
