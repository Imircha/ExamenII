using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminEmpleados
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verifica si el usuario ha iniciado sesión
            if (Session["Usuario"] == null)
            {
                // Si no ha iniciado sesión, redirige al login
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Cierra la sesión y redirige al login
            Session.Abandon(); // Esto eliminará todos los datos de la sesión
            Response.Redirect("Login.aspx");
        }
    }
}