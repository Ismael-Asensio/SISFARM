namespace pj_Pharmacy.Services
{
    /// <summary>
    /// Almacena la información de la sesión del usuario actual.
    /// Patrón singleton estático para acceso global desde cualquier formulario.
    /// </summary>
    public static class SessionManager
    {
        /// <summary>
        /// Nombre del usuario autenticado.
        /// </summary>
        public static string NombreUsuario { get; private set; }

        /// <summary>
        /// Rol del usuario (sysadmin, processadmin, etc.).
        /// </summary>
        public static string RolUsuario { get; private set; }

        /// <summary>
        /// Indica si el usuario tiene rol de administrador completo.
        /// </summary>
        public static bool EsAdministrador => RolUsuario == "sysadmin";

        /// <summary>
        /// Indica si el usuario tiene rol de gerente/proceso.
        /// </summary>
        public static bool EsGerente => RolUsuario == "processadmin";

        /// <summary>
        /// Establece la sesión del usuario tras autenticación exitosa.
        /// </summary>
        public static void IniciarSesion(string usuario, string rol)
        {
            NombreUsuario = usuario;
            RolUsuario = rol;
        }

        /// <summary>
        /// Limpia la sesión al cerrar sesión.
        /// </summary>
        public static void CerrarSesion()
        {
            NombreUsuario = null;
            RolUsuario = null;
        }

        /// <summary>
        /// Verifica si hay sesión activa.
        /// </summary>
        public static bool SesionActiva => !string.IsNullOrEmpty(NombreUsuario);

        /// <summary>
        /// Verifica si el usuario tiene acceso a una funcionalidad específica.
        /// Los administradores tienen acceso total.
        /// Los gerentes tienen acceso limitado (sin productos, contactos, proveedores, usuarios).
        /// </summary>
        public static bool TieneAcceso(string modulo)
        {
            if (EsAdministrador) return true;

            if (EsGerente)
            {
                switch (modulo.ToLower())
                {
                    case "productos":
                    case "contactos":
                    case "proveedores":
                    case "usuarios":
                        return false;
                    default:
                        return true;
                }
            }

            return false;
        }
    }
}
