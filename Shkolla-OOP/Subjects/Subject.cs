using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PersonLib;

namespace Shkolla_OOP
{
    class Subject : IDisplayable
    {
        public int averageGrade { get; set; }
        public string name { get; set; }
        public List<int> grades { get; set; }

        public Subject(string name)
        {
            this.name = name;
            grades = new List<int>();
        }

        public void calculateGradesAverage()
        {
            int gradesTotal = 0;

            foreach (var grade in grades)
            {
                gradesTotal += grade;
            }

            if(grades.Count != 0)
                averageGrade = Convert.ToInt32(Math.Round((double)gradesTotal / grades.Count, MidpointRounding.AwayFromZero));
        }

        public void Display()
        {
            //GeneralDataGrid.DataGrid.Columns.Clear();
            //GeneralDataGrid.DataGrid.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Lenda", DataPropertyName = "name", Name = "name" });
            //GeneralDataGrid.DataGrid.DataSource = new List<Subject>() { this };
            MessageBox.Show($"Lenda u Krijua\nEmri i Lendes: {name}");
        }
    }
}
