using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Text;

namespace pj_Pharmacy.Utilities
{
    /// <summary>
    /// Genera un reporte PDF profesional del Dashboard renderizando cada página
    /// como Bitmap con GDI+ y embebiendo las imágenes en un PDF/1.4 correcto.
    /// Sin dependencias externas — solo System.Drawing.
    /// </summary>
    public static class PdfReportGenerator
    {
        // Tamaño de bitmap interno (A4 a 150 dpi)
        private const int BMP_W = 1240;
        private const int BMP_H = 1754;

        // Tamaño de página PDF en puntos (A4)
        private const int PDF_W = 595;
        private const int PDF_H = 842;

        private static readonly CultureInfo CulEs =
            new CultureInfo("es-NI");

        // ─────────────────────────────────────────────────────────────
        //  ENTRADA PÚBLICA
        // ─────────────────────────────────────────────────────────────

        /// <param name="rutaDestino">Ruta del archivo .pdf a crear.</param>
        /// <param name="kpis">Valores KPI (clave → valor).</param>
        /// <param name="graficos">Bitmaps capturadas de los charts.</param>
        /// <param name="desde">Fecha inicio del periodo.</param>
        /// <param name="hasta">Fecha fin del periodo.</param>
        public static void Generar(
            string rutaDestino,
            Dictionary<string, string> kpis,
            List<Bitmap> graficos,
            DateTime desde,
            DateTime hasta)
        {
            string[] titulosGraf = {
                "Ingresos vs Egresos",
                "Top Productos más Vendidos",
                "Tendencia de Ventas",
                "Productos con Stock Bajo"
            };

            int totalPags = 1 + graficos.Count;

            // Construir páginas como Bitmap
            var paginas = new List<Bitmap>();
            paginas.Add(RenderPortada(kpis, desde, hasta, totalPags));

            for (int i = 0; i < graficos.Count; i++)
            {
                string tit = i < titulosGraf.Length ? titulosGraf[i] : $"Gráfico {i + 1}";
                paginas.Add(RenderPaginaGrafico(graficos[i], tit, i + 2, totalPags, desde, hasta));
            }

            // Convertir a JPEG
            var jpegs = new List<byte[]>();
            var codec = GetJpegCodec();
            using (var ep = new EncoderParameters(1))
            {
                ep.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 90L);
                foreach (var bmp in paginas)
                {
                    using (var ms = new MemoryStream())
                    {
                        bmp.Save(ms, codec, ep);
                        jpegs.Add(ms.ToArray());
                    }
                    bmp.Dispose();
                }
            }

            File.WriteAllBytes(rutaDestino, EscribirPdf(jpegs));
        }

        // ─────────────────────────────────────────────────────────────
        //  RENDERIZADO: PORTADA
        // ─────────────────────────────────────────────────────────────

        private static Bitmap RenderPortada(
            Dictionary<string, string> kpis,
            DateTime desde, DateTime hasta, int totalPags)
        {
            var bmp = new Bitmap(BMP_W, BMP_H, PixelFormat.Format24bppRgb);
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint =
                    System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                // ── Paleta ──────────────────────────────────────────
                var bgDark  = Color.FromArgb(30,  30,  46);
                var bgHead  = Color.FromArgb(60,  20,  90);
                var bgCard  = Color.FromArgb(45,  45,  65);
                var pink    = Color.FromArgb(232, 121, 176);
                var textW   = Color.FromArgb(230, 230, 240);
                var textDim = Color.FromArgb(160, 160, 180);
                var green   = Color.FromArgb(46,  204, 113);
                var red     = Color.FromArgb(231,  76,  60);
                var blue    = Color.FromArgb(52,  152, 219);
                var orange  = Color.FromArgb(243, 156,  18);
                Color[] accents = { green, red, blue, orange };

                // ── Fondo ────────────────────────────────────────────
                g.Clear(bgDark);

                // ── Banda superior degradada ─────────────────────────
                using (var grad = new LinearGradientBrush(
                    new Rectangle(0, 0, BMP_W, 250), bgHead, bgDark,
                    LinearGradientMode.Vertical))
                    g.FillRectangle(grad, 0, 0, BMP_W, 250);

                // Línea acento inferior de la banda
                using (var pen = new Pen(pink, 6))
                    g.DrawLine(pen, 0, 246, BMP_W, 246);

                // ── Título principal ──────────────────────────────────
                using (var f = new Font("Segoe UI", 44, FontStyle.Bold))
                using (var br = new SolidBrush(textW))
                {
                    var sf = new StringFormat { Alignment = StringAlignment.Center };
                    g.DrawString("FARMACIA — REPORTE GENERAL",
                                 f, br, new RectangleF(0, 50, BMP_W, 120), sf);
                }

                // ── Periodo ───────────────────────────────────────────
                string periodo = $"Período:  {desde:dd/MM/yyyy}  →  {hasta:dd/MM/yyyy}";
                using (var f = new Font("Segoe UI", 24))
                using (var br = new SolidBrush(pink))
                {
                    var sf = new StringFormat { Alignment = StringAlignment.Center };
                    g.DrawString(periodo, f, br,
                                 new RectangleF(0, 170, BMP_W, 60), sf);
                }

                // ── Fecha de generación ───────────────────────────────
                string gen = "Generado el " +
                             DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy  HH:mm", CulEs);
                using (var f = new Font("Segoe UI", 17))
                using (var br = new SolidBrush(textDim))
                {
                    var sf = new StringFormat { Alignment = StringAlignment.Center };
                    g.DrawString(gen, f, br,
                                 new RectangleF(0, 212, BMP_W, 38), sf);
                }

                // ── Sección KPIs ──────────────────────────────────────
                using (var f = new Font("Segoe UI", 24, FontStyle.Bold))
                using (var br = new SolidBrush(pink))
                    g.DrawString("INDICADORES CLAVE DEL PERÍODO", f, br,
                                 new PointF(80, 290));

                using (var pen = new Pen(Color.FromArgb(70, 70, 95), 2))
                    g.DrawLine(pen, 80, 334, BMP_W - 80, 334);

                // ── Tarjetas KPI (2 columnas) ─────────────────────────
                var kpiList = new List<KeyValuePair<string, string>>(kpis);
                int cW = 520, cH = 190, cGapX = 40, cGapY = 24;
                int sx = 80, sy = 358;

                for (int i = 0; i < kpiList.Count && i < 4; i++)
                {
                    int col = i % 2, row = i / 2;
                    int cx = sx + col * (cW + cGapX);
                    int cy = sy + row * (cH + cGapY);
                    Color ac = accents[i % accents.Length];

                    // Sombra
                    using (var br = new SolidBrush(Color.FromArgb(30, 0, 0, 0)))
                        g.FillRectangle(br, cx + 5, cy + 5, cW, cH);

                    // Fondo
                    using (var br = new SolidBrush(bgCard))
                        g.FillRectangle(br, cx, cy, cW, cH);

                    // Borde acento izquierdo
                    using (var br = new SolidBrush(ac))
                        g.FillRectangle(br, cx, cy, 10, cH);

                    // Etiqueta
                    using (var f = new Font("Segoe UI", 16, FontStyle.Bold))
                    using (var br = new SolidBrush(textDim))
                        g.DrawString(kpiList[i].Key, f, br, new PointF(cx + 26, cy + 22));

                    // Valor
                    using (var f = new Font("Segoe UI", 40, FontStyle.Bold))
                    using (var br = new SolidBrush(ac))
                        g.DrawString(kpiList[i].Value, f, br, new PointF(cx + 26, cy + 68));
                }

                // ── Separador y nota ──────────────────────────────────
                int noteY = sy + 2 * (cH + cGapY) + 48;
                using (var pen = new Pen(Color.FromArgb(60, 60, 80), 1))
                    g.DrawLine(pen, 80, noteY, BMP_W - 80, noteY);

                using (var f = new Font("Segoe UI", 18))
                using (var br = new SolidBrush(textDim))
                    g.DrawString(
                        "Las siguientes páginas contienen los gráficos detallados del período seleccionado.",
                        f, br, new PointF(80, noteY + 28));

                // ── Pie de página ──────────────────────────────────────
                using (var pen = new Pen(Color.FromArgb(50, 50, 70), 2))
                    g.DrawLine(pen, 80, BMP_H - 90, BMP_W - 80, BMP_H - 90);

                using (var f = new Font("Segoe UI", 15))
                using (var br = new SolidBrush(textDim))
                {
                    g.DrawString(
                        "SISFARM — Sistema de Gestión de Farmacia  |  Documento Confidencial",
                        f, br, new PointF(80, BMP_H - 70));
                    var sfR = new StringFormat { Alignment = StringAlignment.Far };
                    g.DrawString($"Página 1 de {totalPags}", f, br,
                                 new RectangleF(0, BMP_H - 70, BMP_W - 80, 30), sfR);
                }
            }
            return bmp;
        }

        // ─────────────────────────────────────────────────────────────
        //  RENDERIZADO: PÁGINA DE GRÁFICO
        // ─────────────────────────────────────────────────────────────

        private static Bitmap RenderPaginaGrafico(
            Bitmap grafico, string titulo,
            int numPag, int totalPags,
            DateTime desde, DateTime hasta)
        {
            var bmp = new Bitmap(BMP_W, BMP_H, PixelFormat.Format24bppRgb);
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint =
                    System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                var bgDark  = Color.FromArgb(30,  30,  46);
                var bgHead  = Color.FromArgb(60,  20,  90);
                var pink    = Color.FromArgb(232, 121, 176);
                var textW   = Color.FromArgb(230, 230, 240);
                var textDim = Color.FromArgb(160, 160, 180);

                g.Clear(bgDark);

                // Banda superior
                using (var grad = new LinearGradientBrush(
                    new Rectangle(0, 0, BMP_W, 140), bgHead, bgDark,
                    LinearGradientMode.Vertical))
                    g.FillRectangle(grad, 0, 0, BMP_W, 140);

                using (var pen = new Pen(pink, 5))
                    g.DrawLine(pen, 0, 138, BMP_W, 138);

                // Título
                using (var f = new Font("Segoe UI", 32, FontStyle.Bold))
                using (var br = new SolidBrush(textW))
                    g.DrawString(titulo, f, br, new PointF(60, 30));

                // Periodo (alineado a la derecha)
                using (var f = new Font("Segoe UI", 18))
                using (var br = new SolidBrush(pink))
                {
                    var sfR = new StringFormat { Alignment = StringAlignment.Far };
                    g.DrawString($"{desde:dd/MM/yyyy}  –  {hasta:dd/MM/yyyy}",
                                 f, br,
                                 new RectangleF(0, 44, BMP_W - 60, 40), sfR);
                }

                // Imagen del gráfico
                int imgX = 40, imgY = 160;
                int imgW = BMP_W - 80, imgH = BMP_H - 310;
                g.DrawImage(grafico, imgX, imgY, imgW, imgH);

                // Pie de página
                using (var pen = new Pen(Color.FromArgb(50, 50, 70), 2))
                    g.DrawLine(pen, 60, BMP_H - 86, BMP_W - 60, BMP_H - 86);

                using (var f = new Font("Segoe UI", 15))
                using (var br = new SolidBrush(textDim))
                {
                    g.DrawString(
                        "SISFARM — Sistema de Gestión de Farmacia  |  Documento Confidencial",
                        f, br, new PointF(60, BMP_H - 66));
                    var sfR = new StringFormat { Alignment = StringAlignment.Far };
                    g.DrawString($"Página {numPag} de {totalPags}", f, br,
                                 new RectangleF(0, BMP_H - 66, BMP_W - 60, 30), sfR);
                }
            }
            return bmp;
        }

        // ─────────────────────────────────────────────────────────────
        //  ESCRITURA PDF CORRECTA (sin páginas en blanco)
        // ─────────────────────────────────────────────────────────────

        /// <summary>
        /// Escribe un PDF/1.4 mínimo y correcto con N páginas de imágenes JPEG.
        /// Estructura de objetos:
        ///   1 = Catalog
        ///   2 = Pages
        ///   Para página i (base 0):  3+i*3 = Page, 4+i*3 = ImgXObject, 5+i*3 = Content
        /// </summary>
        private static byte[] EscribirPdf(List<byte[]> jpegs)
        {
            int N = jpegs.Count;
            // Total objetos: 2 base + 3 por página
            int totalObjs = 2 + N * 3;
            var offsets = new long[totalObjs + 1]; // indexado desde 1

            var ms = new MemoryStream();

            // Helpers locales
            void Str(string s)
            {
                var b = Encoding.ASCII.GetBytes(s);
                ms.Write(b, 0, b.Length);
            }
            void Bytes(byte[] b) => ms.Write(b, 0, b.Length);

            // ── Encabezado ────────────────────────────────────────────
            Str("%PDF-1.4\n");
            Bytes(new byte[] { (byte)'%', 0xe2, 0xe3, 0xcf, 0xd3, (byte)'\n' });

            // ── Obj 1: Catálogo ───────────────────────────────────────
            offsets[1] = ms.Position;
            Str("1 0 obj\n<< /Type /Catalog /Pages 2 0 R >>\nendobj\n");

            // ── Obj 2: Páginas ────────────────────────────────────────
            var kids = new StringBuilder();
            for (int i = 0; i < N; i++)
            {
                if (i > 0) kids.Append(' ');
                kids.Append($"{3 + i * 3} 0 R");
            }
            offsets[2] = ms.Position;
            Str($"2 0 obj\n<< /Type /Pages /Kids [{kids}] /Count {N} >>\nendobj\n");

            // ── Objetos de página ─────────────────────────────────────
            for (int i = 0; i < N; i++)
            {
                int pageObj    = 3 + i * 3;   // Page
                int imgObj     = 4 + i * 3;   // Image XObject
                int contentObj = 5 + i * 3;   // Content stream

                var dim = GetJpegDims(jpegs[i]);

                // Page
                offsets[pageObj] = ms.Position;
                Str($"{pageObj} 0 obj\n" +
                    $"<< /Type /Page /Parent 2 0 R /MediaBox [0 0 {PDF_W} {PDF_H}] " +
                    $"/Resources << /XObject << /Im{i} {imgObj} 0 R >> >> " +
                    $"/Contents {contentObj} 0 R >>\n" +
                    "endobj\n");

                // Image XObject (stream binario JPEG)
                offsets[imgObj] = ms.Position;
                Str($"{imgObj} 0 obj\n" +
                    $"<< /Type /XObject /Subtype /Image " +
                    $"/Width {dim.w} /Height {dim.h} " +
                    $"/ColorSpace /DeviceRGB /BitsPerComponent 8 " +
                    $"/Filter /DCTDecode /Length {jpegs[i].Length} >>\n" +
                    "stream\n");
                Bytes(jpegs[i]);
                Str("\nendstream\nendobj\n");

                // Content stream: escala imagen a página completa
                byte[] cs = Encoding.ASCII.GetBytes(
                    $"q {PDF_W} 0 0 {PDF_H} 0 0 cm /Im{i} Do Q\n");
                offsets[contentObj] = ms.Position;
                Str($"{contentObj} 0 obj\n<< /Length {cs.Length} >>\nstream\n");
                Bytes(cs);
                Str("\nendstream\nendobj\n");
            }

            // ── Tabla xref ────────────────────────────────────────────
            long xrefPos = ms.Position;
            Str($"xref\n0 {totalObjs + 1}\n");
            Str("0000000000 65535 f \n");           // objeto libre 0
            for (int i = 1; i <= totalObjs; i++)
                Str($"{offsets[i]:D10} 00000 n \n");

            // ── Trailer ───────────────────────────────────────────────
            Str($"trailer\n<< /Size {totalObjs + 1} /Root 1 0 R >>\n");
            Str($"startxref\n{xrefPos}\n%%EOF\n");

            return ms.ToArray();
        }

        // ─────────────────────────────────────────────────────────────
        //  HELPERS
        // ─────────────────────────────────────────────────────────────

        private static (int w, int h) GetJpegDims(byte[] jpeg)
        {
            try
            {
                using (var ms = new MemoryStream(jpeg))
                using (var img = Image.FromStream(ms))
                    return (img.Width, img.Height);
            }
            catch { return (BMP_W, BMP_H); }
        }

        private static ImageCodecInfo GetJpegCodec()
        {
            foreach (var c in ImageCodecInfo.GetImageEncoders())
                if (c.MimeType == "image/jpeg") return c;
            return null;
        }
    }
}
