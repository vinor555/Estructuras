using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Proyecto2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int idDest;
        string nomDest;

        int idDestm;
        int idOrim;
        int costoV;
        int tiempoV;
        private void cargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string line;
            int cont = 0;
            
            WSp2.proyectoWSSoapClient ws = new WSp2.proyectoWSSoapClient();
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Cursor Files|*.csv";
                openFileDialog1.Title = "Abrir Archivo";
                openFileDialog1.ShowDialog();
                
                if (File.Exists(openFileDialog1.FileName))
                {
                    System.IO.StreamReader file = new System.IO.StreamReader(openFileDialog1.FileName);
                    //leer(openFileDialog1.FileName);
                    while ((line = file.ReadLine()) != null)
                    {
                        string[] lines = Regex.Split(line, ",");
                        foreach (string var1 in lines)
                        {
                            if(cont == 0)
                            {
                                idDest = Int32.Parse(var1);
                                cont = 1;
                            }else if(cont == 1)
                            {
                                nomDest = var1;
                                cont = 0;
                            }
                        }
                        ws.insertarAb(idDest, nomDest);
                        //Console.WriteLine(idDest + ", " + nomDest);
                    }
                    Console.WriteLine("Destinos cargados completamente");
                }
            }catch(Exception)
            {
                MessageBox.Show("El archivo no se abrio correctamente");
            }
           



        }

        private void limpiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WSp2.proyectoWSSoapClient ws = new WSp2.proyectoWSSoapClient();
            ws.limpiarWS();
        }

        private void arbolBDestinosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            string path = "C:\\fuentes";
            //Console.WriteLine("The current directory is {0}", path);
            path = path + "\\arbolBDestino.png";
            Process.Start(path);
        }

        private void matrizToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = "C:\\fuentes";
            //Console.WriteLine("The current directory is {0}", path);
            path = path + "\\Matriz.png";
            Process.Start(path);
        }

        private void cargarReservacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WSp2.proyectoWSSoapClient ws = new WSp2.proyectoWSSoapClient();

            int counter = 0;
            string line;
            Stream myStream = null;
            OpenFileDialog file = new OpenFileDialog();
            //file.InitialDirectory = "c:\\";
            file.Filter = "Archivos de Texto (*.CSV)|*.CSV|Todos los archivos (*.*)|*.*";
            file.RestoreDirectory = true;

            //file.ShowDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = file.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            StreamReader archivo = new StreamReader(file.FileName);
                            while ((line = archivo.ReadLine()) != null)
                            {
                                int cont = 0;
                                string nombre = "";
                                string reservacion = "";
                                string costo = "";
                                string tiempo = "";
                                System.Console.WriteLine(line);
                                string[] palabras = line.Split(',');

                                foreach (string token in palabras)
                                {
                                    cont++;
                                    switch (cont)
                                    {
                                        case 1:
                                            nombre = token;
                                            break;
                                        case 2:
                                            reservacion = token;
                                            break;
                                        case 3:
                                            costo = token;
                                            break;
                                        case 4:
                                            tiempo = token;
                                            ws.IngresarHash(nombre, Convert.ToInt32(reservacion), float.Parse(costo), float.Parse(tiempo));
                                            break;
                                        default:
                                            int clave = ws.buscarClaveHash(nombre);
                                            ws.insertarVuelo(clave, Convert.ToInt32(token));
                                            break;
                                    }

                                }

                                counter++;
                            }

                            archivo.Close();
                            Console.WriteLine("Reservaciones cargado completamente");
                            System.Console.WriteLine("There were {0} lines.", counter);
                            // Suspend the screen.  
                            System.Console.ReadLine();

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: NO SE PUDO LEER EL ARCHIVO DESDE EL DISCO. Original error: " + ex.Message);
                }
            }
        }

        private void tHReservacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            string path = "C:\\fuentes";
            //Console.WriteLine("The current directory is {0}", path);
            path = path + "\\Hash.png";
            Process.Start(path);

        }

        private void cargarRutasVueloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string line;
            int cont = 0;

            WSp2.proyectoWSSoapClient ws = new WSp2.proyectoWSSoapClient();
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Cursor Files|*.csv";
                openFileDialog1.Title = "Abrir Archivo";
                openFileDialog1.ShowDialog();

                if (File.Exists(openFileDialog1.FileName))
                {
                    System.IO.StreamReader file = new System.IO.StreamReader(openFileDialog1.FileName);
                    //leer(openFileDialog1.FileName);
                    while ((line = file.ReadLine()) != null)
                    {
                        string[] lines = Regex.Split(line, ",");
                        foreach (string var1 in lines)
                        {
                            if (cont == 0)
                            {
                                idOrim = Int32.Parse(var1);
                                cont++ ;
                            }
                            else if (cont == 1)
                            {
                                idDestm = Int32.Parse(var1);
                                cont++ ;
                            }
                            else if (cont == 2)
                            {
                                costoV = Int32.Parse(var1);
                                cont++;
                            }
                            else if (cont == 3)
                            {
                                tiempoV = Int32.Parse(var1); ;
                                cont = 0;
                            }
                        }
                        if (ws.busquedaABD(idDestm) && ws.busquedaABD(idOrim))
                        {
                            ws.insertarAbom(idOrim, "");
                            ws.insertarAbdm(idDestm, "");
                            ws.insertarAbom(idDestm, "");
                            ws.insertarAbdm(idOrim, "");
                            ws.insertarMatriz(idDestm, idOrim, costoV, tiempoV);
                            ws.insertarMatriz(idOrim, idDestm, costoV, tiempoV);
                        }
                        else
                        {
                            Console.WriteLine(idDestm + " o" + idOrim + " No estan en los destinos");
                        }

                        //Console.WriteLine(idOrim + ", " + idDestm+","+costoV+","+tiempoV);
                    }
                    Console.WriteLine("Rutas cargado correctamente");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("El archivo no se abrio correctamente");
            }
        }

        private void arbolBDestMToolStripMenuItem_Click(object sender, EventArgs e)
        {
 
            string path = "C:\\fuentes";
            path = path + "\\arbolBDestinoMatriz.png";
            Process.Start(path);
        }

        private void arbolBOrigMToolStripMenuItem_Click(object sender, EventArgs e)
        {
  
            string path = "C:\\fuentes";
            path = path + "\\arbolBOrigenMatriz.png";
            Process.Start(path);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WSp2.proyectoWSSoapClient ws = new WSp2.proyectoWSSoapClient();
            string valor1 = comboBox1.SelectedItem.ToString();
            string valor2 = comboBox2.SelectedItem.ToString();
            double costoV = Convert.ToDouble(textBox1.Text.ToString());   
            int tiempoV = Int32.Parse(textBox2.Text.ToString());

            ws.modificarMatriz(Int32.Parse(valor1), Int32.Parse(valor2), costoV, tiempoV);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WSp2.proyectoWSSoapClient ws = new WSp2.proyectoWSSoapClient();
            string nodos = ws.recorrerCol();
            nodos = nodos.TrimEnd(',');
            string[] palabras = nodos.Split(',');
            foreach (string token in palabras)
            {
                comboBox1.Items.Add(token);
                //Console.Write(token + "\n");
            }

            nodos = ws.recorrerFil();
            nodos = nodos.TrimEnd(',');
            palabras = nodos.Split(',');
            foreach (string token in palabras)
            {
                comboBox2.Items.Add(token);
                //Console.Write(token + "\n");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //comboBox1.Items.Clear();
            //comboBox2.Items.Clear();
            WSp2.proyectoWSSoapClient ws = new WSp2.proyectoWSSoapClient();
            string valor1 = comboBox1.SelectedItem.ToString();
            string valor2 = comboBox2.SelectedItem.ToString();
            ws.eliminarMatriz(Int32.Parse(valor1), Int32.Parse(valor2));
            //Console.WriteLine(Int32.Parse(valor1) +","+ Int32.Parse(valor2));
        }

        private void generarMatrizToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WSp2.proyectoWSSoapClient ws = new WSp2.proyectoWSSoapClient();
            ws.graficarMatriz();
        }

        private void generarABDestinosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WSp2.proyectoWSSoapClient ws = new WSp2.proyectoWSSoapClient();
            ws.graficarAb();
        }

        private void generarABDestMatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WSp2.proyectoWSSoapClient ws = new WSp2.proyectoWSSoapClient();
            ws.graficarAbDest();
        }

        private void generarABOrigMatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WSp2.proyectoWSSoapClient ws = new WSp2.proyectoWSSoapClient();
            ws.graficarAbOrig();
        }

        private void generarTHRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WSp2.proyectoWSSoapClient ws = new WSp2.proyectoWSSoapClient();
            ws.graficarHash();
        }

        private void generarGrafoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WSp2.proyectoWSSoapClient ws = new WSp2.proyectoWSSoapClient();
            ws.graficarGrafo();
        }
    }
}
