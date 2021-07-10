using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PersonLib;

namespace Shkolla_OOP
{
    class Teacher : Person,IDisplayable
    {
        public Teacher(string name, string surname, int age, char gender, Address address) : base(name, surname, age, gender, address)
        {
        }

        public void Display()
        {
            MessageBox.Show($"Mesuesi u krijua\n\nEmri: {name}\nMbiemri: {surname}\n" +
                $"Mosha: {age}\nGjinia: {gender}\n\nAdresa\n\nQyteti: {address.city}" +
                $"\nRruga: {address.streetName}\nNumri: {address.number}");
        }
    }
}
