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
                Session.Add("s_Productos", productos);
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

      
        protected bool ExisteProducto(string codProducto)
        {
            bool resp = false;
            List<DetalleFactura> ProductoGrid = (List<DetalleFactura>)Session["s_DetalleFactura"];
            foreach (var item in ProductoGrid)
            {
                if (item.idProducto == codProducto)
                {
                    resp = true; break;
                }
            }
            return resp;
        }
        //Creamos una Clase Temporal con los mismo atributos de la Tabla Producto
        private class DetalleFactura

        {
            public string idProducto { get; set; }
            public string descripcion { get; set; }
            public string cantidad { get; set; }
            public string precioUnitario { get; set; }
            public string importe { get; set; }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            double ir;
           double neto  ;
            ir = 0.00;
            neto = 0.00;
            try
            {

                DetalleFactura detallef = new DetalleFactura();
                List<DetalleFactura> a = new List<DetalleFactura>();

                if (Session["s_DetalleFactura"] != null)
                {
                    a = (List<DetalleFactura>)Session["s_DetalleFactura"];

                }// cierra IF asignaturas tiene datos vaidos...
                bool existe = false;
                if (a.Count > 0)
                    existe = ExisteProducto(ddlProducto.SelectedValue);
                if (!existe)
                {
                    detallef.idProducto = ddlProducto.SelectedValue;
                    detallef.descripcion = ddlProducto.SelectedItem.Text;
                    detallef.cantidad = txtCantidad.Text;
                    List<Entidad.Productos> productosBD = (List<Entidad.Productos>)Session["s_Productos"];
                    int cantProducto = int.Parse(txtCantidad.Text.Trim());
                    decimal precioUnitario = productosBD.Where(p => p.Id == int.Parse(detallef.idProducto)).FirstOrDefault().PrecioUnitario;
                    decimal importeProducto = cantProducto * precioUnitario;
                    detallef.precioUnitario = precioUnitario.ToString();
                    detallef.importe = importeProducto.ToString();
                    a.Add(detallef);
                    //calculando totales de la factura....
                    txtSubtotal.Text = (from x in a select decimal.Parse(x.importe)).Sum().ToString();
                }
                else
                {
                    cvDatos.IsValid = false;
                    cvDatos.ErrorMessage = "Producto seleccionado ya esta en la lista";
                }
                Session["s_DetalleFactura"] = a;
                ir =ir+ double.Parse(txtSubtotal.Text.ToString())*.15;
                neto = double.Parse(txtSubtotal.Text.ToString()) + ir;
                txtImpuesto.Text = ir.ToString();
                txtTotal.Text = neto.ToString();

                gvFaturaDetalle.DataSource = a;
                gvFaturaDetalle.DataBind();



            } //cierra el TRY...
            catch (Exception err)
            {
                cvDatos.IsValid = false;
                cvDatos.ErrorMessage = err.Message;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
           
            try
            {

               
                
                Entidad.Facturas f = new Entidad.Facturas();
                List<Entidad.Factura_Detalle> fd1 = new List<Entidad.Factura_Detalle>();
               
                //Asignamos los Valores recibos por pantalla
                f.IdCliente = int.Parse(txtCliente.Text);
                f.Fecha = DateTime.Now;
                f.FechaProceso = DateTime.Now;
                f.Estado = 1;
                f.Total = decimal.Parse(txtTotal.Text);
                f.Impuesto = decimal.Parse(txtImpuesto.Text);

                //Instancias a dc lo que tiene la Capa Negocio de Factutra
                Negocio.FacturaNegocio dc = new Negocio.FacturaNegocio();

                //creamos una variable con los valores de la clase de Producto creada Temporalmente
                List<DetalleFactura> productoFactura = (List<DetalleFactura>)Session["s_DetalleFactura"];
                
                //llenamos la entidad  Factura detalle con lo que contiene la Session "s_DetalleFactura
                foreach (DetalleFactura item in productoFactura)
                {
                    Entidad.Factura_Detalle fd = new Entidad.Factura_Detalle();
                    fd.IdProducto = int.Parse(item.idProducto);
                    fd.Valor = decimal.Parse(item.importe);
                    fd.Cantidad = int.Parse(item.cantidad);
                    fd.Valor = decimal.Parse(item.importe);
                    fd.FechaProceso = DateTime.Now;

                    fd1.Add(fd);
                    
                }


               if (dc.NuevaFactura(f, fd1))
                {
                    
                    cvDatos.IsValid = false;
                    cvDatos.ErrorMessage = "FACTURA GUARDADA EXITOSAMENTE EN LA BD";
                   //Eliminamos la session
                    Session.Remove("s_DetalleFactura");

                }

                //insertamos una factura



            }
            catch (Exception err )
            {
                cvDatos.IsValid = false;
                cvDatos.ErrorMessage = "Ocurrio un error al guardar la informacion en la BD..." + err.Message;
            }
           






        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            //Aqui limpiamos todos los objetos contenidos en el Formulario
            txtCliente.Text = "";
            txtNombre.Text = "";
            txtCantidad.Text = "";
            Session.Remove("s_DetalleFactura");
            gvFaturaDetalle.DataSource = null;
            gvFaturaDetalle.DataBind();
            CargarProducto();

        }

      
    }
}