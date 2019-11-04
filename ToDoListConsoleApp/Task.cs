using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoListConsoleApp
{
    class Task
    {
        //public int ID { get; set; } 
        public string Name { get; set; }
        public  string Description { get; set; }
        public string Tag { get; set; }
        public DateTime DateOfCreation { get; set; }
        public ItIsAlreadyDone Status { get; set; }
        public DateTime? DateOfCompletion { get; set; }
        
        public void GetInfo()
        {
            Console.WriteLine($"Название задания: {Name}\nОписание: {Description}\nТэг: {Tag}");
        }
        public void AssignTag(string tag)
        {

            Tag = tag;
        }
        public enum ItIsAlreadyDone
        {  
            Done,
            Performed
        }

    }

}
