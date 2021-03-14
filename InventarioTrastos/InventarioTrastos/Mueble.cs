using System;
using System.Collections.Generic;

public class Mueble
{
    public string nombre { get; set; }
    public Trasto[] huecos { get; set; }
    public int limite { get; set; }
    public int contador{ get; set; }

    public Mueble(string nombre, int limite)
    {
        this.nombre = nombre;
        huecos = new Trasto[limite];
        this.limite = limite + 1;
        this.contador = 0;
    }

    public string getHueco(int lugar)
    {
        if (lugar < huecos.Length)
        {
            if (this.huecos[lugar] == null)
            {
                return "hueco vacio";
            }
            else
            {
                return this.huecos[lugar].ToString();
            }
        }
        else
        {
            return "Ese mueble no tiene tantos huecos";
        }
    }

    public override string ToString()
    {
        return nombre;
    }
}