namespace pj_Pharmacy.Forms
{
    partial class Assesor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Assesor));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.dgvSupplier = new System.Windows.Forms.DataGridView();
            this.flpInput = new System.Windows.Forms.FlowLayoutPanel();
            this.txtFN = new pj_Pharmacy.MrControlers.MrTextBox();
            this.txtSN = new pj_Pharmacy.MrControlers.MrTextBox();
            this.txtFA = new pj_Pharmacy.MrControlers.MrTextBox();
            this.txtSA = new pj_Pharmacy.MrControlers.MrTextBox();
            this.txtAddress = new pj_Pharmacy.MrControlers.MrTextBox();
            this.txtTel = new pj_Pharmacy.MrControlers.MrTextBox();
            this.txtMail = new pj_Pharmacy.MrControlers.MrTextBox();
            this.txtContacto = new pj_Pharmacy.MrControlers.MrTextBox();
            this.cboTypeCN = new pj_Pharmacy.MrControlers.MrComboBox();
            this.C_Estado = new System.Windows.Forms.CheckBox();
            this.C_Inactivos = new System.Windows.Forms.CheckBox();
            this.C_Activos = new System.Windows.Forms.CheckBox();
            this.pHomeBar = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupplier)).BeginInit();
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
            this.panel1.Controls.Add(this.dgvSupplier);
            this.panel1.Controls.Add(this.flpInput);
            this.panel1.Controls.Add(this.pHomeBar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(892, 549);
            this.panel1.TabIndex = 13;
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
            this.btnInsertar.Location = new System.Drawing.Point(84, 485);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(188, 41);
            this.btnInsertar.TabIndex = 24;
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
            this.btnDelete.Location = new System.Drawing.Point(596, 485);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(188, 41);
            this.btnDelete.TabIndex = 23;
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
            this.btnEdit.Location = new System.Drawing.Point(352, 485);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(188, 41);
            this.btnEdit.TabIndex = 22;
            this.btnEdit.Text = "EDITAR";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // dgvSupplier
            // 
            this.dgvSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSupplier.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(101)))), ((int)(((byte)(117)))));
            this.dgvSupplier.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSupplier.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(101)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSupplier.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSupplier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSupplier.EnableHeadersVisualStyles = false;
            this.dgvSupplier.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvSupplier.Location = new System.Drawing.Point(34, 209);
            this.dgvSupplier.Name = "dgvSupplier";
            this.dgvSupplier.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(101)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSupplier.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(101)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvSupplier.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSupplier.Size = new System.Drawing.Size(821, 259);
            this.dgvSupplier.TabIndex = 14;
            // 
            // flpInput
            // 
            this.flpInput.Controls.Add(this.txtContacto);
            this.flpInput.Controls.Add(this.txtFN);
            this.flpInput.Controls.Add(this.txtSN);
            this.flpInput.Controls.Add(this.txtFA);
            this.flpInput.Controls.Add(this.txtSA);
            this.flpInput.Controls.Add(this.txtAddress);
            this.flpInput.Controls.Add(this.txtTel);
            this.flpInput.Controls.Add(this.txtMail);
            this.flpInput.Controls.Add(this.cboTypeCN);
            this.flpInput.Controls.Add(this.C_Estado);
            this.flpInput.Controls.Add(this.C_Inactivos);
            this.flpInput.Controls.Add(this.C_Activos);
            this.flpInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpInput.Location = new System.Drawing.Point(0, 67);
            this.flpInput.Margin = new System.Windows.Forms.Padding(7);
            this.flpInput.Name = "flpInput";
            this.flpInput.Padding = new System.Windows.Forms.Padding(7);
            this.flpInput.Size = new System.Drawing.Size(892, 136);
            this.flpInput.TabIndex = 12;
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
            this.txtFN.Location = new System.Drawing.Point(102, 11);
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
            this.txtSN.Location = new System.Drawing.Point(308, 11);
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
            this.txtFA.Location = new System.Drawing.Point(527, 11);
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
            this.txtSA.Size = new System.Drawing.Size(199, 35);
            this.txtSA.TabIndex = 12;
            this.txtSA.Texts = "";
            this.txtSA.UnderlinedStyle = false;
            this.txtSA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Letter_KeyPress);
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.txtAddress.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(171)))), ((int)(((byte)(199)))));
            this.txtAddress.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            this.txtAddress.BorderRadius = 15;
            this.txtAddress.BorderSize = 2;
            this.txtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.ForeColor = System.Drawing.Color.White;
            this.txtAddress.Location = new System.Drawing.Point(218, 54);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtAddress.MaxLength = 32767;
            this.txtAddress.Multiline = false;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtAddress.PasswordChar = false;
            this.txtAddress.PlaceholderColor = System.Drawing.Color.White;
            this.txtAddress.PlaceholderText = "DIRECCIÓN";
            this.txtAddress.Size = new System.Drawing.Size(211, 35);
            this.txtAddress.TabIndex = 8;
            this.txtAddress.Texts = "";
            this.txtAddress.UnderlinedStyle = false;
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
            this.txtTel.Location = new System.Drawing.Point(437, 54);
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
            // txtMail
            // 
            this.txtMail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.txtMail.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(171)))), ((int)(((byte)(199)))));
            this.txtMail.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            this.txtMail.BorderRadius = 15;
            this.txtMail.BorderSize = 2;
            this.txtMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMail.ForeColor = System.Drawing.Color.White;
            this.txtMail.Location = new System.Drawing.Point(644, 54);
            this.txtMail.Margin = new System.Windows.Forms.Padding(4);
            this.txtMail.MaxLength = 32767;
            this.txtMail.Multiline = false;
            this.txtMail.Name = "txtMail";
            this.txtMail.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtMail.PasswordChar = false;
            this.txtMail.PlaceholderColor = System.Drawing.Color.White;
            this.txtMail.PlaceholderText = "CORREO";
            this.txtMail.Size = new System.Drawing.Size(211, 35);
            this.txtMail.TabIndex = 14;
            this.txtMail.Texts = "";
            this.txtMail.UnderlinedStyle = false;
            // 
            // txtContacto
            // 
            this.txtContacto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.txtContacto.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(171)))), ((int)(((byte)(199)))));
            this.txtContacto.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            this.txtContacto.BorderRadius = 15;
            this.txtContacto.BorderSize = 2;
            this.txtContacto.Enabled = false;
            this.txtContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContacto.ForeColor = System.Drawing.Color.White;
            this.txtContacto.Location = new System.Drawing.Point(11, 11);
            this.txtContacto.Margin = new System.Windows.Forms.Padding(4);
            this.txtContacto.MaxLength = 32767;
            this.txtContacto.Multiline = false;
            this.txtContacto.Name = "txtContacto";
            this.txtContacto.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtContacto.PasswordChar = false;
            this.txtContacto.PlaceholderColor = System.Drawing.Color.White;
            this.txtContacto.PlaceholderText = "COD";
            this.txtContacto.Size = new System.Drawing.Size(83, 35);
            this.txtContacto.TabIndex = 17;
            this.txtContacto.Texts = "";
            this.txtContacto.UnderlinedStyle = false;
            // 
            // cboTypeCN
            // 
            this.cboTypeCN.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTypeCN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.cboTypeCN.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(171)))), ((int)(((byte)(199)))));
            this.cboTypeCN.BorderSize = 2;
            this.cboTypeCN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cboTypeCN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTypeCN.ForeColor = System.Drawing.Color.White;
            this.cboTypeCN.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            this.cboTypeCN.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            this.cboTypeCN.ListTextColor = System.Drawing.Color.White;
            this.cboTypeCN.Location = new System.Drawing.Point(10, 96);
            this.cboTypeCN.MinimumSize = new System.Drawing.Size(200, 30);
            this.cboTypeCN.Name = "cboTypeCN";
            this.cboTypeCN.Padding = new System.Windows.Forms.Padding(2);
            this.cboTypeCN.SelectedValue = null;
            this.cboTypeCN.Size = new System.Drawing.Size(210, 34);
            this.cboTypeCN.TabIndex = 13;
            this.cboTypeCN.Texts = "EMPRESA RUC";
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
            this.label1.Size = new System.Drawing.Size(314, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Control de Contactos Asesor";
            // 
            // Assesor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 549);
            this.Controls.Add(this.panel1);
            this.Name = "Assesor";
            this.Text = "Assesor";
            this.Load += new System.EventHandler(this.Assesor_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupplier)).EndInit();
            this.flpInput.ResumeLayout(false);
            this.pHomeBar.ResumeLayout(false);
            this.pHomeBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.DataGridView dgvSupplier;
        private System.Windows.Forms.FlowLayoutPanel flpInput;
        private MrControlers.MrTextBox txtFN;
        private MrControlers.MrTextBox txtSN;
        private MrControlers.MrTextBox txtFA;
        private MrControlers.MrTextBox txtSA;
        private MrControlers.MrTextBox txtAddress;
        private MrControlers.MrTextBox txtTel;
        private MrControlers.MrTextBox txtMail;
        private System.Windows.Forms.CheckBox C_Estado;
        private System.Windows.Forms.CheckBox C_Inactivos;
        private System.Windows.Forms.CheckBox C_Activos;
        private System.Windows.Forms.Panel pHomeBar;
        private System.Windows.Forms.Label label1;
        private MrControlers.MrComboBox cboTypeCN;
        private MrControlers.MrTextBox txtContacto;
    }
}