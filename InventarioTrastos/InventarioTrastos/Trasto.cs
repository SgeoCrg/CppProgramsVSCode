using System;

public class Trasto
{
    public string nombre { get; set; }
    public string abreviatura { get; set; }
    public string ubicacion { get; set; }
    public string mueble { get; set; }
    public int hueco { get; set; }

    public Trasto(string nombre)
    {
        this.nombre = nombre;
        this.abreviatura = abreviar(nombre);
    }

    public string abreviar(string nombre)
    {
        return nombre.Substring(0,4);
    }

    public override string ToString()
    {
        return nombre + ", " + abreviatura;
    }

    public string ToStringByAbre()
    {
        return abreviatura + ": " + nombre + ", en " + ubicacion
            + ", " + mueble + " " + (hueco + 1) + "o hueco.";
    }

    public string ToStringByUbi()
    {
        return ubicacion + " - " + mueble + " - " + hueco + ": "
            + nombre + "(" + abreviatura +").";
    }
}