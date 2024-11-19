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
    public partial class TelefonosEmpleado : Page
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTelefonos();
            }
        }

        protected void LoadTelefonos()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT CedulaEmpleado, NumeroTelefono FROM TelefonosEmpleado", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvTelefonos.DataSource = dt;
                gvTelefonos.DataBind();
            }
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Verificar si la cédula existe en la tabla Empleados antes de agregar el teléfono
                string checkQuery = "SELECT COUNT(1) FROM Empleados WHERE CedulaEmpleado = @Cedula";
                SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                checkCmd.Parameters.AddWithValue("@Cedula", txtCedula.Text);

                con.Open();
                int exists = (int)checkCmd.ExecuteScalar();
                con.Close();

                if (exists == 0)
                {
                    lblMessage.Text = "Error: La cédula no existe en la tabla de Empleados.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                // Insertar el teléfono si la cédula existe
                string query = "INSERT INTO TelefonosEmpleado (CedulaEmpleado, NumeroTelefono) VALUES (@Cedula, @Telefono)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Cedula", txtCedula.Text);
                cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                lblMessage.Text = "Teléfono agregado exitosamente!";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                LoadTelefonos();
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE TelefonosEmpleado SET NumeroTelefono=@Telefono WHERE CedulaEmpleado=@Cedula";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Cedula", txtCedula.Text);
                cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                lblMessage.Text = "Teléfono actualizado!";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                LoadTelefonos();
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM TelefonosEmpleado WHERE CedulaEmpleado=@Cedula AND NumeroTelefono=@Telefono";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Cedula", txtCedula.Text);
                cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                lblMessage.Text = "Teléfono eliminado!";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                LoadTelefonos();
            }
        }

        protected void GvTelefonos_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvTelefonos.SelectedRow;
            txtCedula.Text = row.Cells[0].Text;
            txtTelefono.Text = row.Cells[1].Text;
        }
    }
}