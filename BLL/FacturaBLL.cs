using Entities;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class FacturaBLL
    {
        Respuesta respuesta = new Respuesta();
        Contexto db;

        // Guardar una factura
        public Respuesta Insertar(FacturaDTO factura)
        {
            using (db = new Contexto())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        // preparar al item de factura para guardar
                        Facturas f = new Facturas();
                        f.Fecha = factura.Fecha;
                        f.NumeroFactura = factura.NumeroFactura;
                        f.ClienteId = factura.ClienteId;

                        
                      //  var response = db.SaveChanges();

                        foreach (ItemFacturaDTO item in factura.ItemFacturas)
                        {
                            ItemFactura itemFactura = new ItemFactura();
                            itemFactura.Descripcion = item.Descripcion;
                            itemFactura.Valor = item.Valor;
                            itemFactura.Cantidad = item.Cantidad;
                            itemFactura.Iva = item.Iva;
                            //itemFactura.FacturaId = f.FacturasId;
                            //itemFactura.Factura = f;
                            f.ItemFacturas.Add(itemFactura);
                        }

                        db.Facturas.Add(f);
                        // preparar la respuesta
                        respuesta.FilasAfectadas = db.SaveChanges();
                        respuesta.Mensaje = "Se realizó la operación satisfactoriamente";
                        respuesta.Error = false;

                        transaction.Commit();
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

        // Obtener las facturas
        public List<FacturaDTO> GetRecords()
        {
            using (Contexto db = new Contexto())
            {
                return db.Facturas
                    .Select(t =>
                        new FacturaDTO
                        {
                            FacturasId = t.FacturasId,
                            NumeroFactura = t.NumeroFactura,
                            Fecha = t.Fecha,
                            ClienteId = t.ClienteId
                        }
                    ).ToList();
            }
        }

        // Modificar una factura
        public Respuesta UpdateFactura(FacturaDTO facturaDTO)
        {
            using (Contexto db = new Contexto())
            {
                var facturaUpdate = db.Facturas.Find(facturaDTO.FacturasId);
                if (facturaUpdate != null)
                {
                    //facturaUpdate.NumeroFactura = facturaDTO.NumeroFactura;
                    facturaUpdate.ClienteId = facturaDTO.ClienteId;
                    facturaUpdate.Fecha = facturaDTO.Fecha;
                    //facturaUpdate.FacturasId = facturaDTO.FacturasId;

                    Respuesta respuesta = new Respuesta();
                    respuesta.Mensaje = "Modificado correctamente";
                    respuesta.Error = false;
                    respuesta.FilasAfectadas = db.SaveChanges();
                    return respuesta;
                }
                else
                {
                    Respuesta respuesta = new Respuesta();
                    respuesta.Mensaje = "No se encontro";
                    respuesta.Error = false;
                    respuesta.FilasAfectadas = db.SaveChanges();
                    return respuesta;
                }
            }
        }

        // Eliminar una factura
        public Respuesta DeleteFactura(FacturaDTO facturaDTO)
        {
            using (Contexto db = new Contexto())
            {
                var facturaDelete = db.Facturas.Find(facturaDTO.FacturasId);
                if (facturaDelete != null)
                {
                    db.ItemFacturas.RemoveRange(db.ItemFacturas.Where(item => item.FacturaId == facturaDelete.FacturasId));
                    db.Facturas.Remove(facturaDelete);
                    db.SaveChanges();

                    Respuesta respuesta = new Respuesta();
                    respuesta.Mensaje = "Se ha eliminado la factura con sus items";
                    respuesta.Error = false;
                    respuesta.FilasAfectadas = db.SaveChanges();
                    return respuesta;
                }
                else
                {
                    Respuesta respuesta = new Respuesta();
                    respuesta.Mensaje = "No encontro el registro";
                    respuesta.Error = false;
                    respuesta.FilasAfectadas = db.SaveChanges();
                    return respuesta;
                }
            }
        }
    }
}
