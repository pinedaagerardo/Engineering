using System.Windows.Forms;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsApplication1
{
    public class JCheckBox : CheckBox
    {
        GUI Inst_myform;//instancia de la clase

        public JCheckBox(string name, string text, bool check, Color backcolor, bool autosize, int posX, int posY, int width, int height, GUI form)
        {
            Inst_myform = form;

            this.AllowDrop = true;
            this.Cursor = System.Windows.Forms.Cursors.SizeAll;

            this.Name = name;
            this.Text = text;
            this.Checked = check;  //default: false
            this.BackColor = backcolor; //default: color.transparent
            this.AutoSize = autosize; //default: true
            this.Location = new Point(posX, posY);
            this.Size = new Size(width, height); //default: 80, 20

            this.DragOver += new DragEventHandler(JCheckBox_DragOver);
            this.MouseDown += new MouseEventHandler(JCheckBox_MouseDown);
            this.GiveFeedback += new GiveFeedbackEventHandler(JCheckBox_GiveFeedback);
            this.KeyUp += new KeyEventHandler(JCheckBox_KeyUp);
        }

        //evento keyup
        private void JCheckBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.C)
            {
                int num = Inst_myform.Vg_ArrayJCheck.Count + 1;
                string nombre = "JCheckBox" + num;
                this.Parent.Controls.Add(Inst_myform.newJCheckBox(false, nombre, Text, this.Checked, this.BackColor, this.AutoSize, Left + 3, Top + 3, Width, Height));
            }
        }

        //evento dragOver
        private void JCheckBox_DragOver(object sender, DragEventArgs e)
        {
            JCheckBox tmp_sender = (JCheckBox)sender;
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
        private void JCheckBox_MouseDown(object sender, MouseEventArgs e)
        {
            JCheckBox tmp = (JCheckBox)sender;
            tmp.DoDragDrop(tmp.Name, DragDropEffects.Copy);

            if (e.Clicks == 1)
                mandarPropiedades();
            else
                if (e.Clicks == 2)
                {
                    string borrar_tmp = Inst_myform.preguntar("¿Borrar " + Name + "?");
                    if (borrar_tmp.ToLower().Equals("si"))
                    {
                        Inst_myform.Vg_ArrayJCheck.Remove(Name);
                        Inst_myform.Vg_ArrayJCheck.Add("0");
                        this.Dispose(true);
                    }
                }
        }

        //evento giveFeedback
        private void JCheckBox_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
        }

        //evento muestra propiedades en el form
        public void mandarPropiedades()
        {
            Inst_myform.Vg_arrayActual = 2;
            Inst_myform.Vg_controlActual = this.Name;

            Inst_myform.mostrarPropiedades(Name, Text, ForeColor, BackColor, Font.Size, Left, Top, Height, Width);
            //mostrando iconos de no-editable
            Inst_myform.lbl_no_fcolor.Visible = Inst_myform.lbl_no_fsize.Visible = true;
            Inst_myform.lbl_no_bcolor.Visible = Inst_myform.lbl_no_height.Visible = Inst_myform.lbl_no_left.Visible = Inst_myform.lbl_no_name.Visible = Inst_myform.lbl_no_text.Visible = Inst_myform.lbl_no_top.Visible = Inst_myform.lbl_no_width.Visible = false;
        }

        public string generarDeclaracion()
        {
            string code = "JCheckBox " + Name + ";";
            return code;
        }

        public string generarInstancia()
        {
            string code = Name + " = new JCheckBox(\"" + Text + "\");\n";
            code += Name + ".setSelected(" + Checked + ");\n";
            code += Name + ".setBackground(Color." + BackColor.Name.ToLower() + ");\n";
            code += Name + ".setBounds(" + Left + "," + Top + "," + Width + "," + Height + ");";
            return code;
        }
    }
}
