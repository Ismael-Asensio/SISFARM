using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace pj_Pharmacy.MrControlers
{
    /// <summary>
    /// Botón personalizado con bordes redondeados anti-aliased.
    /// Diseñado para armonizar visualmente con MrTextBox (BorderRadius=15).
    /// </summary>
    public class MrButton : Button
    {
        // Campos
        private int borderRadius = 15;
        private int borderSize = 2;
        private Color borderColor = Color.FromArgb(232, 121, 176); // AccentPink
        private Color hoverColor = Color.FromArgb(200, 100, 155);
        private Color pressColor = Color.FromArgb(232, 121, 176);
        private bool isHovering = false;
        private bool isPressed = false;

        public MrButton()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            BackColor = Color.FromArgb(232, 121, 176); // AccentPink
            ForeColor = Color.White;
            Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            Cursor = Cursors.Hand;
            Size = new Size(140, 37);
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }

        #region Propiedades

        public int BorderRadius
        {
            get => borderRadius;
            set { borderRadius = value; Invalidate(); }
        }

        public int BorderSize_
        {
            get => borderSize;
            set { borderSize = value; Invalidate(); }
        }

        public Color BorderColor_
        {
            get => borderColor;
            set { borderColor = value; Invalidate(); }
        }

        public Color HoverColor
        {
            get => hoverColor;
            set => hoverColor = value;
        }

        public Color PressColor
        {
            get => pressColor;
            set => pressColor = value;
        }

        #endregion

        #region Métodos de dibujo

        private GraphicsPath GetRoundedPath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            // Determinar color de fondo según estado
            Color bgColor = BackColor;
            if (isPressed) bgColor = pressColor;
            else if (isHovering) bgColor = hoverColor;

            // Rectángulos
            RectangleF rectSurface = new RectangleF(0, 0, Width, Height);
            RectangleF rectBorder = new RectangleF(1, 1, Width - 2, Height - 2);

            // Limpiar fondo con color del padre
            if (Parent != null)
                g.Clear(Parent.BackColor);
            else
                g.Clear(Color.FromArgb(30, 30, 46));

            // Dibujar superficie redondeada
            using (GraphicsPath pathSurface = GetRoundedPath(rectSurface, borderRadius))
            using (GraphicsPath pathBorder = GetRoundedPath(rectBorder, borderRadius - 1))
            using (Brush brushSurface = new SolidBrush(bgColor))
            using (Pen penBorder = new Pen(borderColor, borderSize))
            {
                penBorder.Alignment = PenAlignment.Inset;

                // Región redondeada (para clics)
                this.Region = new Region(pathSurface);

                // Fondo
                g.FillPath(brushSurface, pathSurface);

                // Borde
                if (borderSize > 0)
                    g.DrawPath(penBorder, pathBorder);
            }

            // Texto centrado
            TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
            TextRenderer.DrawText(g, Text, Font, new Rectangle(0, 0, Width, Height), ForeColor, flags);
        }

        #endregion

        #region Eventos de ratón

        protected override void OnMouseEnter(EventArgs e)
        {
            isHovering = true;
            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            isHovering = false;
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            isPressed = true;
            Invalidate();
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            isPressed = false;
            Invalidate();
            base.OnMouseUp(e);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }

        #endregion
    }
}
