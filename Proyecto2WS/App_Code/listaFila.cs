using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de listaFila
/// </summary>
public class listaFila
{
    public nodoFila raiz, ultimo;
    public listaFila()
    {
        raiz = ultimo = null;
    }

    public void insertar(int fila)
    {
        nodoFila nuevo = new nodoFila(fila);
        if (raiz == null)
        {// primer nodo 
            raiz = ultimo = nuevo;
        }
        else if (nuevo.fila > ultimo.fila)
        { // mayor al ultimo primer caso
            nuevo.ant = ultimo;
            ultimo.sig = nuevo;
            ultimo = nuevo;

        }
        else if (nuevo.fila < raiz.fila)
        {//menor q raiz segundo caso
            nuevo.sig = raiz;
            raiz.ant = nuevo;
            raiz = nuevo;

        }
        else if (!existe(nuevo))
        {// caso terminal en algun lugar medio de la lista :D
            nodoFila aux = raiz.sig;
            while (aux != null)
            {
                if (nuevo.fila < aux.fila)
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
    public Boolean existe(nodoFila nuevo)
    {
        nodoFila aux = raiz;
        while (aux != null)
        {
            if (nuevo.fila == aux.fila) { return true; }
            aux = aux.sig;
        }

        return false;
    }

    public void imprimir()
    {

        nodoFila aux = raiz;
        while (aux != null)
        {
            Console.WriteLine("esta es la fila---> " + aux.fila);
            aux = aux.sig;
        }
        Console.WriteLine("---------------------------------------------------------------");
    }
}