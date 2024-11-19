<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeBehind="DireccionesEmpleado.aspx.cs" Inherits="AdminEmpleados.DireccionesEmpleado" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CRUD de Direcciones de Empleados</title>
    <link rel="stylesheet" type="text/css" href="styles.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Administrar Direcciones de Empleados</h2>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Green"></asp:Label><br />
            <asp:Label ID="lblCedula" runat="server" Text="Cédula Empleado: "></asp:Label>
            <asp:TextBox ID="txtCedula" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblCalle" runat="server" Text="Calle: "></asp:Label>
            <asp:TextBox ID="txtCalle" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblCiudad" runat="server" Text="Ciudad: "></asp:Label>
            <asp:TextBox ID="txtCiudad" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblNumero" runat="server" Text="Número: "></asp:Label>
            <asp:TextBox ID="txtNumero" runat="server"></asp:TextBox><br /><br />
            <asp:Button ID="btnAdd" runat="server" Text="Agregar" OnClick="BtnAdd_Click" CssClass="styled-button"/>
            <asp:Button ID="btnUpdate" runat="server" Text="Actualizar" OnClick="BtnUpdate_Click" CssClass="styled-button"/>
            <asp:Button ID="btnDelete" runat="server" Text="Eliminar" OnClick="BtnDelete_Click" CssClass="styled-button"/>
            <br /><br />

            <!-- Tabla para mostrar direcciones de empleados -->
            <asp:GridView ID="gvDirecciones" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GvDirecciones_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="CedulaEmpleado" HeaderText="Cédula Empleado" />
                    <asp:BoundField DataField="Calle" HeaderText="Calle" />
                    <asp:BoundField DataField="Ciudad" HeaderText="Ciudad" />
                    <asp:BoundField DataField="Numero" HeaderText="Número" />
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
