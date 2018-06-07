using System.Drawing;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsApplication1
{
    public class JForm : Panel
    {
        GUI Inst_myform;//instancia de la clase
        public string Vg_Text;

        public JForm(string name, string text, int width, int height, GUI form)
        {
            Inst_myform = form;

            this.AllowDrop = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Location = new System.Drawing.Point(3, 3);

            this.Vg_Text = text; //default: JForm
            this.Name = name; //default: JForm
            this.Size = new System.Drawing.Size(width, height); //default: 533,365

            this.DragDrop += new System.Windows.Forms.DragEventHandler(JForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(JForm_DragEnter);
            this.MouseDown += new MouseEventHandler(JForm_MouseDown);
        }

        //evento mouseDown
        private void JForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks == 1)
                mandarPropiedades();
            else
                if (e.Clicks == 2)
                {
                    string borrar_tmp = Inst_myform.preguntar("¿Borrar "+Name+"?");
                    if (borrar_tmp.ToLower().Equals("si"))
                    {
                        Inst_myform.limpiarArrays();
                        Inst_myform.Vg_miForm = null;
                        this.Dispose(true);
                    }
                }
        }

        //evento dragEnter
        private void JForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        //evento dragDrop
        private void JForm_DragDrop(object sender, DragEventArgs e)
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
                    Inst_myform.newJLabel(true, nombre, Color.Black, 8.25f, nombre, "", ContentAlignment.TopLeft, FontStyle.Regular, Color.Transparent, tmp_point.X - 50, tmp_point.Y - 12, 100, 24, true);
                    break;
                case 1:
                    //crea jbutton
                    num = Inst_myform.Vg_ArrayJButton.Count + 1;
                    nombre = "JButton" + num;
                    tmp_point = this.PointToClient(MousePosition);
                    Inst_myform.newJButton(true, nombre, nombre, ContentAlignment.MiddleCenter, tmp_point.X - 37, tmp_point.Y - 12, 74, 24);
                    break;
                case 2:
                    //crea jcheckbox
                    num = Inst_myform.Vg_ArrayJCheck.Count + 1;
                    nombre = "JCheckBox" + num;
                    tmp_point = this.PointToClient(MousePosition);
                    Inst_myform.newJCheckBox(true, nombre, nombre, false, Color.Transparent, true, tmp_point.X - 40, tmp_point.Y - 10, 80, 20);
                    break;
                case 3:
                    //crea jradiobutton
                    num = Inst_myform.Vg_ArrayJRadio.Count + 1;
                    nombre = "JRadioButton" + num;
                    tmp_point = this.PointToClient(MousePosition);
                    Inst_myform.newJRadioButton(true, nombre, nombre, false, Color.Transparent, true, tmp_point.X - 43, tmp_point.Y - 10, 86, 20);
                    break;
                case 4:
                    //crea jbuttongroup
                    num = Inst_myform.Vg_ArrayJBGroup.Count + 1;
                    nombre = "ButtonGroup" + num;
                    tmp_point = this.PointToClient(MousePosition);
                    Inst_myform.newJButtonGroup(true, nombre, 0, tmp_point.X - 100, tmp_point.Y - 50, 200, 100);
                    break;
                case 5:
                    //crea jcombobox
                    num = Inst_myform.Vg_ArrayJCombo.Count + 1;
                    nombre = "JComboBox" + num;
                    tmp_point = this.PointToClient(MousePosition);
                    Inst_myform.newJComboBox(true, nombre, tmp_point.X - 60, tmp_point.Y - 10, 120, 20);
                    break;
                case 6:
                    //crea jtextfield
                    num = Inst_myform.Vg_ArrayJText.Count + 1;
                    nombre = "JTextField" + num;
                    tmp_point = this.PointToClient(MousePosition);
                    Inst_myform.newJTextField(true, nombre, "", tmp_point.X - 50, tmp_point.Y - 10, 100, 20);
                    break;
                case 7:
                    //crea jtextarea
                    num = Inst_myform.Vg_ArrayJTArea.Count + 1;
                    nombre = "JTextArea" + num;
                    tmp_point = this.PointToClient(MousePosition);
                    Inst_myform.newJTextArea(true, nombre, "", tmp_point.X - 50, tmp_point.Y - 10, 100, 20);
                    break;
                case 8:
                    //crea jpasswordfield
                    num = Inst_myform.Vg_ArrayJPassword.Count + 1;
                    nombre = "JPasswordField" + num;
                    tmp_point = this.PointToClient(MousePosition);
                    Inst_myform.newJPasswordField(true, nombre, "", tmp_point.X - 50, tmp_point.Y - 10, 100, 20);
                    break;
                case 9:
                    //crea jtree
                    num = Inst_myform.Vg_ArrayJTree.Count + 1;
                    nombre = "JTree" + num;
                    tmp_point = this.PointToClient(MousePosition);
                    Inst_myform.newJTree(true, nombre, tmp_point.X - 60, tmp_point.Y - 50, 120, 100);
                    break;
                case 10:
                    //crea jtable
                    num = Inst_myform.Vg_ArrayJTable.Count + 1;
                    nombre = "JTable" + num;
                    tmp_point = this.PointToClient(MousePosition);
                    Inst_myform.newJTable(true, nombre, 1, 1, tmp_point.X - 120, tmp_point.Y - 75, 240, 150);
                    break;
                case 11:
                    //crea jpanel
                    num = Inst_myform.Vg_ArrayJPanel.Count + 1;
                    nombre = "JPanel" + num;
                    tmp_point = this.PointToClient(MousePosition);
                    Inst_myform.newJPanel(true, nombre, tmp_point.X - 100, tmp_point.Y - 50, 200, 100, Color.White);
                    break;
                case 12:
                    //crea jfilechooser
                    num = Inst_myform.Vg_ArrayJFileChooser.Count + 1;
                    nombre = "JFileChooser" + num;
                    tmp_point = this.PointToClient(MousePosition);
                    Inst_myform.newJFileChooser(true, nombre, tmp_point.X - 50, tmp_point.Y - 25, 100, 50);
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
            Inst_myform.Vg_arrayActual = 13;
            Inst_myform.Vg_controlActual = this.Name;
            Inst_myform.mostrarPropiedades(Name, Vg_Text, Color.Transparent, BackColor, 0, Left, Top, Height, Width);
            //mostrando iconos de no-editable
            Inst_myform.lbl_no_bcolor.Visible = Inst_myform.lbl_no_left.Visible = Inst_myform.lbl_no_fcolor.Visible = Inst_myform.lbl_no_top.Visible = Inst_myform.lbl_no_fsize.Visible = true;
            Inst_myform.lbl_no_height.Visible = Inst_myform.lbl_no_name.Visible = Inst_myform.lbl_no_text.Visible = Inst_myform.lbl_no_width.Visible = false;
        }
    }
}
