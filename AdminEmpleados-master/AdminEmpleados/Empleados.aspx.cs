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
    public partial class Empleados : Page
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadEmpleados();
            }
        }

        protected void LoadEmpleados()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT CedulaEmpleado, Nombre, Apellido, FechaNacimiento, AniosTrabajados, AniosTrabajadosEnPuestosDiferentes FROM Empleados", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvEmpleados.DataSource = dt;
                gvEmpleados.DataBind();
            }
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Empleados (CedulaEmpleado, Nombre, Apellido, FechaNacimiento, AniosTrabajados, AniosTrabajadosEnPuestosDiferentes) " +
                               "VALUES (@Cedula, @Nombre, @Apellido, @FechaNacimiento, @AniosTrabajados, @AniosPuestos)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Cedula", txtCedula.Text);
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@Apellido", txtApellido.Text);
                cmd.Parameters.AddWithValue("@FechaNacimiento", txtFechaNacimiento.Text);
                cmd.Parameters.AddWithValue("@AniosTrabajados", txtAniosTrabajados.Text);
                cmd.Parameters.AddWithValue("@AniosPuestos", txtAniosPuestos.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                lblMessage.Text = "Empleado agregado exitosamente!";
                LoadEmpleados();
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE Empleados SET Nombre=@Nombre, Apellido=@Apellido, FechaNacimiento=@FechaNacimiento, AniosTrabajados=@AniosTrabajados, AniosTrabajadosEnPuestosDiferentes=@AniosPuestos " +
                               "WHERE CedulaEmpleado=@Cedula";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Cedula", txtCedula.Text);
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@Apellido", txtApellido.Text);
                cmd.Parameters.AddWithValue("@FechaNacimiento", txtFechaNacimiento.Text);
                cmd.Parameters.AddWithValue("@AniosTrabajados", txtAniosTrabajados.Text);
                cmd.Parameters.AddWithValue("@AniosPuestos", txtAniosPuestos.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                lblMessage.Text = "Empleado actualizado!";
                LoadEmpleados();
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Empleados WHERE CedulaEmpleado=@Cedula";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Cedula", txtCedula.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                lblMessage.Text = "Empleado eliminado!";
                LoadEmpleados();
            }
        }

        protected void GvEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvEmpleados.SelectedRow;
            txtCedula.Text = row.Cells[0].Text;
            txtNombre.Text = row.Cells[1].Text;
            txtApellido.Text = row.Cells[2].Text;
            txtFechaNacimiento.Text = row.Cells[3].Text;
            txtAniosTrabajados.Text = row.Cells[4].Text;
            txtAniosPuestos.Text = row.Cells[5].Text;
        }
    }
}