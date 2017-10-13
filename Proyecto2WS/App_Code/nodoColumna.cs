using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de nodoColumna
/// </summary>
public class nodoColumna
{
    public int columna;
    public nodoColumna ant = null, sig = null;
    public nodoMatriz primero = null, ultimo = null;
   
    public nodoColumna(int columna)
    {
        this.columna = columna;
    }
}