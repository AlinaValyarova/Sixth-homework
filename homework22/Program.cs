using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace homework22
{
    class ChildrenGarden
    {

        //методы
        public static string Print()
        {
            Console.WriteLine("1 - print list of kids in a group");
            Console.WriteLine("2 - Add a new kid");
            Console.WriteLine("3 - delete a kid");
            Console.WriteLine("4 - print list of Stuff");
            Console.WriteLine("5 - Fire member of stuff");
            return "";
        }
        static public void PrintList(List<kid> lists)
        {
            for (int i = 0; i < lists.Count; i++)
            {

                kid person = lists[i];
                Console.WriteLine("Name: " + person.FirstName + " " + person.SecondName + " Age: " + person.Age);
                continue;
            }
        }

        static public void PrintList2(List<stuff> lists2)
        {
            for (int i = 0; i < lists2.Count; i++)
            {

                stuff person = lists2[i];
                Console.WriteLine("Name: " + person.FirstName + " " + person.SecondName + " Number of group: " + person.Num);
                continue;
            }
        }
        public static void ReadList(List<kid> first, List<kid> second, List<kid> third, List<kid> fourth, string txt)
        {

            using (StreamReader reader = new StreamReader(txt))
            {
                while (!reader.EndOfStream)
                {
                    kid person = new kid();
                    string text = reader.ReadLine();
                    string[] guests = new string[3];
                    guests = text.Split(" ");
                    person.FirstName = guests[0];
                    person.SecondName = guests[1];
                    person.Age = int.Parse(guests[2]);

                    switch (person.Age)
                    {
                        case 3:
                            first.Add(person);
                            continue;

                        case 4:
                            second.Add(person);
                            continue;

                        case 5:
                            third.Add(person);
                            continue;

                        case 6:
                            fourth.Add(person);
                            continue;
                    }

                }

            }
        }
        public static void Readtechers(List<stuff> spisok, string txt)
        {

            using (StreamReader reader = new StreamReader(txt))
            {
                while (!reader.EndOfStream)
                {
                    stuff person = new stuff();
                    string text = reader.ReadLine();
                    string[] guests = new string[3];
                    guests = text.Split(" ");
                    person.FirstName = guests[0];
                    person.SecondName = guests[1];
                    person.Num = int.Parse(guests[2]);
                    spisok.Add(person);


                }

            }
        }

        public static void AddTofile(string fileName, string text)
        {
            File.AppendAllText(fileName, text);
        }

        public static void DeleteFromFile(string s, string txt)
        {
            var tempFile = Path.GetTempFileName();
            var linesToKeep = File.ReadLines(txt).Where(l => l != s);

            File.WriteAllLines(tempFile, linesToKeep);

            File.Delete(txt);
            File.Move(tempFile, txt);
        }


        abstract public class StuffAndKids
        {
            public abstract int NumberOfgroup();
        }

        public class kid : StuffAndKids
        {
            public string FirstName { get; set; }
            public string SecondName { get; set; }
            public int Age { get; set; }

            public override int NumberOfgroup()
            {
                switch (Age)
                {
                    case 3:
                        return 1;
                    case 4:
                        return 2;
                    case 5:
                        return 3;
                    case 6:
                        return 4;
                    default:
                        Console.WriteLine("Sorry, your kid doesn't fit in age frames of our childern garden");
                        break;
                }
                return 0;
            }
        }

        public class stuff : StuffAndKids
        {
            public string FirstName { get; set; }
            public string SecondName { get; set; }
            public int Num { get; set; }

            public override int NumberOfgroup()
            {
                switch (Num)
                {
                    case 1:
                        return 1;
                    case 2:
                        return 2;
                    default:
                        Console.WriteLine("Sorry, your kid doesn't fit in age frames of our childern garden");
                        break;
                }
                return 0;
            }

        }

        ////////////////////////////////////////////////////////////////////////////////

        static void Main()
        {
            List<kid> firstgroup = new List<kid>();
            List<kid> secondgroup = new List<kid>();
            List<kid> thirdgroup = new List<kid>();
            List<kid> fourthgroup = new List<kid>();
            List<stuff> teachers = new List<stuff>();
            string path = @"C:\Users\Allli\Desktop\kids.txt";
            string path2 = @"C:\Users\Allli\Desktop\stuff.txt";
            Readtechers(teachers, path2);
            ReadList(firstgroup, secondgroup, thirdgroup, fourthgroup, path);

            Console.WriteLine("Welcome to our Children garden. Pleese, choose needed operation ");
            Console.WriteLine(Print());
            try
            {

                int num = Convert.ToInt32(Console.ReadLine());
                switch (num)
                {
                    case 1:
                        Console.WriteLine("Enter number of needed group");
                        int group = Convert.ToInt32(Console.ReadLine());
                        switch (group)
                        {
                            case 1:
                                PrintList(firstgroup);
                                return;

                            case 2:
                                PrintList(secondgroup);
                                return;

                            case 3:
                                PrintList(thirdgroup);
                                return;

                            case 4:
                                PrintList(fourthgroup);
                                return;
                            default:
                                Console.WriteLine("This group wasn't found");
                                return;

                        }
                    case 2:
                        {
                            Console.WriteLine("Enter the first name of a kid");
                            string a = Console.ReadLine();
                            Console.WriteLine("Enter the second name of a kid");
                            string b = Console.ReadLine();
                            Console.WriteLine("Enter the age of a kid");
                            string c = Console.ReadLine();
                            string abc = a + " " + b + " " + c + " ";
                            AddTofile(path, abc);
                            Console.WriteLine("Kid was added successfully");
                            return;
                        }

                    case 3:
                        {
                            Console.WriteLine("Enter the name of kid who you want to delete");
                            string a = Console.ReadLine();
                            Console.WriteLine("Enter the surname of kid who you want to delete");
                            string b = Console.ReadLine();
                            Console.WriteLine("Enter the age of kid who you want to delete");
                            string c = Console.ReadLine();
                            string abc = a + " " + b + " " + c + " ";
                            DeleteFromFile(abc, path);
                            Console.WriteLine("Kid was deleted successfully");
                            return;
                        }

                    case 4:
                        {
                            PrintList2(teachers);
                            return;
                        }

                    case 5:
                        {
                            Console.WriteLine("Enter surname of person you want to fire");
                            string a = Console.ReadLine();
                            Console.WriteLine("Enter the name of person you want to fire");
                            string b = Console.ReadLine();
                            Console.WriteLine("Enter the number of group of person you want to fire");
                            string c = Console.ReadLine();
                            string abc = a + " " + b + " " + c + " ";
                            DeleteFromFile(abc, path2);
                            Console.WriteLine(a + " " + b +" was deleted successfully");
                            return;
                        }


                }
            }

            catch
            {
                Console.WriteLine("Error!");
            }
        }
    }

    }

