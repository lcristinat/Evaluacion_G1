<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfReporteCliente.aspx.cs" Inherits="Presentacion.wfReporteCliente" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">Listado de Clientes</div>
        <div class="panel-body">
            <fieldset class="form-group">
                <rsweb:ReportViewer ID="rvCliente" runat="server" Width="100%"></rsweb:ReportViewer>
            </fieldset>
             <div class="col-lg-4">
                <div class="form-group">
                     <asp:Button ID="btnSalir" runat="server" Text="Ir a Default" />
                    <asp:CustomValidator ID="cvDatos" runat="server" ErrorMessage="*"></asp:CustomValidator>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
