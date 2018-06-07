using System.Windows.Forms;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace WindowsApplication1
{
    public class JTable : DataGridView
    {
        GUI Inst_myform;//instancia de la clase

        public JTable(string name, int rows, int columns, int posX, int posY, int width, int height, GUI form)
        {
            //agregar columnas
            /*this.Columns.AddRange(new DataGridViewColumn[] { this.Column1, this.Column2 });
            DataGridViewTextBoxColumn a = new DataGridViewTextBoxColumn();
            a.HeaderText = "col";
            a.Name = "col";*/
            //filas:
            /*DataGridViewRow r = (DataGridViewRow)Rows[0].Clone();
            r.Cells[0].Value = "dato";
            this.Rows.Add(r);*/

            this.Inst_myform = form;

            this.AllowDrop = true;
            this.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.BackgroundColor = System.Drawing.SystemColors.AppWorkspace;
            this.GridColor = System.Drawing.SystemColors.ControlDark;
            this.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.AllowUserToOrderColumns = false;
            this.AllowUserToResizeColumns = true;
            this.AllowUserToResizeRows = true;
            this.ScrollBars = ScrollBars.Both;
            this.BorderStyle = BorderStyle.FixedSingle;

            this.Location = new System.Drawing.Point(posX, posY);
            this.Name = name;
            this.Size = new System.Drawing.Size(width, height); //default: 240, 150
            for (int i = 0; i < columns; i++)
                this.Columns.Add("Columna" + (i + 1), "Columna" + (i + 1));
            this.Rows.Add(rows);

            this.DragOver += new DragEventHandler(JTable_DragOver);
            this.MouseDown += new MouseEventHandler(JTable_MouseDown);
            this.GiveFeedback += new GiveFeedbackEventHandler(JTable_GiveFeedback);
            this.KeyUp += new KeyEventHandler(JTable_KeyUp);
        }

        //agrega las filas recibidas. rows_data contiene elementos tipo arraylist
        public void agregarFilas(ArrayList rows_data)
        {
            DataGridViewRow r = (DataGridViewRow)this.Rows[0].Clone();
            this.Rows.Clear();
            IEnumerator ie_data = rows_data.GetEnumerator();
            while (ie_data.MoveNext())
            {
                ArrayList tmp = (ArrayList)ie_data.Current;
                IEnumerator ietmp = tmp.GetEnumerator();
                int indice = 0;
                while (ietmp.MoveNext())
                {
                    r.Cells[indice].Value = ietmp.Current;
                    indice++;
                }
                DataGridViewRow r2 = (DataGridViewRow)r.Clone();
                this.Rows.Add(r2);
            }
        }

        //devuelve el contenido de cada fila en un arraylist. cada posicion del arraylist es otro arraylist
        public ArrayList tomarFilas()
        {
            ArrayList data = new ArrayList();
            int numfilas = Rows.Count;
            if (numfilas == 0)
                return data; //array vacio
            for (int i = 0; i < numfilas; i++)
            {
                DataGridViewRow r = (DataGridViewRow)this.Rows[i].Clone();
                int numceldas = r.Cells.Count;
                ArrayList datatmp=new ArrayList();
                for (int j = 0; j < numceldas; j++)
                {
                    datatmp.Add(r.Cells[j].Value);
                }
                ArrayList data2 = (ArrayList)datatmp.Clone();
                data.Add(data2);
            }
            return data; //array con valores
        }

        //evento keyup
        private void JTable_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.C)
            {
                int num = Inst_myform.Vg_ArrayJTable.Count + 1;
                string nombre = "JTable" + num;
                this.Parent.Controls.Add(Inst_myform.newJTable(false, nombre, Rows.Count, Columns.Count, Left + 3, Top + 3, Width, Height));
            }
        }

        //evento dragOver
        private void JTable_DragOver(object sender, DragEventArgs e)
        {
            JTable tmp_sender = (JTable)sender;
            string tmp_data = e.Data.GetData(DataFormats.Text).ToString();
            if (!tmp_data.ToLower().Equals(tmp_sender.Name.ToLower()))
                return;
            Point tmp_point = tmp_sender.Parent.PointToClient(new System.Drawing.Point(e.X, e.Y));
            int x = tmp_point.X - (tmp_sender.Width / 2);
            int y = tmp_point.Y - (tmp_sender.Height / 2);
            tmp_sender.Location = new Point(x, y);
            mandarPropiedades();
        }

        //evento mouseDown
        private void JTable_MouseDown(object sender, MouseEventArgs e)
        {
            JTable tmp = (JTable)sender;
            tmp.DoDragDrop(tmp.Name, DragDropEffects.Copy);

            if (e.Clicks == 1)
                mandarPropiedades();
            else
                if (e.Clicks == 2)
                {
                    string borrar_tmp = Inst_myform.preguntar("¿Borrar " + Name + "?");
                    if (borrar_tmp.ToLower().Equals("si"))
                    {
                        Inst_myform.Vg_ArrayJTable.Remove(Name);
                        Inst_myform.Vg_ArrayJTable.Add("0");
                        this.Dispose(true);
                    }
                }
        }

        //evento giveFeedback
        private void JTable_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
        }

        //evento muestra propiedades en el form
        public void mandarPropiedades()
        {
            Inst_myform.Vg_arrayActual = 10;
            Inst_myform.Vg_controlActual = this.Name;

            Inst_myform.mostrarPropiedades(Name, Text, ForeColor, BackColor, Font.Size, Left, Top, Height, Width);
            //mostrando iconos de no-editable
            Inst_myform.lbl_no_bcolor.Visible = Inst_myform.lbl_no_fcolor.Visible = Inst_myform.lbl_no_fsize.Visible = Inst_myform.lbl_no_text.Visible = true;
            Inst_myform.lbl_no_height.Visible = Inst_myform.lbl_no_left.Visible = Inst_myform.lbl_no_name.Visible =  Inst_myform.lbl_no_top.Visible = Inst_myform.lbl_no_width.Visible = false;
        }

        public string generarDeclaracion()
        {
            string code = "JTable " + Name + ";";
            return code;
        }

        public string generarInstancia()
        {
            string code = Name + " = new JTable(" + Rows.Count + "," + Columns.Count + ");\n";
            code += Name + ".setBounds(" + Left + "," + Top + "," + Width + "," + Height + ");";
            return code;
        }
    }
}
