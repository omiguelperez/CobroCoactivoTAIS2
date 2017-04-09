using Entities;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ItemFacturaBLL
    {
        Respuesta respuesta = new Respuesta();
        Contexto db;

        public Respuesta Insertar(ItemFacturaDTO itemFactura)
        {
            using (db = new Contexto())
            {
                try
                {
                    // preparar al item de factura para guardar
                    ItemFactura item = new ItemFactura();
                    
                    item.Descripcion = itemFactura.Descripcion;
                    item.Valor = itemFactura.Valor;
                    item.Cantidad = itemFactura.Cantidad;
                    item.Iva = itemFactura.Iva;
                    item.FacturaId = itemFactura.FacturaId;

                    db.ItemFacturas.Add(item);

                    // preparar la respuesta
                    respuesta.FilasAfectadas = db.SaveChanges();
                    respuesta.Mensaje = "Se realizó la operación satisfactoriamente";
                    respuesta.Error = false;
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    respuesta.Mensaje = ex.Message;
                    respuesta.FilasAfectadas = 0;
                    respuesta.Error = true;
                }
                catch (Exception ex)
                {
                    respuesta.Mensaje = ex.Message;
                    respuesta.FilasAfectadas = 0;
                    respuesta.Error = true;
                }

                return respuesta;
            }
        }
    }
}
