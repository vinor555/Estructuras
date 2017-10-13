using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de NodoPais
/// </summary>
public class NodoPais
{
    public int codPais;
    public NodoPais siguiente;
    public NodoPais(int cod)
    {
        this.codPais = cod;
        this.siguiente = null;
    }
}