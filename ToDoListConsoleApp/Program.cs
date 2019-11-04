using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ToDoListConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "MyTasks";
            
            List <string> listOfTasks = new List<string>();
            do
            {
                Console.WriteLine("Главное меню:\n" +
                    "Ознакомиться со списком задач - 1\n" +
                    "Добавить новую задачу - 2\n" +
                    "Найти задачу по тэгу - 3\n" +
                    "Редактировать тэг задачи -4\n" +
                    "Завершить задачу - 5\n" +
                    "Выйти из планера - exit\n");
                string a = Console.ReadLine();
                if (a == "1")
                {
                    GetTaskFromFile(fileName);
                }
                else if (a == "2")
                {
                    string task = CreateTask(listOfTasks);
                    WriteToFile(fileName, task);
                }
                else if (a == "3")
                {
                    
                }
                else if (a == "4")
                {

                }
                else if (a == "5")
                {
                    string selectedTask = FindTask(fileName);
                    DateTime time = DateTime.Now;
                    FinishTask(time);
                }
            }
            while (Console.ReadLine() != "exit");


        }

        static string CreateTask(List<string> listOfTasks)
        {
            Console.WriteLine("Введите название задачи");
            Task task = new Task();
            task.Name = Console.ReadLine();
            Console.WriteLine("Опишите задачу");
            task.Description = Console.ReadLine();
            Console.WriteLine("Установим тэг - да/нет?");
            string answer = Console.ReadLine();
            if (answer == "да")
            {
                Console.WriteLine("Введите тэг, который будет установлен к задаче");
                string tag = Console.ReadLine();
                task.AssignTag(tag);
            }
            else
            {
                task.GetInfo();
            }
            string newTask = String.Format("Название задания: {0}\nОписание : {1}\nДата создания: {2} Тэг: {3} ", task.Name, task.Description, task.DateOfCreation, task.Tag);
            return newTask;

        }
    
        static void WriteToFile(string fileName, string newTask)
        {
            if (File.Exists(fileName) != true)
            {  //проверяем есть ли такой файл, если его нет, то создаем
                using (StreamWriter sw = new StreamWriter(new FileStream(fileName, FileMode.Create, FileAccess.Write)))
                {
                    sw.WriteLine(newTask);             //добавляем в файл новую задачу
                    sw.WriteLine("________________________________________________");
                }
            }
            else
            {                              
                //если файл есть, то откываем его и пишем в него 
                using (StreamWriter sw = new StreamWriter(new FileStream(fileName, FileMode.Open, FileAccess.Write)))
                {
                    (sw.BaseStream).Seek(0, SeekOrigin.End);         //идем в конец файла и пишем строку или пишем новое задание
                    sw.WriteLine(newTask);
                    sw.WriteLine("________________________________________________");
                }
            }

        }
        static void GetTaskFromFile(string fileName)
        {
            try
            {                          
                //чтение файла
                string[] allText = File.ReadAllLines(fileName);         //чтение всех строк файла в массив строк
                foreach (string s in allText)
                {     //вывод всех строк на консоль
                    Console.WriteLine(s);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Не найден файл");
            }
        }
        static string FindTask(string fileName)
        {
            Console.WriteLine("Введите название задачи которую хотите найти");
            string selectedName = Console.ReadLine();

            return selectedName;

        }
        static void FinishTask(DateTime time)
        {

        }
    }
}

