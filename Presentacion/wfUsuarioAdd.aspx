<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfUsuarioAdd.aspx.cs" Inherits="Presentacion.wfUsuarioAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="panel panel-default">
        <div class="panel-heading">Registrar Usuarios</div>
        <div class="panel-body">
            <fieldset class="form-group">
                <legend>Datos Generales</legend>    
                <div class="col-lg-6">
                    <div class="form-group">
                        <label class="control-label">Nombre</label>
                        <asp:TextBox ID="txtPrimerNombre" runat="server" class="form-control" placeholder="Nombres y Apellidos de Usuario" required></asp:TextBox>
                    </div>
                </div>
            </fieldset>
            <fieldset class="form-group">
                <legend>Datos de Acceso</legend>
                <div class="col-lg-3">
                    <div class="form-group">
                        <label class="control-label">Login</label>
                        <asp:TextBox ID="txtLogin" runat="server" class="form-control" placeholder="Login" required></asp:TextBox>
                    </div>
                </div>
              
                <div class="col-lg-3">
                    <div class="form-group">
                        <label class="control-label">Clave</label>
                        <asp:TextBox ID="txtClave" runat="server" class="form-control" placeholder="Clave" required></asp:TextBox>
                    </div>
                </div>
            </fieldset>
            <fieldset class="form-group">
                <div class="col-lg-3">
                    <div class="form-group">
                        <label class="control-label">Número de Cédula</label>
                        <asp:TextBox ID="txtNumeroCedula" runat="server" class="form-control" placeholder="000-000000-0000X" required></asp:TextBox>
                     </div>
                </div>
                <br />
                <div class="col-lg-3">
                     <div class="form-group">
                        <asp:Button ID="btnValida_Cedula" runat="server" Text="Validar Cèdula" class="btn btn-info" />
                     </div>
                </div>

            </fieldset>
          
            
            <br />
            <div class="col-lg-3">
                <div class="form-group">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn btn-danger" />
                    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" class="btn btn-info" />
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" class="btn btn-default" />
                </div>
            </div>
        </div>
    </div>


    
</asp:Content>
