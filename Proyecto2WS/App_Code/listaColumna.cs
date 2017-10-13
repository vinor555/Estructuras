using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de listaColumna
/// </summary>
public class listaColumna
{
    public nodoColumna raiz, ultimo;
    public listaColumna()
    {
        raiz = ultimo = null;
    }

    public void insertar(int Columna)
    {
        nodoColumna nuevo = new nodoColumna(Columna);
        if (raiz == null)
        {// primer nodo 
            raiz = ultimo = nuevo;
        }
        else if (nuevo.columna > ultimo.columna)
        { // mayor al ultimo primer caso
            nuevo.ant = ultimo;
            ultimo.sig = nuevo;
            ultimo = nuevo;

        }
        else if (nuevo.columna < raiz.columna)
        {//menor q raiz segundo caso
            nuevo.sig = raiz;
            raiz.ant = nuevo;
            raiz = nuevo;

        }
        else if (!existe(nuevo))
        {// caso terminal en algun lugar medio de la lista :D
            nodoColumna aux = raiz.sig;
            while (aux != null)
            {
                if (nuevo.columna < aux.columna)
                {
                    nuevo.sig = aux;
                    nuevo.ant = aux.ant;
                    aux.ant.sig = nuevo;
                    aux.ant = nuevo;
                    break;
                }
                aux = aux.sig;
            }
        }

    }

    public Boolean existe(nodoColumna nuevo)
    {
        nodoColumna aux = raiz;
        while (aux != null)
        {
            if (nuevo.columna == aux.columna) { return true; }
            aux = aux.sig;
        }

        return false;
    }

    public void imprimir()
    {

        nodoColumna aux = raiz;
        while (aux != null)
        {
            Console.WriteLine("esta es la Columna---> " + aux.columna);
            aux = aux.sig;
        }
        Console.WriteLine("---------------------------------------------------------------");
    }
}