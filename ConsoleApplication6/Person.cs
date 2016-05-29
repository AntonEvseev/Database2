using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Database
{
    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PersonnelNumber { get; set; }
        public Person()
        { }
        public Person(string name, string surname, string personnelnumber)
        {
            Name = name;
            Surname = surname;
            PersonnelNumber = personnelnumber;
        }
    }
}
