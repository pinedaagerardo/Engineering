using System.Windows.Forms;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsApplication1
{
    public class JTree : TreeView
    {
        GUI Inst_myform;//instancia de la clase

        public JTree(string name, int posX, int posY, int width, int height, GUI form)
        {
            Inst_myform = form;

            this.AllowDrop = true;
            this.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.BackColor = System.Drawing.SystemColors.Window;

            this.Name = name;
            this.Location = new System.Drawing.Point(posX, posY);
            this.Size = new System.Drawing.Size(width, height); //default: 120,100

            this.DragOver += new DragEventHandler(JTree_DragOver);
            this.MouseDown += new MouseEventHandler(JTree_MouseDown);
            this.GiveFeedback += new GiveFeedbackEventHandler(JTree_GiveFeedback);
            this.KeyUp += new KeyEventHandler(JTree_KeyUp);
        }

        //evento keyup
        private void JTree_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.C)
            {
                int num = Inst_myform.Vg_ArrayJTree.Count + 1;
                string nombre = "JTree" + num;
                this.Parent.Controls.Add(Inst_myform.newJTree(false, nombre, Left + 3, Top + 3, Width, Height));
            }else
                if (e.KeyCode == Keys.Delete)
                {
                    string borrar_tmp = Inst_myform.preguntar("¿Borrar " + Name + "?");
                    if (borrar_tmp.ToLower().Equals("si"))
                    {
                        Inst_myform.Vg_ArrayJTree.Remove(Name);
                        Inst_myform.Vg_ArrayJTree.Add("0");
                        this.Dispose(true);
                    }
                }
        }

        //evento dragOver
        private void JTree_DragOver(object sender, DragEventArgs e)
        {
            JTree tmp_sender = (JTree)sender;
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
        private void JTree_MouseDown(object sender, MouseEventArgs e)
        {
            JTree tmp = (JTree)sender;
            tmp.DoDragDrop(tmp.Name, DragDropEffects.Copy);

            if (e.Clicks == 1)
                mandarPropiedades();
            else
                if (e.Clicks == 2)
                {
                    MessageBox.Show("Eliminar arbol con suprimir");
                }
        }

        //evento giveFeedback
        private void JTree_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
        }

        //evento muestra propiedades en el form
        public void mandarPropiedades()
        {
            Inst_myform.Vg_arrayActual = 9;
            Inst_myform.Vg_controlActual = this.Name;

            Inst_myform.mostrarPropiedades(Name, Text, ForeColor, BackColor, Font.Size, Left, Top, Height, Width);
            //mostrando iconos de no-editable
            Inst_myform.lbl_no_bcolor.Visible = Inst_myform.lbl_no_fcolor.Visible = Inst_myform.lbl_no_fsize.Visible = Inst_myform.lbl_no_text.Visible = true;
            Inst_myform.lbl_no_height.Visible = Inst_myform.lbl_no_left.Visible = Inst_myform.lbl_no_name.Visible = Inst_myform.lbl_no_top.Visible = Inst_myform.lbl_no_width.Visible = false;
        }

        public string generarDeclaracion()
        {
            string code = "JTree " + Name + ";";
            return code;
        }

        public string generarInstancia()
        {
            string code = Name + " = new JTree();\n";
            code += Name + ".setBounds(" + Left + "," + Top + "," + Width + "," + Height + ");";
            return code;
        }
    }
}
