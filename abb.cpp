#include "abb.h"
#include "matriz.h"

#include <stdio.h>
#include <stdlib.h>
#include <iostream>
#include <QString>
#include <string>

using namespace std;
int numNodos = 0;

nodoAbb *crearNodo(int xId)
{
     nodoAbb *nuevoNodo;
     nuevoNodo = (nodoAbb*)malloc(sizeof(nodoAbb));
     if(nuevoNodo == NULL)
         printf("Error. No se pudo reservar meomoria para el nodo");
     else
     {
         nuevoNodo->id = xId;
         nuevoNodo->pIzq = NULL;
         nuevoNodo->pDer = NULL;
         nuevoNodo->pMa = NULL;
         nuevoNodo->pPCC = NULL;
         nuevoNodo->pPCF = NULL;
         nuevoNodo->pUCC = NULL;
         nuevoNodo->pUCF = NULL;
     }
     return nuevoNodo;
}

void insertarAbb(nodoAbb **arbol, int xId)
{
     if(*arbol == NULL)
     {
           *arbol = crearNodo(xId);
           //cout<<"\n\t Elemento Insertado"<<endl<<endl;
     }
     else if(xId < (*arbol)->id)
          insertarAbb(&((*arbol)->pIzq), xId);
     else //if(xId > ((*arbol)->id))
          insertarAbb(&((*arbol)->pDer), xId);
}

void verArbol(nodoAbb *arbol, int xId)
{

     if(arbol==NULL)
          return;
     verArbol(arbol->pDer, xId+1);

     for(int i=0; i < xId; i++)
         cout<<"   ";

     numNodos++;
     cout<< arbol->id <<endl;

     verArbol(arbol->pIzq, xId+1);
}

nodoAbb *insertarMa(nodoAbb *arbol,int x,int xColumna,int xFila, int xDato)
{
    int encontrado = 0;
    while(!encontrado && arbol != NULL)
    {
        if(x == arbol->id)
        {
            //cout<<"\nEncontrado = "<<arbol->id <<endl<<endl;
            if(arbol->pPCF == NULL)
            {
                stcNodoCF *pPrimeroCF = NULL;
                stcNodoCF *pUltimoCF = NULL;
                stcNodoCC *pPrimeroCC = NULL;
                stcNodoCC *pUltimoCC = NULL;
                MInsertar(&pPrimeroCF,&pUltimoCF,&pPrimeroCC,&pUltimoCC,xColumna,xFila,xDato);
                arbol->pPCF = pPrimeroCF;
                arbol->pUCF = pUltimoCF;
                arbol->pPCC = pPrimeroCC;
                arbol->pUCC = pUltimoCC;
                //imprimirCol(arbol->pPCC);
                encontrado = 1;
            }else if(arbol->pPCF != NULL)
            {
                MInsertar(&(arbol->pPCF),&(arbol->pUCF),&(arbol->pPCC),&(arbol->pUCC),xColumna,xFila,xDato);
                //imprimirCol(arbol->pPCC);
                encontrado = 1;
            }

        }
        else if(x < arbol->id)
        {
            arbol = arbol->pIzq;
        }
        else if(x > arbol->id)
        {
            arbol = arbol->pDer;
        }
    }
    return arbol;

}

void inOrdenABB(stcNodoCF **pPrimeroF, stcNodoCF **pUltimoF, stcNodoCC **pPrimeroC, stcNodoCC **pUltimoC,nodoAbb *arbol)
{
     if(arbol!=NULL)
     {
          inOrdenABB(pPrimeroF,pUltimoF,pPrimeroC,pUltimoC,arbol->pIzq);
          cout << arbol->id << " ";
          imprimirCol(pPrimeroF,pUltimoF,pPrimeroC,pUltimoC,arbol->pPCC);
          inOrdenABB(pPrimeroF,pUltimoF,pPrimeroC,pUltimoC,arbol->pDer);
     }
}

void PreOrdenABB(stcNodoCF **pPrimeroF, stcNodoCF **pUltimoF, stcNodoCC **pPrimeroC, stcNodoCC **pUltimoC,nodoAbb *arbol)
{
     if(arbol!=NULL)
     {

          cout << arbol->id << " ";
          imprimirCol(pPrimeroF,pUltimoF,pPrimeroC,pUltimoC,arbol->pPCC);
          PreOrdenABB(pPrimeroF,pUltimoF,pPrimeroC,pUltimoC,arbol->pIzq);
          PreOrdenABB(pPrimeroF,pUltimoF,pPrimeroC,pUltimoC,arbol->pDer);
     }
}

void PosOrdenABB(stcNodoCF **pPrimeroF, stcNodoCF **pUltimoF, stcNodoCC **pPrimeroC, stcNodoCC **pUltimoC,nodoAbb *arbol)
{
     if(arbol!=NULL)
     {
          PosOrdenABB(pPrimeroF,pUltimoF,pPrimeroC,pUltimoC,arbol->pIzq);
          PosOrdenABB(pPrimeroF,pUltimoF,pPrimeroC,pUltimoC,arbol->pDer);
          imprimirCol(pPrimeroF,pUltimoF,pPrimeroC,pUltimoC,arbol->pPCC);
          cout << arbol->id << " ";
     }
}
