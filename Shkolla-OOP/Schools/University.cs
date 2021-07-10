using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shkolla_OOP
{
    class University : School, ICourse
    {
        public List<string> courses { get; set; }
        public List<ExamPeriod> examPeriods { get; set; }

        public University()
        {
            courses = new List<string>();
            examPeriods = new List<ExamPeriod>();
        }

        public void generateExamPeriods()
        {
            if (!examPeriods.Any())
            {
                for (int i = 0; i < 10; i += 2)
                {
                    examPeriods.Add(new ExamPeriod(new DateTime(2020, 01, 01).AddMonths(i)));
                }
            }
        }

        public bool submitStudentExams(int studentID, List<Subject> subjectsToAttend)
        {
            foreach (var examPeriod in examPeriods)
            {
                // THE SUBMITED EXAM IS VALIDATED WITH CURRENT DATE
                // THE SUBMITED EXAM WILL BE VALIDATED AND AUTOMATICALLY ADDED TO AN EXAM PERIOD
                // IF CURRENT MONTH IS JULY AND THERE IS AN EXAM PERIOD IN JULY, THE EXAM WILL BE ADDED IN JULY PERIOD BUT NOT JUNE OR AUGUST
                if (DateTime.Now.Month <= examPeriod.date.Month)
                {
                    foreach (var subject in subjectsToAttend)
                    {
                        if (!examPeriod.subjects.Contains(subject.name))
                            return false;
                    }
                    examPeriod.studentSubjectsToAttend[studentID] = subjectsToAttend;
                    return true;
                }
            }
            return false;
        }

        public void addRandomExams()
        {
            foreach (var period in examPeriods)
            {
                Random rnd = new Random();
                if(period.studentSubjectsToAttend.Any())
                {
                    var studentSubjects = period.studentSubjectsToAttend.LastOrDefault();
                    foreach (var value in studentSubjects.Value)
                    {
                        var student = getStudentByID(studentSubjects.Key);
                        if (student != null)
                            period.exams.Add(new Exam(student, value, rnd.Next(0, 100)));
                    }
                }
            }
        }

        public Student getStudentByID(int studentID)
        {
            foreach (var student in students)
            {
                if (student.id == studentID)
                    return (UniversityStudent)student;
            }
            return null;
        }

        public List<Exam> passedExamsOfStudent(int studentID)
        {
            var passedExams = new List<Exam>();
            foreach (var period in examPeriods)
            {
                foreach (var exam in period.exams)
                {
                    if (exam.student.id == studentID && exam.examPoints >= 50)
                        passedExams.Add(exam);
                }
            }
            return passedExams;
        }

        public List<KeyValuePair<string,int>> nrOfSubjectPassedExams()
        {
            Dictionary<string, int> passedExamsNr = new Dictionary<string, int>();
            foreach (var period in examPeriods)
            {
                foreach (var exam in period.exams)
                {
                    if (!passedExamsNr.ContainsKey(exam.subject.name))
                    {
                        if (exam.examPoints >= 50)
                            passedExamsNr.Add(exam.subject.name, 1);
                        else
                            passedExamsNr.Add(exam.subject.name, 0);
                    }
                    else
                    {
                        if (exam.examPoints >= 50)
                            passedExamsNr[exam.subject.name]++;
                    }
                }
            }
            return passedExamsNr.ToList();
        }

        public List<KeyValuePair<string, int>> studentsReportByCourse()
        {
            IDictionary<string, int> coursesReport = new Dictionary<string, int>();

            foreach (var course in courses)
            {
                if (!coursesReport.ContainsKey(course))
                    coursesReport.Add(course, 0);
            }
            foreach (var student in students.Cast<UniversityStudent>())
            {
                coursesReport[student.course]++;
            }
            return coursesReport.ToList();
        }

        //FROM "ICourseOperations" INTERFACE
        public bool addCourse(string courseName)
        {
            if (!courses.Contains(courseName))
            {
                courses.Add(courseName);
                return true;
            }
            return false;
        }
    }
}
