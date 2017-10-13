#ifndef AVL_H
#define AVL_H
#include "listasimple.h"

typedef struct _nodo
{
    int dato;
    int FE;
    struct _nodo *derecho;
    struct _nodo *izquierdo;
    struct _nodo *padre;
    struct stcNodoLS *pLS;
} tipoNodo;
typedef tipoNodo *pNodo;
typedef tipoNodo *Arbol;

/* Funciones con árboles: */
/* Insertar en árbol ordenado: */
void Insertar(Arbol *a, int dat);
/* Borrar un elemento: */
void Borrar(Arbol *a, int dat);

/* Función de búsqueda: */
int Buscar(Arbol a, int dat);
/* Comprobar si el árbol está vacío: */
int Vacio(Arbol r);
/* Comprobar si es un nodo hoja: */
int EsHoja(pNodo r);
/* Contar número de nodos: */
int NumeroNodos(Arbol a, int* c);
/* Calcular la altura de un árbol: */
int AlturaArbol(Arbol a, int* altura);
/* Calcular altura de un dato: */
int Altura(Arbol a, int dat);
/* Aplicar una función a cada elemento del árbol: */
void InOrden(Arbol, void (*func)(int*));
void PreOrden(Arbol, void (*func)(int*));
void PostOrden(Arbol, void (*func)(int*));
// Funciones de equilibrado:
void Equilibrar(Arbol *raiz, pNodo nodo, int, int);
void RSI(Arbol *raiz, pNodo nodo);
void RSD(Arbol *raiz, pNodo nodo);
void RDI(Arbol *raiz, pNodo nodo);
void RDD(Arbol *raiz, pNodo nodo);
/* Funciones auxiliares: */
void Podar(Arbol *a);
void auxContador(Arbol a, int*);
void auxAltura(Arbol a, int, int*);
void Mostrar(int *d);

int InsertarAVLLS(Arbol a, int dat, int idImg);

#endif // AVL_H
