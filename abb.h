#ifndef ABB_H
#define ABB_H
#include "matriz.h"
#include <QString>
#include <string>

typedef struct nodoAbb{
     int id;
     struct nodoAbb *pIzq, *pDer;
     struct stcNodoM *pMa;
     struct stcNodoCC *pPCC;
     struct stcNodoCC *pUCC;
     struct stcNodoCF *pPCF;
     struct stcNodoCF *pUCF;
}nodoAbb;

nodoAbb *crearNodo(int xId);
void insertarAbb(nodoAbb **arbol, int x);
void verArbol(nodoAbb *arbol, int xId);
nodoAbb *insertarMa(nodoAbb *arbol,int x,int xColumna,int xFila, int xDato);
void inOrdenABB(stcNodoCF **pPrimeroF, stcNodoCF **pUltimoF, stcNodoCC **pPrimeroC, stcNodoCC **pUltimoC,nodoAbb *arbol);
void PreOrdenABB(stcNodoCF **pPrimeroF, stcNodoCF **pUltimoF, stcNodoCC **pPrimeroC, stcNodoCC **pUltimoC,nodoAbb *arbol);
void PosOrdenABB(stcNodoCF **pPrimeroF, stcNodoCF **pUltimoF, stcNodoCC **pPrimeroC, stcNodoCC **pUltimoC,nodoAbb *arbol);

#endif // ABB_H
