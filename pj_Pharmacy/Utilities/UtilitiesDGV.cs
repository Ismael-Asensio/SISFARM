using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace pj_Pharmacy.Utilities
{
    /// <summary>
    /// Utilidades de formateo para DataGridView.
    /// Ahora es clase estática (no tiene estado).
    /// </summary>
    public static class UtilitiesDGV
    {
        /// <summary>
        /// Aplica formato estándar a un DataGridView y configura la columna de acciones.
        /// </summary>
        public static void FormatearGrid(DataGridView dgv)
        {
            DataGridViewCellStyle style = dgv.ColumnHeadersDefaultCellStyle;
            style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ReadOnly = true;

            // Evitar múltiples suscripciones a eventos
            dgv.DataBindingComplete -= Dgv_DataBindingComplete;
            dgv.DataBindingComplete += Dgv_DataBindingComplete;
        }

        private static void Dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (sender is DataGridView dgv)
            {
                // Formateo automático de fechas y decimales
                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    if (col.ValueType == typeof(DateTime))
                    {
                        col.DefaultCellStyle.Format = "dd/MM/yyyy";
                    }
                    else if (col.ValueType == typeof(decimal) || col.ValueType == typeof(float) || col.ValueType == typeof(double))
                    {
                        col.DefaultCellStyle.Format = "N2";
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                }
            }
        }

        /// <summary>
        /// Aplica formato de moneda a una columna específica del DataGridView.
        /// </summary>
        public static void FormatearColumnaMoneda(DataGridView dgv, string nombreColumna)
        {
            if (dgv.Columns.Contains(nombreColumna))
            {
                dgv.Columns[nombreColumna].DefaultCellStyle.Format = "C2";
                dgv.Columns[nombreColumna].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        /// <summary>
        /// Aplica formato de fecha a una columna específica del DataGridView.
        /// </summary>
        public static void FormatearColumnaFecha(DataGridView dgv, string nombreColumna)
        {
            if (dgv.Columns.Contains(nombreColumna))
            {
                dgv.Columns[nombreColumna].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgv.Columns[nombreColumna].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
    }
}
