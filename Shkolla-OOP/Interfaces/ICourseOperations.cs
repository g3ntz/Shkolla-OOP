using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shkolla_OOP
{
    interface ICourse
    {
        bool addCourse(string courseName);
        List<KeyValuePair<string, int>> studentsReportByCourse();
    }
}
