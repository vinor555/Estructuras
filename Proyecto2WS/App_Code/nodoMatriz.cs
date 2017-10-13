using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de nodoMatriz
/// </summary>
public class nodoMatriz
{
    public nodoMatriz ant = null, sig = null, up = null, down = null;
    public nodoFila fila = null;
    public nodoColumna columna = null;
    public int fil = 0, col = 0;
    public double costoV;
    public int tiempoV;
    public nodoMatriz(int col, int fil, double costoV, int tiempoV)
    {
        this.fil = fil;
        this.col = col;
        this.costoV = costoV;
        this.tiempoV = tiempoV;
    }
}