using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shkolla_OOP
{
    class HighSchool : School, ICourse
    {
        public List<string> courses { get; set; }

        public HighSchool()
        {
            courses = new List<string>();
        }

        public bool addCourse(string courseName)
        {
            if (!courses.Contains(courseName))
            {
                courses.Add(courseName);
                return true;
            }
            return false;
        }

        public List<KeyValuePair<string,int>> studentsReportByCourse()
        {
            IDictionary<string, int> coursesReport = new Dictionary<string, int>();

            foreach (var course in courses)
            {
                if (!coursesReport.ContainsKey(course))
                    coursesReport.Add(course, 0);
            }
            foreach (var student in students.Cast<HighSchoolStudent>())
            {
                coursesReport[student.course]++;
            }
            return coursesReport.ToList();
        }
    }
}
