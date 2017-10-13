#include "listasimple.h"

#include <QDebug>
#include <QString>
#include <stdlib.h>
#include <stdio.h>
#include <string.h>



nodoLS *FnNodoCreaLS(int xIdCapa)
{
    nodoLS *xNodoLS;
    xNodoLS = (nodoLS*)malloc(sizeof(nodoLS));

    //verifico que haya podido reservar memoria
    if(xNodoLS == NULL)
        printf("Error. No se pudo reservar memoria para el nodo");
    else
    {
        xNodoLS->idCap = xIdCapa;
        xNodoLS->pAbb = NULL;
        xNodoLS->pSig = NULL;
    }
    return xNodoLS;
}

int FnLSEmpty(nodoLS *pCabeza)
{
    if(pCabeza == NULL)
        return 1;
    else
        return 0;
}


void LSInsertar(nodoLS **pCabeza, nodoLS **pCola, int xIdCapa)
{
    nodoLS *pNodoNuevo;
    pNodoNuevo = FnNodoCreaLS(xIdCapa);
    if(FnLSEmpty(*pCola))
    {
        *pCola = pNodoNuevo;
        *pCabeza = pNodoNuevo;
    }
    else
    {
        (*pCola)->pSig = pNodoNuevo;
        pNodoNuevo->pSig = NULL;
        *pCola = pNodoNuevo;
    }
}
