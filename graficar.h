#ifndef GRAFICAR_H
#define GRAFICAR_H
#include "abb.h"
#include "circulard.h"
#include "avl.h"
#include <stdio.h>
#include <string>

//void GraficarABB(nodoAbb *pArbol);
void GraficarABB(nodoLCD *pCabezaLCD, nodoLCD *pColaLCD, nodoAbb *pArbol);
void graficarAuxABB(nodoAbb *pArbol);
void graficarBST(nodoAbb *tree);
void bst_print_dot_aux(nodoAbb *node, FILE* stream);
void bst_print_dot_null(int key, int nullcount, FILE* stream);
void GraficarMatrizABB(stcNodoCF *pPrimeroF, stcNodoCC *pPrimeroC,int idMatriz);
void GraficarMatriz(stcNodoCF *pPrimeroF, stcNodoCC *pPrimeroC);
void graficarLCD(nodoLCD *pCabezaLCD, nodoLCD *pColaLCD);
void verArbol1(nodoAbb *arbol, int xId);
void GraficarAVL(Arbol pArbol);
void graficarAuxAVL(Arbol pArbol);
void GraficarMatrizRecorridos(stcNodoCF *pPrimeroF, stcNodoCC *pPrimeroC,int idMatriz);
void GraficarMatrizRecorridosPre(stcNodoCF *pPrimeroF, stcNodoCC *pPrimeroC,int idMatriz);
void GraficarMatrizRecorridosPos(stcNodoCF *pPrimeroF, stcNodoCC *pPrimeroC, int idMatriz);

#endif // GRAFICAR_H
