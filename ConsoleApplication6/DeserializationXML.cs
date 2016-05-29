using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Database
{
    public class DeserializationXML
    {
        public static object  D()
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Person>));         
            using (FileStream fs = new FileStream("person.xml", FileMode.OpenOrCreate))
                {
                    List<Person> employees = (List<Person>)xs.Deserialize(fs);
                    return employees;
                }
          }                  
    }
}
