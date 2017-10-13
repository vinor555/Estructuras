#ifndef CIRCULARD_H
#define CIRCULARD_H
#include "listasimple.h"

struct stcNodoCircular
{
    int iDimg;
    struct stcNodoCircular *pSig;
    struct stcNodoCircular *pAnt;
    struct stcNodoLS *pLS;
};
typedef struct stcNodoCircular nodoLCD;

void LCDInsertar(nodoLCD **pCabeza, nodoLCD **pCola, int xIdimg);
void insertarNumero(nodoLCD **pCola,nodoAbb *arbol, int xIdimg, int xIdCapa);
nodoAbb *linkLSABB(nodoLS *xNodo, nodoAbb *arbol, int xDato);

#endif // CIRCULARD_H
