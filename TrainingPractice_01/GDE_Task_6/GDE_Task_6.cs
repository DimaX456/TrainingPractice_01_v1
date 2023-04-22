using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPractice_01
{
    internal class GDE_Task_6
    {
        static void Main(string[] args)
        {
            string[] fullName = { };
            string[] occupation = { };
            bool isWorking = true;

            Console.WriteLine("Добро пожаловать в базу данных!");

            while (isWorking)
            {
                Console.WriteLine("Введите 1, чтобы добавить досье;");
                Console.WriteLine("Введите 2, чтобы вывести все досье в базе данных;");
                Console.WriteLine("Введите 3, чтобы удалить досье;");
                Console.WriteLine("Введите 4, чтобы совершить поиск по фамилии;");
                Console.WriteLine("Введите 5, чтобы выйти из базы данных.");
                int task;
                task = Convert.ToInt32(Console.ReadLine());

                if (task == 1)
                {
                    InputAddingInfo(ref fullName, ref occupation);
                }
                else if (task == 2)
                {
                    ShowInfo(fullName, occupation);
                }
                else if (task == 3)
                {
                    InputRemovingInfo(ref fullName, ref occupation);
                }
                else if (task == 4)
                {
                    InputFindInfo(fullName, occupation);
                }
                else if (task == 5)
                {
                    Exit(isWorking = false);
                }
                else
                {
                    Console.WriteLine("Неверная команда.");
                }

            }
        }

        static string[] AddInfo(string[] info, string newInfo)
        {
            string[] tempArray = new string[info.Length + 1];

            for (int i = 0; i < info.Length; i++)
            {
                tempArray[i] = info[i];
            }

            info = tempArray;
            info[info.Length - 1] = newInfo;
            return info;
        }

        static void InputAddingInfo(ref string[] fullName, ref string[] occupation)
        {
            string newFullName;
            string newOccupation;

            Console.Clear();
            Console.WriteLine("Введите ФИО сотрудника: ");
            newFullName = Console.ReadLine();
            fullName = AddInfo(fullName, newFullName);
            Console.WriteLine("Введите должность сотрудника: ");
            newOccupation = Console.ReadLine();
            occupation = AddInfo(occupation, newOccupation);
            Console.WriteLine("Досье добавлено! Нажмите любую кнопку, чтобы продолжить.");
            Console.ReadKey();
            Console.Clear();
        }

        static void ShowInfo(string[] fullName, string[] occupation)
        {
            Console.Clear();
            int personNumber = 0;

            for (int i = 0; i < fullName.Length; i++)
            {
                personNumber++;
                Console.WriteLine($"{personNumber}. {fullName[i]} - {occupation[i]};");
            }

            Console.WriteLine("Это вся имеющаяся информация о сотрудниках в базе данных.");
            Console.WriteLine("Нажмите любую клавишу, чтобы продолжить.");
            Console.ReadKey();
            Console.Clear();
        }

        static string[] RemoveInfo(string[] info, int removeIndex)
        {
            string[] tempArray = new string[info.Length - 1];

            for (int i = 0; i < removeIndex; i++)
            {
                tempArray[i] = info[i];
            }

            for (int i = removeIndex; i < tempArray.Length; i++)
            {
                tempArray[i] = info[i + 1];
            }

            info = tempArray;
            return info;
        }

        static void InputRemovingInfo(ref string[] fullName, ref string[] occupation)
        {
            int removeIndex;

            Console.Clear();
            Console.WriteLine("Введите номер досье, который хотите удалить.");
            removeIndex = Convert.ToInt32(Console.ReadLine()) - 1;
            fullName = RemoveInfo(fullName, removeIndex);
            occupation = RemoveInfo(occupation, removeIndex);
            Console.WriteLine("Досье было удалено! Нажмите любую кнопку, чтобы продолжить.");
            Console.ReadKey();
            Console.Clear();
        }


        static void FindInfo(string[] fullName, string[] occupation, string findInfo)
        {
            int personNumber = 0;
            bool wasFound = false;
            string foundFullName;

            for (int i = 0; i < fullName.Length; i++)
            {
                personNumber++;

                if (fullName[i] == findInfo)
                {
                    string foundOccupation = occupation[i];
                    foundFullName = fullName[i];
                    Console.WriteLine("Доступна следующая информация:");
                    Console.WriteLine($"Сотрудник {foundFullName} находится в базе данных под номером {personNumber} и занимает должность {foundOccupation}.");
                    wasFound = true;
                }
                else
                {
                    continue;
                }
            }

            if (wasFound == false)
            {
                Console.WriteLine("Запрашиваемая информация отсутствует в базе данных.");
            }
        }

        static void InputFindInfo(string[] fullName, string[] occupation)
        {
            string findInfo;

            Console.Clear();
            Console.WriteLine("Введите ФИО сотрудника, досье которого хотите найти.");
            findInfo = Console.ReadLine();
            FindInfo(fullName, occupation, findInfo);
            Console.WriteLine("Нажмите любую кнопку, чтобы продолжить.");
            Console.ReadKey();
            Console.Clear();
        }

        static bool Exit(bool isWorking)
        {
            Console.Clear();
            Console.WriteLine("Работа программы завершена!");
            return isWorking;
        }
    }
}
