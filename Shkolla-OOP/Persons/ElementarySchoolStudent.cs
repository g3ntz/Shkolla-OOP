using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shkolla_OOP
{
    class ElementarySchoolStudent : Student
    {
        public ElementarySchoolStudent(string name, string surname, int age, char gender, Address address, string academicYear) :base(name, surname, age, gender, address, academicYear)
        {
        }
    }
}
