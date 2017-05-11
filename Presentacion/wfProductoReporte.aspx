<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfProductoReporte.aspx.cs" Inherits="Presentacion.wfProductoReporte" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="panel panel-default">
        <div class="panel-heading">Registro de Usuarios</div>
        <div class="panel-body">
            <fieldset class="form-group">
                <legend>Datos Generales</legend>

                <div class="col-lg-3">
                    <div class="form-group">
                        <rsweb:ReportViewer ID="rptvwReporte" runat="server" Width="1009px">
                        </rsweb:ReportViewer>
                        
                    </div>
                </div>
                                
</fieldset>
            
<br />
            <div class="col-lg-4">
                <div class="form-group">
                    <asp:Button ID="btnConfirmar" runat="server" Text="Aceptar" class="btn btn-success" OnClick="btnConfirmar_Click1" />
                    
                </div>
            </div>
        </div>
    </div>


    <script type="text/javascript">
        $(function () {
            $('#datetimepicker1').datetimepicker();
        });
    </script>


</asp:Content>
