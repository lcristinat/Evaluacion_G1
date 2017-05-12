<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfEmpleadoBaja.aspx.cs" Inherits="Presentacion.wfEmpleadoBaja" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">Baja de Empleado</div>
        <div class="panel-body">
            <fieldset class="form-group">
                <div class="col-lg-3">
                    <div class="form-group">
                        <label class="control-label">Codigo Empleado</label>
                        <asp:RequiredFieldValidator ID="rvfCodigoEmp" runat="server" ForeColor="Red" ControlToValidate="txtCodigoEmpleado" ErrorMessage="Campo Código Empleado vacío, por favor ingresar" Text="*"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtCodigoEmpleado" runat="server" class="form-control" placeholder="Código" AutoPostBack="True" OnTextChanged="txtCodigoEmpleado_TextChanged"></asp:TextBox>
                        <asp:RangeValidator ID="rvCodigo" runat="server" ErrorMessage="Solo se permiten números" ControlToValidate="txtCodigoEmpleado" MaximumValue="999" MinimumValue="1" Type="Integer" Text="*" ForeColor="Red"></asp:RangeValidator>
                    </div>
                </div>

                <div class="col-lg-3">
                    <div class="form-group">
                        <label class="control-label">Nombre del Empleado</label>
                        <asp:RequiredFieldValidator ID="rvfNombre" runat="server" ForeColor="Red" ControlToValidate="txtNombre" ErrorMessage="Campo Nombre vacío, por favor ingresar" Text="*"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtNombre" runat="server" class="form-control" placeholder="Nombre"></asp:TextBox>
                    </div>
                </div>

            </fieldset>
            <div class="row">
                <div class="col-lg-4">
                    <div class="form-group">
                        <asp:CustomValidator ID="cvDatos" runat="server" ForeColor="Red" Text="*" Font-Size ="Smaller"></asp:CustomValidator>
                        <asp:ValidationSummary ID="vsEmpleado" runat="server" DisplayMode="List" ForeColor="Red" Font-Size ="Smaller"/>
                        <asp:Label ID="lblMensaje" runat="server" Text="*" Visible="false" ForeColor="Red"></asp:Label>
                    </div>
                </div>
           </div>
                <br />
                <br />
                <br />
                <div class="col-lg-4">
                    <div class="form-group">
                        <asp:Button ID="btnGuardar" runat="server" Text="Confirmar" class="btn btn-success" OnClick="btnGuardar_Click" />
                        <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" class="btn btn-info" OnClick="btnLimpiar_Click" CausesValidation="false" />
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" class="btn btn-default" OnClick="btnCancelar_Click" CausesValidation="false" />
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
