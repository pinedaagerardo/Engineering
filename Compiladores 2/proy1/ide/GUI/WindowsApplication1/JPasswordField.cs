using System.Windows.Forms;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsApplication1
{
    public class JPasswordField : TextBox
    {
        GUI Inst_myform;//instancia de la clase

        public JPasswordField(string name, string text, int posX, int posY, int width, int height, GUI form)
        {
            Inst_myform = form;

            this.AllowDrop = true;
            this.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.ReadOnly = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.PasswordChar = '*';
            this.ShortcutsEnabled = false;

            this.Name = name;
            this.Text = text;
            this.Location = new System.Drawing.Point(posX, posY);
            this.Size = new System.Drawing.Size(width, height); //default: 100,20

            this.DragOver += new DragEventHandler(JPasswordField_DragOver);
            this.MouseDown += new MouseEventHandler(JPasswordField_MouseDown);
            this.GiveFeedback += new GiveFeedbackEventHandler(JPasswordField_GiveFeedback);
            this.KeyUp += new KeyEventHandler(JPasswordField_KeyUp);
        }

        //evento keyup
        private void JPasswordField_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.C)
            {
                int num = Inst_myform.Vg_ArrayJPassword.Count + 1;
                string nombre = "JPasswordField" + num;
                this.Parent.Controls.Add(Inst_myform.newJPasswordField(false, nombre, Text, Left + 3, Top + 3, Width, Height));
            }
        }

        //evento dragOver
        private void JPasswordField_DragOver(object sender, DragEventArgs e)
        {
            JPasswordField tmp_sender = (JPasswordField)sender;
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
        private void JPasswordField_MouseDown(object sender, MouseEventArgs e)
        {
            JPasswordField tmp = (JPasswordField)sender;
            tmp.DoDragDrop(tmp.Name, DragDropEffects.Copy);

            if (e.Clicks == 1)
                mandarPropiedades();
            else
                if (e.Clicks == 2)
                {
                    string borrar_tmp = Inst_myform.preguntar("�Borrar " + Name + "?");
                    if (borrar_tmp.ToLower().Equals("si"))
                    {
                        Inst_myform.Vg_ArrayJPassword.Remove(Name);
                        Inst_myform.Vg_ArrayJPassword.Add("0");
                        this.Dispose(true);
                    }
                }
        }

        //evento giveFeedback
        private void JPasswordField_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
        }

        //evento muestra propiedades en el form
        public void mandarPropiedades()
        {
            Inst_myform.Vg_arrayActual = 8;
            Inst_myform.Vg_controlActual = this.Name;

            Inst_myform.mostrarPropiedades(Name, Text, ForeColor, BackColor, Font.Size, Left, Top, Height, Width);
            //mostrando iconos de no-editable
            Inst_myform.lbl_no_bcolor.Visible = Inst_myform.lbl_no_fcolor.Visible = Inst_myform.lbl_no_fsize.Visible = true;
            Inst_myform.lbl_no_height.Visible = Inst_myform.lbl_no_left.Visible = Inst_myform.lbl_no_name.Visible = Inst_myform.lbl_no_text.Visible = Inst_myform.lbl_no_top.Visible = Inst_myform.lbl_no_width.Visible = false;
        }

        public string generarDeclaracion()
        {
            string code = "JPasswordField " + Name + ";";
            return code;
        }

        public string generarInstancia()
        {
            string code = Name + " = new JPasswordField(\"" + Text + "\");\n";
            code += Name + ".setBounds(" + Left + "," + Top + "," + Width + "," + Height + ");";
            return code;
        }
    }
}
