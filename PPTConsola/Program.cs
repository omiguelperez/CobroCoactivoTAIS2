using Entities;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPTConsola
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Cliente para guardar
            //ClienteDTO cliente1 = new ClienteDTO
            //{
            //    Nombre = "Miguel",
            //    Direccion = "Alamos 1",
            //    Telefono = "3113298374"
            //};

            //Guardar el cliente
            //ClienteBLL clienteBLL = new ClienteBLL();
            //Respuesta respuesta = clienteBLL.Insertar(cliente1);
            //Console.WriteLine(respuesta.Mensaje + ", Filas afactadas: " + respuesta.FilasAfectadas);
            //Console.ReadKey();

            //Guardar una factura 

            //List<ItemFacturaDTO> items = new List<ItemFacturaDTO>();
            //FacturaDTO factura1 = new FacturaDTO
            //{
            //    Fecha = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0),
            //    NumeroFactura = "723",
            //    ClienteId = 4009,
            //    ItemFacturas = items
            //};
            //items.Add(new ItemFacturaDTO
            //{
            //    Descripcion = "Primer item",
            //    Valor = 150000,
            //    Cantidad = 30,
            //    Iva = 720000
            //});
            //items.Add(new ItemFacturaDTO
            //{
            //    Descripcion = "Segundo item",
            //    Valor = 300000,
            //    Cantidad = 30,
            //    Iva = 1440000,
            //});

            //FacturaBLL facturaBLL = new FacturaBLL();
            //Respuesta respuesta = facturaBLL.Insertar(factura1);
            //Console.WriteLine(respuesta.Mensaje + ", Filas afactadas: " + respuesta.FilasAfectadas);
            //Console.ReadKey();
            

            // Guardar un ItemFactura con una factura que ya esta en la base de datos
            //ItemFacturaDTO itemFactura1 = new ItemFacturaDTO
            //{
            //    Descripcion = "Desripcion de la factura",
            //    Valor = 150000,
            //    Cantidad = 30,
            //    Iva = 720000,
            //    FacturaId = 1
            //};

            //ItemFacturaBLL itemFacturaBLL = new ItemFacturaBLL();
            //Respuesta respuesta = itemFacturaBLL.Insertar(itemFactura1);
            //Console.WriteLine(respuesta.Mensaje + ", Filas afactadas: " + respuesta.FilasAfectadas);
            //Console.ReadKey();

            //Obtener las facturas
            //FacturaBLL facturaBLL = new FacturaBLL();
            //List<FacturaDTO> facturas = facturaBLL.GetRecords();

            //foreach (var factura in facturas)
            //{
            //    Console.WriteLine("ID: " + factura.FacturasId);
            //    Console.WriteLine("Numero: " + factura.NumeroFactura);
            //    Console.WriteLine("Fecha: " + factura.Fecha);
            //    Console.WriteLine("ClienteId: " + factura.ClienteId);
            //    Console.WriteLine();
            //}

            //Console.WriteLine("Se encontraron " + facturas.Count + " facturas");
            //Console.ReadKey();


        }
    }
}
