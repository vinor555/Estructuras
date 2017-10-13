#include "matriz.h"
#include <stdio.h>
#include <stdlib.h>
#include <QString>
#include <QDebug>
#include <iostream>
#include <string>

using namespace std;

stcNodoCF *FnNodoCreaCF(int xFila)
{
    stcNodoCF *xNodoCF;
    xNodoCF = (stcNodoCF*)malloc(sizeof(stcNodoCF));

    if(xNodoCF == NULL)
        printf("Error. No se pudo reservar meomoria para el nodo");
    else
    {
        xNodoCF->fila = xFila;
        xNodoCF->pSig = NULL;
        xNodoCF->pAnt = NULL;
        xNodoCF->pPrimero = NULL;
        xNodoCF->pUltimo = NULL;
    }
    return xNodoCF;
}


void CFInsertar(stcNodoCF **pPrimero, stcNodoCF **pUltimo, int xFila)
{
    stcNodoCF *pNodoNuevo;
    pNodoNuevo = FnNodoCreaCF(xFila);
    if(*pPrimero == NULL)//si esta vacia primer caso
    {
        *pPrimero = *pUltimo = pNodoNuevo;
    }
    else if(pNodoNuevo->fila > (*pUltimo)->fila)//mayor al ultimo segundo caso
    {
        pNodoNuevo->pAnt = *pUltimo;
        (*pUltimo)->pSig = pNodoNuevo;
        *pUltimo = pNodoNuevo;
    }
    else if(pNodoNuevo->fila < (*pPrimero)->fila)//menor al primero tercer caso
    {
        pNodoNuevo->pSig = *pPrimero;
        (*pPrimero)->pAnt = pNodoNuevo;
        *pPrimero = pNodoNuevo;
    }
    else if(!existeFila(pNodoNuevo, *pPrimero))//en algun lugar en medio de la lista cuarto caso
    {
        stcNodoCF *aux = (*pPrimero)->pSig;
        while(aux != NULL)
        {
            if(pNodoNuevo->fila < aux->fila)
            {
                pNodoNuevo->pSig = aux;
                pNodoNuevo->pAnt = aux->pAnt;
                aux->pAnt->pSig = pNodoNuevo;
                aux->pAnt = pNodoNuevo;
                break;
            }
            aux = aux->pSig;
        }
    }
}

bool existeFila(stcNodoCF *pNodoNuevo, stcNodoCF *pPrimero)
{
    stcNodoCF *aux = pPrimero;
    while(aux != NULL)
    {
        if(pNodoNuevo->fila == aux->fila)
        {
            return true;
        }
        aux = aux->pSig;
    }
    return false;
}

stcNodoCC *FnNodoCreaCC(int xColumna)
{
    stcNodoCC *xNodoCC;
    xNodoCC = (stcNodoCC*)malloc(sizeof(stcNodoCC));

    if(xNodoCC == NULL)
        printf("Error. No se pudo reservar meomoria para el nodo");
    else
    {
        xNodoCC->col = xColumna;
        xNodoCC->pSig = NULL;
        xNodoCC->pAnt = NULL;
        xNodoCC->pPrimero = NULL;
        xNodoCC->pUltimo = NULL;
    }
    return xNodoCC;
}

void CCInsertar(stcNodoCC **pPrimero, stcNodoCC **pUltimo, int xColumna)
{
    stcNodoCC *pNodoNuevo;
    pNodoNuevo = FnNodoCreaCC(xColumna);
    if(*pPrimero == NULL)//si esta vacia primer caso
    {
        *pPrimero = *pUltimo = pNodoNuevo;
    }
    else if(pNodoNuevo->col > (*pUltimo)->col)//mayor al ultimo segundo caso
    {
        pNodoNuevo->pAnt = *pUltimo;
        (*pUltimo)->pSig = pNodoNuevo;
        *pUltimo = pNodoNuevo;
    }
    else if(pNodoNuevo->col < (*pPrimero)->col)//menor al primero tercer caso
    {
        pNodoNuevo->pSig = *pPrimero;
        (*pPrimero)->pAnt = pNodoNuevo;
        *pPrimero = pNodoNuevo;
    }
    else if(!existeCol(pNodoNuevo, *pPrimero))//en algun lugar en medio de la lista cuarto caso
    {
        stcNodoCC *aux = (*pPrimero)->pSig;
        while(aux != NULL)
        {
            if(pNodoNuevo->col < aux->col)
            {
                pNodoNuevo->pSig = aux;
                pNodoNuevo->pAnt = aux->pAnt;
                aux->pAnt->pSig = pNodoNuevo;
                aux->pAnt = pNodoNuevo;
                break;
            }
            aux = aux->pSig;
        }
    }
}

bool existeCol(stcNodoCC *pNodoNuevo, stcNodoCC *pPrimero)
{
    stcNodoCC *aux = pPrimero;
    while(aux != NULL)
    {
        if(pNodoNuevo->col == aux->col)
        {
            return true;
        }
        aux = aux->pSig;
    }
    return false;
}

stcNodoM *FnNodoCreaM(int xColumna, int xFila, int xDato)
{
    stcNodoM *xNodoM;
    xNodoM = (stcNodoM*)malloc(sizeof(stcNodoM));

    if(xNodoM == NULL)
        printf("Error. No se pudo reservar meomoria para el nodo");
    else
    {
        xNodoM->fila = xFila;
        xNodoM->col =  xColumna;
        xNodoM->dato = xDato;
        xNodoM->pSig = NULL;
        xNodoM->pAnt = NULL;
        xNodoM->pArr = NULL;
        xNodoM->pAba = NULL;
        xNodoM->pFila = NULL;
        xNodoM->pCol = NULL;
    }
    return xNodoM;
}

void MInsertar(stcNodoCF **pPrimeroF, stcNodoCF **pUltimoF, stcNodoCC **pPrimeroC, stcNodoCC **pUltimoC, int xColumna, int xFila, int xDato)
{
    stcNodoM *pNodoNuevo;
    pNodoNuevo = FnNodoCreaM(xColumna, xFila, xDato);
    CFInsertar(&(*pPrimeroF), &(*pUltimoF), xFila);//sino existe inserta la fila sino no hace nada
    CCInsertar(&(*pPrimeroC), &(*pUltimoC), xColumna);//sino existe inserta la la columna sino no hace nada
    //primero enlaza por columnas
    stcNodoCC *auxcol = *pPrimeroC;
    while(auxcol != NULL)
    {
        if(auxcol->col == xColumna)//encontre la columna en que se inserta el nodo
        {
            if(auxcol->pPrimero == NULL)//primer caso lista vacia
            {
                auxcol->pPrimero = auxcol->pUltimo = pNodoNuevo;
                pNodoNuevo->pCol = auxcol;
            }
            else if(pNodoNuevo->fila < auxcol->pPrimero->fila)//2do caso menor al primero;
            {
                pNodoNuevo->pAba = auxcol->pPrimero;
                auxcol->pPrimero->pArr = pNodoNuevo;
                auxcol->pPrimero->pCol = NULL;
                auxcol->pPrimero = pNodoNuevo;
                pNodoNuevo->pCol = auxcol;
            }
            else if(pNodoNuevo->fila >auxcol->pUltimo->fila)//3er caso mayor al ultimo
            {
                pNodoNuevo->pArr = auxcol->pUltimo;
                auxcol->pUltimo->pAba = pNodoNuevo;
                auxcol->pUltimo = pNodoNuevo;
            }
            else //4to caso es un nodo de en medio
            {
                stcNodoM *auxM = auxcol->pPrimero;
                while(auxM != NULL)
                {
                    if(pNodoNuevo->fila == auxM->fila)
                    {
                        break;
                    }
                    else if(pNodoNuevo->fila < auxM->fila)
                    {
                        pNodoNuevo->pAba = auxM;
                        pNodoNuevo->pArr = auxM->pArr;
                        auxM->pArr->pAba = pNodoNuevo;
                        auxM->pArr = pNodoNuevo;
                        break;
                    }
                    auxM = auxM->pAba;
                }
            }
        }
        auxcol = auxcol->pSig;
    }
    //enlazar por filas
    stcNodoCF *auxFila = *pPrimeroF;
    while(auxFila != NULL)
    {
        if(auxFila->fila == xFila)//encontre la fila en q se tiene q insertar nodo
        {
            if(auxFila->pPrimero == NULL)//primer caso lista vacia
            {
                auxFila->pPrimero = auxFila->pUltimo = pNodoNuevo;
                pNodoNuevo->pFila = auxFila;
            }
            else if(pNodoNuevo->col < auxFila->pPrimero->col)//2do caso menor al primero;
            {
                pNodoNuevo->pSig = auxFila->pPrimero;
                auxFila->pPrimero->pAnt = pNodoNuevo;
                auxFila->pPrimero->pFila = NULL;
                auxFila->pPrimero = pNodoNuevo;
                pNodoNuevo->pFila = auxFila;
            }
            else if(pNodoNuevo->col > auxFila->pUltimo->col)//3er caso mayor al ultimo
            {
                pNodoNuevo->pAnt = auxFila->pUltimo;
                auxFila->pUltimo->pSig = pNodoNuevo;
                auxFila->pUltimo = pNodoNuevo;
            }
            else// 4to caso. Caso terminal es un nodo medio
            {
                stcNodoM *auxM1 = auxFila->pPrimero;
                while(auxM1 != NULL)
                {
                    if(pNodoNuevo->col == auxM1->col)
                    {
                        break;
                    }
                    else if(pNodoNuevo->col < auxM1->col)
                    {
                        pNodoNuevo->pSig = auxM1;
                        pNodoNuevo->pAnt = auxM1->pAnt;
                        auxM1->pAnt->pSig = pNodoNuevo;
                        auxM1->pAnt = pNodoNuevo;
                        break;
                    }
                    auxM1 = auxM1->pSig;
                }
            }
        }
        auxFila = auxFila->pSig;
    }
}

void imprimirCol(stcNodoCF **pPrimeroF, stcNodoCF **pUltimoF, stcNodoCC **pPrimeroC, stcNodoCC **pUltimoC,stcNodoCC *pPrimero)
{
    stcNodoCC *aux = pPrimero;
    while(aux != NULL)
    {
        printf("Columna-------> %i\n",aux->col);
        stcNodoM *auxM = aux->pPrimero;
        while(auxM != NULL)
        {
            printf("Datos %i<-->%i #%x \n",auxM->col,auxM->fila, auxM->dato);
            MInsertar(pPrimeroF,pUltimoF,pPrimeroC,pUltimoC,auxM->col,auxM->fila,auxM->dato);
            auxM = auxM->pAba;
        }
        aux = aux->pSig;
    }
}


void imprimirFila(stcNodoCF *pPrimero)
{
    stcNodoCF *aux = pPrimero;
    while(aux != NULL)
    {
        printf("Fila-------> %i\n",aux->fila);
        stcNodoM *auxM = aux->pPrimero;
        while(auxM != NULL)
        {
            printf("Datos %i<-->%i, \n",auxM->col,auxM->fila);
            auxM = auxM->pSig;
        }
        aux = aux->pSig;
    }
}

