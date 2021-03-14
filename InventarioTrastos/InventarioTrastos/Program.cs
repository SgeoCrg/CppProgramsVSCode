//Alejandro Pertiñez Gomez
//1 DAM

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        bool primera = true;
        IniciaCasa casa = new IniciaCasa();
        int opcion = 0;
        List<Trasto> trastos = new List<Trasto>();

        do
        {
            if (!primera)
            {
                pausa();
            }
            primera = false;
            Console.Clear();
            menu();
            elegir(ref opcion, casa, trastos);
        }
        while (opcion != 8);
    }

    static void menu()
    {
        Console.WriteLine("************************************************]]");
        Console.WriteLine("* 1... Añadir trasto                             *");
        Console.WriteLine("* 2... Mostrar datos de Trasto                   *");
        Console.WriteLine("* 3... Buscar trasto por texto                   *");
        Console.WriteLine("* 4... Modificar datos de un trasto              *");
        Console.WriteLine("* 5... Eliminar un trasto                        *");
        Console.WriteLine("* 6... Mostrar trastos ordenados por abreviatura *");
        Console.WriteLine("* 7... Mostrar trastos ordenador por ubicacion   *");
        Console.WriteLine("*                                     Salir ...8 *");
        Console.WriteLine("**************************************************");

        //1 ANOTAR NUEVO TRASTO
        //2 MOSTRAR DATOS DE UN TRASTO, ABREVIATURA, NOMBRE, UBICACIÓN, MUEBLE, HUECO-> A PARTIR DE LA ABREVIATURA
        //3 BUSCAR DATOS POR TEXTO (NOMBRE, UBICACION, HUECO)
        //4 MODIFICAR DATOS DE TRASTO A PARTIR DE SU ABREVIATURA
        //5 ELIMINAR TRASTO A PARTIR DE SU ABREVIATURA
        //6 MOSTRAR LOS DATOS ORDENADOS POR ABREVIATURA
        //7 MOSTRAR TODOS LOS DATOS EN FORMATO DEFINIDO
        //8 SALIR
    }

    static void elegir(ref int opcion, IniciaCasa casa, List<Trasto> trastos)
    {
        Int32.TryParse(pedirDato("Selecciona una opcion valida"), out opcion);
        switch (opcion)
        {
            case 1:
                crearTrasto(casa, trastos);
                break;
            case 2:
                mostrarTrasto(casa);
                break;
            case 3:
                buscarTrasto(casa);
                break;
            case 4:
                modificarTrasto(casa, trastos);
                break;
            case 5:
                borrar(casa);
                break;
            case 6:
                ordenarPorAbre(trastos);
                break;
            case 7:
                ordenarPorUbicacion(casa, trastos);
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

    static void ordenarPorUbicacion(IniciaCasa casa, List<Trasto> trastos)
    {
        List<Trasto> aux = trastos.OrderBy(x => x.ubicacion).ToList<Trasto>();
        for (int i = 0; i < aux.Count; i++)
        {
            aux[i].ubicacion = aux[i].ubicacion + " " + aux[i].mueble;
        }
        aux.OrderBy(x => x.ubicacion).ToList<Trasto>();
        for (int i = 0; i < aux.Count; i++)
        {
            bool correcto = false;
            string[] nombre = aux[i].ubicacion.Split(" ");
            int j = 0;
            aux[i].ubicacion = nombre[j];
            do
            {
                for (int k = 0; k < casa.habitaciones.Count; k++)
                {
                    if (aux[i].ubicacion == casa.habitaciones[k].nombre)
                    {
                        correcto = true;
                    }
                    j++;
                }
            }
            while (!correcto);
        }
        for (int i = 0; i < aux.Count; i++)
        {
            Console.WriteLine((i + 1) + aux[i].ToStringByAbre());
        }
    }

    static void ordenarPorAbre(List<Trasto> trastos)
    {
        List<Trasto> aux = trastos.OrderBy(x=>x.abreviatura).ToList<Trasto>();
        for (int i = 0; i < aux.Count; i++)
        {
            Console.WriteLine((i + 1) + aux[i].ToStringByUbi());
        }
    }

    static void borrar(IniciaCasa casa)
    {
        mostrarTrasto(casa);
        string trastoABorrar = pedirDato("Dime el trasto a borrar");
        for (int i = 0; i < casa.habitaciones.Count; i++)
        {
            for (int j = 0; j < casa.habitaciones[i].muebles.Count; j++)
            {
                for (int k = 0; k < casa.habitaciones[i].muebles[j].contador; k++)
                {
                    if (casa.habitaciones[i].muebles[j].huecos[k].nombre.ToUpper() == trastoABorrar.ToUpper())
                    {
                        for (int l = k; l < casa.habitaciones[i].muebles[j].contador; l++)
                        {
                            casa.habitaciones[i].muebles[j].huecos[l] = casa.habitaciones[i].muebles[j].huecos[l + 1];
                            casa.habitaciones[i].muebles[j].contador--;
                        }
                    }
                }
            }
        }
    }

    static void modificarTrasto(IniciaCasa casa, List<Trasto> trastos)
    {
        bool encontrado = false;
        bool ubicacionEX = false;
        bool muebleEx = false;
        string antNombre = "", antUbicacion = "", antMueble = "";
        int antHueco = 0;
        mostrarTrasto(casa);
        do
        {
            string trastoACambiar = pedirDato("Que trasto quieres cambiar?").ToUpper();
            for (int i = 0; i < trastos.Count; i++)
            {
                if (trastos[i].nombre.ToUpper() == trastoACambiar)
                {
                    encontrado = true;
                    antNombre = trastos[i].nombre;
                    antMueble = trastos[i].mueble;
                    antUbicacion = trastos[i].ubicacion;
                    antHueco = trastos[i].hueco;
                    for (int j = 0; j < casa.habitaciones.Count; j++)
                    {
                        for (int k = 0; k < casa.habitaciones[j].muebles.Count; k++)
                        {
                            for (int l = 0; l < casa.habitaciones[j].muebles[k].contador; l++)
                            {
                                if (casa.habitaciones[j].muebles[k].huecos[l].nombre.ToUpper() == trastoACambiar)
                                {
                                    string nombre = pedirDato("nuevo nombre? ENTER PARA CONSERVAR");
                                    if (nombre != "")
                                    {
                                        casa.habitaciones[j].muebles[k].huecos[l].nombre = nombre;
                                        trastos[i].nombre = nombre;
                                        casa.habitaciones[j].muebles[k].huecos[l].abreviatura =
                                            casa.habitaciones[j].muebles[k].huecos[l].abreviar(nombre);
                                    }
                                    nombre = pedirDato("nueva habitación? ENTER PARA CONSERVAR");
                                    if (nombre != "")
                                    {
                                        for (int m = 0; m < casa.habitaciones.Count; m++)
                                        {
                                            if (casa.habitaciones[m].nombre.ToUpper() == nombre.ToUpper())
                                            {
                                                trastos[i].ubicacion = nombre;
                                                ubicacionEX = true;
                                                nombre = pedirDato("En que mueble quieres guardarlo?");
                                                for (int n = 0; n < casa.habitaciones[m].muebles.Count; n++)
                                                {
                                                    if (casa.habitaciones[m].muebles[n].nombre.ToUpper() == nombre.ToUpper())
                                                    {
                                                        trastos[i].mueble = nombre;
                                                        muebleEx = true;
                                                        casa.habitaciones[m].muebles[n].huecos[casa.habitaciones[m].muebles[n].contador] = casa.habitaciones[j].muebles[k].huecos[l];
                                                        trastos[i].hueco = casa.habitaciones[m].muebles[n].contador;
                                                        casa.habitaciones[m].muebles[n].contador++;
                                                        for (int a = l; a < casa.habitaciones[j].muebles[k].contador; a++)
                                                        {
                                                            casa.habitaciones[j].muebles[k].huecos[l] = casa.habitaciones[j].muebles[k].huecos[l + 1];
                                                            casa.habitaciones[j].muebles[k].contador--;
                                                            Console.WriteLine("Objeto cambiado");
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        nombre = pedirDato("nueva habitación? ENTER PARA CONSERVAR");
                                        if (nombre != "")
                                        {
                                            for (int m = 0; m < casa.habitaciones.Count; m++)
                                            {
                                                if (casa.habitaciones[m].nombre.ToUpper() == nombre.ToUpper())
                                                {
                                                    trastos[i].ubicacion = nombre;
                                                    ubicacionEX = true;
                                                    nombre = pedirDato("En que mueble quieres guardarlo?");
                                                    for (int n = 0; n < casa.habitaciones[m].muebles.Count; n++)
                                                    {
                                                        if (casa.habitaciones[m].muebles[n].nombre.ToUpper() == nombre.ToUpper())
                                                        {
                                                            trastos[i].mueble = nombre;
                                                            muebleEx = true;
                                                            casa.habitaciones[m].muebles[n].huecos[casa.habitaciones[m].muebles[n].contador] = casa.habitaciones[j].muebles[k].huecos[l];
                                                            trastos[i].hueco = casa.habitaciones[m].muebles[n].contador;
                                                            casa.habitaciones[m].muebles[n].contador++;
                                                            
                                                            for (int a = l; a < casa.habitaciones[j].muebles[k].contador; a++)
                                                            {
                                                                casa.habitaciones[j].muebles[k].huecos[l] = casa.habitaciones[j].muebles[k].huecos[l + 1];
                                                                casa.habitaciones[j].muebles[k].contador--;
                                                                Console.WriteLine("Objeto cambiado");
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }


                    if (!ubicacionEX || !muebleEx)
                    {
                        trastos[i].nombre = antNombre;
                        trastos[i].ubicacion = antUbicacion;
                        trastos[i].mueble = antMueble;
                        trastos[i].hueco = antHueco;
                    }
                }
            }
        }
        while (!encontrado);
    }

    static void buscarTrasto(IniciaCasa casa)
    {
        string texto = pedirDato("Dime el texto a buscar");
        for (int i = 0; i < casa.habitaciones.Count; i++)
        {
            if (casa.habitaciones[i].nombre.ToString().Contains(texto))
            {
                for (int j = 0; j < casa.habitaciones[i].muebles.Count; j++)
                {
                    for(int k = 0; k < casa.habitaciones[i].muebles[j].contador; k++)
                    {
                        Console.WriteLine(casa.habitaciones[i].muebles[j].huecos[k].ToString() + " " +
                            casa.habitaciones[i].ToString() + " " +
                            casa.habitaciones[i].muebles[j].ToString() + " hueco " +
                            (k + 1) + "o.");
                    }
                }
            }
            else
            {
                for(int j = 0; j < casa.habitaciones[i].muebles.Count; j++)
                {
                    if (casa.habitaciones[i].muebles[j].ToString().Contains(texto))
                    {
                        for (int k = 0; k < casa.habitaciones[i].muebles[j].contador; k++)
                        {
                            Console.WriteLine(casa.habitaciones[i].muebles[j].huecos[k].ToString() + " " +
                                casa.habitaciones[i].ToString() + " " +
                                casa.habitaciones[i].muebles[j].ToString() + " hueco " +
                                (k + 1) + "o.");

                        }
                    }
                    else
                    {
                        for (int k = 0; k < casa.habitaciones[i].muebles[j].contador; k++)
                        {
                            if (casa.habitaciones[i].muebles[j].huecos[k].ToString().Contains(texto))
                            {
                                Console.WriteLine(casa.habitaciones[i].muebles[j].huecos[k].ToString() + " " +
                                    casa.habitaciones[i].ToString() + " " +
                                    casa.habitaciones[i].muebles[j].ToString() + " hueco " +
                                    (k + 1) + "o.");

                            }
                        }
                    }
                }
            }
        }

    }

    static void mostrarTrasto(IniciaCasa casa)
    {
        bool esta = false;
        string textoABuscar = pedirDato("Dime la abreviatura a buscar").ToUpper();
        for (int i = 0; i < casa.habitaciones.Count; i++)
        {
            for (int j = 0; j < casa.habitaciones[i].muebles.Count; j++)
            {
                for (int k = 0; k < casa.habitaciones[i].muebles[j].contador; k++)
                {
                    if (casa.habitaciones[i].muebles[j].contador > 0 &&
                        casa.habitaciones[i].muebles[j].huecos[k].abreviatura.ToUpper() == textoABuscar)
                    {
                        esta = true;
                        Console.WriteLine(
                            casa.habitaciones[i].muebles[j].huecos[k].ToString() + " " +
                            casa.habitaciones[i].ToString() + " " + 
                            casa.habitaciones[i].muebles[j].ToString() + " hueco " +
                            (k + 1) + "o."
                            );
                    }
                }
            }
        }
        if(!esta)
        {

            Console.WriteLine("Ese trasto no está guardado en esta casa");
        }
    }

    static void crearTrasto(IniciaCasa casa, List<Trasto> trastos)
    {
        bool existe = false;
        bool muebleEx = false;
        bool habitacionEx = false;
        bool imprimirListaDeHabitaciones = false;
        bool imprimirListaDeMuebles = false;
        int numeroDeHabitacion = 0;
        string nombre = pedirDato("Dime el nombre del trasto");
        trastos.Add(new Trasto(nombre));

        do
        {
            string ubicacion = pedirDato("Dime la ubicacion del trasto").ToUpper();
            string mueble;

            for (int i = 0; i < casa.habitaciones.Count; i++)
            {
                if (ubicacion == casa.habitaciones[i].nombre.ToUpper() && !existe)
                {
                    trastos[trastos.Count - 1].ubicacion = casa.habitaciones[i].nombre;
                    habitacionEx = true;
                    numeroDeHabitacion = i;
                    do
                    {
                        mueble = pedirDato("Dime el mueble donde quieres guardar el trasto").ToUpper();
                        for (int j = 0; j < casa.habitaciones[i].muebles.Count; j++)
                        {
                            if (mueble == casa.habitaciones[i].muebles[j].nombre.ToUpper() && !existe)
                            {
                                trastos[trastos.Count - 1].mueble = casa.habitaciones[i].muebles[j].nombre;
                                muebleEx = true;
                                if (casa.habitaciones[i].muebles[j].contador <
                                    casa.habitaciones[i].muebles[j].limite)
                                {
                                    casa.habitaciones[i].muebles[j].huecos[
                                        casa.habitaciones[i].muebles[j].contador] = trastos[trastos.Count - 1];
                                    trastos[trastos.Count - 1].hueco = casa.habitaciones[i].muebles[j].contador;
                                    existe = true;
                                    Console.WriteLine("Trasto guardado");
                                    casa.habitaciones[i].muebles[j].contador++;
                                }
                                else
                                {
                                    Console.WriteLine("Mueble lleno");
                                }
                            }
                            else
                            {
                                imprimirListaDeMuebles = true;
                            }
                        }


                        if (imprimirListaDeMuebles && !muebleEx)
                        {

                            Console.WriteLine("El mueble no existe, debe ser uno de los siguientes: ");
                            for (int j = 0; j < casa.habitaciones[numeroDeHabitacion].muebles.Count; j++)
                                Console.WriteLine(casa.habitaciones[numeroDeHabitacion].muebles[j].nombre.ToString() + ", ");
                        }
                    }
                    while (!muebleEx);
                }
                else
                {
                    imprimirListaDeHabitaciones = true;
                }
            }
            if (imprimirListaDeHabitaciones && !habitacionEx)
            {

                Console.WriteLine("Esa ubicacion no existe, debe ser una de las siguientes: ");
                for (int i = 0; i < casa.habitaciones.Count; i++)
                {
                    Console.WriteLine(casa.habitaciones[i].nombre.ToString());
                }
            }
        }
        while (!muebleEx || !habitacionEx);
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