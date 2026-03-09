namespace Assignment_7___Examination_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Create a Subject
            Subject math = new Subject("math");

            // 2. Create Students and enroll them
            Student student1 = new Student("Omar Mohammed", 1);
            Student student2 = new Student("Hesham Ehab", 2);
            Student student3 = new Student("Lewis Hamilton", 3);

            math.Enroll(student1);
            math.Enroll(student2);
            math.Enroll(student3);

            // 3. Create Questions

            // TrueFalse Question
            TFQuestion q1 = new TFQuestion("Q1", "Is 3 an odd number? ", 10, new Answer(1, "True"));
            q1.AnswerList.Add(new Answer(1, "True"));
            q1.AnswerList.Add(new Answer(2, "False"));

            // ChooseOne Question
            ChooseOneQuestion q2 = new ChooseOneQuestion("Q2", "What is 2 + 2?", 10, new Answer(2, "4"));
            q2.AnswerList.Add(new Answer(1, "3"));
            q2.AnswerList.Add(new Answer(2, "4"));
            q2.AnswerList.Add(new Answer(3, "5"));

            // ChooseAll Question
            ChooseAll q3 = new ChooseAll("Q3", "Which are even numbers?", 10, new Answer(1, "1 3 5"));
            q3.AnswerList.Add(new Answer(1, "2"));
            q3.AnswerList.Add(new Answer(2, "3"));
            q3.AnswerList.Add(new Answer(3, "4"));
            q3.AnswerList.Add(new Answer(4, "5"));
            q3.AnswerList.Add(new Answer(5, "6"));

            // 4. Add questions to QuestionList (logs to file)
            QuestionList questionList = new QuestionList($"questions_{math.Name}.txt");
            questionList.Add(q1);
            questionList.Add(q2);
            questionList.Add(q3);

            // 5. Create Exams
            Dictionary<Question, Answer> answerDict = new Dictionary<Question, Answer>();

            PracticeExam practiceExam = new PracticeExam(
                30,
                questionList.Count,
                questionList,
                answerDict,
                math,
                ExamMode.Queued
            );

            FinalExam finalExam = new FinalExam(
                60,
                questionList.Count,
                questionList,
                answerDict,
                math,
                ExamMode.Queued
            );

            // 6. choosing type of exam
            int exType;
            do
            {
                Console.WriteLine("Select Exam Type:");
                Console.WriteLine("1 - Practice");
                Console.WriteLine("2 - Final");
            } while (!int.TryParse(Console.ReadLine(), out exType) || (exType < 1 || exType > 2));

            Exam selectedExam = exType == 1 ? practiceExam : finalExam;

            // 7. Notify students and start exam
            math.NotifyStudents(selectedExam);
            selectedExam.Start();

            // 8. Show exam and take answers
            selectedExam.ShowExam();

            foreach (Question question in selectedExam.Questions)
            {
                Console.WriteLine();
                question.Display();
                int numberOfAnswers = question.AnswerList.Count;

                if (question is ChooseAll)
                {
                    var selectedIds = new List<int>();

                    Console.WriteLine("Enter answer IDs one by one, enter 0 to finish:");

                    do
                    {
                        Console.Write("Enter answer ID: ");

                        if (!int.TryParse(Console.ReadLine(), out int ans))
                        {
                            Console.WriteLine("Invalid input, please enter a number.");
                            continue;
                        }

                        if (ans == 0) break;

                        if (ans < 1 || ans > question.AnswerList.Count)
                        {
                            Console.WriteLine($"Please enter a number between 1 and {question.AnswerList.Count}.");
                            continue;
                        }

                        if (selectedIds.Contains(ans))
                        {
                            Console.WriteLine("You already selected that answer.");
                            continue;
                        }

                        selectedIds.Add(ans);
                        Console.WriteLine($"Answer {ans} added.");

                    } while (true);

                    string studentAnswer = string.Join(" ", selectedIds); // extension method
                    selectedExam.QuestionAnswerDictionary[question] = new Answer(1, studentAnswer);
                }
                else
                {
                    int ans = 0;
                    do
                    {
                        Console.Write("Enter answer ID: ");
                    } while (!int.TryParse(Console.ReadLine(), out ans) || ans < 1 || ans > numberOfAnswers);

                    selectedExam.QuestionAnswerDictionary[question] = question.AnswerList.GetById(ans);
                }

                Console.WriteLine("\n------------------");
            }

            // 9. Finish exam
            selectedExam.Finish();

            // 10. Generic Repository Demo
            Console.WriteLine("\n=== Repository Demo ===");
            GenericRepository<Exam> examRepository = new GenericRepository<Exam>(5);
            examRepository.Add(practiceExam);
            examRepository.Add(finalExam);

            Console.WriteLine("All Exams (sorted):");
            examRepository.Sort();
            foreach (Exam exam in examRepository.GetAll())
                Console.WriteLine(exam.ToString());
        }
    }
}