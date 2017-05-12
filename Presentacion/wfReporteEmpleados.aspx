<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfReporteEmpleados.aspx.cs" Inherits="Presentacion.wfReporteEmpleados" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <table style="width: 100%">
    <tr>
        <td>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" EnableViewState="true" Width="100%" Height="200px" >
            </rsweb:ReportViewer>
        &nbsp;</td>
    </tr>
        </Table>
        <Table>
    <tr>
        <td style="width: 739px">
            <asp:CustomValidator ID="cvdatos" runat="server" ErrorMessage="cvdatos" ForeColor="Red">*</asp:CustomValidator>
        </td>
    </tr>
    <tr>
        <td style="width: 739px">
            <asp:ValidationSummary ID="vsreporte" runat="server" ForeColor="Red" />
        </td>
    </tr>
    <tr>
        <td style="width: 739px">
            &nbsp;</td>
    </tr>
    </table>
</asp:Content>
