<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeBehind="Empleados.aspx.cs" Inherits="AdminEmpleados.Empleados" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Empleados CRUD</title>
    <link rel="stylesheet" type="text/css" href="styles.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Administrar Empleados</h2>
            
            <!-- Formulario para agregar o editar empleados -->
            <asp:Label ID="lblMessage" runat="server" ForeColor="Green"></asp:Label><br />
            <asp:Label ID="lblCedula" runat="server" Text="Cédula: "></asp:Label>
            <asp:TextBox ID="txtCedula" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblNombre" runat="server" Text="Nombre: "></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblApellido" runat="server" Text="Apellido: "></asp:Label>
            <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha de Nacimiento: "></asp:Label>
            <asp:TextBox ID="txtFechaNacimiento" runat="server" TextMode="Date"></asp:TextBox><br />
            <asp:Label ID="lblAniosTrabajados" runat="server" Text="Años Trabajados: "></asp:Label>
            <asp:TextBox ID="txtAniosTrabajados" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblAniosPuestos" runat="server" Text="Años en Puestos Diferentes: "></asp:Label>
            <asp:TextBox ID="txtAniosPuestos" runat="server"></asp:TextBox><br /><br />
            <asp:Button ID="btnAdd" runat="server" Text="Agregar" OnClick="BtnAdd_Click" CssClass="styled-button"/>
            <asp:Button ID="btnUpdate" runat="server" Text="Actualizar" OnClick="BtnUpdate_Click" CssClass="styled-button"/>
            <asp:Button ID="btnDelete" runat="server" Text="Eliminar" OnClick="BtnDelete_Click" CssClass="styled-button"/>
            <br /><br />

            <!-- Tabla para mostrar empleados -->
            <asp:GridView ID="gvEmpleados" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GvEmpleados_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="CedulaEmpleado" HeaderText="Cédula" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                    <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha de Nacimiento" />
                    <asp:BoundField DataField="AniosTrabajados" HeaderText="Años Trabajados" />
                    <asp:BoundField DataField="AniosTrabajadosEnPuestosDiferentes" HeaderText="Años en Puestos Diferentes" />
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
