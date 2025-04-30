using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pisa
{
    public static class ReporteDataSource
    {
        public static Reporte ObtenerReporte()
        {
            return new Reporte
            {
                Empresa = "FADECYA S.A.I.C.",
                Titulo = "Reporte de Ventas",
                Contenido = "Este es un reporte detallado de las ventas realizadas.",
                Fecha = DateTime.Now
            };
        }
    }
}
