using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Database
{
    class DeserializationBinary
    {
        public static object ReadBinary()
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream("person.dat", FileMode.OpenOrCreate))
            {
                List<Person> employees = (List<Person>)bf.Deserialize(fs);
                return employees;
            }
        }
    }
}
