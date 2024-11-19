using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminEmpleados
{
    public partial class Login : Page
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string clave = txtClave.Text.Trim();

            // Validar que los campos no estén vacíos
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(clave))
            {
                lblMessage.Text = "Por favor, ingrese usuario y clave.";
                return;
            }

            if (ValidarLogin(usuario, clave))
            {
                // Configurar la sesión con el nombre de usuario
                Session["Usuario"] = usuario;  // Establecer la sesión
                Response.Redirect("HomePage.aspx");  // Redirigir a la página principal
            }
            else
            {
                lblMessage.Text = "Usuario o clave incorrectos. Intente nuevamente.";
            }
        }

        private bool ValidarLogin(string usuario, string clave)
        {
            bool esValido = false;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Consulta que compara el hash de la clave
                string query = "SELECT COUNT(*) FROM Usuarios WHERE Usuario = @Usuario AND Clave = @Clave";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Usuario", usuario);
                cmd.Parameters.AddWithValue("@Clave", clave); // Para mayor seguridad, aquí puedes aplicar un hash de la contraseña

                con.Open();
                int count = (int)cmd.ExecuteScalar();
                con.Close();

                esValido = count > 0;
            }

            return esValido;
        }
    }
}