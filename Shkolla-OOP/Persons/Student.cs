using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PersonLib;

namespace Shkolla_OOP
{
    abstract class Student : Person,IDisplayable
    {
        public static int staticID;
        public int id { get; set; }
        public int averageGrade { get; set; }
        public string academicYear { get; set; }
        public List<Subject> subjects;

        public Student(string name, string surname, int age, char gender, Address address,string academicYear) :base(name,surname,age,gender,address)
        {
            this.id = ++staticID;
            this.academicYear = academicYear;
            subjects = new List<Subject>();
        }

        public virtual void calculateGradesAverage()
        {
            int gradesAverage = 0;
            int nrOfSubjectsWithAvgGrade = 0;

            foreach (var subject in subjects)
            {
                gradesAverage += subject.averageGrade;
                if(subject.averageGrade != 0)
                    nrOfSubjectsWithAvgGrade++;
            }
            //var temp = Convert.ToInt32(Math.Round((double)gradesAverage / nrOfSubjectsWithAvgGrade, MidpointRounding.AwayFromZero));
            if (nrOfSubjectsWithAvgGrade != 0)
                this.averageGrade = Convert.ToInt32(Math.Round((double)gradesAverage / nrOfSubjectsWithAvgGrade,MidpointRounding.AwayFromZero));
        }

        public void Display()
        {
            MessageBox.Show($"Studenti u krijua\n\nEmri: {name}\nMbiemri: {surname}\n" +
                $"Mosha: {age}\nGjinia: {gender}\nViti Akademik: {academicYear}\n\nAdresa\nQyteti: {address.city}" +
                $"\nRruga: {address.streetName}\nNumri: {address.number}");
        }
    }
}
