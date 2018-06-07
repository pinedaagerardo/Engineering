namespace WindowsApplication1
{
    partial class GUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("JLabel");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("JButton");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("JCheckBox");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("JRadioButton");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("ButtonGroup");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("JComboBox");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("JTextField");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("JTextArea");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("JPasswordField");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("JTree");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("JTable");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("JPanel");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("JFileChooser");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("JForm");
            this.panel1 = new System.Windows.Forms.Panel();
            this.listView_ExploradorArchivos = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.treeView_Explorador = new System.Windows.Forms.TreeView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tree_toolbox = new System.Windows.Forms.TreeView();
            this.panel_tools = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_aplicar = new System.Windows.Forms.Button();
            this.lbl_no_width = new System.Windows.Forms.Label();
            this.lbl_no_height = new System.Windows.Forms.Label();
            this.lbl_no_top = new System.Windows.Forms.Label();
            this.lbl_no_left = new System.Windows.Forms.Label();
            this.lbl_no_bcolor = new System.Windows.Forms.Label();
            this.lbl_no_fsize = new System.Windows.Forms.Label();
            this.lbl_no_fcolor = new System.Windows.Forms.Label();
            this.lbl_no_name = new System.Windows.Forms.Label();
            this.lbl_no_text = new System.Windows.Forms.Label();
            this.lbl_backcolor = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_backcolor = new System.Windows.Forms.Button();
            this.txt_text = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_size = new System.Windows.Forms.Label();
            this.lbl_forecolor = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_Fsize = new System.Windows.Forms.Button();
            this.btn_color = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_height = new System.Windows.Forms.TextBox();
            this.txt_width = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_top = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_left = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.menu_nuevo = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_abrir = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarProyectoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menu_guardar = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_guardarComo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menu_salir = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_cerrarPestaña = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel_editor = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel_tools.SuspendLayout();
            this.panel3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.listView_ExploradorArchivos);
            this.panel1.Controls.Add(this.treeView_Explorador);
            this.panel1.Location = new System.Drawing.Point(12, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(235, 503);
            this.panel1.TabIndex = 3;
            // 
            // listView_ExploradorArchivos
            // 
            this.listView_ExploradorArchivos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listView_ExploradorArchivos.LargeImageList = this.imageList1;
            this.listView_ExploradorArchivos.Location = new System.Drawing.Point(3, 258);
            this.listView_ExploradorArchivos.Name = "listView_ExploradorArchivos";
            this.listView_ExploradorArchivos.Size = new System.Drawing.Size(229, 242);
            this.listView_ExploradorArchivos.SmallImageList = this.imageList1;
            this.listView_ExploradorArchivos.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.listView_ExploradorArchivos.TabIndex = 1;
            this.listView_ExploradorArchivos.UseCompatibleStateImageBehavior = false;
            this.listView_ExploradorArchivos.SelectedIndexChanged += new System.EventHandler(this.listView_ExploradorArchivos_SelectedIndexChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "CLSDFOLD.ICO");
            this.imageList1.Images.SetKeyName(1, "OPENFOLD.ICO");
            this.imageList1.Images.SetKeyName(2, "file.ico");
            this.imageList1.Images.SetKeyName(3, "Refresh.ico");
            this.imageList1.Images.SetKeyName(4, "Sync.ico");
            this.imageList1.Images.SetKeyName(5, "Error.ico");
            // 
            // treeView_Explorador
            // 
            this.treeView_Explorador.ImageIndex = 0;
            this.treeView_Explorador.ImageList = this.imageList1;
            this.treeView_Explorador.Location = new System.Drawing.Point(3, 36);
            this.treeView_Explorador.Name = "treeView_Explorador";
            this.treeView_Explorador.SelectedImageIndex = 1;
            this.treeView_Explorador.Size = new System.Drawing.Size(229, 216);
            this.treeView_Explorador.TabIndex = 0;
            this.treeView_Explorador.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_Explorador_AfterSelect);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(12, 566);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(966, 128);
            this.textBox1.TabIndex = 5;
            this.textBox1.WordWrap = false;
            // 
            // tree_toolbox
            // 
            this.tree_toolbox.AllowDrop = true;
            this.tree_toolbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tree_toolbox.ItemHeight = 17;
            this.tree_toolbox.Location = new System.Drawing.Point(3, 3);
            this.tree_toolbox.Name = "tree_toolbox";
            treeNode1.Name = "Node0";
            treeNode1.Text = "JLabel";
            treeNode2.Name = "Node1";
            treeNode2.Text = "JButton";
            treeNode3.Name = "Node2";
            treeNode3.Text = "JCheckBox";
            treeNode4.Name = "Node3";
            treeNode4.Text = "JRadioButton";
            treeNode5.Name = "Node4";
            treeNode5.Text = "ButtonGroup";
            treeNode6.Name = "Node5";
            treeNode6.Text = "JComboBox";
            treeNode7.Name = "Node6";
            treeNode7.Text = "JTextField";
            treeNode8.Name = "Node7";
            treeNode8.Text = "JTextArea";
            treeNode9.Name = "Node8";
            treeNode9.Text = "JPasswordField";
            treeNode10.Name = "Node9";
            treeNode10.Text = "JTree";
            treeNode11.Name = "Node10";
            treeNode11.Text = "JTable";
            treeNode12.Name = "Node11";
            treeNode12.Text = "JPanel";
            treeNode13.Name = "Node12";
            treeNode13.Text = "JFileChooser";
            treeNode14.Name = "Node0";
            treeNode14.Text = "JForm";
            this.tree_toolbox.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode14});
            this.tree_toolbox.Size = new System.Drawing.Size(242, 246);
            this.tree_toolbox.TabIndex = 6;
            this.tree_toolbox.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tree_toolbox_ItemDrag);
            // 
            // panel_tools
            // 
            this.panel_tools.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_tools.Controls.Add(this.panel3);
            this.panel_tools.Controls.Add(this.tree_toolbox);
            this.panel_tools.Enabled = false;
            this.panel_tools.Location = new System.Drawing.Point(984, 83);
            this.panel_tools.Name = "panel_tools";
            this.panel_tools.Size = new System.Drawing.Size(248, 611);
            this.panel_tools.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btn_aplicar);
            this.panel3.Controls.Add(this.lbl_no_width);
            this.panel3.Controls.Add(this.lbl_no_height);
            this.panel3.Controls.Add(this.lbl_no_top);
            this.panel3.Controls.Add(this.lbl_no_left);
            this.panel3.Controls.Add(this.lbl_no_bcolor);
            this.panel3.Controls.Add(this.lbl_no_fsize);
            this.panel3.Controls.Add(this.lbl_no_fcolor);
            this.panel3.Controls.Add(this.lbl_no_name);
            this.panel3.Controls.Add(this.lbl_no_text);
            this.panel3.Controls.Add(this.lbl_backcolor);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.btn_backcolor);
            this.panel3.Controls.Add(this.txt_text);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.lbl_size);
            this.panel3.Controls.Add(this.lbl_forecolor);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.btn_Fsize);
            this.panel3.Controls.Add(this.btn_color);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.txt_height);
            this.panel3.Controls.Add(this.txt_width);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txt_nombre);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.txt_top);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.txt_left);
            this.panel3.Location = new System.Drawing.Point(3, 255);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(242, 353);
            this.panel3.TabIndex = 14;
            // 
            // btn_aplicar
            // 
            this.btn_aplicar.Location = new System.Drawing.Point(101, 312);
            this.btn_aplicar.Name = "btn_aplicar";
            this.btn_aplicar.Size = new System.Drawing.Size(55, 24);
            this.btn_aplicar.TabIndex = 49;
            this.btn_aplicar.Text = "Aplicar";
            this.btn_aplicar.UseVisualStyleBackColor = true;
            this.btn_aplicar.Click += new System.EventHandler(this.btn_aplicar_Click);
            // 
            // lbl_no_width
            // 
            this.lbl_no_width.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_no_width.ImageKey = "Error.ico";
            this.lbl_no_width.ImageList = this.imageList1;
            this.lbl_no_width.Location = new System.Drawing.Point(214, 276);
            this.lbl_no_width.Name = "lbl_no_width";
            this.lbl_no_width.Size = new System.Drawing.Size(15, 15);
            this.lbl_no_width.TabIndex = 48;
            this.toolTip1.SetToolTip(this.lbl_no_width, "Propiedad no editable para este control");
            this.lbl_no_width.Visible = false;
            // 
            // lbl_no_height
            // 
            this.lbl_no_height.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_no_height.ImageKey = "Error.ico";
            this.lbl_no_height.ImageList = this.imageList1;
            this.lbl_no_height.Location = new System.Drawing.Point(214, 250);
            this.lbl_no_height.Name = "lbl_no_height";
            this.lbl_no_height.Size = new System.Drawing.Size(15, 15);
            this.lbl_no_height.TabIndex = 47;
            this.toolTip1.SetToolTip(this.lbl_no_height, "Propiedad no editable para este control");
            this.lbl_no_height.Visible = false;
            // 
            // lbl_no_top
            // 
            this.lbl_no_top.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_no_top.ImageKey = "Error.ico";
            this.lbl_no_top.ImageList = this.imageList1;
            this.lbl_no_top.Location = new System.Drawing.Point(214, 207);
            this.lbl_no_top.Name = "lbl_no_top";
            this.lbl_no_top.Size = new System.Drawing.Size(15, 15);
            this.lbl_no_top.TabIndex = 46;
            this.toolTip1.SetToolTip(this.lbl_no_top, "Propiedad no editable para este control");
            this.lbl_no_top.Visible = false;
            // 
            // lbl_no_left
            // 
            this.lbl_no_left.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_no_left.ImageKey = "Error.ico";
            this.lbl_no_left.ImageList = this.imageList1;
            this.lbl_no_left.Location = new System.Drawing.Point(214, 181);
            this.lbl_no_left.Name = "lbl_no_left";
            this.lbl_no_left.Size = new System.Drawing.Size(15, 15);
            this.lbl_no_left.TabIndex = 45;
            this.toolTip1.SetToolTip(this.lbl_no_left, "Propiedad no editable para este control");
            this.lbl_no_left.Visible = false;
            // 
            // lbl_no_bcolor
            // 
            this.lbl_no_bcolor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_no_bcolor.ImageKey = "Error.ico";
            this.lbl_no_bcolor.ImageList = this.imageList1;
            this.lbl_no_bcolor.Location = new System.Drawing.Point(214, 132);
            this.lbl_no_bcolor.Name = "lbl_no_bcolor";
            this.lbl_no_bcolor.Size = new System.Drawing.Size(15, 15);
            this.lbl_no_bcolor.TabIndex = 44;
            this.toolTip1.SetToolTip(this.lbl_no_bcolor, "Propiedad no editable para este control");
            this.lbl_no_bcolor.Visible = false;
            // 
            // lbl_no_fsize
            // 
            this.lbl_no_fsize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_no_fsize.ImageKey = "Error.ico";
            this.lbl_no_fsize.ImageList = this.imageList1;
            this.lbl_no_fsize.Location = new System.Drawing.Point(214, 106);
            this.lbl_no_fsize.Name = "lbl_no_fsize";
            this.lbl_no_fsize.Size = new System.Drawing.Size(15, 15);
            this.lbl_no_fsize.TabIndex = 43;
            this.toolTip1.SetToolTip(this.lbl_no_fsize, "Propiedad no editable para este control");
            this.lbl_no_fsize.Visible = false;
            // 
            // lbl_no_fcolor
            // 
            this.lbl_no_fcolor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_no_fcolor.ImageKey = "Error.ico";
            this.lbl_no_fcolor.ImageList = this.imageList1;
            this.lbl_no_fcolor.Location = new System.Drawing.Point(214, 82);
            this.lbl_no_fcolor.Name = "lbl_no_fcolor";
            this.lbl_no_fcolor.Size = new System.Drawing.Size(15, 15);
            this.lbl_no_fcolor.TabIndex = 42;
            this.toolTip1.SetToolTip(this.lbl_no_fcolor, "Propiedad no editable para este control");
            this.lbl_no_fcolor.Visible = false;
            // 
            // lbl_no_name
            // 
            this.lbl_no_name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_no_name.ImageKey = "Error.ico";
            this.lbl_no_name.ImageList = this.imageList1;
            this.lbl_no_name.Location = new System.Drawing.Point(214, 11);
            this.lbl_no_name.Name = "lbl_no_name";
            this.lbl_no_name.Size = new System.Drawing.Size(15, 15);
            this.lbl_no_name.TabIndex = 41;
            this.toolTip1.SetToolTip(this.lbl_no_name, "Propiedad no editable para este control");
            this.lbl_no_name.Visible = false;
            // 
            // lbl_no_text
            // 
            this.lbl_no_text.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_no_text.ImageKey = "Error.ico";
            this.lbl_no_text.ImageList = this.imageList1;
            this.lbl_no_text.Location = new System.Drawing.Point(214, 37);
            this.lbl_no_text.Name = "lbl_no_text";
            this.lbl_no_text.Size = new System.Drawing.Size(15, 15);
            this.lbl_no_text.TabIndex = 40;
            this.toolTip1.SetToolTip(this.lbl_no_text, "Propiedad no editable para este control");
            this.lbl_no_text.Visible = false;
            // 
            // lbl_backcolor
            // 
            this.lbl_backcolor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_backcolor.Location = new System.Drawing.Point(74, 135);
            this.lbl_backcolor.Name = "lbl_backcolor";
            this.lbl_backcolor.Size = new System.Drawing.Size(101, 20);
            this.lbl_backcolor.TabIndex = 33;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 140);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "Backcolor";
            // 
            // btn_backcolor
            // 
            this.btn_backcolor.AutoSize = true;
            this.btn_backcolor.Location = new System.Drawing.Point(181, 132);
            this.btn_backcolor.Name = "btn_backcolor";
            this.btn_backcolor.Size = new System.Drawing.Size(26, 23);
            this.btn_backcolor.TabIndex = 31;
            this.btn_backcolor.Text = "...";
            this.btn_backcolor.UseVisualStyleBackColor = true;
            this.btn_backcolor.Click += new System.EventHandler(this.btn_backcolor_Click);
            // 
            // txt_text
            // 
            this.txt_text.Location = new System.Drawing.Point(74, 37);
            this.txt_text.Name = "txt_text";
            this.txt_text.Size = new System.Drawing.Size(133, 20);
            this.txt_text.TabIndex = 30;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(40, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "Text";
            // 
            // lbl_size
            // 
            this.lbl_size.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_size.Location = new System.Drawing.Point(74, 109);
            this.lbl_size.Name = "lbl_size";
            this.lbl_size.Size = new System.Drawing.Size(101, 20);
            this.lbl_size.TabIndex = 28;
            // 
            // lbl_forecolor
            // 
            this.lbl_forecolor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_forecolor.Location = new System.Drawing.Point(74, 82);
            this.lbl_forecolor.Name = "lbl_forecolor";
            this.lbl_forecolor.Size = new System.Drawing.Size(101, 20);
            this.lbl_forecolor.TabIndex = 27;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "FontSize";
            // 
            // btn_Fsize
            // 
            this.btn_Fsize.AutoSize = true;
            this.btn_Fsize.Location = new System.Drawing.Point(181, 106);
            this.btn_Fsize.Name = "btn_Fsize";
            this.btn_Fsize.Size = new System.Drawing.Size(26, 23);
            this.btn_Fsize.TabIndex = 24;
            this.btn_Fsize.Text = "...";
            this.btn_Fsize.UseVisualStyleBackColor = true;
            this.btn_Fsize.Click += new System.EventHandler(this.btn_Fsize_Click);
            // 
            // btn_color
            // 
            this.btn_color.AutoSize = true;
            this.btn_color.Location = new System.Drawing.Point(181, 82);
            this.btn_color.Name = "btn_color";
            this.btn_color.Size = new System.Drawing.Size(26, 23);
            this.btn_color.TabIndex = 22;
            this.btn_color.Text = "...";
            this.btn_color.UseVisualStyleBackColor = true;
            this.btn_color.Click += new System.EventHandler(this.btn_color_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "ForeColor";
            // 
            // txt_height
            // 
            this.txt_height.Location = new System.Drawing.Point(74, 250);
            this.txt_height.Name = "txt_height";
            this.txt_height.Size = new System.Drawing.Size(133, 20);
            this.txt_height.TabIndex = 20;
            // 
            // txt_width
            // 
            this.txt_width.Location = new System.Drawing.Point(74, 276);
            this.txt_width.Name = "txt_width";
            this.txt_width.Size = new System.Drawing.Size(133, 20);
            this.txt_width.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 253);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Height";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 279);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Width";
            // 
            // txt_nombre
            // 
            this.txt_nombre.Location = new System.Drawing.Point(74, 11);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(133, 20);
            this.txt_nombre.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Left";
            // 
            // txt_top
            // 
            this.txt_top.Location = new System.Drawing.Point(74, 207);
            this.txt_top.Name = "txt_top";
            this.txt_top.Size = new System.Drawing.Size(133, 20);
            this.txt_top.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Top";
            // 
            // txt_left
            // 
            this.txt_left.Location = new System.Drawing.Point(74, 181);
            this.txt_left.Name = "txt_left";
            this.txt_left.Size = new System.Drawing.Size(133, 20);
            this.txt_left.TabIndex = 11;
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "Seleccione la carpeta del proyecto por abrir";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1244, 25);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_nuevo,
            this.menu_abrir,
            this.cerrarProyectoToolStripMenuItem,
            this.toolStripSeparator1,
            this.menu_guardar,
            this.menu_guardarComo,
            this.toolStripSeparator2,
            this.menu_salir});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(56, 22);
            this.toolStripSplitButton1.Text = "Archivo";
            this.toolStripSplitButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            // 
            // menu_nuevo
            // 
            this.menu_nuevo.Name = "menu_nuevo";
            this.menu_nuevo.Size = new System.Drawing.Size(200, 22);
            this.menu_nuevo.Text = "Nuevo Proyecto";
            this.menu_nuevo.Click += new System.EventHandler(this.menu_nuevo_Click);
            // 
            // menu_abrir
            // 
            this.menu_abrir.Name = "menu_abrir";
            this.menu_abrir.Size = new System.Drawing.Size(200, 22);
            this.menu_abrir.Text = "Abrir Proyecto";
            this.menu_abrir.Click += new System.EventHandler(this.menu_abrir_Click);
            // 
            // cerrarProyectoToolStripMenuItem
            // 
            this.cerrarProyectoToolStripMenuItem.Name = "cerrarProyectoToolStripMenuItem";
            this.cerrarProyectoToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.cerrarProyectoToolStripMenuItem.Text = "Cerrar Proyecto";
            this.cerrarProyectoToolStripMenuItem.Click += new System.EventHandler(this.cerrarProyectoToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(197, 6);
            // 
            // menu_guardar
            // 
            this.menu_guardar.Name = "menu_guardar";
            this.menu_guardar.Size = new System.Drawing.Size(200, 22);
            this.menu_guardar.Text = "Guardar Proyecto";
            this.menu_guardar.Click += new System.EventHandler(this.menu_guardar_Click);
            // 
            // menu_guardarComo
            // 
            this.menu_guardarComo.Name = "menu_guardarComo";
            this.menu_guardarComo.Size = new System.Drawing.Size(200, 22);
            this.menu_guardarComo.Text = "Guardar Proyecto Como";
            this.menu_guardarComo.Click += new System.EventHandler(this.menu_guardarComo_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(197, 6);
            // 
            // menu_salir
            // 
            this.menu_salir.Name = "menu_salir";
            this.menu_salir.Size = new System.Drawing.Size(200, 22);
            this.menu_salir.Text = "Salir";
            this.menu_salir.Click += new System.EventHandler(this.menu_salir_Click);
            // 
            // btn_cerrarPestaña
            // 
            this.btn_cerrarPestaña.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cerrarPestaña.AutoSize = true;
            this.btn_cerrarPestaña.Location = new System.Drawing.Point(952, 57);
            this.btn_cerrarPestaña.Name = "btn_cerrarPestaña";
            this.btn_cerrarPestaña.Size = new System.Drawing.Size(22, 23);
            this.btn_cerrarPestaña.TabIndex = 11;
            this.btn_cerrarPestaña.Text = "x";
            this.btn_cerrarPestaña.UseVisualStyleBackColor = true;
            this.btn_cerrarPestaña.Click += new System.EventHandler(this.btn_cerrarPestaña_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel_editor);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(717, 448);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Tag = "";
            this.tabPage1.Text = "Diseño";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel_editor
            // 
            this.panel_editor.AllowDrop = true;
            this.panel_editor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_editor.AutoScroll = true;
            this.panel_editor.BackColor = System.Drawing.Color.Transparent;
            this.panel_editor.Location = new System.Drawing.Point(6, 6);
            this.panel_editor.Name = "panel_editor";
            this.panel_editor.Size = new System.Drawing.Size(705, 436);
            this.panel_editor.TabIndex = 0;
            this.panel_editor.DragDrop += new System.Windows.Forms.DragEventHandler(this.panel_editor_DragDrop);
            this.panel_editor.DragEnter += new System.Windows.Forms.DragEventHandler(this.panel_editor_DragEnter);
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(253, 86);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(725, 474);
            this.tabControl1.TabIndex = 9;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.richTextBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(717, 448);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Código";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(6, 6);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(705, 436);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.WordWrap = false;
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Aviso";
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 706);
            this.Controls.Add(this.btn_cerrarPestaña);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel_tools);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GUI";
            this.Text = "Traductor Java-Web";
            this.panel1.ResumeLayout(false);
            this.panel_tools.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView listView_ExploradorArchivos;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TreeView tree_toolbox;
        private System.Windows.Forms.Panel panel_tools;
        private System.Windows.Forms.TreeView treeView_Explorador;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Panel panel_editor;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem menu_nuevo;
        private System.Windows.Forms.ToolStripMenuItem menu_abrir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menu_guardar;
        private System.Windows.Forms.ToolStripMenuItem menu_guardarComo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem menu_salir;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btn_color;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_Fsize;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_left;
        private System.Windows.Forms.TextBox txt_top;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.TextBox txt_height;
        private System.Windows.Forms.TextBox txt_width;
        private System.Windows.Forms.Label lbl_size;
        private System.Windows.Forms.Label lbl_forecolor;
        private System.Windows.Forms.TextBox txt_text;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_backcolor;
        private System.Windows.Forms.Label lbl_backcolor;
        public System.Windows.Forms.Label lbl_no_width;
        public System.Windows.Forms.Label lbl_no_height;
        public System.Windows.Forms.Label lbl_no_top;
        public System.Windows.Forms.Label lbl_no_left;
        public System.Windows.Forms.Label lbl_no_bcolor;
        public System.Windows.Forms.Label lbl_no_fsize;
        public System.Windows.Forms.Label lbl_no_fcolor;
        public System.Windows.Forms.Label lbl_no_name;
        public System.Windows.Forms.Label lbl_no_text;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.Button btn_cerrarPestaña;
        private System.Windows.Forms.Button btn_aplicar;
        private System.Windows.Forms.ToolStripMenuItem cerrarProyectoToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox richTextBox1;


    }
}

