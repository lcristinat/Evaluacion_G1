<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfEliminarCliente.aspx.cs" Inherits="Presentacion.wfEliminarCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="panel panel-default">
        <div class="panel-heading">Edicion de Clientes</div>
        <div class="panel-body">
            <fieldset class="form-group">
                <div class="col-lg-3">
                    <div class="form-group">
                        <label class="control-label">Id</label>
  
                        <asp:TextBox ID="txtIdCliente" runat="server" class="form-control" OnTextChanged="txtIdCliente_TextChanged" AutoPostBack="True" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ForeColor="Red" ControlToValidate="txtIdCliente" ErrorMessage="El ID ES REQUERIDO" Text="*" Font-Bold ="true" Font-Size="Larger"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revCliente" runat="server" ControlToValidate="txtIdCliente" ErrorMessage="SOLOS SE PERMITEN VALORES NUMERICOS"
                            ForeColor="Red" ValidationExpression="^[0-9]*" Font-Bold ="true" Font-Size="Larger" Text ="*">
                        </asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="col-lg-3">
                    <div class="form-group">
                        <label class="control-label">Nombre del Cliente</label>
                        <asp:TextBox ID="txtNombre" runat="server" class="form-control" placeholder="Nombre del Cliente" ReadOnly ="true"></asp:TextBox>
                    </div>
                </div>
            </fieldset>
            <div class ="row">
                <div class="col-lg-4">
                    <div class="form-group">
                       <asp:CustomValidator ID="cvDatos" runat="server" ForeColor ="Red" Text="*"></asp:CustomValidator>
                        <asp:ValidationSummary ID="vsCliente" runat="server" DisplayMode = "List" ForeColor ="Red" Font-Size ="Smaller" />
                        <asp:Label ID="lblMensaje" CssClass="alert-success" runat="server" Text="*" Visible="false"></asp:Label>
                    </div>
                </div>
            </div>
            <br />
            <div class="col-lg-4">
                <div class="form-group">
                    <asp:Button ID="btnEliminar" runat="server"  Text="Eliminar" class="btn bg-olive btn-lg btn-block" OnClick="btnEliminar_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
