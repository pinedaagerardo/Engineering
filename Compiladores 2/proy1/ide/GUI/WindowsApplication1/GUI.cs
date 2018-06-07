using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using com.calitha.commons;
using com.calitha.goldparser;

// Prefijos:
// Inst = instancia
// Vg = variable global
// sin prefijo = variable local

namespace WindowsApplication1
{
    //interfaz grafica
    public partial class GUI : Form
    {
        infoArbol VgInst_info = null; //instancia para uso del arbol del explorador de carpetas
        int Vg_indice = -1; //variable para uso del arbol del explorador de carpetas
        public string Vg_controlActual; //contiene el id (nombre) del control seleccionado del editor
        public int Vg_arrayActual; //el numero de array donde se contiene el control seleccionado del editor (nodos de tree_toolbox)
        public JForm Vg_miForm; //copia del jform
        public FileMan VgInst_explorador = new FileMan(); //manejador de archivos, instancia
        public string Vg_rutaProyecto; //la ruta al proyecto (carpeta que contiene los paquetes)
        public string Vg_nombreClase; //nombre del archivo de la interfaz grafica
        public string Vg_paquete; //nombre del paquete donde esta la interfaz grafica
        public MyParser Vg_parser; //parser para leer el codigo

        /********************** almacenan los struct para los objetos creados en el editor grafico *********************/
        public ArrayList Vg_ArrayJLabel = new ArrayList();
        public ArrayList Vg_ArrayJButton = new ArrayList();
        public ArrayList Vg_ArrayJCheck = new ArrayList();
        public ArrayList Vg_ArrayJRadio = new ArrayList();
        public ArrayList Vg_ArrayJBGroup = new ArrayList();
        public ArrayList Vg_ArrayJCombo = new ArrayList();
        public ArrayList Vg_ArrayJText = new ArrayList();
        public ArrayList Vg_ArrayJTArea = new ArrayList();
        public ArrayList Vg_ArrayJPassword = new ArrayList();
        public ArrayList Vg_ArrayJTree = new ArrayList();
        public ArrayList Vg_ArrayJTable = new ArrayList();
        public ArrayList Vg_ArrayJPanel = new ArrayList();
        public ArrayList Vg_ArrayJFileChooser = new ArrayList();
        public ArrayList Vg_ArrayJForm = new ArrayList();
        /***************************************************************************************************************/

        public GUI()
        {
            InitializeComponent();
            Vg_parser = new MyParser(Application.StartupPath + "\\tablas.cgt");
        }

        //metodo para agregar los nodos al arbol del explorador de carpetas
        private void load_recursivo(TreeNode trw, string ruta)
        {
            try
            {
                string[] carpetas = Directory.GetDirectories(ruta);

                int i = -1;

                foreach (string directorio in carpetas)
                {
                    i++;
                    trw.Nodes.Add(VgInst_info.nodo(directorio));
                    load_recursivo(trw.Nodes[i], directorio);
                }
            }
            catch { }
        }

        //agrega los archivos de la carpeta seleccionada el explorador de archivos. este es el explorador de carpetas. evento
        private void treeView_Explorador_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            try
            {
                listView_ExploradorArchivos.Clear();

                // añade los archivos
                string[] carpetas = Directory.GetFiles(VgInst_info.v_raiz + treeView_Explorador.SelectedNode.FullPath.ToString());
                foreach (string archivo in carpetas)
                    listView_ExploradorArchivos.Items.Add(VgInst_info.nodo(archivo), 2);
            }
            catch { }
        }

        //lee el archivo seleccionado y lo carga en el editor. evento
        private void listView_ExploradorArchivos_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                //lbl_file.Text += listView_ExploradorArchivos.SelectedItems[var].Text;
                //abrir el archivo en el editor
            }
            catch { }
        }

        //metodo que hace una pregunta al usuario. puede retornar: "si", "no" o "cancelar"
        public string preguntar(string pregunta)
        {
            switch (MessageBox.Show(pregunta, "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    return "si";
                case DialogResult.No:
                    return "no";
                default:
                    return "cancelar";
            }
        }

        //abre un dialogo para escoger una carpeta. devuelve la ruta de la carpeta.
        private string abrirDialogoSeleccionarFolder()
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                return folderBrowserDialog1.SelectedPath;
            else
                return "";
        }

        //carga un proyecto en el editor
        private void cargarProyecto(string ruta)
        {
            if (!VgInst_explorador.existeArchivo(ruta + "\\config"))
            {
                MessageBox.Show("El directorio no es un directorio valido o faltan archivos de configuracion");
                return;
            }

            VgInst_info = new infoArbol(ruta);

            string[] carpetas = Directory.GetDirectories(VgInst_info.v_raiz);

            foreach (string directorio in carpetas)
            {
                Vg_indice++;
                treeView_Explorador.Nodes.Add(VgInst_info.nodo(directorio));
                load_recursivo(treeView_Explorador.Nodes[Vg_indice], directorio);
            }

            string texto = "";
            texto = VgInst_explorador.leerTodo(ruta + "\\config");
            char[] delimitador = { ',' };
            string[] str_config = texto.Split(delimitador);
            Vg_rutaProyecto = ruta;
            Vg_paquete = str_config[0];
            Vg_nombreClase = str_config[1];
            newJForm(str_config[2], str_config[3], int.Parse(str_config[4]), int.Parse(str_config[5]));
            texto = "";
            texto = VgInst_explorador.leerTodo(Vg_rutaProyecto + "\\" + Vg_paquete + "\\" + Vg_nombreClase + ".java");
            richTextBox1.Text = texto;
            generarControles();
            tabControl1.SelectTab(1);
            tabPage1.Text = Vg_nombreClase + ".java (diseño)";
            tabPage1.Tag = Vg_paquete;
            tabPage2.Text = Vg_nombreClase + ".java";
            tabPage2.Tag = Vg_paquete;
            panel_tools.Enabled = true;
        }

        //cerrar proyecto. evento
        private void cerrarProyectoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tmp;

            /************preguntar por guardar******************/
            if (VgInst_info != null)
            {
                tmp = preguntar("¿Desea guardar el proyecto?");
                if (tmp.ToLower().Equals("si"))
                    guardarProyecto();
                else
                    if (tmp.ToLower().Equals("cancelar"))
                        return;
            }
            /***************************************************/
            cerrarProyecto();
        }

        //cierra el proyecto y resetea valores
        private void cerrarProyecto()
        {
            Vg_indice = -1;
            VgInst_info = null;
            treeView_Explorador.Nodes.Clear(); // limpiar el explorador de directorios
            listView_ExploradorArchivos.Clear(); // limpiar el explorador de archivos
            Vg_rutaProyecto = "";
            Vg_nombreClase = "";
            Vg_paquete = "";
            panel_tools.Enabled = false;
            limpiarArrays();
            tabPage1.Text = "Diseño";
            panel_editor.Controls.Clear();
            tabPage2.Text = "Código";
            richTextBox1.Text = "";
            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                tabControl1.SelectTab(i);
                removeActiveTab();
            }
            tabControl1.SelectTab(0);
        }

        //crea el nuevo proyecto y lo carga. este metodo es llamado desde la clase VentanaNuevo
        public void crearNuevoProyecto(string ubicacion, string proyecto, string paquete, string clase)
        {
            cerrarProyecto();
            if (!VgInst_explorador.existeCarpeta(ubicacion))
            {
                MessageBox.Show("No existe la ubicacion seleccionada");
                return;
            }
            if (VgInst_explorador.existeArchivo(ubicacion + "\\" + proyecto + "\\config"))
            {
                MessageBox.Show("Ya existe un proyecto en este directorio");
                return;
            }
            Vg_rutaProyecto = ubicacion + "\\" + proyecto;
            Vg_paquete = paquete;
            Vg_nombreClase = clase;
            VgInst_explorador.crearCarpeta(Vg_rutaProyecto);
            VgInst_explorador.crearCarpeta(Vg_rutaProyecto + "\\" + paquete);
            //archivo de config
            VgInst_explorador.abrir(Vg_rutaProyecto + "\\config");
            VgInst_explorador.escribir(paquete + ",");
            VgInst_explorador.escribir(clase + ",");//archivo .java
            VgInst_explorador.escribir("JForm,");//(Vg_miForm.Name);
            VgInst_explorador.escribir("JForm,");//(Vg_miForm.Vg_Text);
            VgInst_explorador.escribir("533,");//(Vg_miForm.Width.ToString());
            VgInst_explorador.escribir("365");//(Vg_miForm.Height.ToString());
            VgInst_explorador.cerrar();
            //main
            VgInst_explorador.abrir(Vg_rutaProyecto + "\\" + paquete + "\\Main.java");
            VgInst_explorador.escribirLinea("package " + paquete + ";");
            VgInst_explorador.escribirLinea("");
            VgInst_explorador.escribirLinea("public class Main {");
            VgInst_explorador.escribirLinea("   public static void main(String[] args) {");
            VgInst_explorador.escribirLinea("       " + clase + " miVentana = new " + clase + "();");
            VgInst_explorador.escribirLinea("       miVentana.setVisible(true);");
            VgInst_explorador.escribirLinea("   }");
            VgInst_explorador.escribirLinea("}");
            VgInst_explorador.cerrar();
            //gui: archivo .java
            VgInst_explorador.abrir(Vg_rutaProyecto + "\\" + paquete + "\\" + clase + ".java");
            VgInst_explorador.escribirLinea("package " + paquete + ";");
            VgInst_explorador.escribirLinea("");
            VgInst_explorador.escribirLinea("public class " + clase + " extends javax.swing.JFrame {");
            VgInst_explorador.escribirLinea("   public " + clase + "() {");
            VgInst_explorador.escribirLinea("       initComponents();");
            VgInst_explorador.escribirLinea("   }");
            VgInst_explorador.escribirLinea("");
            VgInst_explorador.escribirLinea("//No modificar este codigo");
            VgInst_explorador.escribirLinea("void initComponents(){");
            VgInst_explorador.escribirLinea("}");
            VgInst_explorador.escribirLinea("}");
            VgInst_explorador.cerrar();
            
            cargarProyecto(Vg_rutaProyecto);
        }

        //guarda el proyecto actual
        public void guardarProyecto()
        {
            string texto = "";
            if (tabPage1.Text.Equals("Diseño"))
                return;
            if (Vg_miForm == null)
                newJForm("JForm", "JForm", 533, 365);
            generarCodigo();
            VgInst_explorador.borrarArchivo(Vg_rutaProyecto + "\\config");
            VgInst_explorador.abrir(Vg_rutaProyecto + "\\config");
            VgInst_explorador.escribir(Vg_paquete + ",");
            VgInst_explorador.escribir(Vg_nombreClase + ",");//archivo .java
            VgInst_explorador.escribir(Vg_miForm.Name + ",");//(Vg_miForm.Name);
            VgInst_explorador.escribir(Vg_miForm.Vg_Text + ",");//(Vg_miForm.Vg_Text);
            VgInst_explorador.escribir(Vg_miForm.Width.ToString() + ",");//(Vg_miForm.Width.ToString());
            VgInst_explorador.escribir(Vg_miForm.Height.ToString());//(Vg_miForm.Height.ToString());
            VgInst_explorador.cerrar();
            for (int i = 1; i < tabControl1.TabPages.Count; i++) //comienza desde la 1 porque la 0 es el diseño
            {
                tabControl1.SelectTab(i);
                Control[] tmp = tabControl1.SelectedTab.Controls.Find("richTextBox" + i, true);
                texto = ((RichTextBox)tmp[0]).Text;
                string archivo = Vg_rutaProyecto + "\\" + tabControl1.SelectedTab.Tag.ToString() + "\\" + tabControl1.SelectedTab.Text;
                VgInst_explorador.borrarArchivo(archivo);
                VgInst_explorador.abrir(archivo);
                VgInst_explorador.escribirLinea(texto);
                VgInst_explorador.cerrar();
            }
        }

        //crea un nuevo proyecto. evento
        private void menu_nuevo_Click(object sender, EventArgs e)
        {
            string tmp;

            /************preguntar por guardar******************/
            if (VgInst_info != null)
            {
                tmp = preguntar("¿Desea guardar el proyecto?");
                if (tmp.ToLower().Equals("si"))
                    guardarProyecto();
                else
                    if (tmp.ToLower().Equals("cancelar"))
                        return;
            }
            /***************************************************/

            VentanaNuevo ventana = new VentanaNuevo(this);
            ventana.Show();
        }

        //abre el dialogo para abrir un proyecto existente. evento
        private void menu_abrir_Click(object sender, EventArgs e)
        {
            string tmp;

            /************preguntar por guardar******************/
            if (VgInst_info != null)
            {
                tmp = preguntar("¿Desea guardar el proyecto?");
                if (tmp.ToLower().Equals("si"))
                    guardarProyecto();
                else
                    if (tmp.ToLower().Equals("cancelar"))
                        return;
            }
            /***************************************************/

            tmp = abrirDialogoSeleccionarFolder();
            if (!tmp.Equals(""))
            {
                cerrarProyecto();
                cargarProyecto(tmp);
            }
        }

        //guardar como. evento
        private void menu_guardarComo_Click(object sender, EventArgs e)
        {
            if (tabPage1.Text.Equals("Diseño"))
                return;
            if (folderBrowserDialog1.ShowDialog() != DialogResult.OK)
                return;
            string nuevoPath = folderBrowserDialog1.SelectedPath;
            DirectoryInfo dir = new DirectoryInfo(nuevoPath);
            DirectoryInfo[] folders = dir.GetDirectories();
            FileInfo[] files = dir.GetFiles();
            if (folders.Length + files.Length != 0)
            {
                MessageBox.Show("El directorio debe estar vacio");
                return;
            }
            try
            {
                System.Diagnostics.Process.Start("xcopy", "\"" + Vg_rutaProyecto + "\"" + " " + "\"" + nuevoPath + "\" /e");
                System.Diagnostics.Process.GetCurrentProcess().WaitForExit(500);
            }
            catch { }
            Vg_rutaProyecto = nuevoPath;
            guardarProyecto();
        }

        //guarda el proyecto. evento
        private void menu_guardar_Click(object sender, EventArgs e)
        {
            guardarProyecto();
        }

        //salir. evento
        private void menu_salir_Click(object sender, EventArgs e)
        {
            string tmp;

            /************preguntar por guardar******************/
            if (VgInst_info != null)
            {
                tmp = preguntar("¿Desea guardar el proyecto?");
                if (tmp.ToLower().Equals("si"))
                    guardarProyecto();
                else
                    if (tmp.ToLower().Equals("cancelar"))
                        return;
            }
            /***************************************************/

            this.Dispose(true);
        }

        //elimina al editor la pestaña actual
        private void removeActiveTab()
        {
            int tmp_index = tabControl1.SelectedIndex;
            if (tmp_index <= 1) return;
            /************preguntar por guardar******************/
            /*string tmp_msj = preguntar("¿Desea guardar la clase?");
            if (tmp_msj.ToLower().Equals("si"))
                guardarClase(tmp_index);
            else
                if (tmp_msj.ToLower().Equals("cancelar"))
                    return;
            /***************************************************/
            tabControl1.TabPages.RemoveAt(tmp_index);
            tabControl1.SelectTab(tmp_index - 1);
        }

        //guarda la clase en la pestaña actual
        private void guardarClase(int tmp_index)
        {
            MessageBox.Show("guardarClase: metodo incompleto");
        }

        //agrega al editor una pestaña con editor
        private RichTextBox addTab(string nombre, string paquete)
        {
            int tmp_noPestañas = tabControl1.TabPages.Count;
            /*********** creando richtextbox ***************/
            RichTextBox tmp_richTxt = new RichTextBox();
            tmp_richTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            tmp_richTxt.Location = new System.Drawing.Point(6, 6);
            tmp_richTxt.Name = "richTextBox" + tmp_noPestañas;
            tmp_richTxt.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            tmp_richTxt.Size = new System.Drawing.Size(705, 436);
            tmp_richTxt.Text = "";
            tmp_richTxt.WordWrap = false;
            /************************************************/
            /************* creando pestaña *****************/
            TabPage tmp_tab = new TabPage();
            tmp_tab.SuspendLayout();
            tmp_tab.Controls.Add(tmp_richTxt);
            tmp_tab.Location = new System.Drawing.Point(4, 4);
            tmp_tab.Name = "tabPage" + (tmp_noPestañas + 1);
            tmp_tab.Padding = new System.Windows.Forms.Padding(3);
            tmp_tab.Size = new System.Drawing.Size(717, 448);
            tmp_tab.Text = nombre;
            tmp_tab.UseVisualStyleBackColor = true;
            tmp_tab.ResumeLayout(false);
            tmp_tab.Tag = paquete;
            /************************************************/
            tabControl1.Controls.Add(tmp_tab);
            return tmp_richTxt;
        }

        //cierra la pestaña actual. evento
        private void btn_cerrarPestaña_Click(object sender, EventArgs e)
        {
            removeActiveTab();
        }

        //evento. selecciona un color para las letras del control
        private void btn_color_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() != DialogResult.Cancel)
            {
                lbl_forecolor.BackColor = colorDialog1.Color;
            }
        }

        //evento. escoge un color para el fondo del control
        private void btn_backcolor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() != DialogResult.Cancel)
            {
                lbl_backcolor.BackColor = colorDialog1.Color;
            }
        }

        //evento. selecciona tamaño de letra
        private void btn_Fsize_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                lbl_size.Text = fontDialog1.Font.Size.ToString();
            }
        }

        //limpia todos los array de objetos. se usa al borrar un form
        public void limpiarArrays()
        {
            Vg_ArrayJLabel.Clear();
            Vg_ArrayJButton.Clear();
            Vg_ArrayJCheck.Clear();
            Vg_ArrayJRadio.Clear();
            Vg_ArrayJBGroup.Clear();
            Vg_ArrayJCombo.Clear();
            Vg_ArrayJText.Clear();
            Vg_ArrayJTArea.Clear();
            Vg_ArrayJPassword.Clear();
            Vg_ArrayJTree.Clear();
            Vg_ArrayJTable.Clear();
            Vg_ArrayJPanel.Clear();
            Vg_ArrayJFileChooser.Clear();
            Vg_ArrayJForm.Clear();
        }

        //busca y retorna un control que este adentro del form o de un panel o un buttongroup
        public Control encontrarControl(string nombre)
        {
            Control[] tmpP, tmpF, tmpBG;
            IEnumerator ienumP, ienumBG;
            Control control;
            tmpF = Vg_miForm.Controls.Find(nombre, true);
            if (tmpF.Length > 0)
            {
                control = (Control)tmpF[0];
                return control;
            }
            else
            {
                ienumP = Vg_ArrayJPanel.GetEnumerator();
                while (ienumP.MoveNext())
                {
                    JPanel panel;
                    tmpP = Vg_miForm.Controls.Find((string)ienumP.Current, true);
                    if (tmpP.Length > 0)
                    {
                        panel = (JPanel)tmpP[0];
                        tmpP = panel.Controls.Find(nombre, true);
                        if (tmpP.Length > 0)
                        {
                            control = (Control)tmpP[0];
                            return control;
                        }
                        else
                        {
                            ienumBG = Vg_ArrayJBGroup.GetEnumerator();
                            while (ienumBG.MoveNext())
                            {
                                JButtonGroup bgroup;
                                tmpBG = panel.Controls.Find((string)ienumBG.Current, true);
                                if (tmpBG.Length > 0)
                                {
                                    bgroup = (JButtonGroup)tmpBG[0];
                                    tmpBG = bgroup.Controls.Find(nombre, true);
                                    if (tmpBG.Length > 0)
                                    {
                                        control = (Control)tmpBG[0];
                                        return control;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            //si no esta en el form ni en los panel ni en los jbuttongroup de los panel buscar en los jbuttongroup del form
            ienumBG = Vg_ArrayJBGroup.GetEnumerator();
            while (ienumBG.MoveNext())
            {
                JButtonGroup bgroup;
                tmpBG = Vg_miForm.Controls.Find((string)ienumBG.Current, true);
                if (tmpBG.Length > 0)
                {
                    bgroup = (JButtonGroup)tmpBG[0];
                    tmpBG = bgroup.Controls.Find(nombre, true);
                    if (tmpBG.Length > 0)
                    {
                        control = (Control)tmpBG[0];
                        return control;
                    }
                }
            }
            return null; //si no lo encuentra retorna null (en caso que busque un "0" por el borrado de un control en el array
        }

        //muestra las propiedades recibidas para editarlas o verlas
        public void mostrarPropiedades(string name, string text, Color forecolor, Color backcolor, float fontsize, int left, int top, int height, int width)
        {
            txt_height.Text = height.ToString();
            txt_left.Text = left.ToString();
            txt_nombre.Text = name;
            txt_text.Text = text;
            txt_top.Text = top.ToString();
            txt_width.Text = width.ToString();
            lbl_backcolor.BackColor = backcolor;
            lbl_forecolor.BackColor = forecolor;
            lbl_size.Text = fontsize.ToString();
        }

        //aplica los cambios a las propiedades del control actual. evento
        private void btn_aplicar_Click(object sender, EventArgs e)
        {
            switch (Vg_arrayActual)
            {
                case 0:
                    //crea jlabel
                    if (!Vg_controlActual.Equals(txt_nombre.Text) && existeNombre(txt_nombre.Text))
                    {
                        MessageBox.Show("El nombre ya existe para otro control", "Error");
                        return;
                    }
                    JLabel label = (JLabel)encontrarControl(Vg_controlActual);
                    label.Name = txt_nombre.Text;
                    label.Text = txt_text.Text;
                    label.BackColor = lbl_backcolor.BackColor;
                    label.Font = new Font(label.Font.Name, float.Parse(lbl_size.Text), label.Font.Style);
                    label.ForeColor = lbl_forecolor.BackColor;
                    label.Top = int.Parse(txt_top.Text);
                    label.Left = int.Parse(txt_left.Text);
                    label.Width = int.Parse(txt_width.Text);
                    label.Height = int.Parse(txt_height.Text);
                    Vg_ArrayJLabel.Remove(Vg_controlActual);
                    Vg_ArrayJLabel.Add(txt_nombre.Text);
                    label.mandarPropiedades();
                    break;
                case 1:
                    //crea jbutton
                    if (!Vg_controlActual.Equals(txt_nombre.Text) && existeNombre(txt_nombre.Text))
                    {
                        MessageBox.Show("El nombre ya existe para otro control", "Error");
                        return;
                    }
                    JButton boton = (JButton)encontrarControl(Vg_controlActual);
                    boton.Name = txt_nombre.Text;
                    boton.Text = txt_text.Text;
                    boton.Top = int.Parse(txt_top.Text);
                    boton.Left = int.Parse(txt_left.Text);
                    boton.Width = int.Parse(txt_width.Text);
                    boton.Height = int.Parse(txt_height.Text);
                    Vg_ArrayJButton.Remove(Vg_controlActual);
                    Vg_ArrayJButton.Add(txt_nombre.Text);
                    boton.mandarPropiedades();
                    break;
                case 2:
                    //crea jcheckbox
                    if (!Vg_controlActual.Equals(txt_nombre.Text) && existeNombre(txt_nombre.Text))
                    {
                        MessageBox.Show("El nombre ya existe para otro control", "Error");
                        return;
                    }
                    JCheckBox check = (JCheckBox)encontrarControl(Vg_controlActual);
                    check.Name = txt_nombre.Text;
                    check.Text = txt_text.Text;
                    check.BackColor = lbl_backcolor.BackColor;
                    check.Top = int.Parse(txt_top.Text);
                    check.Left = int.Parse(txt_left.Text);
                    check.Width = int.Parse(txt_width.Text);
                    check.Height = int.Parse(txt_height.Text);
                    Vg_ArrayJCheck.Remove(Vg_controlActual);
                    Vg_ArrayJCheck.Add(txt_nombre.Text);
                    check.mandarPropiedades();
                    break;
                case 3:
                    //crea jradiobutton
                    if (!Vg_controlActual.Equals(txt_nombre.Text) && existeNombre(txt_nombre.Text))
                    {
                        MessageBox.Show("El nombre ya existe para otro control", "Error");
                        return;
                    }
                    JRadioButton radio = (JRadioButton)encontrarControl(Vg_controlActual);
                    radio.Name = txt_nombre.Text;
                    radio.Text = txt_text.Text;
                    radio.BackColor = lbl_backcolor.BackColor;
                    radio.Top = int.Parse(txt_top.Text);
                    radio.Left = int.Parse(txt_left.Text);
                    radio.Width = int.Parse(txt_width.Text);
                    radio.Height = int.Parse(txt_height.Text);
                    Vg_ArrayJRadio.Remove(Vg_controlActual);
                    Vg_ArrayJRadio.Add(txt_nombre.Text);
                    radio.mandarPropiedades();
                    break;
                case 4:
                    //crea jbuttongroup
                    if (!Vg_controlActual.Equals(txt_nombre.Text) && existeNombre(txt_nombre.Text))
                    {
                        MessageBox.Show("El nombre ya existe para otro control", "Error");
                        return;
                    }
                    JButtonGroup grupo = (JButtonGroup)encontrarControl(Vg_controlActual);
                    grupo.Name = txt_nombre.Text;
                    grupo.Top = int.Parse(txt_top.Text);
                    grupo.Left = int.Parse(txt_left.Text);
                    grupo.Width = int.Parse(txt_width.Text);
                    grupo.Height = int.Parse(txt_height.Text);
                    Vg_ArrayJBGroup.Remove(Vg_controlActual);
                    Vg_ArrayJBGroup.Add(txt_nombre.Text);
                    grupo.mandarPropiedades();
                    break;
                case 5:
                    //crea jcombobox
                    if (!Vg_controlActual.Equals(txt_nombre.Text) && existeNombre(txt_nombre.Text))
                    {
                        MessageBox.Show("El nombre ya existe para otro control", "Error");
                        return;
                    }
                    JComboBox combo = (JComboBox)encontrarControl(Vg_controlActual);
                    combo.Name = txt_nombre.Text;
                    combo.Top = int.Parse(txt_top.Text);
                    combo.Left = int.Parse(txt_left.Text);
                    combo.Width = int.Parse(txt_width.Text);
                    combo.Height = int.Parse(txt_height.Text);
                    Vg_ArrayJCombo.Remove(Vg_controlActual);
                    Vg_ArrayJCombo.Add(txt_nombre.Text);
                    combo.mandarPropiedades();
                    break;
                case 6:
                    //crea jtextfield
                    if (!Vg_controlActual.Equals(txt_nombre.Text) && existeNombre(txt_nombre.Text))
                    {
                        MessageBox.Show("El nombre ya existe para otro control", "Error");
                        return;
                    }
                    JTextField text = (JTextField)encontrarControl(Vg_controlActual);
                    text.Name = txt_nombre.Text;
                    text.Text = txt_text.Text;
                    text.Top = int.Parse(txt_top.Text);
                    text.Left = int.Parse(txt_left.Text);
                    text.Width = int.Parse(txt_width.Text);
                    text.Height = int.Parse(txt_height.Text);
                    Vg_ArrayJText.Remove(Vg_controlActual);
                    Vg_ArrayJText.Add(txt_nombre.Text);
                    text.mandarPropiedades();
                    break;
                case 7:
                    //crea jtextarea
                    if (!Vg_controlActual.Equals(txt_nombre.Text) && existeNombre(txt_nombre.Text))
                    {
                        MessageBox.Show("El nombre ya existe para otro control", "Error");
                        return;
                    }
                    JTextArea area = (JTextArea)encontrarControl(Vg_controlActual);
                    area.Name = txt_nombre.Text;
                    area.Text = txt_text.Text;
                    area.Top = int.Parse(txt_top.Text);
                    area.Left = int.Parse(txt_left.Text);
                    area.Width = int.Parse(txt_width.Text);
                    area.Height = int.Parse(txt_height.Text);
                    Vg_ArrayJTArea.Remove(Vg_controlActual);
                    Vg_ArrayJTArea.Add(txt_nombre.Text);
                    area.mandarPropiedades();
                    break;
                case 8:
                    //crea jpasswordfield
                    if (!Vg_controlActual.Equals(txt_nombre.Text) && existeNombre(txt_nombre.Text))
                    {
                        MessageBox.Show("El nombre ya existe para otro control", "Error");
                        return;
                    }
                    JPasswordField pass = (JPasswordField)encontrarControl(Vg_controlActual);
                    pass.Name = txt_nombre.Text;
                    pass.Text = txt_text.Text;
                    pass.Top = int.Parse(txt_top.Text);
                    pass.Left = int.Parse(txt_left.Text);
                    pass.Width = int.Parse(txt_width.Text);
                    pass.Height = int.Parse(txt_height.Text);
                    Vg_ArrayJPassword.Remove(Vg_controlActual);
                    Vg_ArrayJPassword.Add(txt_nombre.Text);
                    pass.mandarPropiedades();
                    break;
                case 9:
                    //crea jtree
                    if (!Vg_controlActual.Equals(txt_nombre.Text) && existeNombre(txt_nombre.Text))
                    {
                        MessageBox.Show("El nombre ya existe para otro control", "Error");
                        return;
                    }
                    JTree arbol = (JTree)encontrarControl(Vg_controlActual);
                    arbol.Name = txt_nombre.Text;
                    arbol.Top = int.Parse(txt_top.Text);
                    arbol.Left = int.Parse(txt_left.Text);
                    arbol.Width = int.Parse(txt_width.Text);
                    arbol.Height = int.Parse(txt_height.Text);
                    Vg_ArrayJTree.Remove(Vg_controlActual);
                    Vg_ArrayJTree.Add(txt_nombre.Text);
                    arbol.mandarPropiedades();
                    break;
                case 10:
                    //crea jtable
                    if (!Vg_controlActual.Equals(txt_nombre.Text) && existeNombre(txt_nombre.Text))
                    {
                        MessageBox.Show("El nombre ya existe para otro control", "Error");
                        return;
                    }
                    JTable tabla = (JTable)encontrarControl(Vg_controlActual);
                    tabla.Name = txt_nombre.Text;
                    tabla.Top = int.Parse(txt_top.Text);
                    tabla.Left = int.Parse(txt_left.Text);
                    tabla.Width = int.Parse(txt_width.Text);
                    tabla.Height = int.Parse(txt_height.Text);
                    Vg_ArrayJTable.Remove(Vg_controlActual);
                    Vg_ArrayJTable.Add(txt_nombre.Text);
                    tabla.mandarPropiedades();
                    break;
                case 11:
                    //crea jpanel
                    if (!Vg_controlActual.Equals(txt_nombre.Text) && existeNombre(txt_nombre.Text))
                    {
                        MessageBox.Show("El nombre ya existe para otro control", "Error");
                        return;
                    }
                    JPanel panel = (JPanel)encontrarControl(Vg_controlActual);
                    panel.Name = txt_nombre.Text;
                    panel.Top = int.Parse(txt_top.Text);
                    panel.Left = int.Parse(txt_left.Text);
                    panel.Width = int.Parse(txt_width.Text);
                    panel.Height = int.Parse(txt_height.Text);
                    panel.BackColor = lbl_backcolor.BackColor;
                    Vg_ArrayJPanel.Remove(Vg_controlActual);
                    Vg_ArrayJPanel.Add(txt_nombre.Text);
                    panel.mandarPropiedades();
                    break;
                case 12:
                    //crea jfilechooser
                    if (!Vg_controlActual.Equals(txt_nombre.Text) && existeNombre(txt_nombre.Text))
                    {
                        MessageBox.Show("El nombre ya existe para otro control", "Error");
                        return;
                    }
                    JFileChooser chooser = (JFileChooser)encontrarControl(Vg_controlActual);
                    chooser.Name = txt_nombre.Text;
                    chooser.Top = int.Parse(txt_top.Text);
                    chooser.Left = int.Parse(txt_left.Text);
                    chooser.Width = int.Parse(txt_width.Text);
                    chooser.Height = int.Parse(txt_height.Text);
                    Vg_ArrayJFileChooser.Remove(Vg_controlActual);
                    Vg_ArrayJFileChooser.Add(txt_nombre.Text);
                    chooser.mandarPropiedades();
                    break;
                case 13:
                    //jform
                    if (!Vg_controlActual.Equals(txt_nombre.Text) && existeNombre(txt_nombre.Text))
                    {
                        MessageBox.Show("El nombre ya existe para otro control", "Error");
                        return;
                    }
                    Vg_miForm.Name = txt_nombre.Text;
                    Vg_miForm.Vg_Text = txt_text.Text;
                    Vg_miForm.Width = int.Parse(txt_width.Text);
                    Vg_miForm.Height = int.Parse(txt_height.Text);
                    Vg_ArrayJForm.Clear();
                    Vg_ArrayJForm.Add(txt_nombre.Text);
                    Vg_miForm.mandarPropiedades();
                    break;
            }
        }

        //dice si existe un nombre de control o no (true=existe,false=no existe)
        public bool existeNombre(string nom)
        {
            int tmp = 0;
            tmp =
            Vg_ArrayJLabel.IndexOf(nom) + Vg_ArrayJButton.IndexOf(nom) + Vg_ArrayJCheck.IndexOf(nom) +
            Vg_ArrayJRadio.IndexOf(nom) + Vg_ArrayJBGroup.IndexOf(nom) + Vg_ArrayJCombo.IndexOf(nom) +
            Vg_ArrayJText.IndexOf(nom) + Vg_ArrayJTArea.IndexOf(nom) + Vg_ArrayJPassword.IndexOf(nom) +
            Vg_ArrayJTree.IndexOf(nom) + Vg_ArrayJTable.IndexOf(nom) + Vg_ArrayJPanel.IndexOf(nom) +
            Vg_ArrayJFileChooser.IndexOf(nom) + Vg_ArrayJForm.IndexOf(nom);
            return tmp != -14;
        }

        //generar codigo. evento
        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (tabPage1.Text.Equals("Diseño"))
                return;
            if (tabControl1.SelectedIndex == 1)
            {
                generarCodigo();
            }
            if (tabControl1.SelectedIndex == 0)
            {
                generarControles();
            }
        }

        //genera el codigo de los botones en el editor
        public void generarCodigo()
        {
            int pos = richTextBox1.Find("//No modificar este codigo", RichTextBoxFinds.Reverse);
            pos += 50;
            richTextBox1.Text = richTextBox1.Text.Remove(pos);
            ArrayList tmp = new ArrayList();
            tmp.Add(Vg_ArrayJLabel); tmp.Add(Vg_ArrayJButton); tmp.Add(Vg_ArrayJCheck);
            tmp.Add(Vg_ArrayJRadio); tmp.Add(Vg_ArrayJBGroup); tmp.Add(Vg_ArrayJCombo);
            tmp.Add(Vg_ArrayJText); tmp.Add(Vg_ArrayJTArea); tmp.Add(Vg_ArrayJPassword);
            tmp.Add(Vg_ArrayJTree); tmp.Add(Vg_ArrayJTable); tmp.Add(Vg_ArrayJPanel);
            tmp.Add(Vg_ArrayJFileChooser); tmp.Add(Vg_ArrayJForm);
            IEnumerator ietmp = tmp.GetEnumerator();
            int cont = 0, vuelta = 0;
            while (ietmp.MoveNext())
            {
                ArrayList array = (ArrayList)ietmp.Current;
                IEnumerator iearray = array.GetEnumerator();
                while (iearray.MoveNext())
                {
                    Control c = encontrarControl((string)iearray.Current);
                    if (c != null)
                    {
                        switch (cont)
                        {
                            case 0:
                                if (vuelta == 0)
                                    richTextBox1.Text += ((JLabel)c).generarInstancia() + "\n";
                                else
                                    richTextBox1.Text += ((JLabel)c).generarDeclaracion() + "\n";
                                break;
                            case 1:
                                if (vuelta == 0)
                                    richTextBox1.Text += ((JButton)c).generarInstancia() + "\n";
                                else
                                    richTextBox1.Text += ((JButton)c).generarDeclaracion() + "\n";
                                break;
                            case 2:
                                if (vuelta == 0)
                                    richTextBox1.Text += ((JCheckBox)c).generarInstancia() + "\n";
                                else
                                    richTextBox1.Text += ((JCheckBox)c).generarDeclaracion() + "\n";
                                break;
                            case 3:
                                if (vuelta == 0)
                                    richTextBox1.Text += ((JRadioButton)c).generarInstancia() + "\n";
                                else
                                    richTextBox1.Text += ((JRadioButton)c).generarDeclaracion() + "\n";
                                break;
                            case 4:
                                if (vuelta == 0)
                                    richTextBox1.Text += ((JButtonGroup)c).generarInstancia() + "\n";
                                else
                                    richTextBox1.Text += ((JButtonGroup)c).generarDeclaracion() + "\n";
                                break;
                            case 5:
                                if (vuelta == 0)
                                    richTextBox1.Text += ((JComboBox)c).generarInstancia() + "\n";
                                else
                                    richTextBox1.Text += ((JComboBox)c).generarDeclaracion() + "\n";
                                break;
                            case 6:
                                if (vuelta == 0)
                                    richTextBox1.Text += ((JTextField)c).generarInstancia() + "\n";
                                else
                                    richTextBox1.Text += ((JTextField)c).generarDeclaracion() + "\n";
                                break;
                            case 7:
                                if (vuelta == 0)
                                    richTextBox1.Text += ((JTextArea)c).generarInstancia() + "\n";
                                else
                                    richTextBox1.Text += ((JTextArea)c).generarDeclaracion() + "\n";
                                break;
                            case 8:
                                if (vuelta == 0)
                                    richTextBox1.Text += ((JPasswordField)c).generarInstancia() + "\n";
                                else
                                    richTextBox1.Text += ((JPasswordField)c).generarDeclaracion() + "\n";
                                break;
                            case 9:
                                if (vuelta == 0)
                                    richTextBox1.Text += ((JTree)c).generarInstancia() + "\n";
                                else
                                    richTextBox1.Text += ((JTree)c).generarDeclaracion() + "\n";
                                break;
                            case 10:
                                if (vuelta == 0)
                                    richTextBox1.Text += ((JTable)c).generarInstancia() + "\n";
                                else
                                    richTextBox1.Text += ((JTable)c).generarDeclaracion() + "\n";
                                break;
                            case 11:
                                if (vuelta == 0)
                                    richTextBox1.Text += ((JPanel)c).generarInstancia() + "\n";
                                else
                                    richTextBox1.Text += ((JPanel)c).generarDeclaracion() + "\n";
                                break;
                            case 12:
                                if (vuelta == 0)
                                    richTextBox1.Text += ((JFileChooser)c).generarInstancia() + "\n";
                                else
                                    richTextBox1.Text += ((JFileChooser)c).generarDeclaracion() + "\n";
                                break;
                            case 13:
                                break;
                        }
                    }
                }
                cont++;
                if (cont == 14)
                {
                    if (vuelta == 0)
                    {
                        ietmp.Reset();
                        richTextBox1.Text += "}\n\n";
                    }
                    vuelta++;
                    cont = 0;
                }
            }
            richTextBox1.Text += "}\n";
        }

        //genera los controles que estan en el codigo
        public void generarControles()
        {
            MessageBox.Show("generar controles, incompleto");//parsear
        }

        /**************************************** crear y agregar controles ****************************************/

        //crea un jtextfield y devuelve la instancia. Si addToForm = true, agrega el control al JForm.
        public JTextField newJTextField(bool addToForm, string name, string text, int posX, int posY, int width, int height)
        {
            for (int i = 0; existeNombre(name); i++, name = name + "_" + i) ;

            JTextField mytext = new JTextField(name, text, posX, posY, width, height, this);
            Vg_ArrayJText.Add(name);
            if (addToForm)
                Vg_miForm.Controls.Add(mytext);
            return mytext;
        }

        //crea un JForm si no existe ninguno, lo agrega al editor y devuelve la instancia. (solo puede haber 1 jform)
        public JForm newJForm(string name, string text, int width, int height)
        {
            if (Vg_ArrayJForm.Count > 0)
            {
                MessageBox.Show("Solo se permite un JForm por proyecto", "Error");
                return null;
            }
            JForm myform = new JForm(name, text, width, height, this);
            Vg_ArrayJForm.Add(name);
            panel_editor.Controls.Add(myform);
            Vg_miForm = myform;
            return myform;
        }

        //crea un JPanel y devuelve la instancia. (solo lo crea encima del jform, en otro panel no se puede)
        public JPanel newJPanel(bool addToForm, string name, int posX, int posY, int width, int height, Color backcolor)
        {
            for (int i = 0; existeNombre(name); i++, name = name + "_" + i) ;

            JPanel mypanel = new JPanel(name, posX, posY, width, height, backcolor, this);
            Vg_ArrayJPanel.Add(name);
            if (addToForm)
                Vg_miForm.Controls.Add(mypanel);
            return mypanel;
        }

        //crea un jlabel y devuelve la instancia. Si addToForm = true, agrega el control al JForm.
        public JLabel newJLabel(bool addToForm, string name, Color forecolor, float fontsize, string text, string imagePath, ContentAlignment align, FontStyle style, Color backcolor, int posX, int posY, int width, int height, bool autosize)
        {
            for (int i = 0; existeNombre(name); i++, name = name + "_" + i) ;

            JLabel mylabel = new JLabel(name, forecolor, fontsize, text, imagePath, align, style, backcolor, posX, posY, width, height, autosize, this);
            Vg_ArrayJLabel.Add(name);
            if (addToForm)
                Vg_miForm.Controls.Add(mylabel);
            return mylabel;
        }

        //crea un jbutton y devuelve la instancia. Si addToForm = true, agrega el control al JForm.
        public JButton newJButton(bool addToForm, string name, string text, ContentAlignment align, int posX, int posY, int width, int height)
        {
            for (int i = 0; existeNombre(name); i++, name = name + "_" + i) ;

            JButton mybutton = new JButton(name, text, align, posX, posY, width, height, this);
            Vg_ArrayJButton.Add(name);
            if (addToForm)
                Vg_miForm.Controls.Add(mybutton);
            return mybutton;
        }

        //crea un jcheckbox y devuelve la instancia. Si addToForm = true, agrega el control al JForm.
        public JCheckBox newJCheckBox(bool addToForm, string name, string text, bool check, Color backcolor, bool autosize, int posX, int posY, int width, int height)
        {
            for (int i = 0; existeNombre(name); i++, name = name + "_" + i) ;

            JCheckBox mycheck = new JCheckBox(name, text, check, backcolor, autosize, posX, posY, width, height, this);
            Vg_ArrayJCheck.Add(name);
            if (addToForm)
                Vg_miForm.Controls.Add(mycheck);
            return mycheck;
        }

        //crea un jradiobutton y devuelve la instancia. Si addToForm = true, agrega el control al JForm.
        public JRadioButton newJRadioButton(bool addToForm, string name, string text, bool check, Color backcolor, bool autosize, int posX, int posY, int width, int height)
        {
            for (int i = 0; existeNombre(name); i++, name = name + "_" + i) ;

            JRadioButton myradio = new JRadioButton(name, text, check, backcolor, autosize, posX, posY, width, height, this);
            Vg_ArrayJRadio.Add(name);
            if (addToForm)
                Vg_miForm.Controls.Add(myradio);
            return myradio;
        }

        //crea un jbuttongroup y devuelve la instancia. Si addToForm = true, agrega el control al JForm.
        public JButtonGroup newJButtonGroup(bool addToForm, string name, int type, int posX, int posY, int width, int height)
        {
            for (int i = 0; existeNombre(name); i++, name = name + "_" + i) ;

            JButtonGroup mybgroup = new JButtonGroup(name, type, posX, posY, width, height, this);
            Vg_ArrayJBGroup.Add(name);
            if (addToForm)
                Vg_miForm.Controls.Add(mybgroup);
            return mybgroup;
        }

        //crea un jcombobox y devuelve la instancia. Si addToForm = true, agrega el control al JForm.
        public JComboBox newJComboBox(bool addToForm, string name, int posX, int posY, int width, int height)
        {
            for (int i = 0; existeNombre(name); i++, name = name + "_" + i) ;

            JComboBox mycombo = new JComboBox(name, posX, posY, width, height, this);
            Vg_ArrayJCombo.Add(name);
            if (addToForm)
                Vg_miForm.Controls.Add(mycombo);
            return mycombo;
        }

        //crea un jtextarea y devuelve la instancia. Si addToForm = true, agrega el control al JForm.
        public JTextArea newJTextArea(bool addToForm, string name, string text, int posX, int posY, int width, int height)
        {
            for (int i = 0; existeNombre(name); i++, name = name + "_" + i) ;

            JTextArea mytextarea = new JTextArea(name, text, posX, posY, width, height, this);
            Vg_ArrayJTArea.Add(name);
            if (addToForm)
                Vg_miForm.Controls.Add(mytextarea);
            return mytextarea;
        }

        //crea un jpasswordfield y devuelve la instancia. Si addToForm = true, agrega el control al JForm.
        public JPasswordField newJPasswordField(bool addToForm, string name, string text, int posX, int posY, int width, int height)
        {
            for (int i = 0; existeNombre(name); i++, name = name + "_" + i) ;

            JPasswordField mypass = new JPasswordField(name, text, posX, posY, width, height, this);
            Vg_ArrayJPassword.Add(name);
            if (addToForm)
                Vg_miForm.Controls.Add(mypass);
            return mypass;
        }

        //crea un jtree y devuelve la instancia. Si addToForm = true, agrega el control al JForm.
        public JTree newJTree(bool addToForm, string name, int posX, int posY, int width, int height)
        {
            for (int i = 0; existeNombre(name); i++, name = name + "_" + i) ;

            JTree mytree = new JTree(name, posX, posY, width, height, this);
            Vg_ArrayJTree.Add(name);
            if (addToForm)
                Vg_miForm.Controls.Add(mytree);
            return mytree;
        }

        //crea un jtable y devuelve la instancia. Si addToForm = true, agrega el control al JForm.
        public JTable newJTable(bool addToForm, string name, int rows, int columns, int posX, int posY, int width, int height)
        {
            for (int i = 0; existeNombre(name); i++, name = name + "_" + i) ;
            
            JTable mytable = new JTable(name, rows, columns, posX, posY, width, height, this);
            Vg_ArrayJTable.Add(name);
            if (addToForm)
                Vg_miForm.Controls.Add(mytable);
            return mytable;
        }

        //crea un jfilechooser y devuelve la instancia. Si addToForm = true, agrega el control al JForm.
        public JFileChooser newJFileChooser(bool addToForm, string name, int posX, int posY, int width, int height)
        {
            for (int i = 0; existeNombre(name); i++, name = name + "_" + i) ;

            JFileChooser mychooser = new JFileChooser(name, posX, posY, width, height, this);
            Vg_ArrayJFileChooser.Add(name);
            if (addToForm)
                Vg_miForm.Controls.Add(mychooser);
            return mychooser;
        }

        //ESTE METODO NO SE VA A USAR, CREO
        //agrega un control a un contenedor. no puede haber un panel contenido en otro, solo el jform puede tener panels
        //bool panel: dice si el contenedo es un panel o no
        public void agregarControl(string contenedor, string control, bool esPanel)
        {
            JPanel mipanel;
            Control[] tmp;
            //falta: hacer tipo: mi grupo de botones

            tmp = Vg_miForm.Controls.Find(contenedor, true);
            if (tmp.Length > 0)
            {
                if (esPanel)
                {
                    mipanel = (JPanel)tmp[0];
                    tmp = Vg_miForm.Controls.Find(control, true);
                    if (tmp.Length > 0)
                    {
                        mipanel.Controls.Add(tmp[0]);
                    }
                    else
                    {
                        MessageBox.Show("No se encontro el control " + control, "Error");
                    }
                }
                else
                {
                    //falta:
                    //instanciar mi grupo de botones
                    //agregar el control
                }
            }
            else
            {
                MessageBox.Show("No se encontro el contenedor " + contenedor, "Error");
            }
        }
        /*************************************************************************************************************/
/***************************************************** drag&drop ****************************************************/
        //evento itemDrag: tree_toolbox
        private void tree_toolbox_ItemDrag(object sender, ItemDragEventArgs e)
        {
            TreeNode tmp_node = (TreeNode)e.Item;
            tree_toolbox.DoDragDrop("" + tmp_node.Index, DragDropEffects.Copy);
        }

        //evento dragdrop: panel_editor
        private void panel_editor_DragDrop(object sender,DragEventArgs e)
        {
            Panel miEditor = (Panel)sender;
            int indice = int.Parse(e.Data.GetData(DataFormats.Text).ToString());
            switch (indice)
            {
                case 13:
                    //crea jform
                    string nombre = "JForm";
                    newJForm(nombre, nombre, 533, 365);
                    break;
            }
        }

        //evento dragenter: panel_editor
        private void panel_editor_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

/********************************************************************************************************************/
    }
}

        /*private void escritura_lectura_archivobinario(object sender, EventArgs e)
        {
            FileMan f = new FileMan();
            ListaEstructuras.struct_myMutableTreeNode m = new ListaEstructuras.struct_myMutableTreeNode(1, "nombre", null);
            ArrayList l = new ArrayList();
            l.Add(m);
            f.binOpen("c:\\a");
            f.binWrite(l);
            f.binClose();
            IEnumerator i = f.binRead("c:\\a");
            i.MoveNext();
            ArrayList ll = (ArrayList)i.Current;
            IEnumerator ii = ll.GetEnumerator();
            ii.MoveNext();
            ListaEstructuras.struct_myMutableTreeNode mm = (ListaEstructuras.struct_myMutableTreeNode)ii.Current;
            MessageBox.Show(mm.Name + " " + mm.Index);
        }*/