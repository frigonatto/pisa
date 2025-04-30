using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pisa
{
    public class ReporteDocumento : IDocument
    {
        public Reporte Modelo { get; }

        public ReporteDocumento(Reporte modelo)
        {
            Modelo = modelo;
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;
        public DocumentSettings GetSettings() => DocumentSettings.Default;

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Margin(50);
                page.Header().Text(Modelo.Empresa).Bold().FontSize(24);
                //page.Header().Text(Modelo.Titulo).Bold().FontSize(20);
                page.Content().Text(Modelo.Contenido).FontSize(12);

                page.Footer().AlignCenter().Text(x =>
                {
                    x.CurrentPageNumber();
                    x.Span(" / ");
                    x.TotalPages();
                });

                //page.Footer().AlignRight().Text($"Fecha: {Modelo.Fecha.ToShortDateString()}");
            });
        }
    }
}
