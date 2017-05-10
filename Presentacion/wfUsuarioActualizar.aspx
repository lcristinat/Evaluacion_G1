﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfUsuarioActualizar.aspx.cs" Inherits="Presentacion.wfUsuarioActualizar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">Actualizar Usuario</div>
        <div class="panel-body">
            <fieldset class="form-group">
                <legend>Datos Generales</legend> 
                <div class="col-lg-6">
                    <div class="form-group">
                        <label class="control-label">Còdigo de Usuario</label>
                        <asp:TextBox ID="txtCodigo" runat="server" class="form-control" placeholder="Còdigo de Usuario" ></asp:TextBox>
                        <br />
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" class="btn btn-success" OnClick="btnBuscar_Click" />
                        <br />
                        <asp:RequiredFieldValidator ID="rvCodigo" runat="server" ErrorMessage="Còdigo es requerido" ForeColor="Red" ControlToValidate="txtCodigo">*</asp:RequiredFieldValidator>
                    </div>
                </div>   
                <div class="col-lg-6">
                    <div class="form-group">
                        <label class="control-label">Nombre</label>
                        <asp:TextBox ID="txtNombre" runat="server" class="form-control" placeholder="Nombres y Apellidos de Usuario"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rvNombre" runat="server" ErrorMessage="Nombre es requerido" ForeColor="Red" ControlToValidate="txtNombre">*</asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="col-lg-3">
                    <div class="form-group">
                        <label class="control-label">Número de Cédula</label>
                        <asp:TextBox ID="txtNumeroCedula" runat="server" class="form-control" placeholder="000-000000-0000X" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rvCedula" runat="server" ControlToValidate="txtNumeroCedula" ErrorMessage="Cèdula es Requerida" ForeColor="Red">*</asp:RequiredFieldValidator>
                     </div>
                </div>
            </fieldset>
            <fieldset class="form-group">
                <legend>Datos de Acceso</legend>
                <div class="col-lg-3">
                    <div class="form-group">
                        <label class="control-label">Login</label>
                        <asp:TextBox ID="txtLogin" runat="server" class="form-control" placeholder="Login" ></asp:TextBox>
                         <asp:RequiredFieldValidator ID="rvLogin" runat="server" ControlToValidate="txtLogin" ErrorMessage="Login es requerido" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </div>
                </div>
                 
                <div class="col-lg-3">
                    <div class="form-group">
                        <label class="control-label">Clave</label>
                        <asp:TextBox ID="txtClave" runat="server" class="form-control" TextMode="Password" placeholder="Clave" ></asp:TextBox>
                         <asp:RequiredFieldValidator ID="rvClave" runat="server" ControlToValidate="txtClave" ErrorMessage="Clave es requerida" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </div>
                </div>
               
            </fieldset>
            
            <br />
            <div class="col-lg-3">
                <div class="form-group">
                    <asp:Button ID="btnGuardar" runat="server" Text="Actualizar" class="btn btn-success" OnClick="btnGuardar_Click" />
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
