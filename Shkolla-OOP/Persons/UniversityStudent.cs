using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shkolla_OOP
{
    class UniversityStudent : Student
    {
        public string course { get; set; }

        public UniversityStudent(string name, string surname, int age, char gender, Address address,string academicYear,string course) : base(name,surname,age,gender,address,academicYear)
        {
            this.course = course;
        }
    }
}
