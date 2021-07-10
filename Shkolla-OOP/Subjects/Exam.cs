using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shkolla_OOP
{
    class Exam
    {
        public Student student { get; set; }
        public Subject subject { get; set; }
        public int examPoints { get; set; }

        public Exam(Student student, Subject subject, int examPoints)
        {
            this.student = student;
            this.subject = subject;
            this.examPoints = examPoints;
        }
    }
}
