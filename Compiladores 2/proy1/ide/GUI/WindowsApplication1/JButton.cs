using System.Windows.Forms;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsApplication1
{
    public class JButton : Button
    {
        GUI Inst_myform;//instancia de la clase

        public JButton(string nombre, string texto, ContentAlignment align, int posX, int posY, int width, int height, GUI form)
        {
            Inst_myform = form;

            this.UseVisualStyleBackColor = true;
            this.AllowDrop = true;
            this.Cursor = System.Windows.Forms.Cursors.SizeAll;

            this.Name = nombre;
            this.Text = texto;
            this.TextAlign = align;
            this.Location = new Point(posX, posY);
            this.Size = new Size(width, height); //default: 74, 24

            this.DragOver += new DragEventHandler(JButton_DragOver);
            this.MouseDown += new MouseEventHandler(JButton_MouseDown);
            this.GiveFeedback += new GiveFeedbackEventHandler(JButton_GiveFeedback);
            this.KeyUp += new KeyEventHandler(JButton_KeyUp);
        }

        //evento keyup
        private void JButton_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.C)
            {
                int num = Inst_myform.Vg_ArrayJButton.Count + 1;
                string nombre = "JButton" + num;
                this.Parent.Controls.Add(Inst_myform.newJButton(false, nombre, Text, TextAlign, Left + 3, Top + 3, Width, Height));
            }
        }

        //evento dragOver
        private void JButton_DragOver(object sender, DragEventArgs e)
        {
            JButton tmp_sender = (JButton)sender;
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
        private void JButton_MouseDown(object sender, MouseEventArgs e)
        {
            JButton tmp = (JButton)sender;
            tmp.DoDragDrop(tmp.Name, DragDropEffects.Copy);

            if (e.Clicks == 1)
                mandarPropiedades();
            else
                if (e.Clicks == 2)
                {
                    string borrar_tmp = Inst_myform.preguntar("¿Borrar " + Name + "?");
                    if (borrar_tmp.ToLower().Equals("si"))
                    {
                        Inst_myform.Vg_ArrayJButton.Remove(Name);
                        Inst_myform.Vg_ArrayJButton.Add("0");
                        this.Dispose(true);
                    }
                }
        }

        //evento giveFeedback
        private void JButton_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
        }

        //evento muestra propiedades en el form
        public void mandarPropiedades()
        {
            Inst_myform.Vg_arrayActual = 1;
            Inst_myform.Vg_controlActual = this.Name;

            Inst_myform.mostrarPropiedades(Name, Text, ForeColor, BackColor, Font.Size, Left, Top, Height, Width);
            //mostrando iconos de no-editable
            Inst_myform.lbl_no_bcolor.Visible = Inst_myform.lbl_no_fcolor.Visible = Inst_myform.lbl_no_fsize.Visible = true;
            Inst_myform.lbl_no_height.Visible = Inst_myform.lbl_no_left.Visible = Inst_myform.lbl_no_name.Visible = Inst_myform.lbl_no_text.Visible = Inst_myform.lbl_no_top.Visible = Inst_myform.lbl_no_width.Visible = false;
        }

        public string generarDeclaracion()
        {
            string code = "JButton " + Name + ";";
            return code;
        }

        public string generarInstancia()
        {
            string code = Name + " = new JButton(\"" + Text + "\");\n";
            string alineacion = TextAlign.ToString();
            if (alineacion.Contains("Left"))
                alineacion = "LEFT";
            else
                if (alineacion.Contains("Center"))
                    alineacion = "CENTER";
                else
                    if (alineacion.Contains("Right"))
                        alineacion = "RIGHT";
            code += Name + ".setHorizontalTextPosition(AbstractButton." + alineacion + ");\n";
            code += Name + ".setBounds(" + Left + "," + Top + "," + Width + "," + Height + ");";
            return code;
        }
    }
}
