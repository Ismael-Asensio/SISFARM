using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace pj_Pharmacy.DataAccess.Repositories
{
    /// <summary>
    /// Repositorio para operaciones CRUD de Clientes (Naturales y Jurídicos).
    /// </summary>
    public static class ClienteRepository
    {
        public static void ListarNaturales(DataGridView dgv)
        {
            DatabaseHelper.FillDataGridView(dgv, "ListClientN");
        }

        public static void ListarJuridicos(DataGridView dgv)
        {
            DatabaseHelper.FillDataGridView(dgv, "ListClientJ");
        }

        public static bool InsertarNatural(string direccion, string telefono, string codDep,
            string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, char tipoCliente)
        {
            return DatabaseHelper.ExecuteNonQuery("NClientNat",
                new SqlParameter("@Dir", SqlDbType.NVarChar) { Value = direccion },
                new SqlParameter("@Tel", SqlDbType.NVarChar) { Value = telefono },
                new SqlParameter("@Cd", SqlDbType.NVarChar) { Value = codDep },
                new SqlParameter("@PN", SqlDbType.NVarChar) { Value = primerNombre },
                new SqlParameter("@SN", SqlDbType.NVarChar) { Value = segundoNombre },
                new SqlParameter("@PA", SqlDbType.NVarChar) { Value = primerApellido },
                new SqlParameter("@SA", SqlDbType.NVarChar) { Value = segundoApellido },
                new SqlParameter("@TPC", SqlDbType.Char) { Value = tipoCliente }
            );
        }

        public static bool InsertarJuridico(string direccion, string telefono, string codDep,
            string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, string cargo)
        {
            return DatabaseHelper.ExecuteNonQuery("NClientJur",
                new SqlParameter("@Dir", SqlDbType.NVarChar) { Value = direccion },
                new SqlParameter("@Tel", SqlDbType.NVarChar) { Value = telefono },
                new SqlParameter("@Cd", SqlDbType.NVarChar) { Value = codDep },
                new SqlParameter("@PN", SqlDbType.NVarChar) { Value = primerNombre },
                new SqlParameter("@SN", SqlDbType.NVarChar) { Value = segundoNombre },
                new SqlParameter("@PA", SqlDbType.NVarChar) { Value = primerApellido },
                new SqlParameter("@SA", SqlDbType.NVarChar) { Value = segundoApellido },
                new SqlParameter("@Cargo", SqlDbType.NVarChar) { Value = cargo }
            );
        }

        public static bool ActualizarNatural(string direccion, string telefono, string codDep,
            string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, char tipoCliente)
        {
            return DatabaseHelper.ExecuteNonQuery("ActClienteNat",
                new SqlParameter("@Dir", SqlDbType.NVarChar) { Value = direccion },
                new SqlParameter("@Tel", SqlDbType.NVarChar) { Value = telefono },
                new SqlParameter("@Cd", SqlDbType.NVarChar) { Value = codDep },
                new SqlParameter("@PN", SqlDbType.NVarChar) { Value = primerNombre },
                new SqlParameter("@SN", SqlDbType.NVarChar) { Value = segundoNombre },
                new SqlParameter("@PA", SqlDbType.NVarChar) { Value = primerApellido },
                new SqlParameter("@SA", SqlDbType.NVarChar) { Value = segundoApellido },
                new SqlParameter("@TPC", SqlDbType.Char) { Value = tipoCliente }
            );
        }

        public static bool ActualizarJuridico(string direccion, string telefono, string codDep,
            string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, string cargo)
        {
            return DatabaseHelper.ExecuteNonQuery("ActClienteJur",
                new SqlParameter("@Dir", SqlDbType.NVarChar) { Value = direccion },
                new SqlParameter("@Tel", SqlDbType.NVarChar) { Value = telefono },
                new SqlParameter("@Cd", SqlDbType.NVarChar) { Value = codDep },
                new SqlParameter("@PN", SqlDbType.NVarChar) { Value = primerNombre },
                new SqlParameter("@SN", SqlDbType.NVarChar) { Value = segundoNombre },
                new SqlParameter("@PA", SqlDbType.NVarChar) { Value = primerApellido },
                new SqlParameter("@SA", SqlDbType.NVarChar) { Value = segundoApellido },
                new SqlParameter("@Cargo", SqlDbType.NVarChar) { Value = cargo }
            );
        }
    }
}
