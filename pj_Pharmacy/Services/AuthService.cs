using System;
using System.Collections.Generic;
using pj_Pharmacy.DataAccess;
using pj_Pharmacy.DataAccess.Repositories;

namespace pj_Pharmacy.Services
{
    /// <summary>
    /// Resultado de un intento de login.
    /// </summary>
    public class LoginResult
    {
        public bool Exitoso { get; set; }
        public string MensajeError { get; set; }
        public string NombreUsuario { get; set; }
        public string Rol { get; set; }
    }

    /// <summary>
    /// Servicio de autenticación contra SQL Server.
    /// Valida credenciales intentando conectar con el usuario/contraseña proporcionados.
    /// Luego verifica roles de servidor para determinar permisos.
    /// </summary>
    public static class AuthService
    {
        /// <summary>
        /// Intenta autenticar al usuario contra SQL Server.
        /// Auto-detecta la instancia de SQL Server.
        /// </summary>
        public static LoginResult Login(string usuario, string contraseña)
        {
            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contraseña))
            {
                return new LoginResult
                {
                    Exitoso = false,
                    MensajeError = "HAY CAMPOS VACÍOS"
                };
            }

            // Auto-detectar el servidor SQL
            string servidor = DatabaseConnection.DetectarServidor();
            string baseDatos = "Pharmacy";

            // Intentar conexión con las credenciales del usuario
            bool conexionExitosa = DatabaseConnection.TestConnection(servidor, usuario, contraseña, baseDatos);

            if (!conexionExitosa)
            {
                // Mostrar el error real para diagnóstico
                string errorDetalle = DatabaseConnection.UltimoError ?? "Error desconocido";
                return new LoginResult
                {
                    Exitoso = false,
                    MensajeError = $"ERROR DE CONEXIÓN: {errorDetalle}"
                };
            }

            // Conexión exitosa: inicializar la conexión global
            DatabaseConnection.Initialize(servidor, usuario, contraseña, baseDatos);

            // Verificar roles del usuario
            List<string> roles = AuthRepository.ObtenerRolesUsuario(usuario);
            string rolAsignado = DeterminarRolPrincipal(roles);

            if (string.IsNullOrEmpty(rolAsignado))
            {
                DatabaseConnection.Reset();
                return new LoginResult
                {
                    Exitoso = false,
                    MensajeError = "EL USUARIO NO TIENE UN ROL VÁLIDO ASIGNADO"
                };
            }

            // Iniciar sesión
            SessionManager.IniciarSesion(usuario, rolAsignado);

            return new LoginResult
            {
                Exitoso = true,
                NombreUsuario = usuario,
                Rol = rolAsignado
            };
        }

        /// <summary>
        /// Cierra la sesión limpiando conexión y datos de sesión.
        /// </summary>
        public static void Logout()
        {
            SessionManager.CerrarSesion();
            DatabaseConnection.Reset();
        }

        /// <summary>
        /// Determina el rol principal del usuario basado en sus roles de servidor.
        /// Prioridad: sysadmin > processadmin
        /// </summary>
        private static string DeterminarRolPrincipal(List<string> roles)
        {
            if (roles.Contains("sysadmin"))
                return "sysadmin";
            if (roles.Contains("processadmin"))
                return "processadmin";

            // Si tiene al menos un rol, usar el primero
            return roles.Count > 0 ? roles[0] : null;
        }
    }
}
