using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_7___Examination_Management_System
{
    internal class QuestionList : List<Question>
    {
        private string fileName;
        public QuestionList(string filename)
        {
            fileName = filename;
        }
        public new void Add(Question question)
        {
            base.Add(question);

            using (StreamWriter writer = new StreamWriter(fileName, append: true))
            {
                writer.WriteLine("================================");
                writer.WriteLine(question.ToString());
                writer.WriteLine("================================");
            }
        }
    }
}
