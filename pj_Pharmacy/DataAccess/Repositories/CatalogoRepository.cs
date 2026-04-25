using System.Data;
using System.Data.SqlClient;

namespace pj_Pharmacy.DataAccess.Repositories
{
    /// <summary>
    /// Repositorio para catálogos del sistema (Departamentos, Productos para combos).
    /// </summary>
    public static class CatalogoRepository
    {
        /// <summary>
        /// Obtiene la lista de departamentos para ComboBox.
        /// </summary>
        public static DataTable ObtenerDepartamentos()
        {
            return DatabaseHelper.ExecuteReader("ListDep");
        }

        /// <summary>
        /// Obtiene la lista de productos para ComboBox, con fila en blanco al inicio.
        /// </summary>
        public static DataTable ObtenerProductosParaCombo()
        {
            DataTable dt = DatabaseHelper.ExecuteReader("ListProd");

            // Agregar fila en blanco al inicio para selección por defecto
            if (dt.Columns.Contains("CodProd") && dt.Columns.Contains("NombreProd"))
            {
                DataRow filaEnBlanco = dt.NewRow();
                filaEnBlanco["CodProd"] = System.DBNull.Value;
                filaEnBlanco["NombreProd"] = "";
                dt.Rows.InsertAt(filaEnBlanco, 0);
            }

            return dt;
        }
    }
}
