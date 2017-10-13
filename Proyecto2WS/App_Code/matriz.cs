using System;
using System.Diagnostics;
using System.IO;

/// <summary>
/// Descripción breve de matriz
/// </summary>
public class matriz
{
    listaFila lisFila = new listaFila();
    listaColumna lisColumna = new listaColumna();
    public matriz()
    {
        //
        // TODO: Agregar aquí la lógica del constructor no hace nimi
        //
    }
    public void insertar(int columna, int fila, double costoV, int tiempoV)
    {
        nodoMatriz nuevo = new nodoMatriz(columna, fila, costoV, tiempoV);
        lisFila.insertar(fila);// si no exite insertar la fila ; else {no hacer nada}  
        lisColumna.insertar(columna);// si no exite insertar la columna ; else {no hacer nada}
        //////////////////////////////////////PRIMERO ENLAZAR POR COLUMNAS//////////////////////////////////////////                        
        nodoColumna auxcol = lisColumna.raiz;
        while (auxcol != null)
        {
            if (auxcol.columna == columna)//encontre la columna en q se tiene q insertar nodo!!
            {
                if (auxcol.primero == null)//1er caso lista vacia
                {
                    auxcol.primero = auxcol.ultimo = nuevo;// primero y ultimo de este nodo
                    nuevo.columna = auxcol;  //doble enlazado
                }
                else if (nuevo.fil < auxcol.primero.fil)// 2do caso menor al primero
                {
                    nuevo.down = auxcol.primero;// enlace  hacia abajo
                    auxcol.primero.up = nuevo;// enlace hacia arriba
                    auxcol.primero.columna = null;// elimina el puntero del primer nodo hacia la columna 
                    auxcol.primero = nuevo; // enlaza columna con el nuevo nodo
                    nuevo.columna = auxcol;
                }
                else if (nuevo.fil > auxcol.ultimo.fil)//3er caso mayor al ultimo
                {
                    nuevo.up = auxcol.ultimo;
                    auxcol.ultimo.down = nuevo;
                    auxcol.ultimo = nuevo;
                }
                else // 4to caso. Caso terminal es un nodo medio!!!!!
                {
                    nodoMatriz auxM = auxcol.primero;
                    while (auxM != null)
                    {
                        if (nuevo.fil == auxM.fil) { break; }
                        else if (nuevo.fil < auxM.fil)
                        {
                            nuevo.down = auxM;
                            nuevo.up = auxM.up;
                            auxM.up.down = nuevo;
                            auxM.up = nuevo;
                            break;
                        }
                        auxM = auxM.down;
                    }

                }
            }
            auxcol = auxcol.sig;// me estoy moviendo en las columnas  
        }
        ////////////////////////////////// ENLAZAR POR FILAS//////////////////////////////////////////////////
        nodoFila auxfil = lisFila.raiz;
        while (auxfil != null)
        {
            if (auxfil.fila == fila)//encontre la fila en q se tiene q insertar nodo!!
            {
                if (auxfil.primero == null)//1er caso lista vacia
                {
                    auxfil.primero = auxfil.ultimo = nuevo;// primero y ultimo de este nodo
                    nuevo.fila = auxfil;  //doble enlazado
                }
                else if (nuevo.col < auxfil.primero.col)// 2do caso menor al primero
                {
                    nuevo.sig = auxfil.primero;// enlace  hacia derecha
                    auxfil.primero.ant = nuevo;// enlace hacia izquierda
                    auxfil.primero.fila = null;// elimina el puntero del primer nodo hacia la fila 
                    auxfil.primero = nuevo; // enlaza columna con el nuevo nodo
                    nuevo.fila = auxfil;
                }
                else if (nuevo.col > auxfil.ultimo.col)//3er caso mayor al ultimo
                {
                    nuevo.ant = auxfil.ultimo;
                    auxfil.ultimo.sig = nuevo;
                    auxfil.ultimo = nuevo;
                }
                else // 4to caso. Caso terminal es un nodo medio!!!!!
                {
                    nodoMatriz auxM = auxfil.primero;
                    while (auxM != null)
                    {
                        if (nuevo.col == auxM.col) { break; }

                        else if (nuevo.col < auxM.col)
                        {
                            nuevo.sig = auxM;
                            nuevo.ant = auxM.ant;
                            auxM.ant.sig = nuevo;
                            auxM.ant = nuevo;
                            break;
                        }
                        auxM = auxM.sig;
                    }

                }
            }
            auxfil = auxfil.sig;// me estoy moviendo en las filas  
        }
    }

    public string RecorrerColumna()
    {
        nodoColumna aux = lisColumna.raiz;
        string nodos = "";
        while (aux != null)
        {
            //Console.WriteLine("Columna  ------> " + aux.columna);
            nodos = nodos + aux.columna.ToString() + ",";
            aux = aux.sig;
        }
        return nodos;
    }

    public string RecorrerFilas()
    {
        nodoFila aux = lisFila.raiz;
        string nodos = "";
        while (aux != null)
        {
            //Console.WriteLine("Columna  ------> " + aux.columna);
            nodos = nodos + aux.fila.ToString() + ",";
            aux = aux.sig;
        }
        return nodos;
    }

    public void graficarMatriz()
    {
        System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\fuentes\Matriz.dot");
        file.Write("digraph GraficaMR{ \n node[shape=record]; graph[rankdir=LR];\n");
        file.Write("subgraph cluster1{\n");
        file.Write("{rank = same Matriz[label = \"Matriz\"]");
        nodoColumna auxCol = lisColumna.raiz;
        while(auxCol != null)
        {
            file.Write(" x"+auxCol.columna+ "[label=\"x"+auxCol.columna+"\"]");
            auxCol = auxCol.sig;
        }
        file.Write("}\n");
        auxCol = lisColumna.raiz;
        while(auxCol != null)
        {
            if(auxCol.sig != null)
            {
                file.Write("x" + auxCol.columna + "->" + "x" + auxCol.sig.columna + ";\n");
                file.Write("x" + auxCol.sig.columna + "->" + "x" + auxCol.columna + ";\n");
            }
            auxCol = auxCol.sig;
        }
        nodoFila auxFil = lisFila.raiz;
        while(auxFil != null)
        {
            file.Write("{rank = same y"+auxFil.fila+"[label=\"y"+auxFil.fila+"\"]\n");
            nodoMatriz auxM = auxFil.primero;
            while(auxM != null)
            {
                file.Write(auxM.col+""+auxM.fil+"[label=\"Costo: "+auxM.costoV+"\\nTiempo: "+auxM.tiempoV+"\"]\n");
                auxM = auxM.sig;
            }
            auxM = auxFil.primero;
            while(auxM.sig != null)
            {
                file.Write(auxM.col+""+auxM.fil+"->"+auxM.sig.col+""+auxM.sig.fil+";\n");
                file.Write(auxM.sig.col + "" + auxM.sig.fil + "->" + auxM.col + "" + auxM.fil + ";\n");
                auxM = auxM.sig;
            }
            auxM = auxFil.primero;
            file.Write("y"+auxM.fil+"->"+auxM.col+""+auxM.fil+";\n");
            file.Write(auxM.col+""+auxM.fil + "->" + "y"+auxM.fil+";\n");

            file.Write("}\n");
            auxFil = auxFil.sig;
        }
        auxCol = lisColumna.raiz;
        while(auxCol != null)
        {
            nodoMatriz auxM = auxCol.primero;
            while(auxM.down != null)
            {
                file.Write(auxM.col + "" + auxM.fil + "->" + auxM.down.col + "" + auxM.down.fil + ";\n");
                file.Write(auxM.down.col + "" + auxM.down.fil + "->" + auxM.col + "" + auxM.fil + ";\n");
                auxM = auxM.down;
            }
            auxM = auxCol.primero;
            file.Write("x" + auxM.col + "->" + auxM.col + "" + auxM.fil + ";\n");
            file.Write(auxM.col + "" + auxM.fil + "->" + "x" + auxM.col + ";\n");
            auxCol = auxCol.sig;
        }
        auxFil = lisFila.raiz;
        while(auxFil != null)
        {
            if(auxFil.sig != null)
            {
                file.Write("y" + auxFil.fila + "->y" + auxFil.sig.fila + ";\n");
                file.Write("y" + auxFil.sig.fila + "->y" + auxFil.fila + ";\n");
            }
            auxFil = auxFil.sig;
        }

        

        file.Write("Matriz->x"+lisColumna.raiz.columna+";\n");
        file.Write("Matriz->y" + lisFila.raiz.fila + ";\n");
        file.Write("x" + lisColumna.raiz.columna + "->Matriz;\n");
        file.Write("y" + lisFila.raiz.fila + "->Matriz;\n");

        file.Write("\n}");
        file.Write("\n}");
        file.Close();

        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo("C:\\fuentes\\release\\bin\\dot.exe");
        startInfo.Arguments = "-Tpng C:\\fuentes\\Matriz.dot -o C:\\fuentes\\Matriz.png";
        Process.Start(startInfo);
    }

    public void ELiminarMatriz(int PrimerPais, int SegundoPais)
    {
        nodoColumna auxcol = lisColumna.raiz;
        while (auxcol != null)
        {
            if(auxcol.columna == PrimerPais)//encontre la columna que voy a eliminar
            {
                if(auxcol.primero == auxcol.ultimo) //1er caso es el unico nodo en esa columna
                {
                    if(lisColumna.raiz == lisColumna.ultimo)//1.1 es la unica columna
                    {
                        auxcol.primero = auxcol.ultimo = null;
                        lisColumna.raiz = lisColumna.ultimo = null;
                    }else if(auxcol == lisColumna.raiz)//1.2 la columna es igual a la raiz
                    {
                        auxcol.primero = auxcol.ultimo = null;
                        lisColumna.raiz = auxcol.sig;
                        lisColumna.raiz.ant = null;
                        auxcol.sig = null;
                    }else if(auxcol == lisColumna.ultimo)//1.3 la columna es igual al ultimo
                    {
                        auxcol.primero = auxcol.ultimo = null;
                        lisColumna.ultimo = auxcol.ant;
                        auxcol.ant = null;
                        auxcol.sig = null;
                        lisColumna.ultimo.sig = null;
                    }
                    else//1.4 es un nodo medio
                    {
                        auxcol.primero = auxcol.ultimo = null;
                        auxcol.ant.sig = auxcol.sig;
                        auxcol.sig.ant = auxcol.ant;
                        auxcol.sig = null;
                        auxcol.ant = null;
                    }
                }else if(auxcol.primero.col == PrimerPais)//2do caso es el primer nodo en esa columna
                {
                    nodoMatriz auxCM = auxcol.primero;
                    auxcol.primero = auxCM.down;
                    auxCM.down.up = auxcol.primero;
                    auxCM.down = null;
                    auxCM.up = null;
                }else if(auxcol.ultimo.col == PrimerPais)//3do caso es el ultimo nodo en esa columna
                {
                    nodoMatriz auxCM = auxcol.ultimo;
                    auxcol.ultimo = auxCM.up;
                    auxCM.up.down = auxcol.ultimo;
                    auxCM.down = null;
                    auxCM.up = null;
                }else//4to caso esta en medio de algun nodo
                {
                    nodoMatriz auxCM = auxcol.primero;
                    while(auxCM != null)
                    {
                        if(auxCM.col == PrimerPais )
                        {
                            auxCM.up.down = auxCM.down;
                            auxCM.down.up = auxCM.up;
                            auxCM.down = null;
                            auxCM.up = null;
                        }
                        auxCM = auxCM.down;
                    }
                }
            }
            auxcol = auxcol.sig;//me muevo columnas
        }
        //desenlace por filas
        nodoFila auxFila = lisFila.raiz;
        while (auxFila != null)
        {
            if (auxFila.fila == SegundoPais)//encontre la columna que voy a eliminar
            {
                if (auxFila.primero == auxFila.ultimo) //1er caso es el unico nodo en esa columna
                {
                    if (lisFila.raiz == lisFila.ultimo)//1.1 es la unica columna
                    {
                        auxFila.primero = auxFila.ultimo = null;
                        lisFila.raiz = lisFila.ultimo = null;
                    }
                    else if (auxFila == lisFila.raiz)//1.2 la columna es igual a la raiz
                    {
                        auxFila.primero = auxFila.ultimo = null;
                        lisFila.raiz = auxFila.sig;
                        lisFila.raiz.ant = null;
                        auxFila.sig = null;
                    }
                    else if (auxFila == lisFila.ultimo)//1.3 la columna es igual al ultimo
                    {
                        auxFila.primero = auxFila.ultimo = null;
                        lisFila.ultimo = auxFila.ant;
                        auxFila.ant = null;
                        lisFila.ultimo.sig = null;
                    }
                    else//1.4 es un nodo medio
                    {
                        auxFila.primero = auxFila.ultimo = null;
                        auxFila.ant.sig = auxFila.sig;
                        auxFila.sig.ant = auxFila.ant;
                        auxFila.sig = null;
                        auxFila.ant = null;
                    }
                }
                else if (auxFila.primero.fil == SegundoPais)//2do caso es el primer nodo en esa columna
                {
                    nodoMatriz auxCM = auxFila.primero;
                    auxFila.primero = auxCM.sig;
                    auxCM.sig.ant = auxFila.primero;
                    auxCM.sig = null;
                    auxCM.ant = null;
                }
                else if (auxFila.ultimo.fil == SegundoPais)//3do caso es el ultimo nodo en esa columna
                {
                    nodoMatriz auxCM = auxFila.ultimo;
                    auxFila.ultimo = auxCM.ant;
                    auxCM.ant.sig = auxFila.ultimo;
                    auxCM.sig = null;
                    auxCM.ant = null;
                }
                else//4to caso esta en medio de algun nodo
                {
                    nodoMatriz auxCM = auxFila.primero;
                    while (auxCM != null)
                    {
                        if (auxCM.fil == SegundoPais)
                        {
                            auxCM.ant.sig = auxCM.sig;
                            auxCM.sig.ant = auxCM.ant;
                            auxCM.sig = null;
                            auxCM.ant = null;
                        }
                        auxCM = auxCM.sig;
                    }
                }
            }
            auxFila = auxFila.sig;
        }
    }

    public void modificarMatriz(int PrimerPais, int SegundoPais, double costo, int tiempo)
    {
        nodoColumna auxcol = lisColumna.raiz;
        while (auxcol != null)
        {
            if (auxcol.columna == PrimerPais)//encontre la columna que voy a eliminar
            {
                nodoMatriz auxM = auxcol.primero;
                while(auxM != null)
                {
                    if(auxM.fil == SegundoPais)
                    {
                        auxM.costoV = costo;
                        auxM.tiempoV = tiempo;
                    }
                    auxM = auxM.down;
                }
            }
            auxcol = auxcol.sig;
        }
    }

    public void graficarGrafo()
    {
        System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\fuentes\Grafo.dot");
        file.Write("digraph Grafo{\n");
        file.Write("subgraph cluster1{\n");

        nodoColumna auxcol = lisColumna.raiz;
        while (auxcol != null)
        {
                nodoMatriz auxM = auxcol.primero;
                while (auxM != null)
                {
                    file.Write(auxM.col+";\n");
                    auxM = auxM.down;
                }
            
            auxcol = auxcol.sig;
        }

        auxcol = lisColumna.raiz;
        while (auxcol != null)
        {
            nodoMatriz auxM = auxcol.primero;
            while (auxM.down != null)
            {
                file.Write(auxM.col+"->"+auxM.down.col + ";\n");
                auxM = auxM.down;
            }

            auxcol = auxcol.sig;
        }


        file.Write("\n}");
        file.Write("\n}");
        file.Close();
        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo("C:\\fuentes\\release\\bin\\dot.exe");
        startInfo.Arguments = "-Tpng C:\\fuentes\\Grafo.dot -o C:\\fuentes\\Grafo.png";
        Process.Start(startInfo);
    }

    }