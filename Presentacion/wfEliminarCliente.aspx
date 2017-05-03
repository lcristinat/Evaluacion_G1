<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfEliminarCliente.aspx.cs" Inherits="Presentacion.wfEliminarCliente" %>
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
                        <asp:TextBox ID="txtNombre" runat="server" class="form-control" placeholder="Nombre del Cliente" ReadOnly ="true"></asp:TextBox>
                    </div>
                </div>
            </fieldset>
            <br />
            <div class="col-lg-4">
                <div class="form-group">
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" class="btn bg-olive btn-lg btn-block" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
