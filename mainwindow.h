#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>

#include "abb.h"
namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    explicit MainWindow(QWidget *parent = 0);
    ~MainWindow();

private slots:
    void on_pushButton_clicked();

    void on_pushButton_4_clicked();

    void on_pushButton_2_clicked();

    void on_pushButton_5_clicked();

    void on_pushButton_3_clicked();

    void on_pushButton_11_clicked();

    void on_pushButton_12_clicked();

    void on_pushButton_13_clicked();

private:
    Ui::MainWindow *ui;
};

void graficarAuxABB1(nodoAbb *pArbol);
void GraficarMatrizABB1(stcNodoCF *pPrimeroF, stcNodoCC *pPrimeroC,int idMatriz);
void convertToASCII(string letter);

#endif // MAINWINDOW_H
