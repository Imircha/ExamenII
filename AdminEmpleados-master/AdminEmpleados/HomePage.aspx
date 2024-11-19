<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="AdminEmpleados.HomePage" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Bienvenido al Sistema de Administración de Empleados</title>
    <link rel="stylesheet" type="text/css" href="styles.css" />
</head>
<body>
    <form runat="server">
        <div>
            <h2>Bienvenido al Sistema de Administración de Empleados</h2>
            
            <p>Accede a las funcionalidades del sistema:</p>
            <ul>
                <li><a href="Empleados.aspx">Administrar Empleados</a></li>
                <li><a href="TelefonosEmpleado.aspx">Administrar Teléfonos de Empleados</a></li>
                <li><a href="DireccionesEmpleado.aspx">Administrar Direcciones de Empleados</a></li>
                <li><a href="PuestosEmpleado.aspx">Administrar Puestos de Empleados</a></li>
            </ul>

            <asp:Button ID="btnLogout" runat="server" Text="Cerrar sesión" OnClick="btnLogout_Click" CssClass="styled-button"/>
        </div>
    </form>
</body>
</html>
