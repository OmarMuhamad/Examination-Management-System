using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_7___Examination_Management_System
{
    internal class PracticeExam : Exam
    {
        public PracticeExam(int time, int numberOfQuestions, List<Question> questions, Dictionary<Question, List<Answer>> questionAnswerDictionary, Subject subject, ExamMode examMode)
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
            using (StreamWriter writer = new StreamWriter($"PracticalExamResult{this.Subject.Name}.txt", append: false))
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
                        Console.WriteLine($"Correct Answers: {string.Join(", ", chooseAll.CorrectAnswers.Select(a => a.Text))}");
                        writer.WriteLine($"Correct Answers: {string.Join(", ", chooseAll.CorrectAnswers.Select(a => a.Text))}");

                        if (chooseAll.CheckAnswers(studentAnswers))
                        {
                            totalScore += question.Marks;
                            Console.WriteLine("Correct!");
                            writer.WriteLine("Correct!");
                        }
                        else
                        {

                            Console.WriteLine("Wrong!");
                            writer.WriteLine("Wrong!");
                        } 
                    }
                    else
                    {
                        Console.WriteLine($"Your Answer:    {studentAnswers[0].Text}");
                        writer.WriteLine($"Your Answer:    {studentAnswers[0].Text}");
                        Console.WriteLine($"Correct Answer: {question.CorrectAnswer.Text}");
                        writer.WriteLine($"Correct Answer: {question.CorrectAnswer.Text}");

                        if (question.CheckAnswer(studentAnswers[0]))
                        {
                            totalScore += question.Marks;
                            Console.WriteLine("Correct!");
                            writer.WriteLine("Correct!");
                        }
                        else
                        {
                            Console.WriteLine("Wrong!");
                            writer.WriteLine("Wrong!");
                        } 
                    }
                    Console.WriteLine("------------------");
                    writer.WriteLine("------------------");
                }
                Console.WriteLine($"Final Grade: {totalScore}");
                writer.WriteLine($"Final Grade: {totalScore}");
            }
            
        }
    }
}
