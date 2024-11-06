// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography.X509Certificates;

Console.WriteLine("Hello, World!");

var factura = new factura();
factura.id = facturaID.comprobante;
factura.version = "1";

var datosTributarios = new infoTributaria();
datosTributarios.claveAcceso = "";
datosTributarios.contribuyenteRimpe = "";

var infoFactura = new facturaInfoFactura { };

factura.infoFactura = infoFactura;


var detalles = new facturaDetalle
{
    descripcion = "prueba",
    precioUnitario = 1,
    codigoPrincipal = "001"
};



Console.WriteLine(factura);
