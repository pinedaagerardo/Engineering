using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsApplication1
{
    public enum Posiciones : int
    {
        //propiedades
        ID = 0,
        EXISTE = 1,
        FORECOLOR = 2,
        FORESIZE = 3,
        TEXT = 4,
        IMAGEPATH = 5,
        ALIGNMENT = 6,
        TYPETITLE = 7, //titulo o normal
        BACKCOLOR = 8,
        CHECK = 9,
        TYPEBUTTON = 10, //jcheck o jradio
        WIDTH = 11,
        HEIGHT = 12,
        TOP = 13,
        LEFT = 14,
        COLS = 15,
        ROWS = 16,
        PARENT = 17,
        EVENTO_CLIC = 18,
        EVENTO_CHANGE = 19,
        MODIFICADOR = 20,

        //tipos de datos
        NODO = 0, //este nodo tiene la info. de la clase, como el nombre, paquete, imports, modificador de acceso.
        JLABEL = 1,
        JBUTTON = 2,
        JCHECKBOX = 3,
        JRADIOBUTTON = 4,
        BUTTONGROUP = 5,
        JCOMBOBOX = 6,
        JTEXTFIELD = 7,
        JTEXTAREA = 8,
        JPASSWORDFIELD = 9,
        JTREE = 10,
        JTABLE = 11,
        JPANEL = 12,
        JFILECHOOSER = 13
    };
}
