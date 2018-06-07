/****************************************************************************
** ui.h extension file, included from the uic-generated form implementation.
**
** If you want to add, delete, or rename functions or slots, use
** Qt Designer to update this file, preserving your code.
**
** You should not define a constructor or destructor in this file.
** Instead, write your code in functions called init() and destroy().
** These will automatically be called by the form's constructor and
** destructor.
*****************************************************************************/
#include "lista.cpp"
#include <string>
#include <qmessagebox.h>
using namespace std;

void practica1::Iguardar()
{
    bool ok;
    lista *l=new lista();
    if(txtTexto_ins->text()!="" && txtId_ins->text()!="" && isNumeric(txtId_ins->text())){
	if(!(l->existe(txtId_ins->text().toInt(&ok,10))))
	    l->insertar(txtTexto_ins->text(),txtId_ins->text().toInt(&ok,10));
	else
	    QMessageBox::critical(0,"Error","El id ya existe");
    }
    else
	QMessageBox::critical(0,"Error","La información no es correcta");
    delete(l);
}


void practica1::salir()
{
    this->close();
}


void practica1::Ieliminar()
{
    if(txtId_nodos->text()=="") return;
    bool ok;
    lista *l=new lista();
    l->eliminar(txtId_nodos->text().toInt(&ok,10));
    Inext();
    delete(l);
}

void practica1::Inext()
{
    bool ok;
    lista *l=new lista();
    l->next(txtId_nodos->text().toInt(&ok,10),txtTexto_nodos,txtId_nodos);
    delete(l);
}


void practica1::Iprev()
{
    bool ok;
    lista *l=new lista();
    l->prev(txtId_nodos->text().toInt(&ok,10),txtTexto_nodos,txtId_nodos);
    delete(l);
}

void practica1::Ivaciar()
{
    lista *l=new lista();
    l->vaciar();
    delete(l);
}


bool practica1::isNumeric( QString s )
{
    if(s==NULL) return false;
    for(int i=0;i<s.length();i++)
	if(!(s.at(i) >= '0' && s.at(i) <= '9'))
	    return false;
    return true;
}
