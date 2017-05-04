<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfEditarCliente.aspx.cs" Inherits="Presentacion.wfEditarCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="panel panel-default">
        <div class="panel-heading">Edicion de Clientes</div>
        <div class="panel-body">
            <fieldset class="form-group">
                <div class="col-lg-3">
                    <div class="form-group">
                        <label class="control-label">Id</label>
                        <asp:TextBox ID="txtIdCliente" runat="server" class="form-control" placeholder="Codigo del Cliente" required></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3">
                    <div class="form-group">
                        <label class="control-label">Nombre del Cliente</label>
                        <asp:TextBox ID="txtNombre" runat="server" class="form-control" placeholder="Nombre del Cliente" required></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3">
                    <div class="form-group">
                        <label class="control-label">Número de Cédula</label>
                        <asp:TextBox ID="txtNumeroCedula" runat="server" class="form-control" placeholder="000-000000-0000X" required></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3">
                    <div class="form-group">
                        <label class="control-label">Direccion</label>
                        <asp:TextBox ID="txtDireccion" runat="server" class="form-control" placeholder="Direccion" required></asp:TextBox>
                    </div>
                </div>
            </fieldset>
            <br />
            <div class="col-lg-4">
                <div class="form-group">
                    <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" class="btn btn-danger" />
                    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" class="btn btn-info" />
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" class="btn btn-default" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
