using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de nodoFila
/// </summary>
public class nodoFila
{
    public int fila;
    public nodoFila sig = null, ant = null;
    public nodoMatriz primero = null, ultimo = null;
    public nodoFila(int fila)
    {
        this.fila = fila;
    }
}