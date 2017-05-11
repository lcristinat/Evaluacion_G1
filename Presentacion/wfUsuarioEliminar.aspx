<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfUsuarioEliminar.aspx.cs" Inherits="Presentacion.wfUsuarioEliminar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">Eliminar Usuario</div>
        <div class="panel-body">
            <fieldset class="form-group">
                <legend>Datos Generales</legend> 
                <div class="col-lg-6">
                    <div class="form-group">
                        <label class="control-label">Còdigo de Usuario</label>
                        <asp:TextBox ID="txtCodigo" runat="server" class="form-control" placeholder="Còdigo de Usuario" ></asp:TextBox>
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" class="btn btn-success" OnClick="btnBuscar_Click" />
                    </div>
                </div>   
                <div class="col-lg-6">
                    <div class="form-group">
                        <label class="control-label">Nombre</label>
                        <asp:TextBox ID="txtNombre" runat="server" class="form-control" placeholder="Nombres y Apellidos de Usuario"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="rvNombre" runat="server" ErrorMessage="Nombre es requerido" ForeColor="Red" ControlToValidate="txtNombre">*</asp:RequiredFieldValidator>--%>
                    </div>
                </div>
                
            </fieldset>
                       
            <br />
            <div class="col-lg-3">
                <div class="form-group">
                    <asp:Button ID="btnGuardar" runat="server" Text="Eliminar" class="btn btn-success" OnClick="btnGuardar_Click" />
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" class="btn btn-default" OnClick="btnCancelar_Click" />
                    <br />
                    <asp:Label ID="lblMensaje" runat="server" Font-Size="Smaller" ForeColor="Red"></asp:Label>
                    <asp:CustomValidator ID="CV_Datos" runat="server" ErrorMessage="CustomValidator" ForeColor="Blue">*</asp:CustomValidator>
                    <asp:ValidationSummary ID="VS_Datos" runat="server" DisplayMode="List" Font-Size="Smaller" ForeColor="Red" />
                </div>
            </div>
        </div>
    </div>


</asp:Content>
