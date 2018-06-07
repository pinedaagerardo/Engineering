using System.Windows.Forms;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace WindowsApplication1
{
    public class JComboBox : ComboBox
    {
        GUI Inst_myform;//instancia de la clase

        public JComboBox(string name, int posX, int posY, int width, int height, GUI form)
        {
            Inst_myform = form;

            this.AllowDrop = true;
            this.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.FormattingEnabled = true;

            this.Name = name;
            this.Location = new Point(posX, posY);
            this.Size = new Size(width, height); //default 120, 20

            this.DragOver += new DragEventHandler(JComboBox_DragOver);
            this.MouseDown += new MouseEventHandler(JComboBox_MouseDown);
            this.GiveFeedback += new GiveFeedbackEventHandler(JComboBox_GiveFeedback);
            this.KeyUp += new KeyEventHandler(JComboBox_KeyUp);
        }

        //evento keyup
        private void JComboBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.C)
            {
                int num = Inst_myform.Vg_ArrayJCombo.Count + 1;
                string nombre = "JComboBox" + num;
                this.Parent.Controls.Add(Inst_myform.newJComboBox(false, nombre, Left + 3, Top + 3, Width, Height));
            }
        }

        //evento dragOver
        private void JComboBox_DragOver(object sender, DragEventArgs e)
        {
            JComboBox tmp_sender = (JComboBox)sender;
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
        private void JComboBox_MouseDown(object sender, MouseEventArgs e)
        {
            JComboBox tmp = (JComboBox)sender;
            tmp.DoDragDrop(tmp.Name, DragDropEffects.Copy);

            if (e.Clicks == 1)
                mandarPropiedades();
            else
                if (e.Clicks == 2)
                {
                    string borrar_tmp = Inst_myform.preguntar("¿Borrar " + Name + "?");
                    if (borrar_tmp.ToLower().Equals("si"))
                    {
                        Inst_myform.Vg_ArrayJCombo.Remove(Name);
                        Inst_myform.Vg_ArrayJCombo.Add("0");
                        this.Dispose(true);
                    }
                }
        }

        //evento giveFeedback
        private void JComboBox_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
        }

        //evento muestra propiedades en el form
        public void mandarPropiedades()
        {
            Inst_myform.Vg_arrayActual = 5;
            Inst_myform.Vg_controlActual = this.Name;

            Inst_myform.mostrarPropiedades(Name, Text, ForeColor, BackColor, Font.Size, Left, Top, Height, Width);
            //mostrando iconos de no-editable
            Inst_myform.lbl_no_bcolor.Visible = Inst_myform.lbl_no_fcolor.Visible = Inst_myform.lbl_no_fsize.Visible = Inst_myform.lbl_no_text.Visible = true;
            Inst_myform.lbl_no_height.Visible = Inst_myform.lbl_no_left.Visible = Inst_myform.lbl_no_name.Visible = Inst_myform.lbl_no_top.Visible = Inst_myform.lbl_no_width.Visible = false;
        }

        public string generarDeclaracion()
        {
            string code = "JComboBox " + Name + ";";
            return code;
        }

        public string generarInstancia()
        {
            string code = Name + " = new JComboBox();\n";
            IEnumerator tmp = Items.GetEnumerator();
            while (tmp.MoveNext())
                code += Name + ".addItem(\"" + (string)tmp.Current + "\");\n";
            code += Name + ".setBounds(" + Left + "," + Top + "," + Width + "," + Height + ");";
            return code;
        }
    }
}
