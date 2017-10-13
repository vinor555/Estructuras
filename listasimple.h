#ifndef LISTASIMPLE_H
#define LISTASIMPLE_H
#include "abb.h"

struct stcNodoLS
{
    int idCap;
    struct stcNodoLS *pSig;
    struct nodoAbb *pAbb;
};

typedef struct stcNodoLS nodoLS;

nodoLS *FnNodoCreaLS(int xIdCapa);
int FnLSEmpty(nodoLS *pCabeza);
void LSInsertar(nodoLS **pCabeza, nodoLS **pCola, int xIdCapa);

#endif // LISTASIMPLE_H
