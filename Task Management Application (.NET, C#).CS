using System;
using System.Collections.Generic;

namespace TaskManagementApp
{
    class Program
    {
        static List<Task> tasks = new List<Task>();

        static void Main(string[] args)
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Task Management Application");
                Console.WriteLine("---------------------------");
                Console.WriteLine("1. Create a new task");
                Console.WriteLine("2. View tasks");
                Console.WriteLine("3. Update a task");
                Console.WriteLine("4. Mark a task as completed");
                Console.WriteLine("5. Delete a task");
                Console.WriteLine("6. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        CreateTask();
                        break;
                    case "2":
                        ViewTasks();
                        break;
                    case "3":
                        UpdateTask();
                        break;
                    case "4":
                        MarkTaskAsCompleted();
                        break;
                    case "5":
                        DeleteTask();
                        break;
                    case "6":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void CreateTask()
        {
            Console.WriteLine("Create a New Task");
            Console.WriteLine("-----------------");

            Console.Write("Enter the task name: ");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Task name cannot be empty.");
                return;
            }

            Task newTask = new Task(Guid.NewGuid(), name, false);
            tasks.Add(newTask);

            Console.WriteLine("Task created successfully.");
        }

        static void ViewTasks()
        {
            Console.WriteLine("Task List");
            Console.WriteLine("---------");

            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks found.");
                return;
            }

            foreach (Task task in tasks)
            {
                Console.WriteLine($"Task ID: {task.Id}");
                Console.WriteLine($"Name: {task.Name}");
                Console.WriteLine($"Status: {(task.IsCompleted ? "Completed" : "Not Completed")}");
                Console.WriteLine();
            }
        }

        static void UpdateTask()
        {
            Console.WriteLine("Update a Task");
            Console.WriteLine("-------------");

            Console.Write("Enter the task ID: ");
            string taskId = Console.ReadLine();

            if (!Guid.TryParse(taskId, out Guid taskIdGuid))
            {
                Console.WriteLine("Invalid task ID format.");
                return;
            }

            Task task = tasks.Find(t => t.Id == taskIdGuid);

            if (task == null)
            {
                Console.WriteLine("Task not found.");
                return;
            }

            Console.Write("Enter the new task name: ");
            string newName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(newName))
            {
                Console.WriteLine("Task name cannot be empty.");
                return;
            }

            task.Name = newName;

            Console.WriteLine("Task updated successfully.");
        }

        static void MarkTaskAsCompleted()
        {
            Console.WriteLine("Mark a Task as Completed");
            Console.WriteLine("------------------------");

            Console.Write("Enter the task ID: ");
            string taskId = Console.ReadLine();

            if (!Guid.TryParse(taskId, out Guid taskIdGuid))
            {
                Console.WriteLine("Invalid task ID format.");
                return;
            }

            Task task = tasks.Find(t => t.Id == taskIdGuid);

            if (task == null)
            {
                Console.WriteLine("Task not found.");
                return;
            }

            task.IsCompleted = true;

            Console.WriteLine("Task marked as completed.");
        }

        static void DeleteTask()
        {
            Console.WriteLine("Delete a Task");
            Console.WriteLine("-------------");

            Console.Write("Enter the task ID: ");
            string taskId = Console.ReadLine();

            if (!Guid.TryParse(taskId, out Guid taskIdGuid))
            {
                Console.WriteLine("Invalid task ID format.");
                return;
            }

            Task task = tasks.Find(t => t.Id == taskIdGuid);

            if (task == null)
            {
                Console.WriteLine("Task not found.");
                return;
            }

            tasks.Remove(task);

            Console.WriteLine("Task deleted successfully.");
        }
    }

    class Task
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }

        public Task(Guid id, string name, bool isCompleted)
        {
            Id = id;
            Name = name;
            IsCompleted = isCompleted;
        }
    }
}
