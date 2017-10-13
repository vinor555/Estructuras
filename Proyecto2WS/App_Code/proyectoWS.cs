using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Descripción breve de proyectoWS
/// </summary>
[WebService(Namespace = "http://proyecto2.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class proyectoWS : System.Web.Services.WebService
{
    static matriz ma = new matriz();
    static ArbolDestinos ab = new ArbolDestinos();
    static TablaHash th = new TablaHash();
    static ArbolDestinos adm = new ArbolDestinos();
    static ArbolDestinos aom = new ArbolDestinos();
    public proyectoWS()
    {
        

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }
    

    [WebMethod]
    public string HelloWorld()
    {
        return "Hola a todos hijos de puta";
    }

    [WebMethod]
    public void insertarMatriz(int x, int y, double costoV, int tiempoV)
    {
        ma.insertar(x,y,costoV,tiempoV);
    }

    [WebMethod]
    public void graficarMatriz()
    {
        ma.graficarMatriz();
    }

    [WebMethod]
    public void limpiarWS()
    {
        ma = new matriz();
        ab = new ArbolDestinos();
        th = new TablaHash();
        adm = new ArbolDestinos();
        aom = new ArbolDestinos();
    }

    [WebMethod]
    public void insertarAb(int codDes, String nomDes)
    {
        ab.insertar(codDes, nomDes);
        
    }

    [WebMethod]
    public void graficarAb()
    {
        ab.graficaB(ab);

    }

    [WebMethod]
    public void graficarAbDest()
    {
        adm.graficaBdest(adm);

    }

    [WebMethod]
    public void graficarAbOrig()
    {
        aom.graficaBorig(aom);

    }



    [WebMethod]
    public void IngresarHash(string nombre, int reser, float cost, float time)
    {
        th.insertarHash(nombre,reser,cost,time);
    }

    [WebMethod]
    public void graficarHash()
    {
        th.GraficarHash();
    }

    [WebMethod]
    public int buscarClaveHash(String nombre)
    {
        return th.buscarNombre(nombre);
    }

    [WebMethod]
    public void insertarVuelo(int clave, int cod)
    {
        th.insertarVuelo(clave, cod);
    }

    [WebMethod]
    public void insertarAbdm(int codDes, String nomDes)
    {
        adm.insertar(codDes, nomDes);

    }

    [WebMethod]
    public void insertarAbom(int codDes, String nomDes)
    {
        aom.insertar(codDes, nomDes);

    }

    [WebMethod]
    public Boolean busquedaABD(int numero)
    {
        NodoRamaArbol aux = ab.busqueda(numero);  
        if(aux != null)
        {
            if (aux.getCodigoDestino() == numero)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    [WebMethod]
    public string recorrerCol()
    {
        return ma.RecorrerColumna();
    }

    [WebMethod]
    public string recorrerFil()
    {
        return ma.RecorrerFilas();
    }


    [WebMethod]
    public void eliminarMatriz(int PrimerPais, int SegundoPais)
    {
        ma.ELiminarMatriz(PrimerPais, SegundoPais);
    }

    [WebMethod]
    public void modificarMatriz(int PrimerPais, int SegundoPais, double costo, int tiempo)
    {
        ma.modificarMatriz(PrimerPais, SegundoPais, costo, tiempo);
    }

    [WebMethod]
    public void graficarGrafo()
    {
        ma.graficarGrafo();
    }

    [WebMethod]
    public void eliminarHash(string nombre)
    {
        th.eliminarHash(nombre);
    }
}
