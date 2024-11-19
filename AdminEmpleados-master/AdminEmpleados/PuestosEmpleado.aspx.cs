using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminEmpleados
{
    public partial class PuestosEmpleado : Page
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPuestos();
            }
        }

        protected void LoadPuestos()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT CedulaEmpleado, PuestoDesempenado FROM PuestosEmpleado", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvPuestos.DataSource = dt;
                gvPuestos.DataBind();
            }
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO PuestosEmpleado (CedulaEmpleado, PuestoDesempenado) VALUES (@Cedula, @Puesto)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Cedula", Convert.ToInt32(txtCedula.Text));
                cmd.Parameters.AddWithValue("@Puesto", txtPuesto.Text);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    lblMessage.Text = "Puesto agregado exitosamente!";
                }
                catch (SqlException ex)
                {
                    lblMessage.Text = $"Error al agregar el puesto: {ex.Message}";
                }
                finally
                {
                    con.Close();
                }
                LoadPuestos();
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE PuestosEmpleado SET PuestoDesempenado=@Puesto WHERE CedulaEmpleado=@Cedula";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Cedula", Convert.ToInt32(txtCedula.Text));
                cmd.Parameters.AddWithValue("@Puesto", txtPuesto.Text);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    lblMessage.Text = "Puesto actualizado!";
                }
                catch (SqlException ex)
                {
                    lblMessage.Text = $"Error al actualizar el puesto: {ex.Message}";
                }
                finally
                {
                    con.Close();
                }
                LoadPuestos();
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM PuestosEmpleado WHERE CedulaEmpleado=@Cedula AND PuestoDesempenado=@Puesto";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Cedula", Convert.ToInt32(txtCedula.Text));
                cmd.Parameters.AddWithValue("@Puesto", txtPuesto.Text);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    lblMessage.Text = "Puesto eliminado!";
                }
                catch (SqlException ex)
                {
                    lblMessage.Text = $"Error al eliminar el puesto: {ex.Message}";
                }
                finally
                {
                    con.Close();
                }
                LoadPuestos();
            }
        }

        protected void GvPuestos_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvPuestos.SelectedRow;
            txtCedula.Text = row.Cells[0].Text;
            txtPuesto.Text = row.Cells[1].Text;
        }
    }
}