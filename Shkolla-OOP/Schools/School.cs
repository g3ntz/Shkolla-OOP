using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shkolla_OOP
{
    abstract class School
    {
        public string name { get; set; }
        public List<Student> students { get; set; }
        public List<Teacher> teachers { get; set; }
        public List<Subject> subjects { get; set; }
        public List<string> academicYears { get; set; }
        

        public School()
        {
            students = new List<Student>();
            teachers = new List<Teacher>();
            subjects = new List<Subject>();
            academicYears = new List<string>();
        }

        public virtual void addStudent(Student student)
        {
            // fill student subjects with every subject that exists in school subjects
            this.subjects.ForEach(x => { student.subjects.Add(new Subject(x.name)); });
            students.Add(student);
        }

        public virtual void addTeacher(Teacher teacher)
        {
            teachers.Add(teacher);
        }

        public virtual void addSubject(Subject subject)
        {
            foreach (var item in subjects)
            {
                if (item.name == subject.name)
                    return;
            }
            subjects.Add(subject);
        }

        // ADD GRADE BY STUDENT ID
        public virtual bool addStudentGrade(int studentID, string subjectName, int grade)
        {
            foreach (var student in students)
            {
                if (student.id == studentID)
                {
                    foreach (var subject in student.subjects)
                    {
                        if (subject.name == subjectName)
                        {
                            subject.grades.Add(grade);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        // ADD GRADE BY STUDENT NAME
        public virtual bool addStudentGrade(string studentName, string subjectName, int grade)
        {
            foreach (var student in students)
            {
                if (student.name + " " + student.surname == studentName)
                {
                    foreach (var subject in student.subjects)
                    {
                        if (subject.name == subjectName)
                        {
                            subject.grades.Add(grade);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public virtual bool addAcademicYear(int academicYear)
        {
            string academicYearString = academicYear + "/" + ++academicYear;
            if (!academicYears.Contains(academicYearString))
            {
                academicYears.Add(academicYearString);
                return true;
            }
            else
                return false;
        }

        public virtual List<Student> studentsSuccessForEachCycle()
        {
            foreach (var student in students)
            {
                foreach (var subject in student.subjects)
                {
                    // INIT SUBJECT averageGrade 
                    subject.calculateGradesAverage();
                }
                // INIT STUDENT averageGrade
                student.calculateGradesAverage();
            }
            return students;
        }

        public virtual List<KeyValuePair<string, int>> studentsNrByAcademicYear()
        {
            Dictionary<string, int> report = new Dictionary<string, int>();

            foreach (var academicYear in academicYears)
            {
                if (!report.ContainsKey(academicYear))
                    report.Add(academicYear, 0);
            }
            foreach (var student in students)
            {
                report[student.academicYear]++;
            }

            return report.ToList();
        }
    }
}
