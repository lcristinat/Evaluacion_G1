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
            
            Negocio.ProductoNegocio dc = new Negocio.ProductoNegocio();
            List<Entidad.Productos> productos = dc.ListaProducto();
           

            if (productos.Count > 0)
            {
                ListItem sel = new ListItem();
                sel.Value = "0";
                sel.Text = "Seleccione...";
                ddlProducto.Items.Add(sel);
                ddlProducto.DataSource = productos;
                ddlProducto.DataTextField = "descripcion";
                ddlProducto.DataValueField = "Id";
                ddlProducto.DataBind();
            } //cierra IF carreras tiene datos validos...
            else
            {
                cvDatos.IsValid = false;
                cvDatos.ErrorMessage = "No hay datos en el catalogo de productos";
                btnAgregar.Enabled = false;
            } //cierra ELSE de validacion de carreras...
        }
  


        #region/*PAGINACION GRIDVIEW*/
        protected void IraPag(object sender, EventArgs e)
        {
            TextBox _IraPag = (TextBox)sender;
            int _NumPag = 0;

            if (int.TryParse(_IraPag.Text, out _NumPag) && _NumPag > 0 && _NumPag <= this.gvFaturaDetalle.PageCount)
            {
                if (int.TryParse(_IraPag.Text, out _NumPag) && _NumPag > 0 && _NumPag <= this.gvFaturaDetalle.PageCount)
                {
                    this.gvFaturaDetalle.PageIndex = _NumPag - 1;
                    CargarProducto();
                }
                else
                {
                    this.gvFaturaDetalle.PageIndex = 0;
                    CargarProducto();
                }
            }

            this.gvFaturaDetalle.SelectedIndex = -1;
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

        protected void gvFaturaDetalle_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Pager)
            {
                //PAGINADO
                //TOTAL PAGINAS
                Label _TotalPags = (Label)e.Row.FindControl("lblTotalNumberOfPages");
                _TotalPags.Text = gvFaturaDetalle.PageCount.ToString();
                // IR A PAGINA
                TextBox _IraPag = (TextBox)e.Row.FindControl("IraPag");
                _IraPag.Text = (gvFaturaDetalle.PageIndex + 1).ToString();

                // ASIGNA AL DROPDOWNLIST COMO VALOR SELECCIONADO EL PAGESIZE ACTUAL
                DropDownList _DropDownList = (DropDownList)e.Row.FindControl("RegsPag");
                _DropDownList.SelectedValue = gvFaturaDetalle.PageSize.ToString();
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
            gvFaturaDetalle.PageSize = int.Parse(_DropDownList.SelectedValue);
            CargarProducto();
        }

        protected void gvFaturaDetalle_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (e.NewPageIndex >= 0)
            {
                gvFaturaDetalle.PageIndex = e.NewPageIndex;
                CargarProducto();
            }
        }
        #endregion

        protected void gvFaturaDetalle_RowCommand(object sender, GridViewCommandEventArgs e)
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

        protected void ddlProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                Entidad.Productos producto = new Entidad.Productos();
                List<Entidad.Productos> a = new List<Entidad.Productos>();

                if (Session["s_Productos"] != null)
                {
                    a = (List<Entidad.Productos>)Session["s_Productos"];

                }// cierra IF asignaturas tiene datos vaidos...
                bool existe = false;
                if (a.Count > 0)
                    existe = ExisteProducto(int.Parse(ddlProducto.SelectedValue));
                if (!existe)
                {
                    producto.Id= int.Parse(ddlProducto.SelectedValue);
                    producto.Descripcion = ddlProducto.SelectedItem.Text;
                    txtCantidad.Focus();
                    
                    producto.Existencia = 5;
                    producto.PrecioUnitario = 10;
                    a.Add(producto);
                }
                else
                {
                    cvDatos.IsValid = false;
                    cvDatos.ErrorMessage = "Producto seleccionado ya esta en la lista";
                }
                Session["s_Productos"] = a;
                gvFaturaDetalle.DataSource = a;
                gvFaturaDetalle.DataBind();
                


            } //cierra el TRY...
            catch (Exception err)
            {
                cvDatos.IsValid = false;
                cvDatos.ErrorMessage = err.Message;
            }
        }
        protected bool ExisteProducto(int codProducto)
        {
            bool resp = false;
            List<Entidad.Productos> ProductoGrid = (List<Entidad.Productos>)Session["s_Productos"];
            foreach (var item in ProductoGrid)
            {
                if (item.Id == codProducto)
                {
                    resp = true; break;
                }
            }
            return resp;
        }
        private class DetalleFactura

        {
            public int idfacturac { get; set; }
            public int idproductoc { get; set; }
            public int cantidadc { get; set; }
            public double valorc { get; set; }
        }
    }
}