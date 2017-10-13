#include "cargararchivos.h"
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#import "abb.h"
#import "matriz.h"
using namespace std;


void cargarCapas(nodoAbb *arbol)
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
        int prueba = 1;

       // char cadena[1024];

        archivo = fopen("capas1.cap","r+b");

        if (archivo == NULL)
            {
                printf("\nError de apertura del archivo. \n\n");
            }
            else
            {
                    printf("\nEl contenido del archivo de prueba es \n\n");

                while (fgets(caracter, sizeof(caracter), archivo) != NULL)
                {
                   strcpy(line,caracter);
                   int longitud=strlen(line);
                   longitud=longitud-3;

                   if(caracter[longitud]=='{')
                   {
                       bandera=1;
                       capa=atoi(line);
                       printf("IDcapa: %d\n",capa);
                       //insertarAbb(&arbol,capa);
                   }
                   if(caracter[longitud]!='{' && caracter[longitud]!='}'&& caracter[0]!='\r')
                   {
                       bandera=2;
                       int flag=1;
                       //Obtenemos el primer token de la cadena
                       char* x=strtok(caracter,",");
                       printf("x: %s\n",x);
                       while(flag==1)
                       {
                          //Se obtiene el siguiente token de la cadena
                          char* y=strtok(NULL,",");
                          printf("y: %s\n",y);
                          //Se obtiene el tercer token "color"
                          char* color=strtok(NULL,";,");
                          printf("color: %s\n",color);
                          //Se obtiene el siguiente token para saber si es fin de linea
                          //y asi poder cambiar el estado de la bandera y detener el proceso
                          char* final=strtok(NULL,"\r\n");
                          //printf("final: %s\n",final);


                          //Se copian los token obtenidos a variables tipo Char[] para manejarlos de mejor manera;
                          strcpy(valx,x);
                          strcpy(valy,y);
                          strcpy(valCol,color);
                          //insertarMa(arbol,capa,atoi(valx),atoi(valy),color);
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
            fclose(archivo);
}
