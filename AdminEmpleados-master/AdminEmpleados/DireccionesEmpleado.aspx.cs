using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminEmpleados
{
    public partial class DireccionesEmpleado : Page
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDirecciones();
            }
        }

        protected void LoadDirecciones()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT CedulaEmpleado, Calle, Ciudad, Numero FROM DireccionesEmpleado", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvDirecciones.DataSource = dt;
                gvDirecciones.DataBind();
            }
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO DireccionesEmpleado (CedulaEmpleado, Calle, Ciudad, Numero) VALUES (@Cedula, @Calle, @Ciudad, @Numero)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Cedula", txtCedula.Text);
                cmd.Parameters.AddWithValue("@Calle", txtCalle.Text);
                cmd.Parameters.AddWithValue("@Ciudad", txtCiudad.Text);
                cmd.Parameters.AddWithValue("@Numero", txtNumero.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                lblMessage.Text = "Dirección agregada exitosamente!";
                LoadDirecciones();
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE DireccionesEmpleado SET Calle=@Calle, Ciudad=@Ciudad, Numero=@Numero WHERE CedulaEmpleado=@Cedula";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Cedula", txtCedula.Text);
                cmd.Parameters.AddWithValue("@Calle", txtCalle.Text);
                cmd.Parameters.AddWithValue("@Ciudad", txtCiudad.Text);
                cmd.Parameters.AddWithValue("@Numero", txtNumero.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                lblMessage.Text = "Dirección actualizada!";
                LoadDirecciones();
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM DireccionesEmpleado WHERE CedulaEmpleado=@Cedula AND Calle=@Calle AND Ciudad=@Ciudad AND Numero=@Numero";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Cedula", txtCedula.Text);
                cmd.Parameters.AddWithValue("@Calle", txtCalle.Text);
                cmd.Parameters.AddWithValue("@Ciudad", txtCiudad.Text);
                cmd.Parameters.AddWithValue("@Numero", txtNumero.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                lblMessage.Text = "Dirección eliminada!";
                LoadDirecciones();
            }
        }

        protected void GvDirecciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvDirecciones.SelectedRow;
            txtCedula.Text = row.Cells[0].Text;
            txtCalle.Text = row.Cells[1].Text;
            txtCiudad.Text = row.Cells[2].Text;
            txtNumero.Text = row.Cells[3].Text;
        }
    }
}
