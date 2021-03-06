#include <string>
using namespace std;

class nodo{
public:
    string nombre;
    int id;
    nodo *prev,*next;
    nodo(string nombre,int id,nodo *prev,nodo *next){
	this->nombre = nombre;
	this->id = id;
	this->prev = prev;
	this->next = next;
    }
    ~nodo(){
	delete(prev);
	delete(next);
    }
};




#include <qlineedit.h>
#include <string>
using namespace std;

class lista{
public:
    nodo *n;
    void insertar(string nombre,int id);
    void eliminar(int id);
    void prev(int id,QLineEdit *nombre,QLineEdit *id);
    void next(int id,QLineEdit *nombre,QLineEdit *id);
    bool existe(int id);
    void vaciar();
    lista(){n = NULL;}
    ~lista(){delete(n);}
};

void lista::vaciar(){
    nodo *tmp_n;
    while(n){
	tmp_n=n;
	n=tmp_n->next;
	delete(tmp_n);
    }
}

void lista::insertar(string nombre,int id){
    if(this->n==NULL) n=new nodo(nombre,id,NULL,NULL);
    else{
	nodo *tmp_n=n;
	while(tmp_n->next!=NULL) tmp_n=tmp_n->next;
	tmp_n->next=new nodo(nombre,id,tmp_n,NULL);
	delete(tmp_n);
    }
}

void lista::eliminar(int id){
    if(!n) return;
    nodo *tmp_n=n;
    while(tmp_n->id!=id)
	tmp_n=tmp_n->next;
    if(tmp_n->prev!=NULL) tmp_n->prev->next=tmp_n->next;
    if(tmp_n->next!=NULL) tmp_n->next->prev=tmp_n->prev;
    delete(tmp_n);
}

void lista::prev(int id,QLineEdit *nombre,QLineEdit *tid){
    QString tmpQS;
    nodo *tmp_n=n;
    while(tmp_n->id!=id){
	if(tmp_n->prev!=NULL)
	    tmp_n=tmp_n->prev;
	else{
	    while(tmp_n->next!=NULL) tmp_n=tmp_n->next;
	    nombre->setText(tmp_n->nombre);
	    tid->setText(tmpQS.setNum(tmp_n->id));
	    delete(tmp_n);
	    return;
	}
    }
    nombre->setText(tmp_n->nombre);
    tid->setText(tmpQS.setNum(tmp_n->id));
    delete(tmp_n);
}

void lista::next(int id,QLineEdit *nombre,QLineEdit *tid){
    QString tmpQS;
    nodo *tmp_n=n;
    while(tmp_n->id!=id){
	if(tmp_n->next!=NULL)
	    tmp_n=tmp_n->next;
	else{
	    nombre->setText(n->nombre);
	    tid->setText(tmpQS.setNum(n->id));
	    delete(tmp_n);
	    return;
	}
    }
    nombre->setText(tmp_n->nombre);
    tid->setText(tmpQS.setNum(tmp_n->id));
    delete(tmp_n);
}

bool lista::existe(int id){
    nodo *tmp_n=n;
    while(tmp_n!=NULL){
	if(tmp_n->id==id){
	    delete(tmp_n);
	    return true;
	}
	tmp_n=tmp_n->next;
    }
    delete(tmp_n);
    return false;
}
