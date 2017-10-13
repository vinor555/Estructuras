#include "mainwindow.h"
#include "ui_mainwindow.h"
#include <QString>
#include <stdio.h>

#include "abb.h"
#include "graficar.h"
#include "matriz.h"
#include "circulard.h"
#include "listasimple.h"
#include "avl.h"
#include <string>

#include <iostream>
using namespace std;

nodoAbb *arbol = NULL;
nodoLCD *cabezaLD = NULL;
nodoLCD *colaLD = NULL;
Arbol ArbolInt=NULL;



stcNodoCF *pPrimeroF = NULL;
stcNodoCF *pUltimoF = NULL;
stcNodoCC *pPrimeroC = NULL;
stcNodoCC *pUltimoC = NULL;

stcNodoCF *pPrimeroFP = NULL;
stcNodoCF *pUltimoFP = NULL;
stcNodoCC *pPrimeroCP = NULL;
stcNodoCC *pUltimoCP = NULL;

stcNodoCF *pPrimeroFPo = NULL;
stcNodoCF *pUltimoFPo = NULL;
stcNodoCC *pPrimeroCPo = NULL;
stcNodoCC *pUltimoCPo = NULL;

int altura;
int nnodos;

void convertToASCII(string letter)
{
    char *x;
    char y;
    for (int i = 0; i < letter.length(); i++)
    {
        y = letter.at(i);
        //strcat(x, y);
        //x = x + letter.at(i);

    }
    cout << atoi(x) << endl;
}



MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::on_pushButton_clicked()
{
    FILE *archivo=NULL;
        char caracter[200];
        char line[200];
        //int capa;
        int id[50];
        char valx[50];
        char valy[50];
        char valCol[50];
        char mobile[100];
        int capa = 0;
        int bandera = 0;
        char valH[50];
        int numH = 0;


       // char cadena[1024];

        archivo = fopen("capas11.cap","r+b");

        if (archivo == NULL)
            {
                printf("\nError de apertura del archivo. \n\n");
            }
            else
            {
                    //wprintf("\nEl contenido del archivo de prueba es \n\n");

                while (fgets(caracter, sizeof(caracter), archivo) != NULL)
                {
                   strcpy(line,caracter);
                   int longitud=strlen(line);
                   longitud=longitud-3;

                   if(caracter[longitud]=='{')
                   {
                       bandera=1;
                       capa=atoi(line);
                       //printf("IDcapa: %d\n",capa);
                       //insertarAbb(&arbol,capa);
                   }
                   if(caracter[longitud]!='{' && caracter[longitud]!='}'&& caracter[0]!='\r')
                   {
                       bandera=2;
                       int flag=1;
                       //Obtenemos el primer token de la cadena
                       char* x=strtok(caracter,",");
                       //printf("x: %s\n",x);
                       while(flag==1)
                       {
                          //Se obtiene el siguiente token de la cadena
                          char* y=strtok(NULL,",");
                          //printf("y: %s\n",y);
                          //Se obtiene el tercer token "color"
                          char* color=strtok(NULL,";,");
                          //printf("%s\n",color);
                          //Se obtiene el siguiente token para saber si es fin de linea
                          //y asi poder cambiar el estado de la bandera y detener el proceso
                          char* final=strtok(NULL,"\r\n");
                          //printf("final: %s\n",final);


                          //Se copian los token obtenidos a variables tipo Char[] para manejarlos de mejor manera;
                          strcpy(valx,x);
                          strcpy(valy,y);
                          strcpy(valCol,color);
                          for(int x=0;x<10;x++)
                          {
                              valH[x] = valCol[x+1];
                          }
                          valH[7] = '\0';
                          numH = (int)strtol(valH, NULL, 16);
                          //printf("%x\n",numH);
                          insertarMa(arbol,capa,atoi(valx),atoi(valy),numH);
                          //insertarEnMatriz(&(*raiz)->capa,valCol,capa,atoi(valx), atoi(valy));

                          //Preguntamos si es fin de cadena para cambiar el valor de la bandera
                          if(final==NULL)
                          {
                              flag=0;
                          }else
                          {
                              x=strtok(final,",");
                          }

                       }
                   }

                   if(bandera==1)
                   {
                       //insertarNodo(&(*raiz),capa);
                       insertarAbb(&arbol,capa);
                   }
                   if(bandera==2)
                   {
                       int a=capa;
                   }
                   if(caracter[longitud]=='}')
                   {
                       bandera=0;
                   }

                }
        }
        //graficarArbol(&(*raiz));
            printf("Archivo de capas cargado correctamente");
            fclose(archivo);
}

void MainWindow::on_pushButton_4_clicked()
{
    GraficarABB(cabezaLD,colaLD,arbol);
}


void MainWindow::on_pushButton_2_clicked()//carga de imagenes
{
    FILE *archivo;
     archivo = fopen("imagenes.im","r+b");
     char *numeros;
     char idImg[10];
     char nCapas[200];
     char nCapas2[200];// sin llave que abre

     if (archivo==NULL)
     {
       perror("No se pudo abrir el fichero");
     }
     else
     {
         while((fscanf(archivo, "%[^{]%[^\n] \n", idImg, nCapas))!=EOF)
         {
             //printf("idImg %d \n", atoi(idImg));
             //printf("nCapas %s \n", nCapas);
             //insertar idImg
             LCDInsertar(&cabezaLD, &colaLD, atoi(idImg));
             for(int i = 0; i < 199 ; i++)
                 {
                     nCapas2[i] = nCapas[i+1];
                 }
             nCapas2[200] = '\0';
             numeros = strtok(nCapas2, "}");
             numeros = strtok(nCapas2, ",");

             while(numeros!=NULL)
             {
                 //printf("numeros %d \n", atoi(numeros));
                 insertarNumero(&colaLD, arbol, atoi(idImg),atoi(numeros));
                 numeros = strtok(NULL, ",");
             }

         }

     }
     printf("Archivo de imagenes cargado correctamente");
     fclose(archivo);
}

void MainWindow::on_pushButton_5_clicked() //graficar avl
{
    GraficarAVL(ArbolInt);
}

void MainWindow::on_pushButton_3_clicked()//carga de usuarios
{
    FILE *archivo;
     archivo = fopen("Usuarios.usu","r+b");
     char *numeros;
     char idUsu[20];
     char nImg[200];
     char nImg2[200];// sin llave que abre
     int numIdusu = 0;

     if (archivo==NULL)
     {
       perror("No se pudo abrir el fichero");
     }
     else
     {
         while((fscanf(archivo, "%[^:]%[^\n] \n", idUsu, nImg))!=EOF)
         {
             //printf("idUsu %s \n", idUsu);
             //**********************inicia conv a ascci
             QString Var1 = idUsu;
                     QChar Var2;
                     int cantidad = Var1.count();
                     int valor = 0;
                     int i = 0;
                     while(i < cantidad)
                     {
                         Var2 = Var1.at(i);
                         valor = Var2.toLatin1() + valor;
                         i++;
                     }
             //finaliza conv a ascii*******************
             printf("idUsu %d \n", valor);
             Insertar(&ArbolInt, valor);
             //printf("nImg %s \n", nImg);
             //insertar idImg
//             LCDInsertar(&cabezaLD, &colaLD, atoi(idImg));
             for(int i = 0; i < 199 ; i++)
                 {
                     nImg2[i] = nImg[i+1];
                 }
             nImg2[200] = '\0';
             numeros = strtok(nImg2, ";");
             numeros = strtok(nImg2, ",");

             while(numeros!=NULL)
             {
                 printf("numeros %d \n", atoi(numeros));
                 if(atoi(numeros)!=0)
                 {
                     InsertarAVLLS(ArbolInt,valor,atoi(numeros));
                 }

                 //insertarNumero(&colaLD, arbol, atoi(idImg),atoi(numeros));
                 numeros = strtok(NULL, ",");
             }

         }

     }
     printf("Archivo de imagenes cargado correctamente");
     fclose(archivo);

}

void MainWindow::on_pushButton_11_clicked()// inorden
{
    inOrdenABB(&pPrimeroF,&pUltimoF,&pPrimeroC,&pUltimoC,arbol);
    GraficarMatrizRecorridos(pPrimeroF, pPrimeroC,1);
}

void MainWindow::on_pushButton_12_clicked()//preorden
{
    PreOrdenABB(&pPrimeroFP,&pUltimoFP,&pPrimeroCP,&pUltimoCP,arbol);
    GraficarMatrizRecorridosPre(pPrimeroFP, pPrimeroCP,1);
}

void MainWindow::on_pushButton_13_clicked()//postorden
{
    PosOrdenABB(&pPrimeroFPo,&pUltimoFPo,&pPrimeroCPo,&pUltimoCPo,arbol);
    GraficarMatrizRecorridosPos(pPrimeroFPo, pPrimeroCPo,1);
}
