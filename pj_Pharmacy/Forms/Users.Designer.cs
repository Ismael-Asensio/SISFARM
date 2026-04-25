namespace pj_Pharmacy.Forms
{
    partial class Users
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Users));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flpInput = new System.Windows.Forms.FlowLayoutPanel();
            this.C_Estado = new System.Windows.Forms.CheckBox();
            this.C_Inactivos = new System.Windows.Forms.CheckBox();
            this.C_Activos = new System.Windows.Forms.CheckBox();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.dgvUser = new System.Windows.Forms.DataGridView();
            this.pHomeBar = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDNI = new pj_Pharmacy.MrControlers.MrTextBox();
            this.txtFN = new pj_Pharmacy.MrControlers.MrTextBox();
            this.txtSN = new pj_Pharmacy.MrControlers.MrTextBox();
            this.txtFA = new pj_Pharmacy.MrControlers.MrTextBox();
            this.txtSA = new pj_Pharmacy.MrControlers.MrTextBox();
            this.txtTel = new pj_Pharmacy.MrControlers.MrTextBox();
            this.txtCargo = new pj_Pharmacy.MrControlers.MrTextBox();
            this.txtSuc = new pj_Pharmacy.MrControlers.MrTextBox();
            this.cboCity = new pj_Pharmacy.MrControlers.MrComboBox();
            this.panel1.SuspendLayout();
            this.flpInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
            this.pHomeBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.panel1.Controls.Add(this.flpInput);
            this.panel1.Controls.Add(this.btnInsertar);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.dgvUser);
            this.panel1.Controls.Add(this.pHomeBar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(892, 549);
            this.panel1.TabIndex = 2;
            // 
            // flpInput
            // 
            this.flpInput.Controls.Add(this.txtDNI);
            this.flpInput.Controls.Add(this.txtFN);
            this.flpInput.Controls.Add(this.txtSN);
            this.flpInput.Controls.Add(this.txtFA);
            this.flpInput.Controls.Add(this.txtSA);
            this.flpInput.Controls.Add(this.txtTel);
            this.flpInput.Controls.Add(this.txtCargo);
            this.flpInput.Controls.Add(this.txtSuc);
            this.flpInput.Controls.Add(this.cboCity);
            this.flpInput.Controls.Add(this.C_Estado);
            this.flpInput.Controls.Add(this.C_Inactivos);
            this.flpInput.Controls.Add(this.C_Activos);
            this.flpInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpInput.Location = new System.Drawing.Point(0, 67);
            this.flpInput.Name = "flpInput";
            this.flpInput.Padding = new System.Windows.Forms.Padding(7);
            this.flpInput.Size = new System.Drawing.Size(892, 136);
            this.flpInput.TabIndex = 37;
            // 
            // C_Estado
            // 
            this.C_Estado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.C_Estado.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.C_Estado.FlatAppearance.BorderSize = 2;
            this.C_Estado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.C_Estado.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.C_Estado.Location = new System.Drawing.Point(226, 96);
            this.C_Estado.Name = "C_Estado";
            this.C_Estado.Size = new System.Drawing.Size(68, 34);
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
            this.C_Inactivos.Location = new System.Drawing.Point(300, 96);
            this.C_Inactivos.Name = "C_Inactivos";
            this.C_Inactivos.Size = new System.Drawing.Size(85, 34);
            this.C_Inactivos.TabIndex = 15;
            this.C_Inactivos.Text = "INACTIVOS";
            this.C_Inactivos.UseVisualStyleBackColor = true;
            // 
            // C_Activos
            // 
            this.C_Activos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.C_Activos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.C_Activos.FlatAppearance.BorderSize = 2;
            this.C_Activos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.C_Activos.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.C_Activos.Location = new System.Drawing.Point(391, 96);
            this.C_Activos.Name = "C_Activos";
            this.C_Activos.Size = new System.Drawing.Size(71, 34);
            this.C_Activos.TabIndex = 16;
            this.C_Activos.Text = "ACTIVOS";
            this.C_Activos.UseVisualStyleBackColor = true;
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
            this.btnInsertar.Location = new System.Drawing.Point(96, 483);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(188, 41);
            this.btnInsertar.TabIndex = 36;
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
            this.btnDelete.Location = new System.Drawing.Point(605, 483);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(188, 41);
            this.btnDelete.TabIndex = 35;
            this.btnDelete.Text = "ELIMINAR";
            this.btnDelete.UseVisualStyleBackColor = true;
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
            this.btnEdit.Location = new System.Drawing.Point(354, 483);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(188, 41);
            this.btnEdit.TabIndex = 34;
            this.btnEdit.Text = "EDITAR";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // dgvUser
            // 
            this.dgvUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUser.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(101)))), ((int)(((byte)(117)))));
            this.dgvUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUser.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(101)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUser.EnableHeadersVisualStyles = false;
            this.dgvUser.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvUser.Location = new System.Drawing.Point(37, 214);
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(101)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUser.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(101)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvUser.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvUser.Size = new System.Drawing.Size(821, 252);
            this.dgvUser.TabIndex = 13;
            // 
            // pHomeBar
            // 
            this.pHomeBar.Controls.Add(this.label1);
            this.pHomeBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pHomeBar.Location = new System.Drawing.Point(0, 0);
            this.pHomeBar.Name = "pHomeBar";
            this.pHomeBar.Size = new System.Drawing.Size(892, 67);
            this.pHomeBar.TabIndex = 11;
            this.pHomeBar.Tag = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Control de Empleados";
            // 
            // txtDNI
            // 
            this.txtDNI.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.txtDNI.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(171)))), ((int)(((byte)(199)))));
            this.txtDNI.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            this.txtDNI.BorderRadius = 15;
            this.txtDNI.BorderSize = 2;
            this.txtDNI.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDNI.ForeColor = System.Drawing.Color.White;
            this.txtDNI.Location = new System.Drawing.Point(11, 11);
            this.txtDNI.Margin = new System.Windows.Forms.Padding(4);
            this.txtDNI.MaxLength = 32767;
            this.txtDNI.Multiline = false;
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtDNI.PasswordChar = false;
            this.txtDNI.PlaceholderColor = System.Drawing.Color.White;
            this.txtDNI.PlaceholderText = "CEDULA";
            this.txtDNI.Size = new System.Drawing.Size(198, 35);
            this.txtDNI.TabIndex = 17;
            this.txtDNI.Texts = "";
            this.txtDNI.UnderlinedStyle = false;
            this.txtDNI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DNI_Validation);
            // 
            // txtFN
            // 
            this.txtFN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.txtFN.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(171)))), ((int)(((byte)(199)))));
            this.txtFN.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            this.txtFN.BorderRadius = 15;
            this.txtFN.BorderSize = 2;
            this.txtFN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFN.ForeColor = System.Drawing.Color.White;
            this.txtFN.Location = new System.Drawing.Point(217, 11);
            this.txtFN.Margin = new System.Windows.Forms.Padding(4);
            this.txtFN.MaxLength = 32767;
            this.txtFN.Multiline = false;
            this.txtFN.Name = "txtFN";
            this.txtFN.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtFN.PasswordChar = false;
            this.txtFN.PlaceholderColor = System.Drawing.Color.White;
            this.txtFN.PlaceholderText = "PRIMER NOMBRE";
            this.txtFN.Size = new System.Drawing.Size(198, 35);
            this.txtFN.TabIndex = 0;
            this.txtFN.Texts = "";
            this.txtFN.UnderlinedStyle = false;
            this.txtFN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Letter_KeyPress);
            // 
            // txtSN
            // 
            this.txtSN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.txtSN.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(171)))), ((int)(((byte)(199)))));
            this.txtSN.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            this.txtSN.BorderRadius = 15;
            this.txtSN.BorderSize = 2;
            this.txtSN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSN.ForeColor = System.Drawing.Color.White;
            this.txtSN.Location = new System.Drawing.Point(423, 11);
            this.txtSN.Margin = new System.Windows.Forms.Padding(4);
            this.txtSN.MaxLength = 32767;
            this.txtSN.Multiline = false;
            this.txtSN.Name = "txtSN";
            this.txtSN.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtSN.PasswordChar = false;
            this.txtSN.PlaceholderColor = System.Drawing.Color.White;
            this.txtSN.PlaceholderText = "SEGUNDO NOMBRE";
            this.txtSN.Size = new System.Drawing.Size(211, 35);
            this.txtSN.TabIndex = 10;
            this.txtSN.Texts = "";
            this.txtSN.UnderlinedStyle = false;
            this.txtSN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Letter_KeyPress);
            // 
            // txtFA
            // 
            this.txtFA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.txtFA.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(171)))), ((int)(((byte)(199)))));
            this.txtFA.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            this.txtFA.BorderRadius = 15;
            this.txtFA.BorderSize = 2;
            this.txtFA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFA.ForeColor = System.Drawing.Color.White;
            this.txtFA.Location = new System.Drawing.Point(642, 11);
            this.txtFA.Margin = new System.Windows.Forms.Padding(4);
            this.txtFA.MaxLength = 32767;
            this.txtFA.Multiline = false;
            this.txtFA.Name = "txtFA";
            this.txtFA.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtFA.PasswordChar = false;
            this.txtFA.PlaceholderColor = System.Drawing.Color.White;
            this.txtFA.PlaceholderText = "PRIMER APELLIDO";
            this.txtFA.Size = new System.Drawing.Size(199, 35);
            this.txtFA.TabIndex = 11;
            this.txtFA.Texts = "";
            this.txtFA.UnderlinedStyle = false;
            this.txtFA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Letter_KeyPress);
            // 
            // txtSA
            // 
            this.txtSA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.txtSA.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(171)))), ((int)(((byte)(199)))));
            this.txtSA.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            this.txtSA.BorderRadius = 15;
            this.txtSA.BorderSize = 2;
            this.txtSA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSA.ForeColor = System.Drawing.Color.White;
            this.txtSA.Location = new System.Drawing.Point(11, 54);
            this.txtSA.Margin = new System.Windows.Forms.Padding(4);
            this.txtSA.MaxLength = 32767;
            this.txtSA.Multiline = false;
            this.txtSA.Name = "txtSA";
            this.txtSA.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtSA.PasswordChar = false;
            this.txtSA.PlaceholderColor = System.Drawing.Color.White;
            this.txtSA.PlaceholderText = "SEGUNDO APELLIDO";
            this.txtSA.Size = new System.Drawing.Size(209, 35);
            this.txtSA.TabIndex = 12;
            this.txtSA.Texts = "";
            this.txtSA.UnderlinedStyle = false;
            this.txtSA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Letter_KeyPress);
            // 
            // txtTel
            // 
            this.txtTel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.txtTel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(171)))), ((int)(((byte)(199)))));
            this.txtTel.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            this.txtTel.BorderRadius = 15;
            this.txtTel.BorderSize = 2;
            this.txtTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTel.ForeColor = System.Drawing.Color.White;
            this.txtTel.Location = new System.Drawing.Point(228, 54);
            this.txtTel.Margin = new System.Windows.Forms.Padding(4);
            this.txtTel.MaxLength = 32767;
            this.txtTel.Multiline = false;
            this.txtTel.Name = "txtTel";
            this.txtTel.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtTel.PasswordChar = false;
            this.txtTel.PlaceholderColor = System.Drawing.Color.White;
            this.txtTel.PlaceholderText = "TELEFONO";
            this.txtTel.Size = new System.Drawing.Size(199, 35);
            this.txtTel.TabIndex = 9;
            this.txtTel.Texts = "";
            this.txtTel.UnderlinedStyle = false;
            this.txtTel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Digit_KeyPress);
            // 
            // txtCargo
            // 
            this.txtCargo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.txtCargo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(171)))), ((int)(((byte)(199)))));
            this.txtCargo.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            this.txtCargo.BorderRadius = 15;
            this.txtCargo.BorderSize = 2;
            this.txtCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCargo.ForeColor = System.Drawing.Color.White;
            this.txtCargo.Location = new System.Drawing.Point(435, 54);
            this.txtCargo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCargo.MaxLength = 32767;
            this.txtCargo.Multiline = false;
            this.txtCargo.Name = "txtCargo";
            this.txtCargo.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtCargo.PasswordChar = false;
            this.txtCargo.PlaceholderColor = System.Drawing.Color.White;
            this.txtCargo.PlaceholderText = "CARGO";
            this.txtCargo.Size = new System.Drawing.Size(211, 35);
            this.txtCargo.TabIndex = 14;
            this.txtCargo.Texts = "";
            this.txtCargo.UnderlinedStyle = false;
            this.txtCargo.Visible = false;
            this.txtCargo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Letter_KeyPress);
            // 
            // txtSuc
            // 
            this.txtSuc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.txtSuc.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(171)))), ((int)(((byte)(199)))));
            this.txtSuc.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            this.txtSuc.BorderRadius = 15;
            this.txtSuc.BorderSize = 2;
            this.txtSuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSuc.ForeColor = System.Drawing.Color.White;
            this.txtSuc.Location = new System.Drawing.Point(654, 54);
            this.txtSuc.Margin = new System.Windows.Forms.Padding(4);
            this.txtSuc.MaxLength = 32767;
            this.txtSuc.Multiline = false;
            this.txtSuc.Name = "txtSuc";
            this.txtSuc.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtSuc.PasswordChar = false;
            this.txtSuc.PlaceholderColor = System.Drawing.Color.White;
            this.txtSuc.PlaceholderText = "CARGO";
            this.txtSuc.Size = new System.Drawing.Size(211, 35);
            this.txtSuc.TabIndex = 18;
            this.txtSuc.Texts = "";
            this.txtSuc.UnderlinedStyle = false;
            // 
            // cboCity
            // 
            this.cboCity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.cboCity.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(171)))), ((int)(((byte)(199)))));
            this.cboCity.BorderSize = 2;
            this.cboCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cboCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCity.ForeColor = System.Drawing.Color.White;
            this.cboCity.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            this.cboCity.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            this.cboCity.ListTextColor = System.Drawing.Color.White;
            this.cboCity.Location = new System.Drawing.Point(10, 96);
            this.cboCity.MinimumSize = new System.Drawing.Size(200, 30);
            this.cboCity.Name = "cboCity";
            this.cboCity.Padding = new System.Windows.Forms.Padding(2);
            this.cboCity.SelectedValue = null;
            this.cboCity.Size = new System.Drawing.Size(210, 34);
            this.cboCity.TabIndex = 6;
            this.cboCity.Texts = "DEPARTAMENTO";
            // 
            // Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 549);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Users";
            this.Text = "Users";
            this.Load += new System.EventHandler(this.Users_Load);
            this.panel1.ResumeLayout(false);
            this.flpInput.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
            this.pHomeBar.ResumeLayout(false);
            this.pHomeBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvUser;
        private System.Windows.Forms.Panel pHomeBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.FlowLayoutPanel flpInput;
        private MrControlers.MrTextBox txtFN;
        private MrControlers.MrTextBox txtSN;
        private MrControlers.MrTextBox txtFA;
        private MrControlers.MrTextBox txtSA;
        private MrControlers.MrTextBox txtTel;
        private MrControlers.MrTextBox txtCargo;
        private MrControlers.MrComboBox cboCity;
        private System.Windows.Forms.CheckBox C_Estado;
        private System.Windows.Forms.CheckBox C_Inactivos;
        private System.Windows.Forms.CheckBox C_Activos;
        private MrControlers.MrTextBox txtDNI;
        private MrControlers.MrTextBox txtSuc;
    }
}