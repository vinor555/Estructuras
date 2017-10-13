#include "graficar.h"
#include <stdio.h>
#include <stdlib.h>
#include <QString>
#include <iostream>
#include <string>
using namespace std;

#include "abb.h"
#include "matriz.h"
#include "circulard.h"
#include "avl.h"

int longitud;
int numNodos1 = 0;

void GraficarABB(nodoLCD *pCabezaLCD, nodoLCD *pColaLCD, nodoAbb *pArbol)
{
    FILE *fp;
    fp = fopen("GraficaABB.dot","w");
    fprintf(fp, "\tdigraph Graficas{");
    fprintf(fp,"node [shape=Mcircle, colorscheme=\"set13\", style=\"filled\",fontcolor=\"white\",color=\"black\"]\n");
    fprintf(fp,"edge [arrowsize=0.75,colorscheme=\"set13\",color=1]\n");
    fclose(fp);
    graficarAuxABB(pArbol);
    fopen("GraficaABB.dot","a");

    //******************************************************inicio prueba
    fprintf(fp, "\tsubgraph cluster_1000\n\t\t{\n");
    fprintf(fp, "\t\tlabel = \"Lista CircularD\"\n\n");

    if(pColaLCD == NULL)
    {
        fprintf(fp, "\t\t\"La ListaCD\\nesta vacia\"\n");
    }
    else
    {
        nodoLCD *aux = pColaLCD->pSig;
        while(aux != pColaLCD)
        {
            fprintf(fp, "\t\t\"imagen%d\"",aux->iDimg);
            if(aux->pSig != NULL)
            {
                fprintf(fp, "-> \"imagen%d\"\n",aux->pSig->iDimg);
                fprintf(fp, "-> \"imagen%d\"\n",aux->iDimg);
            }
            else
            {
                fprintf(fp,"\n");
            }
            if(aux->pLS != NULL)
            {
                fprintf(fp, "\t\t\"imagen%d\"",aux->iDimg);
                fprintf(fp, "-> \"capa_%d\"\n", aux->pLS->idCap);

                nodoLS *temp = aux->pLS;
                while(temp != NULL)
                {
                    fprintf(fp, "\t\t\"capa_%d\"", temp->idCap);
                    if(temp->pSig != NULL)
                    {
                        fprintf(fp, "-> \"capa_%d\"\n", temp->pSig->idCap);
                    }else
                    {
                        fprintf(fp,"\n");
                    }
                    temp = temp->pSig;
                }
            }
            aux = aux->pSig;
        }
        fprintf(fp, "\t\t\"imagen%d\"",aux->iDimg);
        fprintf(fp, "-> \"imagen%d\"\n",aux->pSig->iDimg);
        fprintf(fp, "-> \"imagen%d\"\n",aux->iDimg);
            if(aux->pLS != NULL)
            {
                fprintf(fp, "\t\t\"imagen%d\"",aux->iDimg);
                fprintf(fp, "-> \"capa_%d\"\n", aux->pLS->idCap);
                nodoLS *temp1 = aux->pLS;
                while(temp1 != NULL)
                {
                    fprintf(fp, "\t\t\"capa_%d\"", temp1->idCap);
                    if(temp1->pSig != NULL)
                    {
                        fprintf(fp, "-> \"capa_%d\"\n", temp1->pSig->idCap);
                    }else
                    {
                        fprintf(fp,"\n");
                    }
                    temp1 = temp1->pSig;
                }
            }

    }


    fprintf(fp, "\n\t}\n");
    //fprintf(fp,"\"capa_4\" -> struct4\n");
    //*******************************inilink abb****************
    fclose(fp);

    verArbol1(pArbol, 0);
    //fclose(fp);
    fp = fopen("GraficaABB.dot","a");
    //fin link abb**********************************************

    //************************************************fin prueba
    fprintf(fp,"\n}");
    //fprintf(fp,"\n}");
    fclose(fp);
    system("dot GraficaABB.dot -o GraficaABB.png -Tpng");
    system("xdg-open GraficaABB.png");
}

void graficarAuxABB(nodoAbb *pArbol)
{
    if(pArbol != NULL)
    {
        FILE *fp;
        fp = fopen("GraficaABB.dot","a");
        fprintf(fp,"struct%d [fillcolor=1,label=\"%i\"];\n", pArbol->id, pArbol->id);
        fclose(fp);

        if(pArbol->pPCF == NULL)
        {
            fp = fopen("GraficaABB.dot","a");
            fprintf(fp,"struct%d -> \"Sin Matriz%i\";\n", pArbol->id,pArbol->id);
            fclose(fp);
        }
        else
        {
            GraficarMatrizABB(pArbol->pPCF,pArbol->pPCC,pArbol->id);
            fp = fopen("GraficaABB.dot","a");
            fprintf(fp,"struct%d -> \"Matriz%i\";\n",pArbol->id,pArbol->id);
            fclose(fp);
        }

        if(pArbol->pIzq != NULL)
        {
            fp = fopen("GraficaABB.dot","a");
            fprintf(fp,"struct%d [fillcolor=1,label=\"%i\"];\n", pArbol->pIzq->id, pArbol->pIzq->id);
            fprintf(fp,"struct%i -> struct%i \n",pArbol->id,pArbol->pIzq->id);
            graficarAuxABB(pArbol->pIzq);
            fclose(fp);
        }
        if(pArbol->pDer != NULL)
        {
            fp = fopen("GraficaABB.dot","a");
            fprintf(fp,"struct%d [fillcolor=1,label=\"%i\"];\n", pArbol->pDer->id, pArbol->pDer->id);
            fprintf(fp,"struct%i -> struct%i \n",pArbol->id,pArbol->pDer->id);
            graficarAuxABB(pArbol->pDer);
            fclose(fp);
        }
    }
}

void GraficarMatrizABB(stcNodoCF *pPrimeroF, stcNodoCC *pPrimeroC,int idMatriz){
    FILE *fp;
    fp = fopen("GraficaABB.dot","a");
    fprintf(fp, "subgraph cluster%i{\n",idMatriz);
    fprintf(fp, "node[shape=record]; graph[rankdir=TB];\n");
    fprintf(fp, "{rank = same Matriz%i [label = \"Matriz%i\"]",idMatriz,idMatriz);
    stcNodoCC *auxCol = pPrimeroC;
    while(auxCol != NULL)
    {
        fprintf(fp, "x%i%i [label=\"x%i%i\"]",idMatriz,auxCol->pPrimero->col,idMatriz,auxCol->pPrimero->col);

        auxCol = auxCol->pSig;
    }
    fprintf(fp, "}\n");
    auxCol = pPrimeroC;
    while(auxCol != NULL)
    {
        if(auxCol->pSig != NULL)
        {
            fprintf(fp, "x%i%i -> x%i%i;\n",idMatriz,auxCol->col,idMatriz,auxCol->pSig->col);
        }
        auxCol = auxCol->pSig;
    }

    stcNodoCF *auxFil = pPrimeroF;
    while(auxFil != NULL)
    {
        fprintf(fp, "{rank = same y%i%i [label=\"y%i%i\"]\n",idMatriz,auxFil->fila,idMatriz,auxFil->fila);

        stcNodoM *auxM = auxFil->pPrimero;
        while(auxM != NULL)
        {                   //primera i de mas
            fprintf(fp, "  %i%i%i [label=\"#%x\"] \n",idMatriz,auxM->col,auxM->fila,auxM->dato);
            auxM = auxM->pSig;
        }

        auxM = auxFil->pPrimero;
        while(auxM->pSig != NULL)
        {
            fprintf(fp, "%i%i%i -> %i%i%i;\n",idMatriz,auxM->col,auxM->fila,idMatriz,auxM->pSig->col,auxM->pSig->fila);

            auxM = auxM->pSig;
        }
        auxM = auxFil->pPrimero;
        fprintf(fp, "y%i%i -> %i%i%i;\n",idMatriz,auxM->fila,idMatriz,auxM->col,auxM->fila);

        fprintf(fp, "}\n");
        auxFil = auxFil->pSig;
    }
    auxCol = pPrimeroC;
    while(auxCol != NULL)
    {
        stcNodoM *auxM = auxCol->pPrimero;
        while(auxM->pAba != NULL)
        {
            fprintf(fp, "%i%i%i -> %i%i%i;\n",idMatriz,auxM->col,auxM->fila,idMatriz,auxM->pAba->col,auxM->pAba->fila);
            auxM = auxM->pAba;
        }
        auxM = auxCol->pPrimero;
        fprintf(fp, "x%i%i -> %i%i%i;\n",idMatriz,auxM->col,idMatriz,auxM->col,auxM->fila);
        auxCol = auxCol->pSig;
    }
    auxFil = pPrimeroF;
    while(auxFil != NULL)
    {
        if(auxFil->pSig != NULL)
        {
            fprintf(fp, "y%i%i -> y%i%i;\n",idMatriz,auxFil->fila,idMatriz,auxFil->pSig->fila);
        }
        auxFil = auxFil->pSig;
    }

    fprintf(fp, "Matriz%i -> x%i%i;\n",idMatriz,idMatriz,pPrimeroC->col);
    fprintf(fp, "Matriz%i -> y%i%i;\n",idMatriz,idMatriz,pPrimeroF->fila);



    fprintf(fp, "\n}");
    fclose(fp);


}

void graficarLCD(nodoLCD *pCabezaLCD, nodoLCD *pColaLCD)
{
    FILE *fp;
    fp = fopen("GraficaABB.dot","w");
    //fprintf(fp, "\tdigraph Graficas{");
    //****************************************************

    fprintf(fp, "\tsubgraph cluster_1000\n\t\t{\n");
    fprintf(fp, "\t\tlabel = \"Lista CircularD\"\n\n");

    if(pColaLCD == NULL)
    {
        fprintf(fp, "\t\t\"La ListaCD\\nesta vacia\"\n");
    }
    else
    {
        nodoLCD *aux = pColaLCD->pSig;
        while(aux != pColaLCD)
        {
            fprintf(fp, "\t\t\"imagen%d\"",aux->iDimg);
            if(aux->pSig != NULL)
            {
                fprintf(fp, "-> \"imagen%d\"\n",aux->pSig->iDimg);
                fprintf(fp, "-> \"imagen%d\"\n",aux->iDimg);
            }
            else
            {
                fprintf(fp,"\n");
            }
            if(aux->pLS != NULL)
            {
                fprintf(fp, "\t\t\"imagen%d\"",aux->iDimg);
                fprintf(fp, "-> \"capa_%d\"\n", aux->pLS->idCap);

                nodoLS *temp = aux->pLS;
                while(temp != NULL)
                {
                    fprintf(fp, "\t\t\"capa_%d\"", temp->idCap);
                    if(temp->pSig != NULL)
                    {
                        fprintf(fp, "-> \"capa_%d\"\n", temp->pSig->idCap);
                    }else
                    {
                        fprintf(fp,"\n");
                    }
                    temp = temp->pSig;
                }
            }
            aux = aux->pSig;
        }
        fprintf(fp, "\t\t\"imagen%d\"",aux->iDimg);
        fprintf(fp, "-> \"imagen%d\"\n",aux->pSig->iDimg);
        fprintf(fp, "-> \"imagen%d\"\n",aux->iDimg);
            if(aux->pLS != NULL)
            {
                fprintf(fp, "\t\t\"imagen%d\"",aux->iDimg);
                fprintf(fp, "-> \"capa_%d\"\n", aux->pLS->idCap);
                nodoLS *temp1 = aux->pLS;
                while(temp1 != NULL)
                {
                    fprintf(fp, "\t\t\"capa_%d\"", temp1->idCap);
                    if(temp1->pSig != NULL)
                    {
                        fprintf(fp, "-> \"capa_%d\"\n", temp1->pSig->idCap);
                    }else
                    {
                        fprintf(fp,"\n");
                    }
                    temp1 = temp1->pSig;
                }
            }

    }
    fprintf(fp, "\n\t}\n");
    //************************************************************
    //fprintf(fp, "\n\n}");
    fclose(fp);
}

void verArbol1(nodoAbb *arbol, int xId)//recorro postorden para link abb con ls
{
    if(arbol!=NULL)
    {
        verArbol1(arbol->pIzq,0);
        verArbol1(arbol->pDer,0);
        //cout << arbol->nro << " ";
        FILE *fp;
        fp = fopen("GraficaABB.dot","a");
        fprintf(fp,"\"capa_%d\" -> struct%i\n",arbol->id,arbol->id);
        fclose(fp);
    }
}

void GraficarAVL(Arbol pArbol)
{
    FILE *fp;
    fp = fopen("GraficaAVL.dot","w");
    fprintf(fp, "\tdigraph Graficas{");
    fprintf(fp,"node [shape=Mcircle, colorscheme=\"set13\", style=\"filled\",fontcolor=\"white\",color=\"black\"]\n");
    fprintf(fp,"edge [arrowsize=0.75,colorscheme=\"set13\",color=1]\n");
    fclose(fp);
    graficarAuxAVL(pArbol);
    fopen("GraficaAVL.dot","a");
    fprintf(fp,"\n}");
    //fprintf(fp,"\n}");
    fclose(fp);
    system("dot GraficaAVL.dot -o GraficaAVL.png -Tpng");
    system("xdg-open GraficaAVL.png");
}

void graficarAuxAVL(Arbol pArbol)
{
    if(pArbol != NULL)
    {
        FILE *fp;
        fp = fopen("GraficaAVL.dot","a");
        fprintf(fp,"struct%d [fillcolor=1,label=\"user%i\"];\n", pArbol->dato, pArbol->dato);
        fclose(fp);

        if(pArbol->pLS == NULL)
        {
            fp = fopen("GraficaAVL.dot","a");
            fprintf(fp,"struct%d -> \"SinListaS%i\";\n", pArbol->dato,pArbol->dato);
            fclose(fp);
        }
        else
        {
            //GraficarMatrizABB(pArbol->pPCF,pArbol->pPCC,pArbol->id);
            fp = fopen("GraficaAVL.dot","a");
            fprintf(fp,"struct%d -> \"img%i\";\n", pArbol->dato,pArbol->pLS->idCap);

            nodoLS *temp = pArbol->pLS;
            while(temp != NULL)
            {
                fprintf(fp, "\t\t\"img%d\"", temp->idCap);
                if(temp->pSig != NULL)
                {
                    fprintf(fp, "-> \"img%d\"\n", temp->pSig->idCap);
                }else
                {
                    fprintf(fp,"\n");
                }
                temp = temp->pSig;
            }
            fclose(fp);
        }


        if(pArbol->izquierdo != NULL)
        {
            fp = fopen("GraficaAVL.dot","a");
            fprintf(fp,"struct%d [fillcolor=1,label=\"user%i\"];\n", pArbol->izquierdo->dato, pArbol->izquierdo->dato);
            fprintf(fp,"struct%i -> struct%i \n",pArbol->dato,pArbol->izquierdo->dato);
            graficarAuxAVL(pArbol->izquierdo);
            fclose(fp);
        }
        if(pArbol->derecho != NULL)
        {
            fp = fopen("GraficaAVL.dot","a");
            fprintf(fp,"struct%d [fillcolor=1,label=\"user%i\"];\n", pArbol->derecho->dato, pArbol->derecho->dato);
            fprintf(fp,"struct%i -> struct%i \n",pArbol->dato,pArbol->derecho->dato);
            graficarAuxAVL(pArbol->derecho);
            fclose(fp);
        }
    }
}


void GraficarMatrizRecorridos(stcNodoCF *pPrimeroF, stcNodoCC *pPrimeroC, int idMatriz)
{
    FILE *fp;
    fp = fopen("GraficaMatrizR.dot","w");
    fprintf(fp, "digraph GraficaMR{ \n node[shape=record]; graph[rankdir=TB];\n");
    //*************************************************
    fprintf(fp, "subgraph cluster1{\n");
    fprintf(fp, "{rank = same Matriz%i [label = \"Matriz%i\"]",idMatriz,idMatriz);
    stcNodoCC *auxCol = pPrimeroC;
    while(auxCol != NULL)
    {
        fprintf(fp, "x%i%i [label=\"x%i%i\"]",idMatriz,auxCol->pPrimero->col,idMatriz,auxCol->pPrimero->col);

        auxCol = auxCol->pSig;
    }
    fprintf(fp, "}\n");
    auxCol = pPrimeroC;
    while(auxCol != NULL)
    {
        if(auxCol->pSig != NULL)
        {
            fprintf(fp, "x%i%i -> x%i%i;\n",idMatriz,auxCol->col,idMatriz,auxCol->pSig->col);
        }
        auxCol = auxCol->pSig;
    }

    stcNodoCF *auxFil = pPrimeroF;
    while(auxFil != NULL)
    {
        fprintf(fp, "{rank = same y%i%i [label=\"y%i%i\"]\n",idMatriz,auxFil->fila,idMatriz,auxFil->fila);

        stcNodoM *auxM = auxFil->pPrimero;
        while(auxM != NULL)
        {                   //primera i de mas
            fprintf(fp, "  %i%i%i [label=\"#%x\"] \n",idMatriz,auxM->col,auxM->fila,auxM->dato);
            auxM = auxM->pSig;
        }

        auxM = auxFil->pPrimero;
        while(auxM->pSig != NULL)
        {
            fprintf(fp, "%i%i%i -> %i%i%i;\n",idMatriz,auxM->col,auxM->fila,idMatriz,auxM->pSig->col,auxM->pSig->fila);

            auxM = auxM->pSig;
        }
        auxM = auxFil->pPrimero;
        fprintf(fp, "y%i%i -> %i%i%i;\n",idMatriz,auxM->fila,idMatriz,auxM->col,auxM->fila);

        fprintf(fp, "}\n");
        auxFil = auxFil->pSig;
    }
    auxCol = pPrimeroC;
    while(auxCol != NULL)
    {
        stcNodoM *auxM = auxCol->pPrimero;
        while(auxM->pAba != NULL)
        {
            fprintf(fp, "%i%i%i -> %i%i%i;\n",idMatriz,auxM->col,auxM->fila,idMatriz,auxM->pAba->col,auxM->pAba->fila);
            auxM = auxM->pAba;
        }
        auxM = auxCol->pPrimero;
        fprintf(fp, "x%i%i -> %i%i%i;\n",idMatriz,auxM->col,idMatriz,auxM->col,auxM->fila);
        auxCol = auxCol->pSig;
    }
    auxFil = pPrimeroF;
    while(auxFil != NULL)
    {
        if(auxFil->pSig != NULL)
        {
            fprintf(fp, "y%i%i -> y%i%i;\n",idMatriz,auxFil->fila,idMatriz,auxFil->pSig->fila);
        }
        auxFil = auxFil->pSig;
    }

    fprintf(fp, "Matriz%i -> x%i%i;\n",idMatriz,idMatriz,pPrimeroC->col);
    fprintf(fp, "Matriz%i -> y%i%i;\n",idMatriz,idMatriz,pPrimeroF->fila);


    fprintf(fp, "\n}");
    //****************************************************
    fprintf(fp, "\n\n}");
    fclose(fp);

    system("dot GraficaMatrizR.dot -o GraficaMatrizR.png -Tpng");
    system("xdg-open GraficaMatrizR.png");
}

void GraficarMatrizRecorridosPre(stcNodoCF *pPrimeroF, stcNodoCC *pPrimeroC, int idMatriz)
{
    FILE *fp;
    fp = fopen("GraficaMatrizP.dot","w");
    fprintf(fp, "digraph GraficaMP{ \n node[shape=record]; graph[rankdir=TB];\n");
    //*************************************************
    fprintf(fp, "subgraph cluster1{\n");
    fprintf(fp, "{rank = same Matriz%i [label = \"Matriz%i\"]",idMatriz,idMatriz);
    stcNodoCC *auxCol = pPrimeroC;
    while(auxCol != NULL)
    {
        fprintf(fp, "x%i%i [label=\"x%i%i\"]",idMatriz,auxCol->pPrimero->col,idMatriz,auxCol->pPrimero->col);

        auxCol = auxCol->pSig;
    }
    fprintf(fp, "}\n");
    auxCol = pPrimeroC;
    while(auxCol != NULL)
    {
        if(auxCol->pSig != NULL)
        {
            fprintf(fp, "x%i%i -> x%i%i;\n",idMatriz,auxCol->col,idMatriz,auxCol->pSig->col);
        }
        auxCol = auxCol->pSig;
    }

    stcNodoCF *auxFil = pPrimeroF;
    while(auxFil != NULL)
    {
        fprintf(fp, "{rank = same y%i%i [label=\"y%i%i\"]\n",idMatriz,auxFil->fila,idMatriz,auxFil->fila);

        stcNodoM *auxM = auxFil->pPrimero;
        while(auxM != NULL)
        {                   //primera i de mas
            fprintf(fp, "  %i%i%i [label=\"#%x\"] \n",idMatriz,auxM->col,auxM->fila,auxM->dato);
            auxM = auxM->pSig;
        }

        auxM = auxFil->pPrimero;
        while(auxM->pSig != NULL)
        {
            fprintf(fp, "%i%i%i -> %i%i%i;\n",idMatriz,auxM->col,auxM->fila,idMatriz,auxM->pSig->col,auxM->pSig->fila);

            auxM = auxM->pSig;
        }
        auxM = auxFil->pPrimero;
        fprintf(fp, "y%i%i -> %i%i%i;\n",idMatriz,auxM->fila,idMatriz,auxM->col,auxM->fila);

        fprintf(fp, "}\n");
        auxFil = auxFil->pSig;
    }
    auxCol = pPrimeroC;
    while(auxCol != NULL)
    {
        stcNodoM *auxM = auxCol->pPrimero;
        while(auxM->pAba != NULL)
        {
            fprintf(fp, "%i%i%i -> %i%i%i;\n",idMatriz,auxM->col,auxM->fila,idMatriz,auxM->pAba->col,auxM->pAba->fila);
            auxM = auxM->pAba;
        }
        auxM = auxCol->pPrimero;
        fprintf(fp, "x%i%i -> %i%i%i;\n",idMatriz,auxM->col,idMatriz,auxM->col,auxM->fila);
        auxCol = auxCol->pSig;
    }
    auxFil = pPrimeroF;
    while(auxFil != NULL)
    {
        if(auxFil->pSig != NULL)
        {
            fprintf(fp, "y%i%i -> y%i%i;\n",idMatriz,auxFil->fila,idMatriz,auxFil->pSig->fila);
        }
        auxFil = auxFil->pSig;
    }

    fprintf(fp, "Matriz%i -> x%i%i;\n",idMatriz,idMatriz,pPrimeroC->col);
    fprintf(fp, "Matriz%i -> y%i%i;\n",idMatriz,idMatriz,pPrimeroF->fila);


    fprintf(fp, "\n}");
    //****************************************************
    fprintf(fp, "\n\n}");
    fclose(fp);

    system("dot GraficaMatrizP.dot -o GraficaMatrizP.png -Tpng");
    system("xdg-open GraficaMatrizP.png");
}


void GraficarMatrizRecorridosPos(stcNodoCF *pPrimeroF, stcNodoCC *pPrimeroC, int idMatriz)
{
    FILE *fp;
    fp = fopen("GraficaMatrizPos.dot","w");
    fprintf(fp, "digraph GraficaMPos{ \n node[shape=record]; graph[rankdir=TB];\n");
    //*************************************************
    fprintf(fp, "subgraph cluster1{\n");
    fprintf(fp, "{rank = same Matriz%i [label = \"Matriz%i\"]",idMatriz,idMatriz);
    stcNodoCC *auxCol = pPrimeroC;
    while(auxCol != NULL)
    {
        fprintf(fp, "x%i%i [label=\"x%i%i\"]",idMatriz,auxCol->pPrimero->col,idMatriz,auxCol->pPrimero->col);

        auxCol = auxCol->pSig;
    }
    fprintf(fp, "}\n");
    auxCol = pPrimeroC;
    while(auxCol != NULL)
    {
        if(auxCol->pSig != NULL)
        {
            fprintf(fp, "x%i%i -> x%i%i;\n",idMatriz,auxCol->col,idMatriz,auxCol->pSig->col);
        }
        auxCol = auxCol->pSig;
    }

    stcNodoCF *auxFil = pPrimeroF;
    while(auxFil != NULL)
    {
        fprintf(fp, "{rank = same y%i%i [label=\"y%i%i\"]\n",idMatriz,auxFil->fila,idMatriz,auxFil->fila);

        stcNodoM *auxM = auxFil->pPrimero;
        while(auxM != NULL)
        {                   //primera i de mas
            fprintf(fp, "  %i%i%i [label=\"#%x\"] \n",idMatriz,auxM->col,auxM->fila,auxM->dato);
            auxM = auxM->pSig;
        }

        auxM = auxFil->pPrimero;
        while(auxM->pSig != NULL)
        {
            fprintf(fp, "%i%i%i -> %i%i%i;\n",idMatriz,auxM->col,auxM->fila,idMatriz,auxM->pSig->col,auxM->pSig->fila);

            auxM = auxM->pSig;
        }
        auxM = auxFil->pPrimero;
        fprintf(fp, "y%i%i -> %i%i%i;\n",idMatriz,auxM->fila,idMatriz,auxM->col,auxM->fila);

        fprintf(fp, "}\n");
        auxFil = auxFil->pSig;
    }
    auxCol = pPrimeroC;
    while(auxCol != NULL)
    {
        stcNodoM *auxM = auxCol->pPrimero;
        while(auxM->pAba != NULL)
        {
            fprintf(fp, "%i%i%i -> %i%i%i;\n",idMatriz,auxM->col,auxM->fila,idMatriz,auxM->pAba->col,auxM->pAba->fila);
            auxM = auxM->pAba;
        }
        auxM = auxCol->pPrimero;
        fprintf(fp, "x%i%i -> %i%i%i;\n",idMatriz,auxM->col,idMatriz,auxM->col,auxM->fila);
        auxCol = auxCol->pSig;
    }
    auxFil = pPrimeroF;
    while(auxFil != NULL)
    {
        if(auxFil->pSig != NULL)
        {
            fprintf(fp, "y%i%i -> y%i%i;\n",idMatriz,auxFil->fila,idMatriz,auxFil->pSig->fila);
        }
        auxFil = auxFil->pSig;
    }

    fprintf(fp, "Matriz%i -> x%i%i;\n",idMatriz,idMatriz,pPrimeroC->col);
    fprintf(fp, "Matriz%i -> y%i%i;\n",idMatriz,idMatriz,pPrimeroF->fila);


    fprintf(fp, "\n}");
    //****************************************************
    fprintf(fp, "\n\n}");
    fclose(fp);

    system("dot GraficaMatrizPos.dot -o GraficaMatrizPos.png -Tpng");
    system("xdg-open GraficaMatrizPos.png");
}

