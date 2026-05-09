using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace pj_Pharmacy.DataAccess
{
    /// <summary>
    /// Métodos genéricos reutilizables para ejecutar stored procedures.
    /// Elimina las ~1000 líneas de boilerplate repetido del Utility.cs original.
    /// </summary>
    public static class DatabaseHelper
    {
        /// <summary>
        /// Ejecuta un stored procedure que retorna un DataTable (para SELECT/listados).
        /// </summary>
        public static DataTable ExecuteReader(string storedProcedure, params SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = DatabaseConnection.CreateConnection())
                using (SqlCommand cmd = new SqlCommand(storedProcedure, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (parameters != null && parameters.Length > 0)
                        cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar datos: {ex.Message}", "Error de Base de Datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        /// <summary>
        /// Ejecuta un stored procedure de tipo INSERT/UPDATE/DELETE (sin retorno de datos).
        /// Retorna true si la ejecución fue exitosa.
        /// </summary>
        public static bool ExecuteNonQuery(string storedProcedure, params SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.CreateConnection())
                using (SqlCommand cmd = new SqlCommand(storedProcedure, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (parameters != null && parameters.Length > 0)
                        cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al ejecutar operación: {ex.Message}", "Error de Base de Datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Ejecuta un stored procedure y retorna un valor escalar.
        /// </summary>
        public static object ExecuteScalar(string storedProcedure, params SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.CreateConnection())
                using (SqlCommand cmd = new SqlCommand(storedProcedure, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (parameters != null && parameters.Length > 0)
                        cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al ejecutar consulta: {ex.Message}", "Error de Base de Datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Ejecuta una consulta SQL directa (text) y retorna un DataTable.
        /// Usar solo para consultas del sistema (verificar roles, etc.).
        /// </summary>
        public static DataTable ExecuteQuery(string query, params SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = DatabaseConnection.CreateConnection())
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    if (parameters != null && parameters.Length > 0)
                        cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al ejecutar consulta: {ex.Message}", "Error de Base de Datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        /// <summary>
        /// Llena un DataGridView con los resultados de un stored procedure.
        /// Método de conveniencia que combina ExecuteReader + asignar DataSource.
        /// </summary>
        public static void FillDataGridView(DataGridView dgv, string storedProcedure, params SqlParameter[] parameters)
        {
            dgv.DataSource = ExecuteReader(storedProcedure, parameters);
        }
    }
}
