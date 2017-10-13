using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de RamaArbol
/// </summary>
public class RamaArbol
{
    private NodoRamaArbol primero;
    private int cuenta;
    private Boolean hoja;
    private String tempFlechas;
    public RamaArbol()
    {
        cuenta = 0;
        hoja = true;
    }

    public void insertar(NodoRamaArbol nodo)
    {
        if (estaEnBlanco())
        {
            primero = nodo;
            primero.setAnterior(null);
            primero.setSiguiente(null);
            cuenta++;
        }
        else
        {
            NodoRamaArbol temp = primero;
            do
            {
                if (nodo.getCodigoDestino() == temp.getCodigoDestino())
                {
                    break;
                }
                else if (nodo.getCodigoDestino() < temp.getCodigoDestino())
                {
                    cuenta++;
                    if (temp == primero)
                    {
                        primero.setAnterior(nodo);
                        primero.setIzquierda(nodo.getDerecha());
                        nodo.setSiguiente(primero);
                        primero = nodo;
                        break;
                    }
                    else
                    {
                        nodo.setAnterior(temp.getAnterior());
                        nodo.setSiguiente(temp);
                        temp.getAnterior().setSiguiente(nodo);
                        temp.getAnterior().setDerecha(nodo.getIzquierda());
                        temp.setAnterior(nodo);
                        temp.setIzquierda(nodo.getDerecha());
                        break;
                    }
                }
                else if (temp.getSiguiente() == null)
                {
                    cuenta++;
                    temp.setSiguiente(nodo);
                    temp.setDerecha(nodo.getIzquierda());
                    nodo.setAnterior(temp);
                    nodo.setSiguiente(null);
                    break;
                }
                temp = temp.getSiguiente();
            } while (temp != null);
        }
    }

    /**
     *
     * @return
     */
    public int getCuenta()
    {
        return cuenta;
    }

    private Boolean estaEnBlanco()
    {
        return primero == null;
    }

    /**
     *
     * @return
     */
    public NodoRamaArbol getPrimero()
    {
        return primero;
    }

    /**
     *
     * @param primero
     */
    public void setPrimero(NodoRamaArbol primero)
    {
        this.primero = primero;
    }

    /**
     *
     * @return
     */
    public Boolean esHoja()
    {
        return hoja;
    }

    /**
     *
     * @param hoja
     */
    public void setHoja(Boolean hoja)
    {
        this.hoja = hoja;
    }

    /**
     * Genera parte del contenido del archivo fuente para GraphViz
     * @return
     */
    public String getGraphNodo()
    {
        tempFlechas = "";
        String temp = "nodo" + primero.getCodigoDestino() + " [ label =\"";
        NodoRamaArbol tempRecorre = primero;
        int i = 0;
        String detalles = "";
        for (i = 0; i < cuenta; i++, tempRecorre = tempRecorre.getSiguiente())
        {
            temp += "<C" + i + ">|<D" + i + ">Codigo: " + tempRecorre.getCodigoDestino() + "\\nDestino: " + tempRecorre.getNombreDestino() + "|";
            if (tempRecorre.getIzquierda() != null)
            {
                tempFlechas += "nodo" + primero.getCodigoDestino() + ":C" + i + "->nodo" + tempRecorre.getIzquierda().primero.getCodigoDestino() + "\n";
            }
        }
        temp += "<C" + i + ">\" fillcolor=\"#ffffff\"];\n";
        tempRecorre = primero;
        while (tempRecorre.getSiguiente() != null)
        {
            tempRecorre = tempRecorre.getSiguiente();
        }
        if (tempRecorre.getDerecha() != null)
        {
            tempFlechas += "nodo" + primero.getCodigoDestino() + ":C" + i + "->nodo" + tempRecorre.getDerecha().primero.getCodigoDestino() + "\n";
        }
        temp += tempFlechas;
        temp += detalles;
        return temp;
    }

    public String getGraphNodo2()
    {
        tempFlechas = "";
        String temp = "nodo" + primero.getCodigoDestino() + " [ label =\"";
        NodoRamaArbol tempRecorre = primero;
        int i = 0;
        String detalles = "";
        for (i = 0; i < cuenta; i++, tempRecorre = tempRecorre.getSiguiente())
        {
            temp += "<C" + i + ">|<D" + i + ">Codigo: " + tempRecorre.getCodigoDestino() +  "|";
            if (tempRecorre.getIzquierda() != null)
            {
                tempFlechas += "nodo" + primero.getCodigoDestino() + ":C" + i + "->nodo" + tempRecorre.getIzquierda().primero.getCodigoDestino() + "\n";
            }
        }
        temp += "<C" + i + ">\" fillcolor=\"#ffffff\"];\n";
        tempRecorre = primero;
        while (tempRecorre.getSiguiente() != null)
        {
            tempRecorre = tempRecorre.getSiguiente();
        }
        if (tempRecorre.getDerecha() != null)
        {
            tempFlechas += "nodo" + primero.getCodigoDestino() + ":C" + i + "->nodo" + tempRecorre.getDerecha().primero.getCodigoDestino() + "\n";
        }
        temp += tempFlechas;
        temp += detalles;
        return temp;
    }
}