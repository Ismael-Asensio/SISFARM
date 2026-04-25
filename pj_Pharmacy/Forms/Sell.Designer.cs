namespace pj_Pharmacy.Forms
{
    partial class Sell
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sell));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvSell = new System.Windows.Forms.DataGridView();
            this.flpInput = new System.Windows.Forms.FlowLayoutPanel();
            this.txtClient = new pj_Pharmacy.MrControlers.MrTextBox();
            this.txtSeller = new pj_Pharmacy.MrControlers.MrTextBox();
            this.txtCantidad = new pj_Pharmacy.MrControlers.MrTextBox();
            this.txtSubT = new pj_Pharmacy.MrControlers.MrTextBox();
            this.txtTotal = new pj_Pharmacy.MrControlers.MrTextBox();
            this.pHomeBar = new System.Windows.Forms.Panel();
            this.cboProducts = new pj_Pharmacy.MrControlers.MrComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSell)).BeginInit();
            this.flpInput.SuspendLayout();
            this.pHomeBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.panel1.Controls.Add(this.btnInsertar);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.dgvSell);
            this.panel1.Controls.Add(this.flpInput);
            this.panel1.Controls.Add(this.pHomeBar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(892, 549);
            this.panel1.TabIndex = 2;
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
            this.btnInsertar.Location = new System.Drawing.Point(87, 483);
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
            this.btnDelete.Location = new System.Drawing.Point(601, 483);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(188, 41);
            this.btnDelete.TabIndex = 31;
            this.btnDelete.Text = "ELIMINAR";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // dgvSell
            // 
            this.dgvSell.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSell.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(101)))), ((int)(((byte)(117)))));
            this.dgvSell.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSell.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(101)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSell.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSell.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSell.EnableHeadersVisualStyles = false;
            this.dgvSell.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvSell.Location = new System.Drawing.Point(37, 171);
            this.dgvSell.Name = "dgvSell";
            this.dgvSell.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(101)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSell.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(101)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvSell.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSell.Size = new System.Drawing.Size(821, 279);
            this.dgvSell.TabIndex = 14;
            // 
            // flpInput
            // 
            this.flpInput.Controls.Add(this.txtClient);
            this.flpInput.Controls.Add(this.txtSeller);
            this.flpInput.Controls.Add(this.txtCantidad);
            this.flpInput.Controls.Add(this.txtSubT);
            this.flpInput.Controls.Add(this.txtTotal);
            this.flpInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpInput.Location = new System.Drawing.Point(0, 67);
            this.flpInput.Name = "flpInput";
            this.flpInput.Padding = new System.Windows.Forms.Padding(7);
            this.flpInput.Size = new System.Drawing.Size(892, 86);
            this.flpInput.TabIndex = 13;
            // 
            // txtClient
            // 
            this.txtClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.txtClient.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(171)))), ((int)(((byte)(199)))));
            this.txtClient.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            this.txtClient.BorderRadius = 15;
            this.txtClient.BorderSize = 2;
            this.txtClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClient.ForeColor = System.Drawing.Color.White;
            this.txtClient.Location = new System.Drawing.Point(11, 11);
            this.txtClient.Margin = new System.Windows.Forms.Padding(4);
            this.txtClient.MaxLength = 32767;
            this.txtClient.Multiline = false;
            this.txtClient.Name = "txtClient";
            this.txtClient.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtClient.PasswordChar = false;
            this.txtClient.PlaceholderColor = System.Drawing.Color.White;
            this.txtClient.PlaceholderText = "ID CLIENTE";
            this.txtClient.Size = new System.Drawing.Size(122, 35);
            this.txtClient.TabIndex = 3;
            this.txtClient.Texts = "";
            this.txtClient.UnderlinedStyle = false;
            this.txtClient.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Digit_KeyPress);
            // 
            // txtSeller
            // 
            this.txtSeller.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.txtSeller.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(171)))), ((int)(((byte)(199)))));
            this.txtSeller.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            this.txtSeller.BorderRadius = 15;
            this.txtSeller.BorderSize = 2;
            this.txtSeller.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSeller.ForeColor = System.Drawing.Color.White;
            this.txtSeller.Location = new System.Drawing.Point(141, 11);
            this.txtSeller.Margin = new System.Windows.Forms.Padding(4);
            this.txtSeller.MaxLength = 32767;
            this.txtSeller.Multiline = false;
            this.txtSeller.Name = "txtSeller";
            this.txtSeller.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtSeller.PasswordChar = false;
            this.txtSeller.PlaceholderColor = System.Drawing.Color.White;
            this.txtSeller.PlaceholderText = "ID VENDEDOR";
            this.txtSeller.Size = new System.Drawing.Size(158, 35);
            this.txtSeller.TabIndex = 6;
            this.txtSeller.Texts = "";
            this.txtSeller.UnderlinedStyle = false;
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
            this.txtCantidad.Location = new System.Drawing.Point(307, 11);
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
            // txtSubT
            // 
            this.txtSubT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.txtSubT.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(171)))), ((int)(((byte)(199)))));
            this.txtSubT.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            this.txtSubT.BorderRadius = 15;
            this.txtSubT.BorderSize = 2;
            this.txtSubT.Enabled = false;
            this.txtSubT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubT.ForeColor = System.Drawing.Color.White;
            this.txtSubT.Location = new System.Drawing.Point(426, 11);
            this.txtSubT.Margin = new System.Windows.Forms.Padding(4);
            this.txtSubT.MaxLength = 32767;
            this.txtSubT.Multiline = false;
            this.txtSubT.Name = "txtSubT";
            this.txtSubT.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtSubT.PasswordChar = false;
            this.txtSubT.PlaceholderColor = System.Drawing.Color.White;
            this.txtSubT.PlaceholderText = "SUBTOTAL";
            this.txtSubT.Size = new System.Drawing.Size(120, 35);
            this.txtSubT.TabIndex = 5;
            this.txtSubT.Texts = "";
            this.txtSubT.UnderlinedStyle = false;
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.txtTotal.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(171)))), ((int)(((byte)(199)))));
            this.txtTotal.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            this.txtTotal.BorderRadius = 15;
            this.txtTotal.BorderSize = 2;
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.ForeColor = System.Drawing.Color.White;
            this.txtTotal.Location = new System.Drawing.Point(554, 11);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotal.MaxLength = 32767;
            this.txtTotal.Multiline = false;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtTotal.PasswordChar = false;
            this.txtTotal.PlaceholderColor = System.Drawing.Color.White;
            this.txtTotal.PlaceholderText = "TOTAL";
            this.txtTotal.Size = new System.Drawing.Size(138, 35);
            this.txtTotal.TabIndex = 4;
            this.txtTotal.Texts = "";
            this.txtTotal.UnderlinedStyle = false;
            // 
            // pHomeBar
            // 
            this.pHomeBar.Controls.Add(this.cboProducts);
            this.pHomeBar.Controls.Add(this.label1);
            this.pHomeBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pHomeBar.Location = new System.Drawing.Point(0, 0);
            this.pHomeBar.Name = "pHomeBar";
            this.pHomeBar.Size = new System.Drawing.Size(892, 67);
            this.pHomeBar.TabIndex = 12;
            this.pHomeBar.Tag = "";
            // 
            // cboProducts
            // 
            this.cboProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboProducts.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboProducts.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.cboProducts.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(171)))), ((int)(((byte)(199)))));
            this.cboProducts.BorderSize = 2;
            this.cboProducts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cboProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProducts.ForeColor = System.Drawing.Color.White;
            this.cboProducts.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            this.cboProducts.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            this.cboProducts.ListTextColor = System.Drawing.Color.White;
            this.cboProducts.Location = new System.Drawing.Point(244, 19);
            this.cboProducts.MinimumSize = new System.Drawing.Size(200, 30);
            this.cboProducts.Name = "cboProducts";
            this.cboProducts.Padding = new System.Windows.Forms.Padding(2);
            this.cboProducts.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cboProducts.SelectedValue = null;
            this.cboProducts.Size = new System.Drawing.Size(614, 34);
            this.cboProducts.TabIndex = 7;
            this.cboProducts.Texts = "BUSCAR";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Control de Ventas";
            // 
            // Sell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 549);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Sell";
            this.Text = "Sell";
            this.Load += new System.EventHandler(this.Sell_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSell)).EndInit();
            this.flpInput.ResumeLayout(false);
            this.pHomeBar.ResumeLayout(false);
            this.pHomeBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvSell;
        private System.Windows.Forms.FlowLayoutPanel flpInput;
        private MrControlers.MrTextBox txtCantidad;
        private System.Windows.Forms.Panel pHomeBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.Button btnDelete;
        private MrControlers.MrTextBox txtClient;
        private MrControlers.MrTextBox txtSubT;
        private MrControlers.MrTextBox txtTotal;
        private MrControlers.MrTextBox txtSeller;
        private MrControlers.MrComboBox cboProducts;
    }
}