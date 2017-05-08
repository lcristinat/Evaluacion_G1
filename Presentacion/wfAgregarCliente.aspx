<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfAgregarCliente.aspx.cs" Inherits="Presentacion.wfAgregarCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">Registro de Clientes</div>
        <div class="panel-body">
            <fieldset class="form-group">
                <div class="col-lg-4">
                    <div class="form-group">
                        <label class="control-label">Nombre del Cliente</label>
                        <asp:RequiredFieldValidator ID="rvfNombre" runat="server" ForeColor="Red" ControlToValidate="txtNombre" ErrorMessage="El Nombre es requerido" Text="*" Font-Bold ="true" Font-Size="Larger"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtNombre" runat="server" class="form-control" placeholder="Nombre del Cliente" Style="text-transform: uppercase" ></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="form-group">
                        <label class="control-label">Número de Cédula</label>
                        <asp:RequiredFieldValidator ID="rvfCedula" runat="server" ForeColor="Red" ControlToValidate="txtNumeroCedula" ErrorMessage="El Numero de Cedula es requerido" Text="*" Font-Bold ="true" Font-Size="Larger"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtNumeroCedula" runat="server" class="form-control" placeholder="0000000000000X" Style="text-transform: uppercase"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="form-group">
                        <label class="control-label">Direccion</label>
                        <asp:RequiredFieldValidator ID="rvfDireccion" runat="server" ForeColor="Red" ControlToValidate="txtDireccion" ErrorMessage="La Direccion es requerida" Text="*" Font-Bold ="true" Font-Size="Larger"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtDireccion" runat="server" class="form-control" placeholder="Direccion" Style="text-transform: uppercase"></asp:TextBox>
                        
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
            <div class="col-lg-4">
                <div class="form-group">
                    <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" class="btn btn-success" OnClick="btnConfirmar_Click" />
                    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" class="btn btn-info" OnClick="btnLimpiar_Click"/>
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" class="btn btn-default" OnClick="btnCancelar_Click" />
                </div>
            </div>
            <br />
            
            

        </div>
    </div>
</asp:Content>
