using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonLib;

namespace Shkolla_OOP
{
    class Person
    {
        public string name { get; set; }
        public string surname { get; set; }
        public int age { get; set; }
        public char gender { get; set; } 
        public Address address { get; set; }

        public Person(string name,string surname,int age,char gender,Address address)
        {
            this.name = name;
            this.surname = surname;
            this.age = age;
            this.gender = gender;
            this.address = address;
        }
    }
}
