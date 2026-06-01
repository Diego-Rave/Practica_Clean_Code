
namespace ToDo;

internal class Program
{
    public static List<string> TaskList { get; set; } = new List<string>();

    static void Main(string[] args)
    {
        int seleccionMenu = 0;
        do
        {
            seleccionMenu = ShowMainMenu();
            if ((MenuOptions)seleccionMenu == MenuOptions.NuevaTarea)
            {
                AgregarTarea();
            }
            else if ((MenuOptions)seleccionMenu == MenuOptions.RemoverTarea)
            {
                RemoverTarea();
            }
            else if ((MenuOptions)seleccionMenu == MenuOptions.TareasPendientes)
            {
                MostrarTareas();
            }
            else
            {
                Console.WriteLine("Opción no válida");
            }
        } while (seleccionMenu != (int)MenuOptions.Salir);
    }
   
   // Muestra el menú principal y devuelve la opción seleccionada por el usuario
    public static int ShowMainMenu()
    {
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Ingrese la opción a realizar: ");
        Console.WriteLine("1. Nueva tarea");
        Console.WriteLine("2. Remover tarea");
        Console.WriteLine("3. Tareas pendientes");
        Console.WriteLine("4. Salir");

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
          
            int indexToRemove = Convert.ToInt32(indexSelection) - 1;

            if (indexToRemove < 0 || indexToRemove >= TaskList.Count)
            {
                Console.WriteLine("Número de tarea no válido");
                return;
            }
            else
            {
                string task = TaskList[indexToRemove];
                TaskList.RemoveAt(indexToRemove);
                Console.WriteLine("Tarea " + task + " eliminada");
            }

        }
        catch (Exception)
        {
            Console.WriteLine("Opción no válida");
            
        }
    }

    public static void AgregarTarea()
    {
        Console.WriteLine("Ingrese el nombre de la tarea: ");
        string taskName = Console.ReadLine();

        // Validación explícita de los datos de entrada
        if (string.IsNullOrWhiteSpace(taskName))
        {
            Console.WriteLine("Error: El nombre de la tarea no puede estar vacío.");
            return; 
        }

        TaskList.Add(taskName);
        Console.WriteLine("Tarea registrada exitosamente.");
    }

    public static void MostrarTareas()
    {
        if (TaskList ?.Count > 0)
        {
            ListarTareas();
        } 
        else
        {
            Console.WriteLine("No hay tareas por realizar");
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
        
        TaskList.ForEach(t => Console.WriteLine(($"{TaskList.IndexOf(t) + 1}. {t}")));
        
        Console.WriteLine("----------------------------------------");
    }
}

