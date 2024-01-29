using System;
using System.Collections.Generic;

namespace ToDo
{
    internal class Program
    {
        //Se corrige el nombre de la lista de TL, que no describia nada siendo una mala practica, a ListaTareas, siendo mucho mas descriptiva y acertada
        public static List<string> ListaTareas { get; set; }

        static void Main(string[] args)
        {
            ListaTareas = new List<string>();
            //Se cambia el nombre de la variable a SeleccionMenu, para ser mas entendible
            int SeleccionMenu = 0;
            do
            {
                SeleccionMenu = ShowMainMenu();
                //El colocar el (Menu) al inicio hace un cambio automatico a la seleccion del menu
                if ((Menu)SeleccionMenu == Menu.Añadir)
                {
                    ShowMenuAdd();
                }
                else if ((Menu)SeleccionMenu == Menu.Eliminar)
                {
                    ShowMenuRemove();           //Se cambia el nombre de los metodos de las opciones para hacerlo mas entendible
                }
                else if ((Menu)SeleccionMenu == Menu.Enlistar)
                {
                    ShowMenuTareasPendientes();
                }
            } while ((Menu)SeleccionMenu != Menu.Salir);
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
            string line = Console.ReadLine();
            return Convert.ToInt32(line);
        }

        public static void ShowMenuRemove()
        {

            try
            {
                Console.WriteLine("Ingrese el número de la tarea a remover: ");
                // Show current taks
                ListarTareas();
                string line = Console.ReadLine();
                // Remove one position
                int indexToRemove = Convert.ToInt32(line) - 1;

                //Se hace control de la excepcion sin hacer uso del catch y evitar asi el consumo innecesario de recursos
                //Se identifica una posible excepcion y se hace su respectivo control
                if(indexToRemove > (ListaTareas.Count - 1) || indexToRemove <= 0){
                    Console.WriteLine("El numero seleccionado no es valido");
                }
                else{
                    
                    if (indexToRemove > -1 && ListaTareas.Count > 0)
                    {
                        string task = ListaTareas[indexToRemove];
                        ListaTareas.RemoveAt(indexToRemove);
                        Console.WriteLine("Tarea " + task + " eliminada");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Se ha presentado un error");
            }
        }

        public static void ShowMenuAdd()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la tarea: ");
                string task = Console.ReadLine();
                ListaTareas.Add(task);
                Console.WriteLine("Tarea registrada");
            }
            catch (Exception)
            {
            }
        }

        public static void ShowMenuTareasPendientes()
        {
            if (ListaTareas == null || ListaTareas.Count == 0)
            {
                Console.WriteLine("No hay tareas por realizar");
            } 
            else
            {
                ListarTareas();
            }
        }

        //Se crea un metodo para listar el menu en vez de repetir el codigo varias veces
        public static void ListarTareas(){
            //La variavle IndexTareas sirve para llevar el conteo que normalmente usaria el incremento de los indices del ciclo for
            //Se cambia la sintaxis del clico for por un ForEach
            var IndexTareas=1;
            ListaTareas.ForEach(p=> Console.WriteLine(IndexTareas++ +". " + p));
            Console.WriteLine("----------------------------------------");
        }
    }

    //Se añade un Enum que servira para hacer la seleccion del menú mas entendible
    public enum Menu{
        Añadir=1,
        Eliminar=2,
        Enlistar=3,
        Salir=4
    }
}