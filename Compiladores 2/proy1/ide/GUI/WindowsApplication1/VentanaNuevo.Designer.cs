namespace WindowsApplication1
{
    partial class VentanaNuevo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentanaNuevo));
            this.txt_nombreProyecto = new System.Windows.Forms.TextBox();
            this.lbl_nombreProyecto = new System.Windows.Forms.Label();
            this.lbl_nombreClase = new System.Windows.Forms.Label();
            this.txt_nombreClase = new System.Windows.Forms.TextBox();
            this.lbl_ubicacionProyecto = new System.Windows.Forms.Label();
            this.txt_ubicacionProyecto = new System.Windows.Forms.TextBox();
            this.btn_buscarCarpeta = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btn_aceptar = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.txt_nombrePaquete = new System.Windows.Forms.TextBox();
            this.lbl_nombrePaquete = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_nombreProyecto
            // 
            this.txt_nombreProyecto.Location = new System.Drawing.Point(206, 62);
            this.txt_nombreProyecto.Name = "txt_nombreProyecto";
            this.txt_nombreProyecto.Size = new System.Drawing.Size(255, 20);
            this.txt_nombreProyecto.TabIndex = 0;
            // 
            // lbl_nombreProyecto
            // 
            this.lbl_nombreProyecto.AutoSize = true;
            this.lbl_nombreProyecto.Location = new System.Drawing.Point(203, 29);
            this.lbl_nombreProyecto.Name = "lbl_nombreProyecto";
            this.lbl_nombreProyecto.Size = new System.Drawing.Size(108, 13);
            this.lbl_nombreProyecto.TabIndex = 1;
            this.lbl_nombreProyecto.Text = "Nombre del proyecto:";
            // 
            // lbl_nombreClase
            // 
            this.lbl_nombreClase.AutoSize = true;
            this.lbl_nombreClase.Location = new System.Drawing.Point(203, 125);
            this.lbl_nombreClase.Name = "lbl_nombreClase";
            this.lbl_nombreClase.Size = new System.Drawing.Size(101, 13);
            this.lbl_nombreClase.TabIndex = 2;
            this.lbl_nombreClase.Text = "Nombre de la clase:";
            // 
            // txt_nombreClase
            // 
            this.txt_nombreClase.Location = new System.Drawing.Point(206, 156);
            this.txt_nombreClase.Name = "txt_nombreClase";
            this.txt_nombreClase.Size = new System.Drawing.Size(255, 20);
            this.txt_nombreClase.TabIndex = 3;
            // 
            // lbl_ubicacionProyecto
            // 
            this.lbl_ubicacionProyecto.AutoSize = true;
            this.lbl_ubicacionProyecto.Location = new System.Drawing.Point(203, 299);
            this.lbl_ubicacionProyecto.Name = "lbl_ubicacionProyecto";
            this.lbl_ubicacionProyecto.Size = new System.Drawing.Size(116, 13);
            this.lbl_ubicacionProyecto.TabIndex = 4;
            this.lbl_ubicacionProyecto.Text = "Ubicación del proyecto";
            // 
            // txt_ubicacionProyecto
            // 
            this.txt_ubicacionProyecto.Location = new System.Drawing.Point(206, 332);
            this.txt_ubicacionProyecto.Name = "txt_ubicacionProyecto";
            this.txt_ubicacionProyecto.ReadOnly = true;
            this.txt_ubicacionProyecto.Size = new System.Drawing.Size(255, 20);
            this.txt_ubicacionProyecto.TabIndex = 9;
            // 
            // btn_buscarCarpeta
            // 
            this.btn_buscarCarpeta.AutoSize = true;
            this.btn_buscarCarpeta.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_buscarCarpeta.ImageIndex = 1;
            this.btn_buscarCarpeta.ImageList = this.imageList1;
            this.btn_buscarCarpeta.Location = new System.Drawing.Point(467, 330);
            this.btn_buscarCarpeta.Name = "btn_buscarCarpeta";
            this.btn_buscarCarpeta.Size = new System.Drawing.Size(22, 22);
            this.btn_buscarCarpeta.TabIndex = 6;
            this.btn_buscarCarpeta.UseVisualStyleBackColor = true;
            this.btn_buscarCarpeta.Click += new System.EventHandler(this.btn_buscarCarpeta_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Find.ico");
            this.imageList1.Images.SetKeyName(1, "Documents2.ico");
            // 
            // btn_aceptar
            // 
            this.btn_aceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_aceptar.Location = new System.Drawing.Point(538, 404);
            this.btn_aceptar.Name = "btn_aceptar";
            this.btn_aceptar.Size = new System.Drawing.Size(75, 23);
            this.btn_aceptar.TabIndex = 7;
            this.btn_aceptar.Text = "Aceptar";
            this.btn_aceptar.UseVisualStyleBackColor = true;
            this.btn_aceptar.Click += new System.EventHandler(this.btn_aceptar_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancelar.Location = new System.Drawing.Point(457, 404);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(75, 23);
            this.btn_cancelar.TabIndex = 8;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // txt_nombrePaquete
            // 
            this.txt_nombrePaquete.Location = new System.Drawing.Point(206, 245);
            this.txt_nombrePaquete.Name = "txt_nombrePaquete";
            this.txt_nombrePaquete.Size = new System.Drawing.Size(255, 20);
            this.txt_nombrePaquete.TabIndex = 5;
            // 
            // lbl_nombrePaquete
            // 
            this.lbl_nombrePaquete.AutoSize = true;
            this.lbl_nombrePaquete.Location = new System.Drawing.Point(203, 219);
            this.lbl_nombrePaquete.Name = "lbl_nombrePaquete";
            this.lbl_nombrePaquete.Size = new System.Drawing.Size(106, 13);
            this.lbl_nombrePaquete.TabIndex = 10;
            this.lbl_nombrePaquete.Text = "Nombre del paquete:";
            // 
            // VentanaNuevo
            // 
            this.AcceptButton = this.btn_aceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_cancelar;
            this.ClientSize = new System.Drawing.Size(639, 452);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_nombrePaquete);
            this.Controls.Add(this.txt_nombrePaquete);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btn_aceptar);
            this.Controls.Add(this.btn_buscarCarpeta);
            this.Controls.Add(this.txt_ubicacionProyecto);
            this.Controls.Add(this.lbl_ubicacionProyecto);
            this.Controls.Add(this.txt_nombreClase);
            this.Controls.Add(this.lbl_nombreClase);
            this.Controls.Add(this.lbl_nombreProyecto);
            this.Controls.Add(this.txt_nombreProyecto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "VentanaNuevo";
            this.Text = "Asistente";
            this.Load += new System.EventHandler(this.VentanaNuevo_Load);
            this.Disposed += new System.EventHandler(this.VentanaNuevo_Disposed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_nombreProyecto;
        private System.Windows.Forms.Label lbl_nombreProyecto;
        private System.Windows.Forms.Label lbl_nombreClase;
        private System.Windows.Forms.TextBox txt_nombreClase;
        private System.Windows.Forms.Label lbl_ubicacionProyecto;
        private System.Windows.Forms.TextBox txt_ubicacionProyecto;
        private System.Windows.Forms.Button btn_buscarCarpeta;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btn_aceptar;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.TextBox txt_nombrePaquete;
        private System.Windows.Forms.Label lbl_nombrePaquete;
    }
}