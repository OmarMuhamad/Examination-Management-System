using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_7___Examination_Management_System
{
    internal class Subject
    {
        public string Name { get; set; }
        public List<Student> Students { get; private set; }


        public Subject(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or empty");
            Name = name;
            Students = new List<Student>();
        }
        public bool Enroll(Student student)
        {
            if (student == null)
                throw new ArgumentNullException("Student cannot be null");
            if (Students.Contains(student))
                return false;
            Students.Add(student);
            return true;
        }
        public void NotifyStudents(Exam exam)
        {
            if (exam == null)
                throw new ArgumentNullException("Exam cannot be null");
            foreach (Student s in Students)
                exam.ExamStarted += s.OnExamStarted;
        }
    }
}
