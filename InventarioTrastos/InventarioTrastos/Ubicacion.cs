using System;
using System.Collections.Generic;

public class Ubicacion
{
    public string nombre { get; set; }
    public List<Mueble> muebles { get; set; }

    public Ubicacion(string nombre)
    {
        this.nombre = nombre;
        muebles = new List<Mueble>();
    }

    public Mueble getMueble(int posicion)
    {
        return muebles[posicion];
    }

    public void ListaToString()
    {
        for (int i = 0; i < muebles.Count; i++)
        {
            Console.Write("" + getMueble(i).ToString());
        }
    }

    public override string ToString()
    {
        return nombre;
    }
}