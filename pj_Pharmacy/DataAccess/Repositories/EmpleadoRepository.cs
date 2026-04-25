using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace pj_Pharmacy.DataAccess.Repositories
{
    /// <summary>
    /// Repositorio para operaciones CRUD de Empleados.
    /// </summary>
    public static class EmpleadoRepository
    {
        public static void Listar(DataGridView dgv)
        {
            DatabaseHelper.FillDataGridView(dgv, "ListEmp");
        }

        public static bool Insertar(string dni, string primerNombre, string segundoNombre,
            string primerApellido, string segundoApellido, string telefono, string idDepartamento, string idSucursal, string cargo)
        {
            return DatabaseHelper.ExecuteNonQuery("NuevoEmpleado",
                new SqlParameter("@DNI", SqlDbType.VarChar) { Value = dni },
                new SqlParameter("@PN", SqlDbType.VarChar) { Value = primerNombre },
                new SqlParameter("@SN", SqlDbType.VarChar) { Value = segundoNombre },
                new SqlParameter("@PA", SqlDbType.VarChar) { Value = primerApellido },
                new SqlParameter("@SA", SqlDbType.VarChar) { Value = segundoApellido },
                new SqlParameter("@Tel", SqlDbType.VarChar) { Value = telefono },
                new SqlParameter("@idDep", SqlDbType.VarChar) { Value = idDepartamento },
                new SqlParameter("@idSuc", SqlDbType.VarChar) { Value = idSucursal },
                new SqlParameter("@Cargo", SqlDbType.VarChar) { Value = cargo }
            );
        }

        public static bool Actualizar(string dni, string primerNombre, string segundoNombre,
            string primerApellido, string segundoApellido, string telefono, string idDepartamento, string idSucursal, string cargo)
        {
            return DatabaseHelper.ExecuteNonQuery("ActualizarEmpleado",
                new SqlParameter("@DNI", SqlDbType.VarChar) { Value = dni },
                new SqlParameter("@PN", SqlDbType.VarChar) { Value = primerNombre },
                new SqlParameter("@SN", SqlDbType.VarChar) { Value = segundoNombre },
                new SqlParameter("@PA", SqlDbType.VarChar) { Value = primerApellido },
                new SqlParameter("@SA", SqlDbType.VarChar) { Value = segundoApellido },
                new SqlParameter("@Tel", SqlDbType.VarChar) { Value = telefono },
                new SqlParameter("@idDep", SqlDbType.VarChar) { Value = idDepartamento },
                new SqlParameter("@idSuc", SqlDbType.VarChar) { Value = idSucursal },
                new SqlParameter("@Cargo", SqlDbType.VarChar) { Value = cargo }
            );
        }
    }
}
