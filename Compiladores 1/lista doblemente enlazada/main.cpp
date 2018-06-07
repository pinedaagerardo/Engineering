#include <qapplication.h>
#include "practica1.h"

int main( int argc, char ** argv )
{
    QApplication a( argc, argv );
    practica1 w;
    w.show();
    a.connect( &a, SIGNAL( lastWindowClosed() ), &a, SLOT( quit() ) );
    return a.exec();
}
