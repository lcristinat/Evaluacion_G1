using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class wfFactura : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                txtFecha.Text = DateTime.Now.ToShortDateString();

                CargarProducto();
            }
        }
        protected void CargarProducto()
        {

        }


        #region/*PAGINACION GRIDVIEW*/
        protected void IraPag(object sender, EventArgs e)
        {
            TextBox _IraPag = (TextBox)sender;
            int _NumPag = 0;

            if (int.TryParse(_IraPag.Text, out _NumPag) && _NumPag > 0 && _NumPag <= this.gvUsuarios.PageCount)
            {
                if (int.TryParse(_IraPag.Text, out _NumPag) && _NumPag > 0 && _NumPag <= this.gvUsuarios.PageCount)
                {
                    this.gvUsuarios.PageIndex = _NumPag - 1;
                    CargarProducto();
                }
                else
                {
                    this.gvUsuarios.PageIndex = 0;
                    CargarProducto();
                }
            }

            this.gvUsuarios.SelectedIndex = -1;
        }

        private int getpageindex(GridView gv, string clave)
        {
            if (clave == "Firts")
            {
                return 0;
            }

            else if (clave == "Next")
            {
                return gv.PageIndex + 1;
            }

            if (clave == "Last")
            {
                return gv.PageCount - 1;
            }

            else if (clave == "Prev")
            {
                return gv.PageIndex - 1;
            }

            else
            {
                return gv.PageIndex;
            }
        }

        protected void gvUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Pager)
            {
                //PAGINADO
                //TOTAL PAGINAS
                Label _TotalPags = (Label)e.Row.FindControl("lblTotalNumberOfPages");
                _TotalPags.Text = gvUsuarios.PageCount.ToString();
                // IR A PAGINA
                TextBox _IraPag = (TextBox)e.Row.FindControl("IraPag");
                _IraPag.Text = (gvUsuarios.PageIndex + 1).ToString();

                // ASIGNA AL DROPDOWNLIST COMO VALOR SELECCIONADO EL PAGESIZE ACTUAL
                DropDownList _DropDownList = (DropDownList)e.Row.FindControl("RegsPag");
                _DropDownList.SelectedValue = gvUsuarios.PageSize.ToString();
            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // APLICA ESTILOS A EVENTOS ON MOUSE OVER Y OUT
                e.Row.Attributes.Add("OnMouseOut", "this.className = this.orignalclassName;");
                //e.Row.Attributes.Add("OnMouseOver", "this.orignalclassName = this.className;this.className = 'altoverow';");
            }
        }

        protected void RegsPag_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CAMBIAR NUMERO DE FILAS A MOSTRAR
            //OBTIENE EL NUMERO ELEGIDO
            DropDownList _DropDownList = (DropDownList)sender;
            // CAMBIA EL PAGESIZE DEL GRID ASIGNANDO EL ELEGIDO
            gvUsuarios.PageSize = int.Parse(_DropDownList.SelectedValue);
            CargarProducto();
        }

        protected void gvUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (e.NewPageIndex >= 0)
            {
                gvUsuarios.PageIndex = e.NewPageIndex;
                CargarProducto();
            }
        }
        #endregion

        protected void gvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string identificador = e.CommandArgument.ToString();
            if (e.CommandName == "ELIMINAR")
            {
                /*codigo para eliminar*/
            }
            else
            {
                /*Codigo para editar*/
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Negocio.ClienteNegocio dc = new Negocio.ClienteNegocio();
            Entidad.Clientes cliente = dc.ObtenerCliente(int.Parse(txtCliente.Text.Trim()));
            
            if(cliente !=null)
            {
                //recupera Nombre del cliente
                txtNombre.Text = cliente.Nombre.ToUpper();
            }
            else
            {
                cvDatos.IsValid = false;
                cvDatos.ErrorMessage = "No se encontro coincidencia en la BD";
            }
            try
            {

            }
            catch (Exception err)
            {

                cvDatos.IsValid = false;
                cvDatos.ErrorMessage = err.Message;
            }
            
        }

      
    }
}