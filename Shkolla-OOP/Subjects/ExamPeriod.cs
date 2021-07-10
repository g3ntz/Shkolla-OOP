using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PersonLib;

namespace Shkolla_OOP
{
    class ExamPeriod : IDisplayable
    {
        public DateTime date { get; set; }
        public List<string> subjects { get; set; }
        public List<Exam> exams { get; set; }
        public Dictionary<int, List<Subject>> studentSubjectsToAttend;
   

        public ExamPeriod(DateTime date)
        {
            subjects = new List<string>();
            exams = new List<Exam>();
            studentSubjectsToAttend = new Dictionary<int, List<Subject>>();
            this.date = date;
        }

        public string getPeriodMonth()
        {
            return date.ToString("MMMM");
        }

        public void addSubject(string subjectName)
        {
            if (!subjects.Contains(subjectName))
            {
                subjects.Add(subjectName);
            }       
        }

        public void Display()
        {
            MessageBox.Show($"U shtua Lenda ne afatin {getPeriodMonth()}\nEmri i Lendes: {subjects.Last()}");
        }
    }
}
