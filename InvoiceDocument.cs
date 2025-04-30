using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace pisa
{
    public class InvoiceDocument : IDocument
    {
        public InvoiceModel Model { get; }

        public InvoiceDocument (InvoiceModel model)
        {
            Model = model;
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;
        public DocumentSettings GetSettings() => DocumentSettings.Default;


        public void Compose(IDocumentContainer container)
        {
            container
                .Page(page =>
                {
                    page.Margin(50);

                    //page.Header().Height(100).Background(Colors.Grey.Lighten1);
                    page.Header().Element(ComposeHeader);

                    //page.Content().Background(Colors.Grey.Lighten3);
                    page.Content().Element(ComposeContent);
                    
                    //page.Footer().Height(50).Background(Colors.Grey.Lighten1);
                    page.Footer().AlignCenter().Text(x =>
                    {
                        x.CurrentPageNumber();
                        x.Span(" / ");
                        x.TotalPages();
                    });
                });
        }

        public void ComposeHeader(IContainer container)
        {
            container.Row( row =>
            {
                row.RelativeItem().Column(column =>
                {
                    column.Item()
                    .Text($"Invoice #{Model.InvoiceNumber}")
                    .FontSize(20).SemiBold().FontColor(Colors.Blue.Medium);

                    column.Item().Text(text =>
                    {
                        text.Span("Issue date: ").SemiBold();
                        text.Span($"{Model.IssueDate:d}");
                    });


                    column.Item().Text(text =>
                    {
                        text.Span("Due date: ").SemiBold();
                        text.Span($"{Model.DueDate:d}");
                    });
                });

                row.ConstantItem(100).Height(50).Placeholder();
            });
        }

        public void ComposeContent(IContainer container)
        {
            container
                .PaddingVertical(40)
                .Height(250)
                .Background(Colors.Grey.Lighten3)
                .AlignCenter()
                .AlignMiddle()
                .Text("Content").FontSize(16);
        }

    }
}
