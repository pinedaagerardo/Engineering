using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public class TablaSimbolos
    {
        const int vg_num_tipos = 14; //cantidad de tipos de datos en la tabla
        const int vg_num_propiedades = 21; //cantidad de propiedades de los objetos en la tabla
        object[] vg_tabla = new object[vg_num_tipos]; //variable con los datos de la tabla de simbolos

        public TablaSimbolos()
        {
            vg_tabla[0] = new InfoTabla();
            for (int i = 1; i < vg_num_tipos; i++)
            {
                vg_tabla[i] = new ArrayList();
            }
        }

        //agrega un item
        public void addItem(string id, int pos_tipo)
        {
            if (existeItem(id))
                throw new Exception("Ya existe un objeto con id " + id);

            object[] tmppropiedades = new object[vg_num_propiedades];
            for (int i = 0; i < vg_num_propiedades; i++)
                tmppropiedades[i] = null;
            tmppropiedades[(int)Posiciones.ID] = id;
            tmppropiedades[(int)Posiciones.EXISTE] = false;
            ArrayList tmparray = (ArrayList)vg_tabla[pos_tipo];
            tmparray.Add(tmppropiedades);
        }

        //dice si un item existe
        public bool existeItem(string id)
        {
            for (int i = 1; i < vg_num_tipos; i++)
            {
                ArrayList tmparray = (ArrayList)vg_tabla[i];
                IEnumerator tmpie = tmparray.GetEnumerator();
                while (tmpie.MoveNext())
                {
                    object[] tmpitem = (object[])tmpie.Current;
                    if (tmpitem[(int)Posiciones.ID].ToString().Equals(id))
                        return true;
                }
            }
            return false;
        }

        //devuelve la tabla
        public object[] getTabla()
        {
            return vg_tabla;
        }

        //modifica un item
        public void setItem(string id, int pos_propiedad, object dato)
        {
            for (int i = 1; i < vg_num_tipos; i++)
            {
                ArrayList tmparray = (ArrayList)vg_tabla[i];
                IEnumerator tmpie = tmparray.GetEnumerator();
                while (tmpie.MoveNext())
                {
                    object[] tmpitem = (object[])tmpie.Current;
                    if (tmpitem[(int)Posiciones.ID].ToString().Equals(id))
                    {
                        tmpitem[pos_propiedad] = dato;
                        return;
                    }
                }
            }
            throw new Exception("No existe el objeto con id " + id);
        }

        //convierte un string que representa un tipo de dato al valor correspondiente segun el enum Posiciones
        public int convertPos(string tipo)
        {
            tipo = tipo.Substring(3); //quitando set o get
            if (tipo.Equals("Name"))
                return (int)Posiciones.ID;
            if (tipo.Equals("Foreground"))
                return (int)Posiciones.FORECOLOR;
            //falta

            if (tipo.Equals("JLabel"))
                return (int)Posiciones.JLABEL;
            if (tipo.Equals("JButton"))
                return (int)Posiciones.JBUTTON;
            if (tipo.Equals("JCheckBox"))
                return (int)Posiciones.JCHECKBOX;
            if (tipo.Equals("JRadioButton"))
                return (int)Posiciones.JRADIOBUTTON;
            if (tipo.Equals("ButtonGroup"))
                return (int)Posiciones.BUTTONGROUP;
            if (tipo.Equals("JComboBox"))
                return (int)Posiciones.JCOMBOBOX;
            if (tipo.Equals("JTextField"))
                return (int)Posiciones.JTEXTFIELD;
            if (tipo.Equals("JTextArea"))
                return (int)Posiciones.JTEXTAREA;
            if (tipo.Equals("JPasswordField"))
                return (int)Posiciones.JPASSWORDFIELD;
            if (tipo.Equals("JTree"))
                return (int)Posiciones.JTREE;
            if (tipo.Equals("JTable"))
                return (int)Posiciones.JTABLE;
            if (tipo.Equals("JPanel"))
                return (int)Posiciones.JPANEL;
            if (tipo.Equals("JFileChooser"))
                return (int)Posiciones.JFILECHOOSER;

            return -1; //si no coincide con ninguno
        }
    }
}
