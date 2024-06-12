using SistemaGestionData;
using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionBussiness
{
    public class VentaBussiness
    {
        public static List<Venta> ObtenerVenta(int id)
        {
            return VentaData.ObtenerVenta(id);
        }
        public static List<Venta> ListarVentas()
        {
            return VentaData.ListarVentas();
        }
        public static void CrearVenta(Venta venta)
        {
            VentaData.CrearVenta(venta);
        }
        public static void ActualizarVenta(Venta venta)
        {
            VentaData.ActualizarVenta(venta);
        }
        public static void EliminarVenta(int id)
        {
            VentaData.EliminarVenta(id);
        }
    }
}
