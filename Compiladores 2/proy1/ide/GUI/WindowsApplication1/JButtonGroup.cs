using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsApplication1
{
    public class JButtonGroup : GroupBox
    {
        GUI Inst_myform;//instancia de la clase
        int Type; //1=jradiobutton | 0=jcheckbox

        public JButtonGroup(string name, int type, int posX, int posY, int width, int height, GUI form)
        {
            Inst_myform = form;

            this.AllowDrop = true;
            this.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.BackColor = Color.White;

            this.Name = name;
            this.Type = type; //default 0
            this.Location = new Point(posX, posY);
            this.Size = new System.Drawing.Size(width, height); //default: 200, 100

            this.DragOver += new DragEventHandler(JButtonGroup_DragOver);
            this.MouseDown += new MouseEventHandler(JButtonGroup_MouseDown);
            this.GiveFeedback += new GiveFeedbackEventHandler(JButtonGroup_GiveFeedback);
            this.KeyUp += new KeyEventHandler(JButtonGroup_KeyUp);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(JButtonGroup_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(JButtonGroup_DragEnter);
        }

        //evento keyup
        private void JButtonGroup_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.C)
            {
                int num = Inst_myform.Vg_ArrayJBGroup.Count + 1;
                string nombre = "ButtonGroup" + num;
                this.Parent.Controls.Add(Inst_myform.newJButtonGroup(false, nombre, Type, Left + 3, Top + 3, Width, Height));
            }
        }

        //evento dragOver
        private void JButtonGroup_DragOver(object sender, DragEventArgs e)
        {
            JButtonGroup tmp_sender = (JButtonGroup)sender;
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
        private void JButtonGroup_MouseDown(object sender, MouseEventArgs e)
        {
            JButtonGroup tmp = (JButtonGroup)sender;
            tmp.DoDragDrop(tmp.Name, DragDropEffects.Copy);

            if (e.Clicks == 1)
                mandarPropiedades();
            else
                if (e.Clicks == 2)
                {
                    string borrar_tmp = Inst_myform.preguntar("¿Borrar " + Name + "?");
                    if (borrar_tmp.ToLower().Equals("si"))
                    {
                        Inst_myform.Vg_ArrayJBGroup.Remove(Name);
                        Inst_myform.Vg_ArrayJBGroup.Add("0");
                        this.Dispose(true);
                    }
                }
        }

        //evento giveFeedback
        private void JButtonGroup_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
        }

        //evento dragEnter
        private void JButtonGroup_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        //evento dragDrop
        private void JButtonGroup_DragDrop(object sender, DragEventArgs e)
        {
            int indice = int.Parse(e.Data.GetData(DataFormats.Text).ToString());
            int num;
            string nombre;
            Point tmp_point;

            switch (indice)
            {
                case 2:
                    if (Type == 1)
                        break;
                    //crea jcheckbox
                    num = Inst_myform.Vg_ArrayJCheck.Count + 1;
                    nombre = "JCheckBox" + num;
                    tmp_point = this.PointToClient(MousePosition);
                    this.Controls.Add(Inst_myform.newJCheckBox(false, nombre, nombre, false, Color.Transparent, true, tmp_point.X - 40, tmp_point.Y - 10, 80, 20));
                    break;
                case 3:
                    if (Type == 0)
                        break;
                    //crea jradiobutton
                    num = Inst_myform.Vg_ArrayJRadio.Count + 1;
                    nombre = "JRadioButton" + num;
                    tmp_point = this.PointToClient(MousePosition);
                    this.Controls.Add(Inst_myform.newJRadioButton(false, nombre, nombre, false, Color.Transparent, true, tmp_point.X - 43, tmp_point.Y - 10, 86, 20));
                    break;
            }
        }

        //evento muestra propiedades en el form
        public void mandarPropiedades()
        {
            Inst_myform.Vg_arrayActual = 4;
            Inst_myform.Vg_controlActual = this.Name;

            Inst_myform.mostrarPropiedades(Name, Text, ForeColor, BackColor, Font.Size, Left, Top, Height, Width);
            //mostrando iconos de no-editable
            Inst_myform.lbl_no_text.Visible = Inst_myform.lbl_no_bcolor.Visible = Inst_myform.lbl_no_fcolor.Visible = Inst_myform.lbl_no_fsize.Visible = true;
            Inst_myform.lbl_no_top.Visible = Inst_myform.lbl_no_width.Visible = Inst_myform.lbl_no_height.Visible = Inst_myform.lbl_no_left.Visible = Inst_myform.lbl_no_name.Visible = false;
        }

        public string generarDeclaracion()
        {
            string code = "ButtonGroup " + Name + ";";
            return code;
        }

        public string generarInstancia()
        {
            IEnumerator tmp = this.Controls.GetEnumerator();
            string code = Name + " = new ButtonGroup();\n";
            while (tmp.MoveNext())
                code += Name + ".add(" + ((Control)tmp.Current).Name + ");\n";
            code += Name + ".Type = " + Type + ";\n";
            code += Name + ".setBounds(" + Left + "," + Top + "," + Width + "," + Height + ");";
            return code;
        }
    }
}
