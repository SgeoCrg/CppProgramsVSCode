using System;
using System.Collections.Generic;

public class IniciaCasa
{
    public List<Ubicacion> habitaciones { get; set; }
    public List<Trasto> trastos { get; set; }

    public IniciaCasa()
    {

        Mueble error = new Mueble("Ese mueble no existe", 10000);
        Mueble m6huecos = new Mueble("Estanteria 3 alturas", 6);
        Mueble m4huecos = new Mueble("EStanteria 2 alturas", 4);
        Mueble televisor = new Mueble("Televisor", 6);
        Mueble escritorio = new Mueble("Escritorio", 1);
        Mueble sofa = new Mueble("Sofa", 1);
        Mueble escobero = new Mueble("Escobero", 4);
        Mueble a2huecos1 = new Mueble("Armario de cocina bajo 1", 2);
        Mueble a3huecos = new Mueble("Armario de cocina bajo 2", 3);
        Mueble a2huecos2 = new Mueble("Armario de cocina bajo 3", 2);
        Mueble a2huecosC1 = new Mueble("Armario de cocina alto 1", 2);
        Mueble a2huecosC2 = new Mueble("Armario de cocina alto 2", 2);
        Mueble a2huecosC3 = new Mueble("Armario de cocina alto 3", 2);
        Mueble a2huecosC4 = new Mueble("Armario de cocina alto 4", 2);
        Mueble a12huecosE = new Mueble("Armario empotrado", 12);
        Mueble e16huecos = new Mueble("Estanteria abierta", 16);
        Mueble e4huecosE = new Mueble("Armario empotrado", 4);

        Ubicacion salon = new Ubicacion("Salón");
        Ubicacion cocina = new Ubicacion("Cocina");
        Ubicacion pasillo = new Ubicacion("Pasillo");
        Ubicacion habitacion1 = new Ubicacion("Habitacion infantil");
        Ubicacion habitacion2 = new Ubicacion("Dormitorio doble");
        Ubicacion banno = new Ubicacion("Baño");

        salon.muebles = new List<Mueble>
        {
            m6huecos,
            m4huecos,
            televisor,
            escritorio,
            sofa,
            escobero
        };

        cocina.muebles = new List<Mueble>
        {
            a2huecos1,
            a3huecos,
            a2huecos2,
            a2huecosC1,
            a2huecosC2,
            a2huecosC3,
            a2huecosC4
        };

        pasillo.muebles = new List<Mueble>
        {
            a12huecosE
        };

        habitacion1.muebles = new List<Mueble>
        {
            e16huecos,
            m4huecos
        };

        habitacion2.muebles = new List<Mueble>
        {
            e4huecosE,
            m6huecos
        };

        banno.muebles = new List<Mueble>
        {
            a2huecos2
        };

        habitaciones = new List<Ubicacion>
        {
            salon,
            cocina,
            pasillo,
            habitacion1,
            habitacion2,
            banno
        };
    }
}