using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pj_Pharmacy.Utilities
{
    internal class UtilitiesDGV
    {
        public void DGV_Format(ref DataGridView Dgv)
        {
            DataGridViewCellStyle style = Dgv.ColumnHeadersDefaultCellStyle;
            style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;


            Dgv.AllowUserToAddRows = false;
            Dgv.AllowUserToDeleteRows = false;
            Dgv.ReadOnly = true;
        }
    }
}
