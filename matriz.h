#ifndef MATRIZ_H
#define MATRIZ_H
#include <QString>
#include <iostream>
#include <string>
using namespace std;

struct stcNodoM
{
    int fila;
    int col;
    int dato;
    //int datoDec;
    struct stcNodoM *pSig;
    struct stcNodoM *pAnt;
    struct stcNodoM *pArr;
    struct stcNodoM *pAba;

    struct stcNodoCF *pFila;
    struct stcNodoCC *pCol;
};

struct stcNodoCF
{
    int fila;
    struct stcNodoCF *pSig;
    struct stcNodoCF *pAnt;

    struct stcNodoM *pPrimero;
    struct stcNodoM *pUltimo;
};


struct stcNodoCC
{
    int col;
    struct stcNodoCC *pSig;
    struct stcNodoCC *pAnt;

    struct stcNodoM *pPrimero;
    struct stcNodoM *pUltimo;
};

stcNodoCF *FnNodoCreaCF(int xFila);
void CFInsertar(stcNodoCF **pPrimero, stcNodoCF **pUltimo, int xFila);
bool existeFila(stcNodoCF *pNodoNuevo, stcNodoCF *pPrimero);
stcNodoCC *FnNodoCreaCC(int xColumna);
void CCInsertar(stcNodoCC **pPrimero, stcNodoCC **pUltimo, int xColumna);
bool existeCol(stcNodoCC *pNodoNuevo, stcNodoCC *pPrimero);
stcNodoM *FnNodoCreaM(int xColumna, int xFila, int xDato);
void MInsertar(stcNodoCF **pPrimeroF, stcNodoCF **pUltimoF, stcNodoCC **pPrimeroC, stcNodoCC **pUltimoC, int xColumna, int xFila, int xDato);
void imprimirCol(stcNodoCF **pPrimeroF, stcNodoCF **pUltimoF, stcNodoCC **pPrimeroC, stcNodoCC **pUltimoC,stcNodoCC *pPrimero);
void imprimirFila(stcNodoCF *pPrimero);

#endif // MATRIZ_H
