using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Database
{
    class Menu
    {
        public void Show()
        {
            string line = "";
            using (StreamReader sr = new StreamReader("option.ini", System.Text.Encoding.Default))
            {
                line = sr.ReadLine();
            }
            List<Person> employees = new List<Person>();

            if (line == "xml")
            {
                if (File.Exists("person.xml"))
                {
                    employees = (List<Person>)DeserializationXML.D();
                }
            }
            if (line == "bin")
            {
                if (File.Exists("person.dat"))
                {
                    employees = (List<Person>)DeserializationBinary.ReadBinary();
                }
            }
            if (line == "bin" || line == "xml")
            {
                Console.WriteLine("Установите значение bin или xml в файле option.ini.txt");
            }
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите команду:");
                string com = Console.ReadLine();
                if (com.ToLower() == "exit")
                {
                    if (line == "xml")
                    {
                        SerializationXML s = new SerializationXML();
                        s.WriteXML(employees);
                        return;
                    }
                    else
                    {
                        SerializationBinary s = new SerializationBinary();
                        s.WriteBinary(employees);
                        return;
                    }
                }
                if (com.ToLower() == "allsee")
                {
                    if (line == "xml")
                    {
                        var res = employees.OrderBy(u => u.Name).ThenBy(u => u.Surname);
                        foreach (Person u in res)
                        {
                            Console.WriteLine("Имя: {0} Фамилия: {1} Табельный номер: {2}", u.Name, u.Surname, u.PersonnelNumber);
                        }
                        Console.ReadLine();
                        continue;
                    }
                    if (line == "bin")
                    {
                        var res = employees.OrderBy(u => u.Name).ThenBy(u => u.Surname);
                        foreach (Person u in res)
                        {
                            Console.WriteLine("Имя: {0} Фамилия: {1} Табельный номер: {2}", u.Name, u.Surname, u.PersonnelNumber);
                        }
                        Console.ReadLine();
                        continue;
                    }
                }
                if (com.ToLower() == "del")
                {
                    string t;
                    Console.WriteLine("Введите табельный номер сотрудника для удаления из базы:");
                    t = Console.ReadLine();
                    if (employees.Exists(p => p.PersonnelNumber == t))
                    {
                        for (int i = 0; i < employees.Count; i++)
                        {
                            if (employees[i].PersonnelNumber == t)
                            {
                                employees.Remove(employees[i]);
                            }
                        }
                        Console.WriteLine("Удаление прошло успешно.");
                    }
                    else
                    {
                        Console.WriteLine("Сотрудника с таким табельным номером не существует!");
                    }
                    Console.ReadKey();
                    continue;
                }
                if (com.ToLower() == "add")
                {
                    string name;
                    string surname;
                    string personnelnumber;
                    Console.WriteLine("Введите имя сотрудника:");
                    name = Console.ReadLine();
                    Console.WriteLine("Введите фамилию сотрудника:");
                    surname = Console.ReadLine();
                    Console.WriteLine("Введите табельный номер сотрудника:");
                    personnelnumber = Console.ReadLine();
                    Person p = new Person(name, surname, personnelnumber);
                    employees.Add(p);
                    continue;
                }
                if (com.ToLower() != "add")
                {
                    Console.WriteLine("Доступные команды:");
                    Console.WriteLine("\tadd создать запись сотрудника");
                    Console.WriteLine("\tdel Удалить запись сотрудника");
                    Console.WriteLine("\tallsee Просмотреть список сотрудников");
                    Console.WriteLine("\texit Выйти и сохранить данные");
                    Console.ReadKey();
                    continue;
                }
            }
       }
    }
}
