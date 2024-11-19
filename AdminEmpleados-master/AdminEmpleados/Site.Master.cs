using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminEmpleados
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verifica si hay una sesión activa
            if (Session["Usuario"] == null)
            {
                // Si no hay sesión activa, redirige al login
                Response.Redirect("Login.aspx");
            }
        }

        // Evento para cerrar sesión
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Finaliza la sesión del usuario
            Session.Abandon(); // Elimina todos los datos de la sesión
            Response.Redirect("Login.aspx"); // Redirige a la página de login
        }
    }
}