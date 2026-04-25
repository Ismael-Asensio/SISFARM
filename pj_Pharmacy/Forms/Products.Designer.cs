namespace pj_Pharmacy.Forms
{
    partial class Products
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Products));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.flpInput = new System.Windows.Forms.FlowLayoutPanel();
            this.C_Receta = new System.Windows.Forms.CheckBox();
            this.C_Estado = new System.Windows.Forms.CheckBox();
            this.C_Inactivos = new System.Windows.Forms.CheckBox();
            this.C_Activos = new System.Windows.Forms.CheckBox();
            this.pHomeBar = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCod = new pj_Pharmacy.MrControlers.MrTextBox();
            this.txtName = new pj_Pharmacy.MrControlers.MrTextBox();
            this.txtDesc = new pj_Pharmacy.MrControlers.MrTextBox();
            this.txtCantidad = new pj_Pharmacy.MrControlers.MrTextBox();
            this.txtPrice = new pj_Pharmacy.MrControlers.MrTextBox();
            this.txtFecE = new pj_Pharmacy.MrControlers.MrTextBox();
            this.cboSupplier = new pj_Pharmacy.MrControlers.MrComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.flpInput.SuspendLayout();
            this.pHomeBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.panel1.Controls.Add(this.btnInsertar);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.dgvProducts);
            this.panel1.Controls.Add(this.flpInput);
            this.panel1.Controls.Add(this.pHomeBar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(892, 549);
            this.panel1.TabIndex = 1;
            // 
            // btnInsertar
            // 
            this.btnInsertar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnInsertar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnInsertar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInsertar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(171)))), ((int)(((byte)(199)))));
            this.btnInsertar.FlatAppearance.BorderSize = 2;
            this.btnInsertar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            this.btnInsertar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(171)))), ((int)(((byte)(199)))));
            this.btnInsertar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsertar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsertar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnInsertar.Image = ((System.Drawing.Image)(resources.GetObject("btnInsertar.Image")));
            this.btnInsertar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInsertar.Location = new System.Drawing.Point(94, 483);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(188, 41);
            this.btnInsertar.TabIndex = 32;
            this.btnInsertar.Text = "INSERTAR";
            this.btnInsertar.UseVisualStyleBackColor = true;
            this.btnInsertar.Click += new System.EventHandler(this.btnInsertar_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(171)))), ((int)(((byte)(199)))));
            this.btnDelete.FlatAppearance.BorderSize = 2;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(171)))), ((int)(((byte)(199)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(608, 483);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(188, 41);
            this.btnDelete.TabIndex = 31;
            this.btnDelete.Text = "ELIMINAR";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(171)))), ((int)(((byte)(199)))));
            this.btnEdit.FlatAppearance.BorderSize = 2;
            this.btnEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            this.btnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(171)))), ((int)(((byte)(199)))));
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(351, 483);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(188, 41);
            this.btnEdit.TabIndex = 30;
            this.btnEdit.Text = "EDITAR";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // dgvProducts
            // 
            this.dgvProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProducts.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(101)))), ((int)(((byte)(117)))));
            this.dgvProducts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProducts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(101)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.EnableHeadersVisualStyles = false;
            this.dgvProducts.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvProducts.Location = new System.Drawing.Point(37, 171);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(101)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProducts.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(101)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvProducts.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvProducts.Size = new System.Drawing.Size(821, 279);
            this.dgvProducts.TabIndex = 14;
            this.dgvProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellClick);
            // 
            // flpInput
            // 
            this.flpInput.Controls.Add(this.txtCod);
            this.flpInput.Controls.Add(this.txtName);
            this.flpInput.Controls.Add(this.txtDesc);
            this.flpInput.Controls.Add(this.txtCantidad);
            this.flpInput.Controls.Add(this.txtPrice);
            this.flpInput.Controls.Add(this.txtFecE);
            this.flpInput.Controls.Add(this.cboSupplier);
            this.flpInput.Controls.Add(this.C_Receta);
            this.flpInput.Controls.Add(this.C_Estado);
            this.flpInput.Controls.Add(this.C_Inactivos);
            this.flpInput.Controls.Add(this.C_Activos);
            this.flpInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpInput.Location = new System.Drawing.Point(0, 67);
            this.flpInput.Name = "flpInput";
            this.flpInput.Padding = new System.Windows.Forms.Padding(7);
            this.flpInput.Size = new System.Drawing.Size(892, 98);
            this.flpInput.TabIndex = 10;
            // 
            // C_Receta
            // 
            this.C_Receta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.C_Receta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.C_Receta.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            this.C_Receta.FlatAppearance.BorderSize = 2;
            this.C_Receta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.C_Receta.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.C_Receta.Location = new System.Drawing.Point(411, 53);
            this.C_Receta.Name = "C_Receta";
            this.C_Receta.Size = new System.Drawing.Size(68, 34);
            this.C_Receta.TabIndex = 4;
            this.C_Receta.Text = "RECETA";
            this.C_Receta.UseVisualStyleBackColor = true;
            // 
            // C_Estado
            // 
            this.C_Estado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.C_Estado.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.C_Estado.FlatAppearance.BorderSize = 2;
            this.C_Estado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.C_Estado.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.C_Estado.Location = new System.Drawing.Point(485, 53);
            this.C_Estado.Name = "C_Estado";
            this.C_Estado.Size = new System.Drawing.Size(71, 34);
            this.C_Estado.TabIndex = 5;
            this.C_Estado.Text = "ESTADO";
            this.C_Estado.UseVisualStyleBackColor = true;
            // 
            // C_Inactivos
            // 
            this.C_Inactivos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.C_Inactivos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.C_Inactivos.FlatAppearance.BorderSize = 2;
            this.C_Inactivos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.C_Inactivos.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.C_Inactivos.Location = new System.Drawing.Point(562, 53);
            this.C_Inactivos.Name = "C_Inactivos";
            this.C_Inactivos.Size = new System.Drawing.Size(85, 34);
            this.C_Inactivos.TabIndex = 17;
            this.C_Inactivos.Text = "INACTIVOS";
            this.C_Inactivos.UseVisualStyleBackColor = true;
            this.C_Inactivos.CheckedChanged += new System.EventHandler(this.C_Inactivos_CheckedChanged);
            // 
            // C_Activos
            // 
            this.C_Activos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.C_Activos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.C_Activos.FlatAppearance.BorderSize = 2;
            this.C_Activos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.C_Activos.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.C_Activos.Location = new System.Drawing.Point(653, 53);
            this.C_Activos.Name = "C_Activos";
            this.C_Activos.Size = new System.Drawing.Size(71, 34);
            this.C_Activos.TabIndex = 18;
            this.C_Activos.Text = "ACTIVOS";
            this.C_Activos.UseVisualStyleBackColor = true;
            this.C_Activos.CheckedChanged += new System.EventHandler(this.C_Activos_CheckedChanged);
            // 
            // pHomeBar
            // 
            this.pHomeBar.Controls.Add(this.label1);
            this.pHomeBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pHomeBar.Location = new System.Drawing.Point(0, 0);
            this.pHomeBar.Name = "pHomeBar";
            this.pHomeBar.Size = new System.Drawing.Size(892, 67);
            this.pHomeBar.TabIndex = 9;
            this.pHomeBar.Tag = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Control de Productos";
            // 
            // txtCod
            // 
            this.txtCod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.txtCod.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(171)))), ((int)(((byte)(199)))));
            this.txtCod.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            this.txtCod.BorderRadius = 15;
            this.txtCod.BorderSize = 2;
            this.txtCod.Enabled = false;
            this.txtCod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCod.ForeColor = System.Drawing.Color.White;
            this.txtCod.Location = new System.Drawing.Point(11, 11);
            this.txtCod.Margin = new System.Windows.Forms.Padding(4);
            this.txtCod.MaxLength = 32767;
            this.txtCod.Multiline = false;
            this.txtCod.Name = "txtCod";
            this.txtCod.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtCod.PasswordChar = false;
            this.txtCod.PlaceholderColor = System.Drawing.Color.White;
            this.txtCod.PlaceholderText = "COD";
            this.txtCod.Size = new System.Drawing.Size(101, 35);
            this.txtCod.TabIndex = 20;
            this.txtCod.Texts = "";
            this.txtCod.UnderlinedStyle = false;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.txtName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(171)))), ((int)(((byte)(199)))));
            this.txtName.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            this.txtName.BorderRadius = 15;
            this.txtName.BorderSize = 2;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.ForeColor = System.Drawing.Color.White;
            this.txtName.Location = new System.Drawing.Point(120, 11);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.MaxLength = 32767;
            this.txtName.Multiline = false;
            this.txtName.Name = "txtName";
            this.txtName.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtName.PasswordChar = false;
            this.txtName.PlaceholderColor = System.Drawing.Color.White;
            this.txtName.PlaceholderText = "NOMBRE";
            this.txtName.Size = new System.Drawing.Size(198, 35);
            this.txtName.TabIndex = 0;
            this.txtName.Texts = "";
            this.txtName.UnderlinedStyle = false;
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Letter_KeyPress);
            // 
            // txtDesc
            // 
            this.txtDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.txtDesc.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(171)))), ((int)(((byte)(199)))));
            this.txtDesc.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            this.txtDesc.BorderRadius = 15;
            this.txtDesc.BorderSize = 2;
            this.txtDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc.ForeColor = System.Drawing.Color.White;
            this.txtDesc.Location = new System.Drawing.Point(326, 11);
            this.txtDesc.Margin = new System.Windows.Forms.Padding(4);
            this.txtDesc.MaxLength = 32767;
            this.txtDesc.Multiline = false;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtDesc.PasswordChar = false;
            this.txtDesc.PlaceholderColor = System.Drawing.Color.White;
            this.txtDesc.PlaceholderText = "DESCRIPCIÓN";
            this.txtDesc.Size = new System.Drawing.Size(177, 35);
            this.txtDesc.TabIndex = 1;
            this.txtDesc.Texts = "";
            this.txtDesc.UnderlinedStyle = false;
            this.txtDesc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Letter_KeyPress);
            // 
            // txtCantidad
            // 
            this.txtCantidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.txtCantidad.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(171)))), ((int)(((byte)(199)))));
            this.txtCantidad.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            this.txtCantidad.BorderRadius = 15;
            this.txtCantidad.BorderSize = 2;
            this.txtCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.ForeColor = System.Drawing.Color.White;
            this.txtCantidad.Location = new System.Drawing.Point(511, 11);
            this.txtCantidad.Margin = new System.Windows.Forms.Padding(4);
            this.txtCantidad.MaxLength = 32767;
            this.txtCantidad.Multiline = false;
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtCantidad.PasswordChar = false;
            this.txtCantidad.PlaceholderColor = System.Drawing.Color.White;
            this.txtCantidad.PlaceholderText = "CANTIDAD";
            this.txtCantidad.Size = new System.Drawing.Size(111, 35);
            this.txtCantidad.TabIndex = 2;
            this.txtCantidad.Texts = "";
            this.txtCantidad.UnderlinedStyle = false;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Digit_KeyPress);
            // 
            // txtPrice
            // 
            this.txtPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.txtPrice.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(171)))), ((int)(((byte)(199)))));
            this.txtPrice.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            this.txtPrice.BorderRadius = 15;
            this.txtPrice.BorderSize = 2;
            this.txtPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.ForeColor = System.Drawing.Color.White;
            this.txtPrice.Location = new System.Drawing.Point(630, 11);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(4);
            this.txtPrice.MaxLength = 32767;
            this.txtPrice.Multiline = false;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtPrice.PasswordChar = false;
            this.txtPrice.PlaceholderColor = System.Drawing.Color.White;
            this.txtPrice.PlaceholderText = "PRECIO";
            this.txtPrice.Size = new System.Drawing.Size(111, 35);
            this.txtPrice.TabIndex = 3;
            this.txtPrice.Texts = "";
            this.txtPrice.UnderlinedStyle = false;
            // 
            // txtFecE
            // 
            this.txtFecE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.txtFecE.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(171)))), ((int)(((byte)(199)))));
            this.txtFecE.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            this.txtFecE.BorderRadius = 15;
            this.txtFecE.BorderSize = 2;
            this.txtFecE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecE.ForeColor = System.Drawing.Color.White;
            this.txtFecE.Location = new System.Drawing.Point(11, 54);
            this.txtFecE.Margin = new System.Windows.Forms.Padding(4);
            this.txtFecE.MaxLength = 32767;
            this.txtFecE.Multiline = false;
            this.txtFecE.Name = "txtFecE";
            this.txtFecE.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtFecE.PasswordChar = false;
            this.txtFecE.PlaceholderColor = System.Drawing.Color.White;
            this.txtFecE.PlaceholderText = "FECHA ELAB.";
            this.txtFecE.Size = new System.Drawing.Size(177, 35);
            this.txtFecE.TabIndex = 19;
            this.txtFecE.Texts = "";
            this.txtFecE.UnderlinedStyle = false;
            // 
            // cboSupplier
            // 
            this.cboSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSupplier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.cboSupplier.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(171)))), ((int)(((byte)(199)))));
            this.cboSupplier.BorderSize = 2;
            this.cboSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cboSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSupplier.ForeColor = System.Drawing.Color.White;
            this.cboSupplier.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            this.cboSupplier.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            this.cboSupplier.ListTextColor = System.Drawing.Color.White;
            this.cboSupplier.Location = new System.Drawing.Point(195, 53);
            this.cboSupplier.MinimumSize = new System.Drawing.Size(200, 30);
            this.cboSupplier.Name = "cboSupplier";
            this.cboSupplier.Padding = new System.Windows.Forms.Padding(2);
            this.cboSupplier.SelectedValue = null;
            this.cboSupplier.Size = new System.Drawing.Size(210, 37);
            this.cboSupplier.TabIndex = 6;
            this.cboSupplier.Texts = "PROVEEDOR";
            // 
            // Products
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 549);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Products";
            this.Text = "Products";
            this.Load += new System.EventHandler(this.Products_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.flpInput.ResumeLayout(false);
            this.pHomeBar.ResumeLayout(false);
            this.pHomeBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flpInput;
        private MrControlers.MrTextBox txtName;
        private MrControlers.MrTextBox txtDesc;
        private MrControlers.MrTextBox txtCantidad;
        private MrControlers.MrTextBox txtPrice;
        private MrControlers.MrComboBox cboSupplier;
        private System.Windows.Forms.CheckBox C_Receta;
        private System.Windows.Forms.CheckBox C_Estado;
        private System.Windows.Forms.Panel pHomeBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.CheckBox C_Inactivos;
        private System.Windows.Forms.CheckBox C_Activos;
        private MrControlers.MrTextBox txtFecE;
        private MrControlers.MrTextBox txtCod;
    }
}