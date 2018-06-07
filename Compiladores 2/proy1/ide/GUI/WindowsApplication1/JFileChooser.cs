using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsApplication1
{
    public class JFileChooser : Panel
    {
        GUI Inst_myform;//instancia de la clase

        public JFileChooser(string name, int posX, int posY, int width, int height, GUI form)
        {
            Inst_myform = form;

            this.AllowDrop = true;
            this.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.BackColor = Color.DarkGreen;

            this.Name = name;
            this.Location = new Point(posX, posY);
            this.Size = new Size(width, height); //default: 100, 50

            this.DragOver += new DragEventHandler(JFileChooser_DragOver);
            this.MouseDown += new MouseEventHandler(JFileChooser_MouseDown);
            this.GiveFeedback += new GiveFeedbackEventHandler(JFileChooser_GiveFeedback);
            this.KeyUp += new KeyEventHandler(JFileChooser_KeyUp);
        }

        //evento keyup
        private void JFileChooser_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.C)
            {
                int num = Inst_myform.Vg_ArrayJFileChooser.Count + 1;
                string nombre = "JFileChooser" + num;
                this.Parent.Controls.Add(Inst_myform.newJFileChooser(false, nombre, Left + 3, Top + 3, Width, Height));
            }
        }

        //evento dragOver
        private void JFileChooser_DragOver(object sender, DragEventArgs e)
        {
            JFileChooser tmp_sender = (JFileChooser)sender;
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
        private void JFileChooser_MouseDown(object sender, MouseEventArgs e)
        {
            JFileChooser tmp = (JFileChooser)sender;
            tmp.DoDragDrop(tmp.Name, DragDropEffects.Copy);

            if (e.Clicks == 1)
                mandarPropiedades();
            else
                if (e.Clicks == 2)
                {
                    string borrar_tmp = Inst_myform.preguntar("¿Borrar " + Name + "?");
                    if (borrar_tmp.ToLower().Equals("si"))
                    {
                        Inst_myform.Vg_ArrayJFileChooser.Remove(Name);
                        Inst_myform.Vg_ArrayJFileChooser.Add("0");
                        this.Dispose(true);
                    }
                }
        }

        //evento giveFeedback
        private void JFileChooser_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
        }

        //evento muestra propiedades en el form
        public void mandarPropiedades()
        {
            Inst_myform.Vg_arrayActual = 12;
            Inst_myform.Vg_controlActual = this.Name;

            Inst_myform.mostrarPropiedades(Name, Text, ForeColor, BackColor, Font.Size, Left, Top, Height, Width);
            //mostrando iconos de no-editable
            Inst_myform.lbl_no_bcolor.Visible = Inst_myform.lbl_no_fcolor.Visible = Inst_myform.lbl_no_fsize.Visible = Inst_myform.lbl_no_text.Visible = true;
            Inst_myform.lbl_no_height.Visible = Inst_myform.lbl_no_left.Visible = Inst_myform.lbl_no_name.Visible = Inst_myform.lbl_no_top.Visible = Inst_myform.lbl_no_width.Visible = false;
        }

        public string generarDeclaracion()
        {
            string code = "JFileChooser " + Name + ";";
            return code;
        }

        public string generarInstancia()
        {
            string code = Name + " = new JFileChooser();\n";
            code += Name + ".setBounds(" + Left + "," + Top + "," + Width + "," + Height + ");";
            return code;
        }
    }
}
