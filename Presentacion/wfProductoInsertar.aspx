<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfProductoInsertar.aspx.cs" Inherits="Presentacion.wfProductoInsertar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <div class="panel panel-default">
        <div class="panel-heading">Registro de Usuarios</div>
        <div class="panel-body">
            <fieldset class="form-group">
                <legend>Datos Generales</legend>

                <div class="col-lg-3">
                    <div class="form-group">

                        <label class="control-label">Descripción</label>
                        <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" ErrorMessage="El campo descripción no puede estar vacío" Font-Bold="True" ForeColor="Red" ControlToValidate="txtDescripcion">*</asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtDescripcion" class="form-control" runat="server" Width="217px"></asp:TextBox>
                        
                    </div>
                </div>

                <div class="col-lg-3">
                    <div class="form-group">

                        <label class="control-label">Existencia</label>
                        <asp:RequiredFieldValidator ID="rfvExistencia" runat="server" ErrorMessage="El campo existencia no puede estar vacío" Font-Bold="True" ForeColor="Red" ControlToValidate="txtExistencia">*</asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtExistencia" class="form-control" runat="server" Width="220px"></asp:TextBox>
                        

                    </div>
                </div>

                <div class="col-lg-3">
                    <div class="form-group">

                        <label class="control-label">Precio</label>
                        <asp:RequiredFieldValidator ID="rfvPrecio" runat="server" ErrorMessage="El campo precio no puede estar vacío" Font-Bold="True" ForeColor="Red" ControlToValidate="txtPrecio">*</asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtPrecio" class="form-control" runat="server"></asp:TextBox>
                

                    </div>
                </div>
    
                <div class="col-lg-3">
                    <div class="form-group">
                    
                        <asp:CustomValidator ID="cvErrores" runat="server" ErrorMessage="Ocurrió un error al guardar" Font-Bold="True" ForeColor="Red" Text="Ocurrió un error al guardar"></asp:CustomValidator>
         
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
                    <asp:Button ID="btnConfirmar" runat="server" Text="Guardar" class="btn btn-success" OnClick="btnConfirmar_Click1"/>
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
