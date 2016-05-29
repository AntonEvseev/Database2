using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Database
{
    public class SerializationXML
    {
        XmlSerializer xs = new XmlSerializer(typeof(List<Person>));
        public void WriteXML(List<Person> employees)
        {
            using (FileStream fs = new FileStream("person.xml", FileMode.Create))
            {
                xs.Serialize(fs, employees);
            }
        }
    }
}
