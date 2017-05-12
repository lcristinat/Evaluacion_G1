<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfEmpleadoEdit.aspx.cs" Inherits="Presentacion.wfEmpleadoEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <div class="panel panel-default">
        <div class="panel-heading">Registro de Empleados</div>
        <div class="panel-body">
            <fieldset class="form-group">
                          <div class="col-lg-3">
                    <div class="form-group">
                        <label class="control-label">Código Empleado</label>
                        <asp:RequiredFieldValidator ID="rfvCodEmp" runat="server" ForeColor="Red" ControlToValidate="txtCodigoEmpleado" ErrorMessage="Campo Código vacío, por favor ingresar" Text="*" ></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtCodigoEmpleado" runat="server" class="form-control" placeholder="Código" AutoPostBack="True" OnTextChanged="txtCodigoEmpleado_TextChanged" ></asp:TextBox>
                        <asp:RangeValidator ID="rvCodigo" runat="server" ErrorMessage="Solo se permiten números" ControlToValidate="txtCodigoEmpleado" MaximumValue="999" MinimumValue="1" Type="Integer" Text="*" ForeColor="Red"></asp:RangeValidator>  
                    </div>
                </div>

                   <div class="col-lg-3">
                    <div class="form-group">
                        <label class="control-label">Nombre del Empleado</label>
                        <asp:RequiredFieldValidator ID="rvfNombre" runat="server" ForeColor="Red" ControlToValidate="txtNombre" ErrorMessage="Campo Nombre vacío, por favor ingresar" Text="*" ></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtNombre" runat="server" class="form-control" placeholder="Nombre del Empleado" Style="text-transform: uppercase"></asp:TextBox>
                         <asp:RegularExpressionValidator ID="revNombre" runat="server" ErrorMessage="Campo valido solo para letras" ForeColor="Red" ControlToValidate="txtNombre" ValidationExpression="^[a-zA-Z ]*$" Text="*"></asp:RegularExpressionValidator>
                    </div>
                </div>

                <div class="col-lg-3">
                    <div class="form-group">
                        <label class="control-label">Número de Cédula</label>
                        <asp:RequiredFieldValidator ID="rvfCedula" runat="server" ForeColor="Red" ControlToValidate="txtNumeroCedula" ErrorMessage="Campo Cedula vacío, por favor ingresar" Text="*" ></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtNumeroCedula" runat="server" class="form-control" placeholder="0000000000000X" Style="text-transform: uppercase"></asp:TextBox>
                       
                    </div>
                </div>
                <div class="col-lg-3">
                    <div class="form-group">
                        <label class="control-label">Dirección</label>
                         <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ForeColor="Red" ControlToValidate="txtDireccion" ErrorMessage="Campo Dirección vacío, por favor ingresar" Text="*" ></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtDireccion" runat="server" class="form-control" placeholder="Dirección" Style="text-transform: uppercase"></asp:TextBox>
                    </div>
                </div>                           
       </fieldset>
           <div class ="row">
                <div class="col-lg-4">
                    <div class="form-group">
                       <asp:CustomValidator ID="cvDatos" runat="server" ForeColor ="Red" Text="*"></asp:CustomValidator>
                         <asp:ValidationSummary ID="vsEmpleado" runat="server" DisplayMode = "List" ForeColor ="Red" Font-Size ="Smaller"/>
                       <asp:Label ID="lblMensaje"  runat="server" Text="*" Visible="false" ForeColor="Red"></asp:Label>
                    </div>
                </div>
          </div>
            <br />
            <br />
            <br />

             <div class="col-lg-4">
                <div class="form-group">
                    <asp:Button ID="btnGuardar" runat="server" Text="Confirmar" class="btn btn-success" OnClick="btnGuardar_Click" />
                    <asp:Button ID="Button1" runat="server" Text="Limpiar" class="btn btn-info" OnClick="btnLimpiar_Click" CausesValidation="false"/>
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" class="btn btn-default" OnClick="btnCancelar_Click" CausesValidation="false" />
                </div>
            </div>
        </div>
    </div>


</asp:Content>
