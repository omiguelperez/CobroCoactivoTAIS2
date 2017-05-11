using Entities;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PPTConsola
{
    public class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            string line;

            // Read the file and display it line by line.  
            String prepath = AppDomain.CurrentDomain.BaseDirectory;
            prepath = Regex.Split(prepath, "PPTConsola")[0] + "AspNetIdentity";
            System.IO.StreamReader file =
                new System.IO.StreamReader(prepath + "/departamentoscolombiacsv.txt");
            while ((line = file.ReadLine()) != null)
            {
                if (counter<=20)
                {
                    string[] ciudades = Regex.Split(line, ",");
                System.Console.WriteLine(ciudades[0]+" - "+ ciudades[1]+" - "+ ciudades[2]+" - "+ ciudades[3]);
                counter++;

                }
                else
                {
                    break;
                }
            }

            file.Close();
            System.Console.WriteLine("There were {0} lines.", counter);
            // Suspend the screen.  
            System.Console.ReadLine();







            // PersonaDTO para guardar
            //PersonaDTO cliente2 = new PersonaDTO
            //{
            //    Identificacion = "123456",
            //    Nombres = "nojoda  ",
            //    Direccion = "asdasd 1",
            //    Telefono = 311329837,
            //    Apellidos = "sjsjsjsjsj",
            //    Sexo = "M",
            //};

            ////Guardar el cliente
            //PersonaBLL clienteBLL1 = new PersonaBLL();
            //Respuesta respuesta = clienteBLL1.Insertar(cliente2);
            //Console.WriteLine(respuesta.Mensaje + ", Filas afactadas PErsonas: " + respuesta.FilasAfectadas);
            //Console.ReadKey();


            ////PersonaDTO para guardar
            //ObligacionDTO cliente1 = new ObligacionDTO();
            //cliente1.Cuantia = 5000;
            //cliente1.Dueda = 5000;
            //cliente1.Estado = "Normal";
            //cliente1.FechaPreinscripcion = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0);
            ////PersonaBLL objjj = new PersonaBLL();
            ////cliente1.Persona = objjj.FindByIdentificacion("123456");
            //// Guardar el cliente
            ////PersonaDTO person = objjj.FindByIdentificacion("123456");
            ////ObligacionDTO objjjjj = new ObligacionDTO
            ////{
            ////    Cuantia = 15151,
            ////    Dueda = 2515,
            ////    Estado = "Nodfadfsd",
            ////    FechaPreinscripcion = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0),
            ////    Persona = person
            ////};
            //cliente1.PersonaId = 1;
            //ObligacionBLL kkk = new ObligacionBLL();
            //Respuesta respuesta = kkk.InsertarObligacion(cliente1);
            //Console.WriteLine(respuesta.Mensaje + ", Filas afactadas: " + respuesta.FilasAfectadas);
            //Console.ReadKey();




            //PersonaDTO para guardar
            // PersonaDTO cliente1 = new PersonaDTO
            // {
            //     Identificacion=1065827940,
            //     Nombres = "Miguel",
            //     Direccion = "Alamos 1",
            //     Telefono = 311329837,
            //     Apellidos = "Jjdnjdn",
            //     Sexo = "M",
            // };

            //// Guardar el cliente
            // PersonaBLL clienteBLL = new PersonaBLL();
            // Respuesta respuesta = clienteBLL.Insertar(cliente1);
            // Console.WriteLine(respuesta.Mensaje + ", Filas afactadas: " + respuesta.FilasAfectadas);
            // Console.ReadKey();

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
