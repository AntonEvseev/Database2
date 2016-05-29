using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Database
{
    class SerializationBinary
    {
        BinaryFormatter bf = new BinaryFormatter();
        public void WriteBinary(List<Person> employees)
        {
            using (FileStream fs = new FileStream("person.dat", FileMode.Create))
            {
                bf.Serialize(fs, employees);
            }
        }
    }
}
