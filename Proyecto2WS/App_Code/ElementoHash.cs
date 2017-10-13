using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ElementoHash
/// </summary>
public class ElementoHash
{
    public float costoViaje;
    public float tiempoVuelo;
    public int numReservacion;
    public string nomCliente;
    public int eliminado;
    public NodoPais PlanVuelo;
    public NodoPais inicio;
    public NodoPais fin;

    public ElementoHash(string nom, int res, float cost, float tiempo)
    {
        this.costoViaje = cost;
        this.tiempoVuelo = tiempo;
        this.numReservacion = res;
        this.nomCliente = nom;
        this.eliminado = 0;
        this.PlanVuelo = null;
        this.inicio = null;
        this.fin = null;
    }
}