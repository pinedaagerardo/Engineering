using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public partial class VentanaNuevo : Form
    {
        GUI Inst_padre; //instancia del padre de esta clase. se usa para enviarle datos llamando a un metodo

        public VentanaNuevo()
        {
            InitializeComponent();
        }

        public VentanaNuevo(GUI mygui)
        {
            InitializeComponent();
            Inst_padre = mygui;
        }

        private void btn_buscarCarpeta_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                txt_ubicacionProyecto.Text = folderBrowserDialog1.SelectedPath;
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            /**************** verificando campos en blanco ********************/
            if (txt_nombreClase.Text.Length * txt_nombreProyecto.Text.Length * txt_ubicacionProyecto.Text.Length * txt_nombrePaquete.Text.Length == 0)
            {
                MessageBox.Show("Se debe llenar todos los campos");
                return;
            }
            /*******************************************************************/
            /*********** verificando nombre de archivos y carpetas *************/
            if (txt_nombreClase.Text.Contains(".") || txt_nombreClase.Text.Contains("\\") || txt_nombreClase.Text.Contains("/") || txt_nombreClase.Text.Contains(":") || txt_nombreClase.Text.Contains("*") || txt_nombreClase.Text.Contains("?") || txt_nombreClase.Text.Contains("\"") || txt_nombreClase.Text.Contains("<") || txt_nombreClase.Text.Contains(">") || txt_nombreClase.Text.Contains("|"))
            {
                MessageBox.Show("El nombre de la clase no puede tener ninguno de estos caracteres .\\/:*?\"<>|");
                return;
            }

            if (txt_nombreProyecto.Text.Contains("\\") || txt_nombreProyecto.Text.Contains("/") || txt_nombreProyecto.Text.Contains(":") || txt_nombreProyecto.Text.Contains("*") || txt_nombreProyecto.Text.Contains("?") || txt_nombreProyecto.Text.Contains("\"") || txt_nombreProyecto.Text.Contains("<") || txt_nombreProyecto.Text.Contains(">") || txt_nombreProyecto.Text.Contains("|"))
            {
                MessageBox.Show("El nombre del proyecto no puede tener ninguno de estos caracteres \\/:*?\"<>|");
                return;
            }

            if (txt_nombrePaquete.Text.Contains("\\") || txt_nombrePaquete.Text.Contains("/") || txt_nombrePaquete.Text.Contains(":") || txt_nombrePaquete.Text.Contains("*") || txt_nombrePaquete.Text.Contains("?") || txt_nombrePaquete.Text.Contains("\"") || txt_nombrePaquete.Text.Contains("<") || txt_nombrePaquete.Text.Contains(">") || txt_nombrePaquete.Text.Contains("|"))
            {
                MessageBox.Show("El nombre del paquete no puede tener ninguno de estos caracteres \\/:*?\"<>|");
                return;
            }
            /*******************************************************************/

            // todos los campos estan bien, continuar
            Inst_padre.crearNuevoProyecto(txt_ubicacionProyecto.Text, txt_nombreProyecto.Text, txt_nombrePaquete.Text, txt_nombreClase.Text);
            this.Dispose(true);
        }

        //se ejecuta al cargar la ventana. evento
        private void VentanaNuevo_Load(object sender, EventArgs e)
        {
            Inst_padre.Enabled = false;
        }

        //se ejecuta al cerrar la ventana. evento
        private void VentanaNuevo_Disposed(object sender, EventArgs e)
        {
            Inst_padre.Enabled = true;
            Inst_padre.Select();
        }
    }
}