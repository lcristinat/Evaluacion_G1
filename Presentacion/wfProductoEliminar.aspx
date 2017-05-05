<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfProductoEliminar.aspx.cs" Inherits="Presentacion.wfProductoEliminar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="panel panel-default">
        <div class="panel-heading">Registro de Usuarios</div>
        <div class="panel-body">
            <fieldset class="form-group">
                <legend>Datos Generales</legend>

                <div class="col-lg-3">
                    <div class="form-group">
                        <label class="control-label">Código de producto</label>
                        <asp:TextBox ID="txtCodigoProducto" runat="server" class="form-control" placeholder="Código de producto"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvCodigoProducto" runat="server" ErrorMessage="El campo código de producto es requerido" Font-Bold="True" ForeColor="Red" ControlToValidate="txtCodigoProducto">*</asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="col-lg-3">
                    <div class="form-group">
                        
                        <asp:Label ID="lblDescripcion" runat="server" Font-Bold="True"></asp:Label>
                        
                    </div>
                </div>

                <div class="col-lg-3">
                    <div class="form-group">
                        
                        <asp:CustomValidator ID="cvErrores" runat="server" Font-Bold="True" ForeColor="Red"></asp:CustomValidator>
                        
                    </div>
                </div>
                                
                 <div class="col-lg-3">
                    <div class="form-group">
                        
                        <label id="lblResultado" runat="server" class="color:Blue;"></label> 
                        
                    </div>
                </div>

</fieldset>

            <br />
            <div class="col-lg-4">
                <div class="form-group">
                    <asp:Button ID="btnConfirmar" runat="server" Text="Eliminar" class="btn btn-danger" OnClick="btnConfirmar_Click1" />
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" class="btn btn-info" OnClick="btnBuscar_Click1" />
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" class="btn btn-default" OnClick="btnCancelar_Click1" />
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