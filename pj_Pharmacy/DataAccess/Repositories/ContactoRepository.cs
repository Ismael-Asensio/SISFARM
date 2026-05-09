using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace pj_Pharmacy.DataAccess.Repositories
{
    /// <summary>
    /// Repositorio para operaciones CRUD de Contactos/Asesores.
    /// </summary>
    public static class ContactoRepository
    {
        public static void Listar(DataGridView dgv)
        {
            DatabaseHelper.FillDataGridView(dgv, "ListCA");
        }

        public static bool Insertar(string primerNombre, string segundoNombre,
            string primerApellido, string segundoApellido, string direccion,
            string telefono, string email, string rucProveedor)
        {
            return DatabaseHelper.ExecuteNonQuery("NuevosContactos",
                new SqlParameter("@PN", SqlDbType.NVarChar) { Value = primerNombre },
                new SqlParameter("@SN", SqlDbType.NVarChar) { Value = segundoNombre },
                new SqlParameter("@PA", SqlDbType.NVarChar) { Value = primerApellido },
                new SqlParameter("@SA", SqlDbType.NVarChar) { Value = segundoApellido },
                new SqlParameter("@Dir", SqlDbType.NVarChar) { Value = direccion },
                new SqlParameter("@Tel", SqlDbType.NVarChar) { Value = telefono },
                new SqlParameter("@Mail", SqlDbType.NVarChar) { Value = email },
                new SqlParameter("@RUC", SqlDbType.NVarChar) { Value = rucProveedor }
            );
        }

        public static bool Actualizar(string idContacto, string primerNombre, string segundoNombre,
            string primerApellido, string segundoApellido, string direccion,
            string telefono, string email, string rucProveedor)
        {
            return DatabaseHelper.ExecuteNonQuery("ActualizarContactos",
                new SqlParameter("@IdC", SqlDbType.Char) { Value = idContacto },
                new SqlParameter("@PN", SqlDbType.NVarChar) { Value = primerNombre },
                new SqlParameter("@SN", SqlDbType.NVarChar) { Value = segundoNombre },
                new SqlParameter("@PA", SqlDbType.NVarChar) { Value = primerApellido },
                new SqlParameter("@SA", SqlDbType.NVarChar) { Value = segundoApellido },
                new SqlParameter("@Dir", SqlDbType.NVarChar) { Value = direccion },
                new SqlParameter("@Tel", SqlDbType.Char) { Value = telefono },
                new SqlParameter("@Mail", SqlDbType.NVarChar) { Value = email },
                new SqlParameter("@RUC", SqlDbType.Char) { Value = rucProveedor }
            );
        }
    }
}
