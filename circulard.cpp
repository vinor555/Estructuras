#include "circulard.h"
#include "listasimple.h"
#include "abb.h"

#include <QDebug>
#include <QString>
#include <stdlib.h>
#include <stdio.h>
#include <string.h>



nodoLCD *FnCreaNodoLCD( int xIdimg)
{
    nodoLCD *xNodoLCD;
    xNodoLCD = (nodoLCD*)malloc(sizeof(nodoLCD));
    if(xNodoLCD == NULL)
        printf("Error. No se pudo reservar memoria para el nodo");
    else
    {

        xNodoLCD->iDimg = xIdimg;
        xNodoLCD->pSig = NULL;
        xNodoLCD->pAnt = NULL;
        xNodoLCD->pLS = NULL;
    }
    return xNodoLCD;
}

int FnLCDEmpty(nodoLCD *pCabeza)
{
    if(pCabeza == NULL)
        return 1;
    else
        return 0;
}

void LCDInsertar(nodoLCD **pCabeza, nodoLCD **pCola, int xIdimg)
{
    nodoLCD *pNodoNuevo;
    pNodoNuevo = FnCreaNodoLCD(xIdimg);

    if(FnLCDEmpty(*pCola))
    {
        pNodoNuevo->pSig = pNodoNuevo;
        pNodoNuevo->pAnt = pNodoNuevo;
        *pCola = *pCabeza = pNodoNuevo;
        (*pCola)->pLS = NULL;
    }
    else
    {
        pNodoNuevo->pSig = (*pCola)->pSig;
        (*pCabeza)->pAnt = pNodoNuevo;
        (*pCola)->pSig = pNodoNuevo;
        pNodoNuevo->pAnt = *pCola;
        *pCola = pNodoNuevo;
        (*pCola)->pLS = NULL;
    }
}


void insertarNumero(nodoLCD **pCola,nodoAbb *arbol, int xIdimg, int xIdCapa)
{

        nodoLCD *aux = (*pCola)->pSig;
        while(aux != *pCola)
        {
            if(xIdimg == aux->iDimg)
            {
                nodoLS *pNodoNuevo = FnNodoCreaLS(xIdCapa);
                pNodoNuevo->pAbb = NULL;
                if(aux->pLS == NULL)
                {
                    aux->pLS = pNodoNuevo;
                    linkLSABB(pNodoNuevo,arbol,xIdCapa);
                }
                else
                {
                    pNodoNuevo->pSig = aux->pLS;
                    aux->pLS = pNodoNuevo;
                    linkLSABB(pNodoNuevo,arbol,xIdCapa);

                }
                break;
            }
            aux = aux->pSig;
        }
        if(xIdimg == aux->iDimg)
        {
            nodoLS *pNodoNuevo = FnNodoCreaLS(xIdCapa);
            pNodoNuevo->pAbb = NULL;
            if(aux->pLS == NULL)
            {
                aux->pLS = pNodoNuevo;
                linkLSABB(pNodoNuevo,arbol,xIdCapa);
            }
            else
            {
                pNodoNuevo->pSig = aux->pLS;
                aux->pLS = pNodoNuevo;
                linkLSABB(pNodoNuevo,arbol,xIdCapa);
            }
        }
}

nodoAbb *linkLSABB(nodoLS *xNodo, nodoAbb *arbol, int xDato)
{
    int encontrado = 0;
    while(!encontrado && arbol != NULL)
    {
        if(xDato == arbol->id)
        {
            //cout<<"\nEncontrado = "<<arbol->id <<endl<<endl;
            xNodo->pAbb = arbol;
            encontrado = 1;
        }
        else if(xDato < arbol->id)
        {
            arbol = arbol->pIzq;
        }
        else if(xDato > arbol->id)
        {
            arbol = arbol->pDer;
        }
    }
    return arbol;

}









