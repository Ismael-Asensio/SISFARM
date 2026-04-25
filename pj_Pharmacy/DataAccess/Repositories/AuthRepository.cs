using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace pj_Pharmacy.DataAccess.Repositories
{
    /// <summary>
    /// Repositorio para autenticación y verificación de roles SQL Server.
    /// </summary>
    public static class AuthRepository
    {
        /// <summary>
        /// Obtiene los roles de servidor del usuario SQL actual.
        /// </summary>
        public static List<string> ObtenerRolesUsuario(string usuario)
        {
            List<string> roles = new List<string>();

            string query = @"SELECT r.name 
                FROM sys.server_role_members m 
                INNER JOIN sys.server_principals p ON m.member_principal_id = p.principal_id 
                INNER JOIN sys.server_principals r ON m.role_principal_id = r.principal_id 
                WHERE p.name = @Usuario";

            DataTable dt = DatabaseHelper.ExecuteQuery(query,
                new SqlParameter("@Usuario", SqlDbType.NVarChar) { Value = usuario }
            );

            foreach (DataRow row in dt.Rows)
            {
                roles.Add(row["name"].ToString());
            }

            return roles;
        }
    }
}
