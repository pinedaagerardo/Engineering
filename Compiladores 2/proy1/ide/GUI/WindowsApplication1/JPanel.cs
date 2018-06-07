using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsApplication1
{
    public class JPanel : Panel
    {
        GUI Inst_myform;//instancia de la clase

        public JPanel(string name, int posX, int posY, int width, int height,Color backcolor, GUI form)
        {
            Inst_myform = form;

            this.AllowDrop = true;
            this.Cursor = System.Windows.Forms.Cursors.SizeAll;

            this.Location = new System.Drawing.Point(posX, posY);
            this.Name = name;
            this.Size = new System.Drawing.Size(width, height); //default: 200,100
            this.BackColor = backcolor; //default: color.white

            this.DragDrop += new System.Windows.Forms.DragEventHandler(JPanel_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(JPanel_DragEnter);
            this.DragOver += new DragEventHandler(JPanel_DragOver);
            this.MouseDown += new MouseEventHandler(JPanel_MouseDown);
            this.GiveFeedback += new GiveFeedbackEventHandler(JPanel_GiveFeedback);
        }

        //evento dragOver
        private void JPanel_DragOver(object sender, DragEventArgs e)
        {
            JPanel tmp_sender = (JPanel)sender;
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
        private void JPanel_MouseDown(object sender, MouseEventArgs e)
        {
            JPanel tmp = (JPanel)sender;
            tmp.DoDragDrop(tmp.Name, DragDropEffects.Copy);

            if (e.Clicks == 1)
                mandarPropiedades();
            else
                if (e.Clicks == 2)
                {
                    string borrar_tmp = Inst_myform.preguntar("¿Borrar " + Name + "?");
                    if (borrar_tmp.ToLower().Equals("si"))
                    {
                        Inst_myform.Vg_ArrayJPanel.Remove(Name);
                        Inst_myform.Vg_ArrayJPanel.Add("0");
                        this.Dispose(true);
                    }
                }
        }

        //evento giveFeedback
        private void JPanel_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
        }

        //evento dragEnter
        private void JPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        //evento dragDrop
        private void JPanel_DragDrop(object sender, DragEventArgs e)
        {
            int indice = int.Parse(e.Data.GetData(DataFormats.Text).ToString());
            int num;
            string nombre;
            Point tmp_point;

            switch (indice)
            {
                case 0:
                    //crea jlabel
                    num = Inst_myform.Vg_ArrayJLabel.Count + 1;
                    nombre = "JLabel" + num;
                    tmp_point = this.PointToClient(MousePosition);
                    this.Controls.Add(Inst_myform.newJLabel(false, nombre, Color.Black, 8.25f, nombre, "", ContentAlignment.TopLeft, FontStyle.Regular, Color.Transparent, tmp_point.X - 50, tmp_point.Y - 12, 100, 24, true));
                    break;
                case 1:
                    //crea jbutton
                    num = Inst_myform.Vg_ArrayJButton.Count + 1;
                    nombre = "JButton" + num;
                    tmp_point = this.PointToClient(MousePosition);
                    this.Controls.Add(Inst_myform.newJButton(false, nombre, nombre, ContentAlignment.MiddleCenter, tmp_point.X - 37, tmp_point.Y - 12, 74, 24));
                    break;
                case 2:
                    //crea jcheckbox
                    num = Inst_myform.Vg_ArrayJCheck.Count + 1;
                    nombre = "JCheckBox" + num;
                    tmp_point = this.PointToClient(MousePosition);
                    this.Controls.Add(Inst_myform.newJCheckBox(false, nombre, nombre, false, Color.Transparent, true, tmp_point.X - 40, tmp_point.Y - 10, 80, 20));
                    break;
                case 3:
                    //crea jradiobutton
                    num = Inst_myform.Vg_ArrayJRadio.Count + 1;
                    nombre = "JRadioButton" + num;
                    tmp_point = this.PointToClient(MousePosition);
                    this.Controls.Add(Inst_myform.newJRadioButton(false, nombre, nombre, false, Color.Transparent, true, tmp_point.X - 43, tmp_point.Y - 10, 86, 20));
                    break;
                case 4:
                    //crea jbuttongroup
                    num = Inst_myform.Vg_ArrayJBGroup.Count + 1;
                    nombre = "ButtonGroup" + num;
                    tmp_point = this.PointToClient(MousePosition);
                    this.Controls.Add(Inst_myform.newJButtonGroup(false, nombre, 0, tmp_point.X - 100, tmp_point.Y - 50, 200, 100));
                    break;
                case 5:
                    //crea jcombobox
                    num = Inst_myform.Vg_ArrayJCombo.Count + 1;
                    nombre = "JComboBox" + num;
                    tmp_point = this.PointToClient(MousePosition);
                    this.Controls.Add(Inst_myform.newJComboBox(false, nombre, tmp_point.X - 60, tmp_point.Y - 10, 120, 20));
                    break;
                case 6:
                    //crea jtextfield
                    num = Inst_myform.Vg_ArrayJText.Count + 1;
                    nombre = "JTextField" + num;
                    tmp_point = this.PointToClient(MousePosition);
                    this.Controls.Add(Inst_myform.newJTextField(false, nombre, "", tmp_point.X - 50, tmp_point.Y - 10, 100, 20));
                    break;
                case 7:
                    //crea jtextarea
                    num = Inst_myform.Vg_ArrayJTArea.Count + 1;
                    nombre = "JTextArea" + num;
                    tmp_point = this.PointToClient(MousePosition);
                    this.Controls.Add(Inst_myform.newJTextArea(false, nombre, "", tmp_point.X - 50, tmp_point.Y - 10, 100, 20));
                    break;
                case 8:
                    //crea jpasswordfield
                    num = Inst_myform.Vg_ArrayJPassword.Count + 1;
                    nombre = "JPasswordField" + num;
                    tmp_point = this.PointToClient(MousePosition);
                    this.Controls.Add(Inst_myform.newJPasswordField(false, nombre, "", tmp_point.X - 50, tmp_point.Y - 10, 100, 20));
                    break;
                case 9:
                    //crea jtree
                    num = Inst_myform.Vg_ArrayJTree.Count + 1;
                    nombre = "JTree" + num;
                    tmp_point = this.PointToClient(MousePosition);
                    this.Controls.Add(Inst_myform.newJTree(false, nombre, tmp_point.X - 60, tmp_point.Y - 50, 120, 100));
                    break;
                case 10:
                    //crea jtable
                    num = Inst_myform.Vg_ArrayJTable.Count + 1;
                    nombre = "JTable" + num;
                    tmp_point = this.PointToClient(MousePosition);
                    this.Controls.Add(Inst_myform.newJTable(false, nombre, 1, 1, tmp_point.X - 120, tmp_point.Y - 75, 240, 150));
                    break;
                case 11:
                    //no se puede un panel adentro de otro
                    MessageBox.Show("No se permite agregar un JPanel adentro de otro", "Error");
                    break;
                case 12:
                    //crea jfilechooser
                    num = Inst_myform.Vg_ArrayJFileChooser.Count + 1;
                    nombre = "JFileChooser" + num;
                    tmp_point = this.PointToClient(MousePosition);
                    this.Controls.Add(Inst_myform.newJFileChooser(false, nombre, tmp_point.X - 50, tmp_point.Y - 25, 100, 50));
                    break;
                case 13:
                    //solo 1 form por proyecto
                    MessageBox.Show("Solo se permite un JForm por proyecto", "Error");
                    break;
            }
        }

        //evento muestra propiedades en el form
        public void mandarPropiedades()
        {
            Inst_myform.Vg_arrayActual = 11;
            Inst_myform.Vg_controlActual = this.Name;
            Inst_myform.mostrarPropiedades(Name, "", Color.Transparent, BackColor, 0, Left, Top, Height, Width);
            //mostrando iconos de no-editable
            Inst_myform.lbl_no_fcolor.Visible = Inst_myform.lbl_no_fsize.Visible = Inst_myform.lbl_no_text.Visible = true;
            Inst_myform.lbl_no_bcolor.Visible = Inst_myform.lbl_no_height.Visible = Inst_myform.lbl_no_left.Visible = Inst_myform.lbl_no_name.Visible = Inst_myform.lbl_no_top.Visible = Inst_myform.lbl_no_width.Visible = false;
        }

        public string generarDeclaracion()
        {
            string code = "JPanel " + Name + ";";
            return code;
        }

        public string generarInstancia()
        {
            string code = Name + " = new JPanel();\n";
            code += Name + ".setBackground(Color." + BackColor.Name.ToLower() + ");\n";
            IEnumerator tmp = this.Controls.GetEnumerator();
            while (tmp.MoveNext())
                code += Name + ".add(" + ((Control)tmp.Current).Name + ");\n";
            code += Name + ".setBounds(" + Left + "," + Top + "," + Width + "," + Height + ");";
            return code;
        }
    }
}
