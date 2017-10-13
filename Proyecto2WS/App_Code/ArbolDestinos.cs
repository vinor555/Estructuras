using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ArbolDestinos
/// </summary>
public class ArbolDestinos
{
    private RamaArbol raiz;
    private String nodos = "";
    public ArbolDestinos()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    /**
         * Verifica el contenido del árbol
         * @return true - Si el árbol está vacío; false - Si no lo está
         */
    public Boolean estaVacio()
    {
        return raiz == null;
    }

    /**
     *
     * @param val
     */
    public void insertar(int codDes, String nomDes)
    {
        NodoRamaArbol nodo = new NodoRamaArbol(codDes, nomDes);
        if (estaVacio())
        {
            raiz = new RamaArbol();
            raiz.insertar(nodo);
        }
        else
        {
            Object obj = inserta(nodo, raiz);
            if (obj is NodoRamaArbol)
            {
                raiz = new RamaArbol();
                raiz.insertar((NodoRamaArbol)obj);
                raiz.setHoja(false);
            }
        }
    }




    private Object inserta(NodoRamaArbol nodo, RamaArbol rama)
    {
        if (rama.esHoja())
        {
            rama.insertar(nodo);
            if (rama.getCuenta() == 5)
            {
                return dividir(rama);
            }
            else
            {
                return rama;
            }
        }
        else
        {
            NodoRamaArbol temp = rama.getPrimero();
            do
            {
                if (nodo.getCodigoDestino() == temp.getCodigoDestino())
                {
                    return rama;
                }
                else if (nodo.getCodigoDestino() < temp.getCodigoDestino())
                {
                    Object obj = inserta(nodo, temp.getIzquierda());
                    if (obj is NodoRamaArbol)
                    {
                        rama.insertar((NodoRamaArbol)obj);
                        if (rama.getCuenta() == 5)
                        {
                            return dividir(rama);
                        }
                    }
                    return rama;
                }
                else if (temp.getSiguiente() == null)
                {
                    Object obj = inserta(nodo, temp.getDerecha());
                    if (obj is NodoRamaArbol)
                    {
                        rama.insertar((NodoRamaArbol)obj);
                        if (rama.getCuenta() == 5)
                        {
                            return dividir(rama);
                        }
                    }
                    return rama;
                }
                temp = temp.getSiguiente();
            } while (temp != null);
        }
        return rama;
    }

    private NodoRamaArbol dividir(RamaArbol rama)
    {
        RamaArbol derecha = new RamaArbol(), izquierda = new RamaArbol();
        NodoRamaArbol medio = null, temp = rama.getPrimero();
        for (int i = 1; i < 6; i++, temp = temp.getSiguiente())
        {
            NodoRamaArbol nodo = new NodoRamaArbol(temp.getCodigoDestino(), temp.getNombreDestino());
            nodo.setIzquierda(temp.getIzquierda());
            nodo.setDerecha(temp.getDerecha());
            if (nodo.getDerecha() != null && nodo.getIzquierda() != null)
            {
                izquierda.setHoja(false);
                derecha.setHoja(false);
            }
            switch (i)
            {
                case 1:
                case 2:
                    izquierda.insertar(nodo);
                    break;
                case 3:
                    medio = nodo;
                    break;
                case 4:
                case 5:
                    derecha.insertar(nodo);
                    break;
            }
        }
        medio.setIzquierda(izquierda);
        medio.setDerecha(derecha);
        return medio;
    }

    /**
     *
     * Genera el contenido del archivo fuente para GraphViz
     * @return Un String con el contenido del archivo.
     */
    public String getDot()
    {
        String aux = "digraph lista{ \nnode [shape = record, style=filled];";
        aux += "splines=line; \n";
        getGrafNodos(raiz);
        aux += nodos;
        aux += "}";
        return aux;
    }

    private void getGrafNodos(RamaArbol raiz)
    {
        if (raiz == null)
        {
            return;
        }
        nodos += raiz.getGraphNodo();
        NodoRamaArbol aux = raiz.getPrimero();
        while (aux != null)
        {
            getGrafNodos(aux.getIzquierda());
            aux = aux.getSiguiente();
        }
        aux = raiz.getPrimero();
        while (aux.getSiguiente() != null)
        {
            aux = aux.getSiguiente();
        }
        getGrafNodos(aux.getDerecha());
    }

    public NodoRamaArbol busqueda(int numero)
    {
        if (!estaVacio())
        {
            return busca(numero, raiz);
        }
        else
        {
            return null;
        }
    }

    private NodoRamaArbol busca(int codDes, RamaArbol rama)
    {
        NodoRamaArbol nodo = rama.getPrimero();
        while (nodo != null)
        {
            if (codDes < nodo.getCodigoDestino())
            {
                if (rama.esHoja())
                {
                    return null;
                }
                else
                {
                    return busca(codDes, nodo.getIzquierda());
                }
            }
            else if (codDes == nodo.getCodigoDestino())
            {
                return nodo;
            }
            else if (nodo.getSiguiente() == null)
            {
                if (rama.esHoja())
                {
                    return null;
                }
                else
                {
                    return busca(codDes, nodo.getDerecha());
                }
            }
            nodo = nodo.getSiguiente();
        }
        return null;
    }







    private void busca(int codDes, RamaArbol rama, RamaArbol salida)
    {
        if (rama == null)
        {
            return;
        }
        NodoRamaArbol nodo = rama.getPrimero();
        while (nodo != null)
        {
            if (!rama.esHoja())
            {
                busca(codDes, nodo.getIzquierda(), salida);
                busca(codDes, nodo.getDerecha(), salida);
            }
            if (nodo.getCodigoDestino() == codDes)
            {
                salida.insertar(new NodoRamaArbol(nodo.getCodigoDestino(), nodo.getNombreDestino()));
            }
            nodo = nodo.getSiguiente();
        }
    }

    public void graficaB(ArbolDestinos aB)
    {

        StreamWriter fichero = null;
        try
        {
            fichero = new StreamWriter(@"C:\fuentes\arbolBDestino.dot");
            fichero.Write(getDot());
        }
        catch (Exception e) {
            //MessageBox.Show(e.ToString());
        }
        finally
        {
            try
            {
                if (null != fichero)
                    fichero.Close();
            }
            catch (Exception e2) { 
                //MessageBox.Show(e2.ToString());
            }
        }
        try
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("C:\\fuentes\\release\\bin\\dot.exe");
            startInfo.Arguments = "-Tpng  C:\\fuentes\\arbolBDestino.dot  -o  C:\\fuentes\\arbolBDestino.png ";
            Process.Start(startInfo);
            //Process.Start("C:\\fuentes\\arbolBDestino.png");
        }
        catch (Exception ex)
        {
            //MessageBox.Show("Error en generar archivo dot " + ex.ToString());
        }
    }

    public void graficaBdest(ArbolDestinos aB)
    {

        StreamWriter fichero = null;
        try
        {
            fichero = new StreamWriter(@"C:\fuentes\arbolBDestinoMatriz.dot");
            fichero.Write(getDotdest());
        }
        catch (Exception e)
        {
            //MessageBox.Show(e.ToString());
        }
        finally
        {
            try
            {
                if (null != fichero)
                    fichero.Close();
            }
            catch (Exception e2)
            {
                //MessageBox.Show(e2.ToString());
            }
        }
        try
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("C:\\fuentes\\release\\bin\\dot.exe");
            startInfo.Arguments = "-Tpng  C:\\fuentes\\arbolBDestinoMatriz.dot  -o  C:\\fuentes\\arbolBDestinoMatriz.png ";
            Process.Start(startInfo);
            //Process.Start("C:\\fuentes\\arbolBDestino.png");
        }
        catch (Exception ex)
        {
            //MessageBox.Show("Error en generar archivo dot " + ex.ToString());
        }
    }

    public String getDotdest()
    {
        String aux = "digraph lista{ \nnode [shape = record, style=filled];";
        aux += "splines=line; \n";
        getGrafNodosdest(raiz);
        aux += nodos;
        aux += "}";
        return aux;
    }

    private void getGrafNodosdest(RamaArbol raiz)
    {
        if (raiz == null)
        {
            return;
        }
        nodos += raiz.getGraphNodo2();
        NodoRamaArbol aux = raiz.getPrimero();
        while (aux != null)
        {
            getGrafNodosdest(aux.getIzquierda());
            aux = aux.getSiguiente();
        }
        aux = raiz.getPrimero();
        while (aux.getSiguiente() != null)
        {
            aux = aux.getSiguiente();
        }
        getGrafNodosdest(aux.getDerecha());
    }

    public void graficaBorig(ArbolDestinos aB)
    {

        StreamWriter fichero = null;
        try
        {
            fichero = new StreamWriter(@"C:\fuentes\arbolBOrigenMatriz.dot");
            fichero.Write(getDotorig());
        }
        catch (Exception e)
        {
            //MessageBox.Show(e.ToString());
        }
        finally
        {
            try
            {
                if (null != fichero)
                    fichero.Close();
            }
            catch (Exception e2)
            {
                //MessageBox.Show(e2.ToString());
            }
        }
        try
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("C:\\fuentes\\release\\bin\\dot.exe");
            startInfo.Arguments = "-Tpng  C:\\fuentes\\arbolBOrigenMatriz.dot  -o  C:\\fuentes\\arbolBOrigenMatriz.png";
            Process.Start(startInfo);
            //Process.Start("C:\\fuentes\\arbolBDestino.png");
        }
        catch (Exception ex)
        {
            //MessageBox.Show("Error en generar archivo dot " + ex.ToString());
        }
    }

    public String getDotorig()
    {
        String aux = "digraph lista{ \nnode [shape = record, style=filled];";
        aux += "splines=line; \n";
        getGrafNodosorig(raiz);
        aux += nodos;
        aux += "}";
        return aux;
    }

    private void getGrafNodosorig(RamaArbol raiz)
    {
        if (raiz == null)
        {
            return;
        }
        nodos += raiz.getGraphNodo2();
        NodoRamaArbol aux = raiz.getPrimero();
        while (aux != null)
        {
            getGrafNodosorig(aux.getIzquierda());
            aux = aux.getSiguiente();
        }
        aux = raiz.getPrimero();
        while (aux.getSiguiente() != null)
        {
            aux = aux.getSiguiente();
        }
        getGrafNodosorig(aux.getDerecha());
    }


}