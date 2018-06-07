using System.Drawing;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsApplication1
{
    public class JLabel : Label
    {
        GUI Inst_myform;//instancia de la clase
        string Vg_imagePath;

        public JLabel(string name, Color forecolor, float fontsize, string text, string imagePath, ContentAlignment align, FontStyle style, Color backcolor, int posX, int posY, int width, int height,bool autosize, GUI form)
        {
            Inst_myform = form;

            this.AutoSize = false;
            this.AllowDrop = true;
            this.Cursor = System.Windows.Forms.Cursors.SizeAll;

            this.Name = name;
            this.ForeColor = forecolor; //default: color.black
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", fontsize, style);
            this.Text = text;
            Vg_imagePath = imagePath;
            if (imagePath.Length > 0)
            {
                Image tmp_i = Image.FromFile(imagePath);
                this.Image = tmp_i;
            }
            this.TextAlign = align; //default: ContentAlignment.TopLeft
            this.BackColor = backcolor; //default: color.transparent
            this.Location = new System.Drawing.Point(posX, posY);
            this.Size = new Size(width, height); //default 100,24
            this.AutoSize = autosize;

            this.DragOver += new DragEventHandler(JLabel_DragOver);
            this.MouseDown += new MouseEventHandler(JLabel_MouseDown);
            this.GiveFeedback += new GiveFeedbackEventHandler(JLabel_GiveFeedback);
        }

        //evento dragOver
        private void JLabel_DragOver(object sender, DragEventArgs e)
        {
            JLabel tmp_sender = (JLabel)sender;
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
        private void JLabel_MouseDown(object sender, MouseEventArgs e)
        {
            JLabel tmp = (JLabel)sender;
            tmp.DoDragDrop(tmp.Name, DragDropEffects.Copy);

            if (e.Clicks == 1)
                mandarPropiedades();
            else
                if (e.Clicks == 2)
                {
                    string borrar_tmp = Inst_myform.preguntar("¿Borrar " + Name + "?");
                    if (borrar_tmp.ToLower().Equals("si"))
                    {
                        Inst_myform.Vg_ArrayJLabel.Remove(Name);
                        Inst_myform.Vg_ArrayJLabel.Add("0");
                        this.Dispose(true);
                    }
                }
        }

        //evento giveFeedback
        private void JLabel_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
        }

        //evento muestra propiedades en el form
        public void mandarPropiedades()
        {
            Inst_myform.Vg_arrayActual = 0;
            Inst_myform.Vg_controlActual = this.Name;

            Inst_myform.mostrarPropiedades(Name, Text, ForeColor, BackColor, Font.Size, Left, Top, Height, Width);
            //mostrando iconos de no-editable
            //ninguno se hace visible, todo es editable
            Inst_myform.lbl_no_bcolor.Visible = Inst_myform.lbl_no_fcolor.Visible = Inst_myform.lbl_no_fsize.Visible = Inst_myform.lbl_no_height.Visible = Inst_myform.lbl_no_left.Visible = Inst_myform.lbl_no_name.Visible = Inst_myform.lbl_no_text.Visible = Inst_myform.lbl_no_top.Visible = Inst_myform.lbl_no_width.Visible = false;
        }

        public string generarDeclaracion()
        {
            string code = "";
            if (Vg_imagePath.Length > 0)
                code += "ImageIcon img_" + Name + ";\n";
            code += "JLabel " + Name + ";";
            return code;
        }

        public string generarInstancia()
        {
            string alineacion = TextAlign.ToString();
            if (alineacion.Contains("Left"))
                alineacion = "LEFT";
            else
                if (alineacion.Contains("Center"))
                    alineacion = "CENTER";
                else
                    if (alineacion.Contains("Right"))
                        alineacion = "RIGHT";

            string code = "", tmp_imagen = "";
            if (Vg_imagePath.Length > 0)
            {
                code += "img_" + Name + " = new ImageIcon(\"" + Vg_imagePath + "\");\n";
                tmp_imagen = "img_" + Name + ", ";
            }
            code += Name + " = new JLabel(\"" + Text + "\", " + tmp_imagen + "JLabel." + alineacion + ");\n";
            code += Name + ".setForeground(Color." + ForeColor.Name.ToLower() + ");\n";
            string tmp_style = "";
            if (Font.Strikeout)
                tmp_style = "Font.BOLD|Font.ITALIC";
            else
                if (Font.Italic)
                    tmp_style = "Font.ITALIC";
                else
                    if (Font.Bold)
                        tmp_style = "Font.BOLD";
                    else
                        tmp_style = "Font.PLAIN";
            code += Name + ".setFont(new Font(\"DejaVu Sans\", " + tmp_style + ", " + Font.Size.ToString() + "));\n";
            code += Name + ".setBackground(Color." + BackColor.Name.ToLower() + ");\n";
            code += Name + ".setBounds(" + Left + "," + Top + "," + Width + "," + Height + ");";
            return code;
        }
    }
}
