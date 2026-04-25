namespace pj_Pharmacy.Forms
{
    partial class Buy
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Buy));
            this.pHomeBar = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.flpInput = new System.Windows.Forms.FlowLayoutPanel();
            this.txtCodProd = new pj_Pharmacy.MrControlers.MrTextBox();
            this.txtCantidad = new pj_Pharmacy.MrControlers.MrTextBox();
            this.txtPrecio = new pj_Pharmacy.MrControlers.MrTextBox();
            this.txtSubT = new pj_Pharmacy.MrControlers.MrTextBox();
            this.txtTotal = new pj_Pharmacy.MrControlers.MrTextBox();
            this.cboSupplier = new pj_Pharmacy.MrControlers.MrComboBox();
            this.dgvBuys = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.pHomeBar.SuspendLayout();
            this.flpInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuys)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pHomeBar
            // 
            this.pHomeBar.Controls.Add(this.label1);
            this.pHomeBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pHomeBar.Location = new System.Drawing.Point(0, 0);
            this.pHomeBar.Name = "pHomeBar";
            this.pHomeBar.Size = new System.Drawing.Size(892, 67);
            this.pHomeBar.TabIndex = 12;
            this.pHomeBar.Tag = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Control de Compras";
            // 
            // flpInput
            // 
            this.flpInput.Controls.Add(this.txtCodProd);
            this.flpInput.Controls.Add(this.txtCantidad);
            this.flpInput.Controls.Add(this.txtPrecio);
            this.flpInput.Controls.Add(this.txtSubT);
            this.flpInput.Controls.Add(this.txtTotal);
            this.flpInput.Controls.Add(this.cboSupplier);
            this.flpInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpInput.Location = new System.Drawing.Point(0, 67);
            this.flpInput.Name = "flpInput";
            this.flpInput.Padding = new System.Windows.Forms.Padding(7);
            this.flpInput.Size = new System.Drawing.Size(892, 86);
            this.flpInput.TabIndex = 13;
            // 
            // txtCodProd
            // 
            this.txtCodProd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.txtCodProd.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(171)))), ((int)(((byte)(199)))));
            this.txtCodProd.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            this.txtCodProd.BorderRadius = 15;
            this.txtCodProd.BorderSize = 2;
            this.txtCodProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodProd.ForeColor = System.Drawing.Color.White;
            this.txtCodProd.Location = new System.Drawing.Point(11, 11);
            this.txtCodProd.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodProd.MaxLength = 32767;
            this.txtCodProd.Multiline = false;
            this.txtCodProd.Name = "txtCodProd";
            this.txtCodProd.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtCodProd.PasswordChar = false;
            this.txtCodProd.PlaceholderColor = System.Drawing.Color.White;
            this.txtCodProd.PlaceholderText = "COD PRODUCTO";
            this.txtCodProd.Size = new System.Drawing.Size(157, 35);
            this.txtCodProd.TabIndex = 0;
            this.txtCodProd.Texts = "";
            this.txtCodProd.UnderlinedStyle = false;
            this.txtCodProd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Digit_KeyPress);
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
            this.txtCantidad.Location = new System.Drawing.Point(176, 11);
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
            // txtPrecio
            // 
            this.txtPrecio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.txtPrecio.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(171)))), ((int)(((byte)(199)))));
            this.txtPrecio.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            this.txtPrecio.BorderRadius = 15;
            this.txtPrecio.BorderSize = 2;
            this.txtPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecio.ForeColor = System.Drawing.Color.White;
            this.txtPrecio.Location = new System.Drawing.Point(295, 11);
            this.txtPrecio.Margin = new System.Windows.Forms.Padding(4);
            this.txtPrecio.MaxLength = 32767;
            this.txtPrecio.Multiline = false;
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtPrecio.PasswordChar = false;
            this.txtPrecio.PlaceholderColor = System.Drawing.Color.White;
            this.txtPrecio.PlaceholderText = "PRECIO";
            this.txtPrecio.Size = new System.Drawing.Size(111, 35);
            this.txtPrecio.TabIndex = 3;
            this.txtPrecio.Texts = "";
            this.txtPrecio.UnderlinedStyle = false;
            this.txtPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Digit_KeyPress);
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
            this.txtSubT.Location = new System.Drawing.Point(414, 11);
            this.txtSubT.Margin = new System.Windows.Forms.Padding(4);
            this.txtSubT.MaxLength = 32767;
            this.txtSubT.Multiline = false;
            this.txtSubT.Name = "txtSubT";
            this.txtSubT.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtSubT.PasswordChar = false;
            this.txtSubT.PlaceholderColor = System.Drawing.Color.White;
            this.txtSubT.PlaceholderText = "SUBTOTAL";
            this.txtSubT.Size = new System.Drawing.Size(120, 35);
            this.txtSubT.TabIndex = 8;
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
            this.txtTotal.Location = new System.Drawing.Point(542, 11);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotal.MaxLength = 32767;
            this.txtTotal.Multiline = false;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtTotal.PasswordChar = false;
            this.txtTotal.PlaceholderColor = System.Drawing.Color.White;
            this.txtTotal.PlaceholderText = "TOTAL";
            this.txtTotal.Size = new System.Drawing.Size(110, 35);
            this.txtTotal.TabIndex = 7;
            this.txtTotal.Texts = "";
            this.txtTotal.UnderlinedStyle = false;
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
            this.cboSupplier.Location = new System.Drawing.Point(659, 10);
            this.cboSupplier.MinimumSize = new System.Drawing.Size(200, 30);
            this.cboSupplier.Name = "cboSupplier";
            this.cboSupplier.Padding = new System.Windows.Forms.Padding(2);
            this.cboSupplier.SelectedValue = null;
            this.cboSupplier.Size = new System.Drawing.Size(210, 37);
            this.cboSupplier.TabIndex = 6;
            this.cboSupplier.Texts = "PROVEEDOR";
            // 
            // dgvBuys
            // 
            this.dgvBuys.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBuys.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(101)))), ((int)(((byte)(117)))));
            this.dgvBuys.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBuys.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(101)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBuys.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBuys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBuys.EnableHeadersVisualStyles = false;
            this.dgvBuys.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvBuys.Location = new System.Drawing.Point(37, 171);
            this.dgvBuys.Name = "dgvBuys";
            this.dgvBuys.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(101)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBuys.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(101)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvBuys.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBuys.Size = new System.Drawing.Size(821, 279);
            this.dgvBuys.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(66)))), ((int)(((byte)(77)))));
            this.panel1.Controls.Add(this.btnInsertar);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.dgvBuys);
            this.panel1.Controls.Add(this.flpInput);
            this.panel1.Controls.Add(this.pHomeBar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlLight;
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
            this.btnInsertar.Location = new System.Drawing.Point(88, 478);
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
            this.btnDelete.Location = new System.Drawing.Point(604, 478);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(188, 41);
            this.btnDelete.TabIndex = 31;
            this.btnDelete.Text = "ELIMINAR";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // Buy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 549);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Buy";
            this.Text = "Buy";
            this.Load += new System.EventHandler(this.Buy_Load);
            this.pHomeBar.ResumeLayout(false);
            this.pHomeBar.PerformLayout();
            this.flpInput.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuys)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pHomeBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flpInput;
        private MrControlers.MrTextBox txtCodProd;
        private MrControlers.MrTextBox txtCantidad;
        private MrControlers.MrTextBox txtPrecio;
        private MrControlers.MrComboBox cboSupplier;
        private System.Windows.Forms.DataGridView dgvBuys;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.Button btnDelete;
        private MrControlers.MrTextBox txtSubT;
        private MrControlers.MrTextBox txtTotal;
    }
}