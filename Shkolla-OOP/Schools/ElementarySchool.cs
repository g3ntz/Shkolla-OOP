using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shkolla_OOP
{
    class ElementarySchool : School
    {
        public ElementarySchool()
        {

        }

        public List<KeyValuePair<int, int>> showStudentsStatistics()
        {
            IDictionary<int, int> numberNames = new Dictionary<int, int>();
            var grades = new Dictionary<int, int>(){
                {1, 0},
                {2, 0},
                {3, 0},
                {4, 0},
                {5,0}
            };
            studentsSuccessForEachCycle();
            foreach (var student in students)
            {
                if (student.averageGrade != 0)
                    grades[student.averageGrade]++;
            }
            return grades.ToList();
        }
    }
}
