using System.Windows.Forms;

namespace pj_Pharmacy.Utilities
{
    /// <summary>
    /// Validadores de entrada reutilizables para todos los formularios.
    /// Elimina la duplicación de Digit_KeyPress y Letter_KeyPress en 6+ formularios.
    /// </summary>
    public static class InputValidator
    {
        /// <summary>
        /// Permite solo dígitos numéricos y teclas de control.
        /// Uso: txtCampo.KeyPress += InputValidator.SoloDigitos;
        /// </summary>
        public static void SoloDigitos(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Ingresa solo valores numéricos.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Permite solo letras y teclas de control.
        /// Uso: txtCampo.KeyPress += InputValidator.SoloLetras;
        /// </summary>
        public static void SoloLetras(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Ingresa solo letras.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Permite letras, dígitos y teclas de control (para DNI/cédula).
        /// Uso: txtDNI.KeyPress += InputValidator.LetrasYDigitos;
        /// </summary>
        public static void LetrasYDigitos(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Ingresa solo letras y números.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Verifica si alguno de los campos de texto está vacío.
        /// Retorna true si hay campos vacíos (y muestra mensaje).
        /// </summary>
        public static bool HayCamposVacios(params string[] valores)
        {
            foreach (string valor in valores)
            {
                if (string.IsNullOrWhiteSpace(valor))
                {
                    MessageBox.Show("No podemos procesar campos vacíos.", "Campos Requeridos",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
                }
            }
            return false;
        }
    }
}
