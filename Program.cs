using System;
using System.Collections.Generic;

namespace ToDo
{
    internal class Program
    {
        public static List<string> TaskList { get; set; }

        static void Main(string[] args)
        {
            TaskList = new List<string>();
            int seleccionMenu = 0;
            do
            {
                seleccionMenu = ShowMainMenu();
                if ((MenuOptions)seleccionMenu == MenuOptions.NuevaTarea)
                {
                    ShowMenuAdd();
                }
                else if ((MenuOptions)seleccionMenu == MenuOptions.RemoverTarea)
                {
                    RemoverTarea();
                }
                else if ((MenuOptions)seleccionMenu == MenuOptions.TareasPendientes)
                {
                    MostrarTareas();
                }
            } while (seleccionMenu != (int)MenuOptions.Salir);
        }
        /// <summary>
        /// Show the main menu 
        /// </summary>
        /// <returns>Returns option indicated by user</returns>
        public static int ShowMainMenu()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. Tareas pendientes");
            Console.WriteLine("4. Salir");

            // Read line
            string mainMenuOption = Console.ReadLine();
            return Convert.ToInt32(mainMenuOption);
        }

        public static void RemoverTarea()
        {
            try
            {
                Console.WriteLine("Ingrese el número de la tarea a remover: ");
                // Show current taks
                ListarTareas();

                string indexSelection = Console.ReadLine();
                // Remove one position
                int indexToRemove = Convert.ToInt32(indexSelection) - 1;
                if (indexToRemove > -1 && TaskList.Count > 0)
                {
                    string task = TaskList[indexToRemove];
                    TaskList.RemoveAt(indexToRemove);
                    Console.WriteLine("Tarea " + task + " eliminada");
                }
            }
            catch (Exception)
            {
            }
        }

        public static void ShowMenuAdd()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la tarea: ");
                string taskName = Console.ReadLine();
                TaskList.Add(taskName);
                Console.WriteLine("Tarea registrada");
            }
            catch (Exception)
            {
            }
        }

        public static void MostrarTareas()
        {
            if (TaskList == null || TaskList.Count == 0)
            {
                Console.WriteLine("No hay tareas por realizar");
            } 
            else
            {
            ListarTareas();
            }
        }

        public enum MenuOptions
        {
            NuevaTarea = 1,
            RemoverTarea = 2,
            TareasPendientes = 3,
            Salir = 4
        }

        public static void ListarTareas()
        {
            Console.WriteLine("----------------------------------------");
            
            TaskList.ForEach(t => Console.WriteLine((TaskList.IndexOf(t) + 1) + ". " + t));
            
            Console.WriteLine("----------------------------------------");
        }
    }
}
