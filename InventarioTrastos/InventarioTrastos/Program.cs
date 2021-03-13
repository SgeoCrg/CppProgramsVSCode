using System;

class Program
{
    static void Main()
    {
        IniciaCasa casa = new IniciaCasa();
        int opcion = 0;
        do
        {
            Console.Clear();
            menu(casa);
            elegir(ref opcion, casa);
        }
        while (opcion != 8);
    }

    static void menu(IniciaCasa casa)
    {
        Console.WriteLine("**************************************");
        Console.WriteLine("* 1... Añadir trasto                 *");
        Console.WriteLine("* 2... Mostrar datos de Trasto       *");
        Console.WriteLine("* 3... Buscar trasto por texto       *");
        Console.WriteLine("* 4... Modificar datos de un trasto  *");
        Console.WriteLine("* 5... Eliminar un trasto            *");
        Console.WriteLine("* 6... Mostrar los trastos ordenados *");
        Console.WriteLine("* 7... Eliminar un trasto            *");
        Console.WriteLine("*                         Salir ...8 *");
        Console.WriteLine("**************************************");
        
        //1 ANOTAR NUEVO TRASTO
        //2 MOSTRAR DATOS DE UN TRASTO, ABREVIATURA, NOMBRE, UBICACIÓN, MUEBLE, HUECO-> A PARTIR DE LA ABREVIATURA
        //3 BUSCAR DATOS POR TEXTO (NOMBRE, UBICACION, HUECO)
        //4 MODIFICAR DATOS DE TRASTO A PARTIR DE SU ABREVIATURA
        //5 ELIMINAR TRASTO A PARTIR DE SU ABREVIATURA
        //6 MOSTRAR LOS DATOS ORDENADOS POR ABREVIATURA
        //7 MOSTRAR TODOS LOS DATOS EN FORMATO DEFINIDO
        //8 SALIR
    }

    static void elegir(ref int opcion, IniciaCasa casa)
    {
        Int32.TryParse(pedirDato("Selecciona una opcion valida"),out opcion);
        switch(opcion)
        {
            case 1:
                crearTrasto(casa);
                //Añadir trasto a hueco
                break;
            default:
                if (opcion != 8)
                {
                    Console.WriteLine("Debe ser una opción valida");
                    pausa();
                }
                break;
        }
    }

    static void crearTrasto(IniciaCasa casa)
    {
        string nombre = pedirDato("Dime el nombre del trasto");
        string ubicacion = pedirDato("Dime la ubicacion del trasto").ToUpper();
        for (int i = 0; i < casa.habitaciones.Count; i++)
        {
            if (ubicacion == casa.habitaciones[i].nombre.ToUpper())
            {
                Console.Write("SIII");
            }
            else
            {
                Console.Write("NOO");
            }
        }
        pausa();
        Trasto trasto = new Trasto(nombre, new Ubicacion(nombre));
    }

    static string pedirDato(string texto)
    {
        string respuesta;
        Console.WriteLine(texto); 
        respuesta = Console.ReadLine();
        return respuesta;
    }

    static void pausa()
    {
        Console.WriteLine("Pulse enter para continuar");
        string pausa = Console.ReadLine();
    }
}