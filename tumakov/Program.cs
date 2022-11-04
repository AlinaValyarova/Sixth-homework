﻿using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace tumakov
{
    class Program
    {
        static void Main(string[] args)
        {
            ex3();
        }


        public class account
        {
            public int num;
            public decimal money;
        }
        public static void AddMoney(List<account> bank)
        {
            Console.WriteLine("Enter number of your account");
            int acnum = Convert.ToInt32(Console.ReadLine());
            var found = bank.Find(p => p.num == acnum);

            Console.WriteLine("Emter amount of money you want to add");
            decimal num = Convert.ToDecimal(Console.ReadLine());
            int a = bank.IndexOf(found);
            bank[a].money = num;
            Console.WriteLine("money were added successfully");

        }

        public static void TakeMoney(List<account> bank)
        {
            Console.WriteLine("Enter number of your account");
            int acnum = Convert.ToInt32(Console.ReadLine());
            var found = bank.Find(p => p.num == acnum);

            Console.WriteLine("Emter amount of money you want to take");
            decimal num = Convert.ToDecimal(Console.ReadLine());
            int a = bank.IndexOf(found);
            if (bank[a].money >= num)
            {
                bank[a].money -= num;
                Console.WriteLine("success!");
            }
            else
            {
                Console.WriteLine("You don't have enough money");
            }
            
            

        }



        public static void ex1()
        {
            Console.WriteLine("Создать класс счет в банке с закрытыми полями: номер счета, баланс, " +
                "тип банковского счета(использовать перечислимый тип из упр.3.1)." +
                "Предусмотреть методы для доступа к данным – заполнения и чтения. Создать объект класса, " +
                "заполнить его поля и вывести информацию об объекте класса на печать.");
            Console.WriteLine("Enter number of needed operation");
            Console.WriteLine("1 - print");
            Console.WriteLine("2 - new");
            List<account> clients = new List<account>();
            int num = Convert.ToInt32(Console.ReadLine());
            switch (num)
            {
                case 1:
                    for (int i = 0; i < clients.Count; i++)
                    {

                        account person = clients[i];
                        Console.WriteLine("Name: " + person.num + " Sum: " + person.money);
                        continue;
                    }
                    return;

                case 2:
                    Console.WriteLine("Enter number of account");
                    account newclient = new account();
                    int numofacc = Convert.ToInt32(Console.ReadLine());
                    numofacc = newclient.num;
                    Console.WriteLine("Enter sum");
                    decimal sumofacc = Convert.ToDecimal(Console.ReadLine());
                    sumofacc = newclient.money;
                    return;
            }
        }

        public static void ex2()
        {
            Console.WriteLine("Изменить класс счет в банке из упражнения 7.1 таким образом, " +
                "чтобы номер счета генерировался сам и был уникальным. Для этого надо создать в классе статическую переменную " +
                "и метод, который увеличивает значение этого переменной.");
            Console.WriteLine("Enter number of needed operation");
            Console.WriteLine("1 - print");
            Console.WriteLine("2 - new");
            List<account> clients = new List<account>();
            int account = clients.Count;
            int num = Convert.ToInt32(Console.ReadLine());
            switch (num)
            {
                case 1:
                    for (int i = 0; i < clients.Count; i++)
                    {

                        account person = clients[i];
                        Console.WriteLine("Name: " + person.num + " Sum: " + person.money);
                        continue;
                    }
                    return;

                case 2:
                    Console.WriteLine("Enter number of account");
                    account newclient = new account();
                    account += 1;
                    account = newclient.num;
                    Console.WriteLine("Enter sum");
                    decimal sumofacc = Convert.ToDecimal(Console.ReadLine());
                    sumofacc = newclient.money;
                    return;
            }


        }

        public static void ex3()
        {
            Console.WriteLine("Добавить в класс счет в банке два метода: снять со счета и положить на счет." +
                "Метод снять со счета проверяет, возможно ли снять запрашиваемую сумму, " +
                "и в случае положительного результата изменяет баланс.");
            List<account> clients = new List<account>();
            try
            {
                Console.WriteLine("Choose needed operation");
                Console.WriteLine(" 1 - Add money");
                Console.WriteLine("2 - Take money");
                int a = Convert.ToInt32(Console.ReadLine());
                switch (a)
                {
                    case 1:
                        AddMoney(clients);
                        return;

                    case 2:
                        TakeMoney(clients);
                        return;

                    default:
                        Console.WriteLine("You entered something wrong");
                        return;

                }
                
            }
            catch
            {

                Console.WriteLine("Error!");
            }
        }
        }
    }


