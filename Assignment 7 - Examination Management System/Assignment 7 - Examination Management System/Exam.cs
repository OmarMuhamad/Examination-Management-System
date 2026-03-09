using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_7___Examination_Management_System
{
    internal abstract class Exam : IComparable<Exam>, ICloneable, IExamBehavior
    {
        public int Time { get; private set; }
        public int NumberOfQuestions { get; private set; }
        public List<Question> Questions { get; private set; }
        public Subject Subject { get; private set; }
        public Dictionary<Question, Answer> QuestionAnswerDictionary  { get; set;}
        public ExamMode ExamMode { get; set; }

        public event ExamStartedHandler ExamStarted; // eventhandler


        public Exam(int time, int numberOfQuestions, List<Question> questions,
                Dictionary<Question, Answer> questionAnswerDictionary,
                Subject subject, ExamMode examMode)
        {
            if (time <= 0)
                throw new ArgumentException("Time must be greater than 0");
            if (numberOfQuestions <= 0)
                throw new ArgumentException("Number of questions must be greater than 0");
            if (questions == null)
                throw new ArgumentNullException("Questions cannot be null");
            if (questionAnswerDictionary == null)
                throw new ArgumentNullException("QuestionAnswerDictionary cannot be null");
            if (subject == null)
                throw new ArgumentNullException("Subject cannot be null");

            Time = time;
            NumberOfQuestions = numberOfQuestions;
            QuestionAnswerDictionary = questionAnswerDictionary;
            Questions = questions;
            Subject = subject;
            ExamMode = examMode;
        }

        public abstract void ShowExam();
        public virtual void Start()
        {
            OnExamStarted(new ExamEventArgs(Subject, this)) ;
            ExamMode = ExamMode.Starting;
        }
        public virtual void Finish()
        {
            ExamMode = ExamMode.Finished;
        }
        protected virtual void OnExamStarted(ExamEventArgs e)
        {
            ExamStarted?.Invoke(this, e);
        }
        public void CorrectExam(){
            int totalScore = 0;
            foreach(KeyValuePair<Question, Answer> q in QuestionAnswerDictionary)
            {
                if (q.Key is ChooseAll chooseAll)
                {
                    if (chooseAll.CheckAnswer(q.Value)) // pass to it the student Answers
                        totalScore += q.Key.Marks;
                }
                else
                {
                    if (q.Key.CorrectAnswer.Equals(q.Value))
                        totalScore += q.Key.Marks;
                }
            }
            Console.WriteLine($"Total Score: {totalScore}");
        }
        public override string ToString()
        {
            return $"Exam | Time: {Time} | Questions: {NumberOfQuestions} | Mode: {ExamMode}";
        }
        public override bool Equals(object? obj)
        {
            if (obj is Exam other)
                return this.Time == other.Time && this.NumberOfQuestions == other.NumberOfQuestions;
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Time, NumberOfQuestions);
        }
        public int CompareTo(Exam? other)
        {
            int timeComparison = this.Time.CompareTo(other?.Time);
            if (timeComparison != 0)
                return timeComparison;

            return this.NumberOfQuestions.CompareTo(other?.NumberOfQuestions);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
