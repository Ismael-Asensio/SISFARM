namespace pj_Pharmacy.Forms
{
    partial class Envio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Envio));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.dgvEnvio = new System.Windows.Forms.DataGridView();
            this.flpInput = new System.Windows.Forms.FlowLayoutPanel();
            this.txtEnvio = new pj_Pharmacy.MrControlers.MrTextBox();
            this.txtOrigen = new pj_Pharmacy.MrControlers.MrTextBox();
            this.txtDNI = new pj_Pharmacy.MrControlers.MrTextBox();
            this.txtDest = new pj_Pharmacy.MrControlers.MrTextBox();
            this.C_Estado = new System.Windows.Forms.CheckBox();
            this.pHomeBar = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnvio)).BeginInit();
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
            this.panel1.Controls.Add(this.dgvEnvio);
            this.panel1.Controls.Add(this.flpInput);
            this.panel1.Controls.Add(this.pHomeBar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(892, 549);
            this.panel1.TabIndex = 12;
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
            this.btnInsertar.Location = new System.Drawing.Point(139, 486);
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
            this.btnDelete.Location = new System.Drawing.Point(565, 486);
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
            this.btnEdit.Location = new System.Drawing.Point(351, 486);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(188, 41);
            this.btnEdit.TabIndex = 30;
            this.btnEdit.Text = "EDITAR";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // dgvEnvio
            // 
            this.dgvEnvio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEnvio.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(101)))), ((int)(((byte)(117)))));
            this.dgvEnvio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEnvio.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(101)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEnvio.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEnvio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEnvio.EnableHeadersVisualStyles = false;
            this.dgvEnvio.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvEnvio.Location = new System.Drawing.Point(37, 171);
            this.dgvEnvio.Name = "dgvEnvio";
            this.dgvEnvio.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(101)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEnvio.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(101)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvEnvio.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvEnvio.Size = new System.Drawing.Size(821, 279);
            this.dgvEnvio.TabIndex = 14;
            this.dgvEnvio.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEnvio_CellClick);
            // 
            // flpInput
            // 
            this.flpInput.Controls.Add(this.txtEnvio);
            this.flpInput.Controls.Add(this.txtOrigen);
            this.flpInput.Controls.Add(this.txtDNI);
            this.flpInput.Controls.Add(this.txtDest);
            this.flpInput.Controls.Add(this.C_Estado);
            this.flpInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpInput.Location = new System.Drawing.Point(0, 67);
            this.flpInput.Name = "flpInput";
            this.flpInput.Padding = new System.Windows.Forms.Padding(7);
            this.flpInput.Size = new System.Drawing.Size(892, 87);
            this.flpInput.TabIndex = 12;
            // 
            // txtEnvio
            // 
            this.txtEnvio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.txtEnvio.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(171)))), ((int)(((byte)(199)))));
            this.txtEnvio.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            this.txtEnvio.BorderRadius = 15;
            this.txtEnvio.BorderSize = 2;
            this.txtEnvio.Enabled = false;
            this.txtEnvio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnvio.ForeColor = System.Drawing.Color.White;
            this.txtEnvio.Location = new System.Drawing.Point(11, 11);
            this.txtEnvio.Margin = new System.Windows.Forms.Padding(4);
            this.txtEnvio.MaxLength = 32767;
            this.txtEnvio.Multiline = false;
            this.txtEnvio.Name = "txtEnvio";
            this.txtEnvio.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtEnvio.PasswordChar = false;
            this.txtEnvio.PlaceholderColor = System.Drawing.Color.White;
            this.txtEnvio.PlaceholderText = "ID ENVIO";
            this.txtEnvio.Size = new System.Drawing.Size(136, 35);
            this.txtEnvio.TabIndex = 6;
            this.txtEnvio.Texts = "";
            this.txtEnvio.UnderlinedStyle = false;
            // 
            // txtOrigen
            // 
            this.txtOrigen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.txtOrigen.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(171)))), ((int)(((byte)(199)))));
            this.txtOrigen.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            this.txtOrigen.BorderRadius = 15;
            this.txtOrigen.BorderSize = 2;
            this.txtOrigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrigen.ForeColor = System.Drawing.Color.White;
            this.txtOrigen.Location = new System.Drawing.Point(155, 11);
            this.txtOrigen.Margin = new System.Windows.Forms.Padding(4);
            this.txtOrigen.MaxLength = 32767;
            this.txtOrigen.Multiline = false;
            this.txtOrigen.Name = "txtOrigen";
            this.txtOrigen.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtOrigen.PasswordChar = false;
            this.txtOrigen.PlaceholderColor = System.Drawing.Color.White;
            this.txtOrigen.PlaceholderText = "ORIGEN";
            this.txtOrigen.Size = new System.Drawing.Size(198, 35);
            this.txtOrigen.TabIndex = 0;
            this.txtOrigen.Texts = "";
            this.txtOrigen.UnderlinedStyle = false;
            this.txtOrigen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Letter_KeyPress);
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
            this.txtDNI.Location = new System.Drawing.Point(361, 11);
            this.txtDNI.Margin = new System.Windows.Forms.Padding(4);
            this.txtDNI.MaxLength = 32767;
            this.txtDNI.Multiline = false;
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtDNI.PasswordChar = false;
            this.txtDNI.PlaceholderColor = System.Drawing.Color.White;
            this.txtDNI.PlaceholderText = "DNI";
            this.txtDNI.Size = new System.Drawing.Size(177, 35);
            this.txtDNI.TabIndex = 1;
            this.txtDNI.Texts = "";
            this.txtDNI.UnderlinedStyle = false;
            this.txtDNI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DNI_Validation);
            // 
            // txtDest
            // 
            this.txtDest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.txtDest.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(171)))), ((int)(((byte)(199)))));
            this.txtDest.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            this.txtDest.BorderRadius = 15;
            this.txtDest.BorderSize = 2;
            this.txtDest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDest.ForeColor = System.Drawing.Color.White;
            this.txtDest.Location = new System.Drawing.Point(546, 11);
            this.txtDest.Margin = new System.Windows.Forms.Padding(4);
            this.txtDest.MaxLength = 32767;
            this.txtDest.Multiline = false;
            this.txtDest.Name = "txtDest";
            this.txtDest.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtDest.PasswordChar = false;
            this.txtDest.PlaceholderColor = System.Drawing.Color.White;
            this.txtDest.PlaceholderText = "ID DESTINATARIO";
            this.txtDest.Size = new System.Drawing.Size(187, 35);
            this.txtDest.TabIndex = 2;
            this.txtDest.Texts = "";
            this.txtDest.UnderlinedStyle = false;
            this.txtDest.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Digit_KeyPress);
            // 
            // C_Estado
            // 
            this.C_Estado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.C_Estado.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.C_Estado.FlatAppearance.BorderSize = 2;
            this.C_Estado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.C_Estado.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.C_Estado.Location = new System.Drawing.Point(740, 10);
            this.C_Estado.Name = "C_Estado";
            this.C_Estado.Size = new System.Drawing.Size(70, 34);
            this.C_Estado.TabIndex = 5;
            this.C_Estado.Text = "ESTADO";
            this.C_Estado.UseVisualStyleBackColor = true;
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
            this.label1.Size = new System.Drawing.Size(199, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Control de Envios";
            // 
            // Envio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 549);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Envio";
            this.Text = "Envio";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnvio)).EndInit();
            this.flpInput.ResumeLayout(false);
            this.pHomeBar.ResumeLayout(false);
            this.pHomeBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flpInput;
        private MrControlers.MrTextBox txtOrigen;
        private MrControlers.MrTextBox txtDNI;
        private MrControlers.MrTextBox txtDest;
        private System.Windows.Forms.CheckBox C_Estado;
        private System.Windows.Forms.Panel pHomeBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvEnvio;
        private MrControlers.MrTextBox txtEnvio;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
    }
}