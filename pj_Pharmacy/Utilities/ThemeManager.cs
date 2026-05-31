using System.Drawing;
using System.Windows.Forms;

namespace pj_Pharmacy.Utilities
{
    /// <summary>
    /// Tema oscuro centralizado para todo el proyecto.
    /// Aplica la colorimetría de forma recursiva a cualquier formulario.
    /// </summary>
    public static class ThemeManager
    {
        // === PALETA PRINCIPAL ===
        public static readonly Color BgDark = Color.FromArgb(30, 30, 46);
        public static readonly Color BgCard = Color.FromArgb(45, 45, 65);
        public static readonly Color BgInput = Color.FromArgb(55, 55, 78);
        public static readonly Color BgSidebar = Color.FromArgb(38, 38, 56);
        public static readonly Color BgHeader = Color.FromArgb(35, 35, 52);
        public static readonly Color BorderInput = Color.FromArgb(70, 70, 95);

        public static readonly Color TextLight = Color.FromArgb(230, 230, 240);
        public static readonly Color TextDim = Color.FromArgb(160, 160, 180);
        public static readonly Color TextPlaceholder = Color.FromArgb(110, 110, 135);

        public static readonly Color AccentPink = Color.FromArgb(232, 121, 176);
        public static readonly Color AccentGreen = Color.FromArgb(46, 204, 113);
        public static readonly Color AccentRed = Color.FromArgb(231, 76, 60);
        public static readonly Color AccentBlue = Color.FromArgb(52, 152, 219);
        public static readonly Color AccentOrange = Color.FromArgb(243, 156, 18);

        public static readonly Color BtnPrimary = Color.FromArgb(232, 121, 176);
        public static readonly Color BtnHover = Color.FromArgb(200, 100, 155);
        public static readonly Color BtnDanger = Color.FromArgb(231, 76, 60);

        public static readonly Color GridLine = Color.FromArgb(55, 55, 75);
        public static readonly Color GridHeaderBg = Color.FromArgb(50, 50, 70);
        public static readonly Color GridSelectBg = Color.FromArgb(65, 55, 85);
        public static readonly Color GridAltRow = Color.FromArgb(38, 38, 55);

        /// <summary>
        /// Aplica el tema oscuro a un formulario y todos sus controles.
        /// </summary>
        public static void AplicarTema(Form form)
        {
            form.BackColor = BgDark;
            form.ForeColor = TextLight;
            AplicarRecursivo(form);
        }

        private static void AplicarRecursivo(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                // === TEXTBOXES ===
                if (c is TextBox txt)
                {
                    txt.BackColor = BgInput;
                    txt.ForeColor = TextLight;
                    if (txt.Parent is pj_Pharmacy.MrControlers.MrTextBox)
                        txt.BorderStyle = BorderStyle.None;
                    else
                        txt.BorderStyle = BorderStyle.FixedSingle;
                }
                // === COMBOBOXES ===
                else if (c is ComboBox cmb)
                {
                    cmb.BackColor = BgInput;
                    cmb.ForeColor = TextLight;
                    if (!(cmb.Parent is pj_Pharmacy.MrControlers.MrComboBox))
                        cmb.FlatStyle = FlatStyle.Flat;
                }
                // === BUTTONS ===
                else if (c is Button btn)
                {
                    EstiloBoton(btn);
                }
                // === MR CONTROLLERS ===
                else if (c is pj_Pharmacy.MrControlers.MrTextBox mrtxt)
                {
                    mrtxt.BackColor = BgInput;
                    mrtxt.ForeColor = TextLight;
                    mrtxt.BorderColor = BorderInput;
                    mrtxt.BorderFocusColor = AccentPink;
                    mrtxt.PlaceholderColor = TextPlaceholder;
                }
                else if (c is pj_Pharmacy.MrControlers.MrComboBox mrcmb)
                {
                    mrcmb.BackColor = BgInput;
                    mrcmb.ForeColor = TextLight;
                    mrcmb.BorderColor = BorderInput;
                    mrcmb.IconColor = AccentPink;
                    mrcmb.ListBackColor = BgCard;
                    mrcmb.ListTextColor = TextLight;
                }
                // === DATAGRIDVIEW ===
                else if (c is DataGridView dgv)
                {
                    AplicarTemaDGV(dgv);
                }
                // === LABELS ===
                else if (c is Label lbl)
                {
                    lbl.ForeColor = TextLight;
                    // No tocar BackColor de labels (pueden ser transparentes)
                }
                // === GROUPBOX ===
                else if (c is GroupBox gb)
                {
                    gb.BackColor = BgCard;
                    gb.ForeColor = TextLight;
                }
                // === CHECKBOX ===
                else if (c is CheckBox chk)
                {
                    chk.ForeColor = TextLight;
                    chk.BackColor = Color.Transparent;
                }
                // === RADIOBUTTON ===
                else if (c is RadioButton rb)
                {
                    rb.ForeColor = TextLight;
                    rb.BackColor = Color.Transparent;
                }
                // === TABCONTROL ===
                else if (c is TabControl tab)
                {
                    foreach (TabPage page in tab.TabPages)
                    {
                        page.BackColor = BgDark;
                        page.ForeColor = TextLight;
                    }
                }
                // === NUMERICUPDOWN ===
                else if (c is NumericUpDown nud)
                {
                    nud.BackColor = BgInput;
                    nud.ForeColor = TextLight;
                }
                // === DATETIMEPICKER ===
                else if (c is DateTimePicker dtp)
                {
                    dtp.CalendarMonthBackground = BgInput;
                    dtp.CalendarForeColor = TextLight;
                }
                // === PANELS ===
                // Los paneles que envuelven textboxes como "borde" son los que
                // tienen exactamente 1 hijo y son solo un poco más grandes que ese hijo.
                // Les ponemos un borde sutil en vez del cyan original.
                else if (c is Panel pnl)
                {
                    // PictureBox containers - no tocar
                    if (ContieneSoloPictureBox(pnl))
                    {
                        // No cambiar fondo de paneles que solo contienen imágenes
                    }
                    // Panel "borde" de textbox: tiene 1 hijo que es TextBox o ComboBox
                    else if (EsPanelBordeInput(pnl))
                    {
                        pnl.BackColor = BorderInput;
                        pnl.Padding = new Padding(1);
                    }
                    // Panel normal
                    else
                    {
                        pnl.BackColor = BgDark;
                        pnl.ForeColor = TextLight;
                    }
                }
                // === FLOWLAYOUTPANEL ===
                else if (c is FlowLayoutPanel flp)
                {
                    flp.BackColor = BgDark;
                    flp.ForeColor = TextLight;
                }

                // Recurrir a hijos
                if (c.HasChildren)
                    AplicarRecursivo(c);
            }
        }

        /// <summary>
        /// Detecta si un panel actúa como borde visual de un TextBox/ComboBox.
        /// Estos paneles generalmente tienen 1 hijo input y padding mínimo.
        /// </summary>
        private static bool EsPanelBordeInput(Panel pnl)
        {
            if (pnl.Controls.Count != 1) return false;
            Control child = pnl.Controls[0];
            return (child is TextBox || child is ComboBox || child is NumericUpDown);
        }

        private static bool ContieneSoloPictureBox(Panel pnl)
        {
            if (pnl.Controls.Count != 1) return false;
            return pnl.Controls[0] is PictureBox;
        }

        /// <summary>
        /// Estilo consistente para botones.
        /// </summary>
        private static void EstiloBoton(Button btn)
        {
            // MrButton se dibuja solo — no aplicar estilo estándar
            if (btn is pj_Pharmacy.MrControlers.MrButton)
                return;

            btn.FlatStyle = FlatStyle.Flat;
            btn.Cursor = Cursors.Hand;
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            string name = btn.Name.ToLower();

            // Ocultar botones legacy (btnEdit y btnDelete) sin Visible=false
            if (name == "btnedit" || name == "btndelete")
            {
                btn.Size = new Size(0, 0);
                btn.TabStop = false;
                return;
            }

            // Botones normales — estilo limpio
            btn.BackColor = BtnPrimary;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = AccentPink;
            btn.FlatAppearance.MouseOverBackColor = BtnHover;
            btn.FlatAppearance.MouseDownBackColor = AccentPink;
            btn.Region = null;
        }

        /// <summary>
        /// Crea un MrButton "NUEVO" estilizado listo para usar en cualquier formulario.
        /// </summary>
        public static pj_Pharmacy.MrControlers.MrButton CrearBotonNuevo()
        {
            var btn = new pj_Pharmacy.MrControlers.MrButton();
            btn.Name = "btnNuevo";
            btn.Text = "✚ NUEVO";
            btn.Size = new Size(110, 37);
            btn.BackColor = BgCard;
            btn.ForeColor = TextLight;
            btn.BorderColor_ = AccentPink;
            btn.HoverColor = BgInput;
            btn.Margin = new Padding(5, 11, 10, 0);
            return btn;
        }

        /// <summary>
        /// Configura un btnInsertar como MrButton redondeado para el panel de inputs.
        /// Retorna el MrButton que reemplaza al botón original.
        /// </summary>
        public static pj_Pharmacy.MrControlers.MrButton CrearBotonGuardar(Button btnInsertar, FlowLayoutPanel flpInput)
        {
            // Crear MrButton redondeado
            var mrBtn = new pj_Pharmacy.MrControlers.MrButton();
            mrBtn.Name = "btnGuardar";
            mrBtn.Text = "GUARDAR";
            mrBtn.Size = new Size(140, 37);
            mrBtn.BackColor = BtnPrimary;
            mrBtn.ForeColor = Color.White;
            mrBtn.BorderColor_ = AccentPink;
            mrBtn.HoverColor = BtnHover;
            mrBtn.Margin = new Padding(10, 11, 5, 0);

            // Conectar al mismo evento Click que el botón original
            mrBtn.Click += (s, e) => btnInsertar.PerformClick();

            // Ocultar botón original
            btnInsertar.Size = new Size(0, 0);
            btnInsertar.TabStop = false;

            // Añadir al panel
            flpInput.Controls.Add(mrBtn);
            return mrBtn;
        }

        /// <summary>
        /// Aplica el tema oscuro a un DataGridView.
        /// </summary>
        public static void AplicarTemaDGV(DataGridView dgv)
        {
            dgv.BackgroundColor = BgCard;
            dgv.GridColor = GridLine;
            dgv.BorderStyle = BorderStyle.None;

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = GridHeaderBg;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = TextLight;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9F);
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = GridHeaderBg;
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(4, 2, 4, 2);

            dgv.DefaultCellStyle.BackColor = BgCard;
            dgv.DefaultCellStyle.ForeColor = TextDim;
            dgv.DefaultCellStyle.SelectionBackColor = GridSelectBg;
            dgv.DefaultCellStyle.SelectionForeColor = TextLight;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgv.DefaultCellStyle.Padding = new Padding(3, 1, 3, 1);

            dgv.RowsDefaultCellStyle.BackColor = BgCard;
            dgv.RowsDefaultCellStyle.ForeColor = TextDim;
            dgv.RowsDefaultCellStyle.SelectionBackColor = GridSelectBg;
            dgv.RowsDefaultCellStyle.SelectionForeColor = TextLight;
            dgv.RowsDefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgv.RowsDefaultCellStyle.Padding = new Padding(3, 1, 3, 1);

            dgv.AlternatingRowsDefaultCellStyle.BackColor = GridAltRow;
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = TextDim;
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = GridSelectBg;
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = TextLight;

            dgv.RowHeadersVisible = false;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.AllowUserToAddRows = false;
            dgv.ReadOnly = true;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.RowTemplate.Height = 28;
        }

        /// <summary>
        /// Aplica tema al sidebar del Home.
        /// </summary>
        public static void AplicarTemaSidebar(Panel sidebar, Panel topBar)
        {
            sidebar.BackColor = BgSidebar;
            topBar.BackColor = BgHeader;

            AplicarSidebarRecursivo(sidebar);
        }

        private static void AplicarSidebarRecursivo(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is Button btn)
                {
                    btn.BackColor = Color.Transparent;
                    btn.ForeColor = TextLight;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(55, 55, 80);
                    btn.FlatAppearance.MouseDownBackColor = AccentPink;
                    btn.Cursor = Cursors.Hand;

                    // Botón logout especial
                    if (btn.Name.ToLower().Contains("logout"))
                    {
                        btn.FlatAppearance.BorderSize = 1;
                        btn.FlatAppearance.BorderColor = AccentPink;
                    }
                }
                else if (c is Label lbl)
                {
                    lbl.ForeColor = TextLight;
                }
                else if (c is Panel pnl)
                {
                    // Paneles indicadores laterales (5px de ancho)
                    if (pnl.Width <= 10)
                        pnl.BackColor = BgDark;
                    else
                        pnl.BackColor = Color.Transparent;
                }
                else if (c is PictureBox)
                {
                    // No tocar imágenes
                }

                if (c.HasChildren)
                    AplicarSidebarRecursivo(c);
            }
        }
    }
}
