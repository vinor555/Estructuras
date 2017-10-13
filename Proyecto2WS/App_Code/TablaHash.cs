using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de TablaHash
/// </summary>
public class TablaHash
{
    ElementoHash[] Tabla = new ElementoHash[7];
    int tamanio;
    float facOcupacion;
    float facVacio;
    int numDatos;
    bool insertar;
    int repetido;
    int iteracion;
    public TablaHash()
    {
        tamanio = 7;
        facOcupacion = numDatos / tamanio;
        facVacio = 0;
        numDatos = 0;
        insertar = false;
        repetido = 0;
        iteracion = 0;
    }

    public int funcionHash(string nom)
    {
        if (nom != " ")
        {
            int clave;
            byte[] codigo = System.Text.ASCIIEncoding.ASCII.GetBytes(nom);
            int suma = 0;
            for (int i = 0; i < 3; i++)
            {
                suma = suma + codigo[i];
            }

            clave = suma % tamanio;

            if (clave > (tamanio - 1))
            {
                clave = clave - tamanio;
            }
            return clave;
        }
        else
        {
            return -1;
        }
    }

    public int funcionHashInversa(string nom, int tam)
    {
        if (nom != " ")
        {
            int clave;
            byte[] codigo = System.Text.ASCIIEncoding.ASCII.GetBytes(nom);
            int suma = 0;
            for (int i = 0; i < 3; i++)
            {
                suma = suma + codigo[i];
            }

            clave = suma % tam;
            return clave;
        }
        else
        {
            return -1;
        }

    }

    public void insertarHash(string nombre, int reser, float cost, float time)
    {

        facOcupacion = (float)numDatos / tamanio;
        int clave = funcionHash(nombre);
        insertar = true;

        if (facOcupacion <= 0.5)
        {
            while (insertar == true)
            {
                if (Tabla[clave] == null)
                {
                    Tabla[clave] = new ElementoHash(nombre, reser, cost, time);
                    //MessageBox.Show("EL NOMBRE: " + nombre + "\n SE INGRESO SATISFACTORIAMENTE");
                    insertar = false;
                    numDatos++;
                    iteracion = 0;
                }
                else
                {
                    if (Tabla[clave].nomCliente.Equals(nombre))
                    {
                        //MessageBox.Show("Ya existe un nombre igual a: " + nombre);
                        System.Console.WriteLine("EL Nombre ya existe");
                        insertar = false;
                        repetido++;
                        break;
                    }
                    else
                    {
                        iteracion++;
                        clave = clave + (iteracion * iteracion);

                        while (clave > (Tabla.Length - 1))
                        {
                            clave = clave - Tabla.Length;
                        }
                    }
                }
            }
        }
        else
        {
            //MessageBox.Show("SE REQUIERE DE RE-HASHING");
            ReHashing();
            insertarHash(nombre, reser, cost, time);

        }
    }

    public void ReHashing()
    {
        tamanio = buscarPrimoSiguiente(tamanio);
        ElementoHash[] aux = new ElementoHash[tamanio];
        int clave2;
        insertar = false;

        for (int i = 0; i < Tabla.Length; i++)
        {
            if (Tabla[i] != null)
            {
                clave2 = funcionHash(Tabla[i].nomCliente);
                insertar = true;

                while (insertar == true)
                {
                    if (aux[clave2] == null)
                    {
                        aux[clave2] = new ElementoHash(Tabla[i].nomCliente, Tabla[i].numReservacion, Tabla[i].costoViaje, Tabla[i].tiempoVuelo);
                        aux[clave2].inicio = Tabla[i].inicio;
                        insertar = false;
                        iteracion = 0;
                    }
                    else
                    {
                        iteracion++;
                        clave2 = clave2 + (iteracion * iteracion);

                        while (clave2 > (Tabla.Length - 1))
                        {
                            clave2 = clave2 - Tabla.Length;
                        }
                    }
                }

            }
        }

        Tabla = aux;
    }

    public void ReHashingInverso()
    {
        tamanio = buscarPrimoAnterior(tamanio);
        ElementoHash[] aux = new ElementoHash[tamanio];
        int clave2;
        insertar = false;

        for (int i = 0; i < Tabla.Length; i++)
        {
            if (Tabla[i] != null && Tabla[i].eliminado == 0)
            {
                clave2 = funcionHash(Tabla[i].nomCliente);

                insertar = true;

                while (insertar == true)
                {
                    if (aux[clave2] == null)
                    {
                        aux[clave2] = new ElementoHash(Tabla[i].nomCliente, Tabla[i].numReservacion, Tabla[i].costoViaje, Tabla[i].tiempoVuelo);
                        aux[clave2].inicio = Tabla[i].inicio;
                        insertar = false;
                        iteracion = 0;
                    }
                    else
                    {
                        iteracion++;
                        clave2 = clave2 + (iteracion * iteracion);

                        while (clave2 > (aux.Length - 1))
                        {
                            clave2 = clave2 - aux.Length;
                        }
                    }
                }

            }
        }

        Tabla = aux;
    }
    public int buscarPrimoSiguiente(int semilla)
    {
        bool primo = false;
        int valor = semilla;
        int divisor;
        int contador = 0;

        while (primo == false)
        {
            valor++;
            divisor = 2;
            contador = 0;
            while (divisor <= valor)
            {

                if (valor % divisor == 0)
                {
                    contador++;
                    divisor++;
                }
                else
                {
                    divisor++;
                }

            }

            if (contador == 1)
            {
                primo = true;
            }
        }
        return valor;
    }

    public int buscarPrimoAnterior(int semilla)
    {
        bool primo = false;
        int valor = semilla;
        int divisor;
        int contador = 0;

        while (primo == false)
        {
            valor--;
            divisor = 2;
            contador = 0;
            while (divisor <= valor)
            {

                if (valor % divisor == 0)
                {
                    contador++;
                    divisor++;
                }
                else
                {
                    divisor++;
                }

            }

            if (contador == 1)
            {
                primo = true;
            }
        }

        //MessageBox.Show("EL PRIMO ANTERIOR ES: " + valor.ToString());
        return valor;

    }
    public void eliminarHash(string name)
    {
        int clave = buscarNombre(name);
        if (clave != -1)
        {
            Tabla[clave].eliminado = 1;
            //MessageBox.Show(name + "\nSE ELIMINO SATISFACTORIAMENTE");
            numDatos--;
            facVacio = (float)numDatos / tamanio;

            if (facVacio <= 0.4)
            {
                //Se llama a la funcion ReHashing Inverso
                //MessageBox.Show("SE REQUIERE \nRE-HASHING INVERSO");
                int primoAnt = buscarPrimoAnterior(tamanio);
                ReHashingInverso();
            }

        }

    }
    public int buscarNombre(string name)
    {
        int clave;
        clave = funcionHash(name);
        bool buscar = true;
        while (clave > Tabla.Length - 1)
        {
            clave = clave - Tabla.Length;
        }

        while (buscar == true)
        {
            if (Tabla[clave] == null)
            {
                //MessageBox.Show("EL NOMBRE: " + name + "\n !!NO EXISTE!!");
                buscar = false;
            }
            else
            {
                if (name.Equals(Tabla[clave].nomCliente, StringComparison.InvariantCultureIgnoreCase))
                {
                    iteracion = 0;
                    buscar = false;
                    return clave;
                }
                else
                {
                    iteracion++;
                    clave = clave + (iteracion * iteracion);

                    while (clave > (Tabla.Length - 1))
                    {
                        clave = clave - Tabla.Length;
                    }
                }
            }
        }
        return -1;
    }

    public void GraficarHash()
    {

        int u = Tabla.Length - 1;
        System.IO.StreamWriter Archivo = new System.IO.StreamWriter(@"C:\fuentes\Hash.dot");
        //StreamWriter Archivo = new StreamWriter("Hash.dot");

        Archivo.Write("digraph G {\n");
        Archivo.Write("nodesep=.05;\n");
        Archivo.Write("rankdir=LR;\n");
        Archivo.Write("node [shape=record,width=.1,height=.1];\n");
        Archivo.Write("node0 [label = \"");
        for (int j = 0; j < Tabla.Length - 1; j++)
        {
            Archivo.Write("<f" + j + ">" + j + "|");
        }
        Archivo.Write("<f" + u + ">" + u + "\"" + ",height=2.5];\n");
        Archivo.Write("node [width = 1.5];\n");

        for (int j = 0; j < Tabla.Length; j++)
        {
            if (Tabla[j] != null && Tabla[j].eliminado == 0)
            {
                Archivo.Write("node" + (j + 1) + "[label = \"{<n> " + Tabla[j].nomCliente + "\\nRes: " + Tabla[j].numReservacion + "}\"];\n");
                if (Tabla[j].inicio != null)
                {
                    NodoPais aux;
                    aux = Tabla[j].inicio;
                    while (aux != null)
                    {
                        Archivo.Write(Tabla[j].nomCliente + aux.codPais + "[label=\"Cod: " + aux.codPais + "\"];\n");
                        aux = aux.siguiente;
                    }
                }
            }
        }
        for (int j = 0; j < Tabla.Length; j++)
        {
            if (Tabla[j] != null && Tabla[j].eliminado == 0)
            {
                Archivo.Write("node0:f" + j + "->" + "node" + (j + 1) + ":n;\n");
                if (Tabla[j].inicio != null)
                {
                    NodoPais aux;
                    aux = Tabla[j].inicio;
                    while (aux != null)
                    {

                        if (aux.siguiente != null)
                        {
                            Archivo.Write(Tabla[j].nomCliente + aux.codPais + "->" + Tabla[j].nomCliente + aux.siguiente.codPais + ";\n");
                        }
                        aux = aux.siguiente;
                    }
                    Archivo.Write("node" + (j + 1) + "->" + Tabla[j].nomCliente + Tabla[j].inicio.codPais + ";\n");
                }
            }
        }
        Archivo.Write("\n}");

        Archivo.Close();
        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo("C:\\fuentes\\release\\bin\\dot.exe");
        startInfo.Arguments = "-Tpng C:\\fuentes\\Hash.dot -o C:\\fuentes\\Hash.png";
        Process.Start(startInfo);
    }

    public void insertarVuelo(int clave, int cod)
    {
        //int clave = buscarNombre(nom);
        if (clave != -1)
        {
            NodoPais nuevo = new NodoPais(cod);
            if (Tabla[clave].inicio == null)
            {
                Tabla[clave].inicio = nuevo;
                Tabla[clave].fin = nuevo;
            }
            else
            {
                Tabla[clave].fin.siguiente = nuevo;
                Tabla[clave].fin = nuevo;
            }
        }

    }
}